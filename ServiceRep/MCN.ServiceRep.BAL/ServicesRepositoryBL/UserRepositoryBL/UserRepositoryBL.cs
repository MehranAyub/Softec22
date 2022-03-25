using MCN.Common;
using MCN.Common.AttribParam;
using MCN.Common.Exceptions;
using MCN.Core.Entities.Entities;
using MCN.ServiceRep.BAL.ContextModel;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos;
using MCN.ServiceRep.BAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using static MCN.Common.AttribParam.SwallTextData;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL
{
    public class UserRepositoryBL : BaseRepository, IUserRepositoryBL
    {
        // private readonly IEmailLogRepositoryBL _emailrepo;
        private readonly SwallResponseWrapper _swallResponseWrapper;
        private readonly SwallText _swallText;
        // private readonly ForgotPasswordEmailDTO _ForgotPasswordEmailDTO;
        // private readonly IAutoCodeNumberRepositoryBL _autoCodeNumberRepositoryBL;
        public static int DEFAULT_USERID = 1;

        public UserRepositoryBL(RepositoryContext repository) : base(repository)
        {
            _swallResponseWrapper = new SwallResponseWrapper();
            _swallText = new SwallText();
            //_autoCodeNumberRepositoryBL = autoCodeNumberRepositoryBL;
            repositoryContext = repository;
            //_emailrepo = emailrepo;
            //_ForgotPasswordEmailDTO = new ForgotPasswordEmailDTO();
        }


        public SwallResponseWrapper IsValidUserEmail(string email, string Url, string RoleType)
        {
            var usr = new User();

            var IsValidEmail = repositoryContext.Users.FirstOrDefault(x => x.Email == email);
            if (IsValidEmail != null && IsValidEmail.IsEmailVerified==true)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = new LoginUser().SwallTextEmailVerifiedSuccess,
                    StatusCode = 200,
                    Data = null
                };
            }
            else  if(IsValidEmail != null && IsValidEmail.IsEmailVerified == false)
            {
                return new SwallResponseWrapper()
                {
                    SwallText =new LoginUser().SwallTextEmailVerifiedFailure,
                    StatusCode = 401,
                    Data = usr
                };
            }
            else
            {
                return new SwallResponseWrapper()
                {
                    SwallText = LoginUser.EmailVerifcationInvalidUser,
                    StatusCode = 404,
                    Data = usr
                };
            }
        }



        public SwallResponseWrapper ReGenerateEmailVerificationPasscode(CreateUserDto userDto, string IpAddress)
        {
            var context = repositoryContext;

            var usr = context.Users.AsNoTracking().FirstOrDefault(x => x.Email == userDto.Email);
            if (usr == null)
            {
                CreateUserDto createUserDto = new CreateUserDto() { Email = userDto.Email };
                var response = CreateUser(createUserDto);
                if (response.StatusCode == 200)
                {
                    return new SwallResponseWrapper()
                    {
                        SwallText = LoginUser.EmailVerifcationInvalidUser,
                        StatusCode = 1,
                        Data = null
                    };

                }

            }
            else if (usr.Email != null && usr.Password == null)
            {
                var passcode = RandomHelper.GetRandomNumber().ToString("x");
                SavePasscode(passcode, IpAddress, usr.ID);
                return new SwallResponseWrapper()
                {
                    SwallText = LoginUser.EmailVerifcationInvalidUser,
                    StatusCode = 1,
                    Data = usr
                };
            }
            else if (usr.Email != null && usr.Password != null)
            {

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 2,
                    Data = usr
                };

            }


            //var passcode = RandomHelper.GetRandomNumber().ToString("x");
            //SavePasscode(passcode, IpAddress, usr.ID);

            //return new SwallResponseWrapper()
            //{
            //    SwallText =Auth.ValidateEmail,
            //    StatusCode = 200,
            //    Data = usr
            //};
            //_emailrepo.SendEmailVerificationPasscode(
            //    new EmailVerificationEmailDTO
            //    {
            //        BaseURI = BaseURL,
            //        Email = email,   
            //        Passcode = passcode,
            //        UserId = usr.ID,
            //        //UserName = usr.UserName
            //    }
            //    );
            return new SwallResponseWrapper()
            {
                SwallText = null,
                StatusCode = 0,
                Data = null
            };
        }

        public SwallResponseWrapper CreateUser(CreateUserDto dto)
        {
            User usr = new User
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedBy = DEFAULT_USERID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                IsActive = true,
                LastName = dto.LastName,
                LoginFailureCount = 0,
                Password = dto.Password,
                UpdatedBy = DEFAULT_USERID,
                IsEmailVerified = false,
                UserLoginTypeId = AppConstants.UserEntityType.Applicant,//edit here 
               
            };
           

            repositoryContext.Users.Add(usr);
            repositoryContext.SaveChanges();
            var passcode = RandomHelper.GetRandomNumber().ToString("x");
            SavePasscode(passcode, dto.IpAddress, usr.ID);
            //_emailrepo.SendEmailVerificationPasscode(
            //    new EmailVerificationEmailDTO
            //    {
            //        BaseURI = dto.BaseURL,
            //        Email = dto.Email,
            //        FormId = form.FormId,
            //        FormName = form.FormName,
            //        FormSupportEmail = form.FormSupportEmail,
            //        Passcode = passcode,
            //        UserId = usr.UserID,
            //        //UserName = usr.UserName,
            //        FormURL = form.FormUrl
            //    }
            //    );

            return new SwallResponseWrapper()
            {
                SwallText = LoginUser.UserCreatedScuccessfully,
                StatusCode = 200,
                Data = usr
            };
        }

        //public SwallResponseWrapper ResetPassword(ChangePasswordDTO resetPassword)
        //{
        //    var token = repositoryContext.UserAuthtoken.Where(x => x.Authtoken == resetPassword.Token && x.AccessIP == resetPassword.IpAddress).OrderByDescending(x => x.CreatedOn).FirstOrDefault();

        //    if (token.CreatedOn?.AddHours(24) < DateTime.Now)
        //    {
        //        _swallText.html = LoginSwallMessagesHtml.ResetPasswordTokenExpireHtmlFailure;
        //        _swallText.title = LoginSwallMessagesHtml.ResetPasswordTokenExpireTitleFailure;
        //        _swallText.type = SwalType.Error;
        //        throw new UserThrownException(_swallText);
        //    }

        //    var user = repositoryContext.Users.Where(x => x.ID == token.UserID).FirstOrDefault();
        //    if (user != null && user.Email == resetPassword.Email)
        //    {
        //        user.Password = resetPassword.Password;
        //        repositoryContext.Update(user);
        //        repositoryContext.SaveChanges();
        //        _swallText.html = LoginSwallMessagesHtml.ResetPasswordChangedHtmlSuccess;
        //        _swallText.title = LoginSwallMessagesHtml.ResetPasswordChangedTitleFailure;
        //        _swallText.type = SwalType.Success;
        //        _swallResponseWrapper.SwallText = _swallText;
        //        _swallResponseWrapper.StatusCode = 200;
        //        _swallResponseWrapper.Data = null;
        //        return _swallResponseWrapper;
        //    }
        //    else
        //    {
        //        _swallText.html = LoginSwallMessagesHtml.ResetPasswordInvUserHtmlFailure;
        //        _swallText.title = LoginSwallMessagesHtml.ResetPasswordInvUserTitleFailure;
        //        _swallText.type = SwalType.Error;
        //        throw new UserThrownException(_swallText);
        //    }

        //}

        public SwallResponseWrapper IsEmailVerified(string Passcode, string IpAddress, string Email)
        {
            var result = checkPasscode(Passcode, IpAddress, Email);

            if (result != null)
            {
                var user = repositoryContext.Users.FirstOrDefault(x => x.Email == Email);
                user.IsEmailVerified = true;
                repositoryContext.Entry(user).State = EntityState.Modified;
                repositoryContext.SaveChanges();

                return new SwallResponseWrapper()
                {
                    StatusCode = 200,
                    SwallText = new LoginUser().SwallTextEmailPasscodeVerifiedSuccess
                    ,
                    Data = repositoryContext.Users
                    .Where(x => x.ID == result.UserID).FirstOrDefault()
                };
            }
            else
                return null;
        }

        public SwallResponseWrapper IsValidEmailPasscode(string Passcode, string IpAddress, string Email)
        {
            var result = checkPasscode(Passcode, IpAddress, Email);

            return result != null ?
                new SwallResponseWrapper()
                {
                    StatusCode = 200,
                    SwallText = new LoginUser().SwallTextEmailPasscodeVerifiedSuccess,
                    Data = repositoryContext.Users
                    .Where(x => x.ID == result.UserID).FirstOrDefault()
                }
                :
                 null;
        }

        public UserMultiFactor checkPasscode(string Passcode, string IpAddress, string Email)
        {
            var user = repositoryContext.Users.FirstOrDefault(x => x.Email == Email);

            if (user != null)
            {
                var passcodeSuccess = repositoryContext.UserMultiFactors.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x => x.AccessIP == IpAddress && x.UserID == user.ID);

                if (passcodeSuccess?.EmailToken == Passcode)
                {
                    user.IsEmailVerified = true;
                    repositoryContext.Entry(user).State = EntityState.Modified;
                    repositoryContext.SaveChanges();

                    return passcodeSuccess;
                }
                else
                {
                    //throw new UserThrownBadRequest(new LoginUser().SwallTextEmailPasscodeFailure, null);
                    return null;
                }

            }
            else
            {
                // throw new UserThrownBadRequest(new LoginUser().SwallTextEmailPasscodeFailure, null);
                return null;
            }
        }

        public SwallResponseWrapper IsValidPassword(string Password,
            string Email, string IpAddress)
        {
            // var user = GetUserByUrlEmail(Email, Url);

            var user = (from u in repositoryContext.Users
                        where u.Email.ToLower() == Email.ToLower() && u.Password == Password && u.IsEmailVerified==true
                        select u).FirstOrDefault();

            if (user == null)
            {
                return new SwallResponseWrapper()
                {
                    Data = null,
                    StatusCode = 404,
                    SwallText = new LoginUser().SwallTextEmailVerifiedFailure
                };

            }
            return new SwallResponseWrapper()
            {
                Data = user,
                StatusCode = 200,
                SwallText = new LoginUser().SwallTextPasswordVerifiedSuccess
            };
        }


        private void SavePasscode(string Passcode, string IpAddress, int userId)
        {

            var obj = new UserMultiFactor();
            obj.AccessIP = IpAddress;
            obj.CreatedOn = DateTime.Now;
            obj.EmailToken = Passcode;
            obj.UpdatedOn = DateTime.Now;
            obj.UserID = userId;
            //obj.UserMultiFactorKey = _autoCodeNumberRepositoryBL.GetAutoCodeNumber(nameof(UserMultiFactor));
            ///////////////////////////////////            
            repositoryContext.UserMultiFactors.Add(obj);
            repositoryContext.SaveChanges();
        }

        //public SwallResponseWrapper PasswordChange(PasswordChangeDto passwordChangeDto)
        //{
        //    var user = repositoryContext.User.FirstOrDefault(x => x.Email == passwordChangeDto.Email);
        //    if (user != null)
        //    {
        //        if (user.Password != passwordChangeDto.OldPassword)
        //        {
        //            _swallText.html = LoginSwallMessagesHtml.OldPasswordNotCorrect;
        //            _swallText.title = LoginSwallMessagesHtml.ChangePasswordFail;
        //            _swallText.type = SwalType.Error;
        //            throw new UserThrownException(_swallText);
        //        }
        //        user.Password = passwordChangeDto.Password;
        //        repositoryContext.User.Update(user);
        //        repositoryContext.SaveChanges();

        //        _swallText.html = LoginSwallMessagesHtml.ResetPasswordChangedHtmlSuccess;
        //        _swallText.title = LoginSwallMessagesHtml.ResetPasswordChangedTitleFailure;
        //        _swallText.type = SwalType.Success;
        //        _swallResponseWrapper.SwallText = _swallText;
        //        _swallResponseWrapper.StatusCode = 200;
        //        _swallResponseWrapper.Data = null;
        //        return _swallResponseWrapper;
        //    }
        //    else
        //    {
        //        _swallText.html = LoginSwallMessagesHtml.ResetPasswordInvUserHtmlFailure;
        //        _swallText.title = LoginSwallMessagesHtml.ResetPasswordInvUserTitleFailure;
        //        _swallText.type = SwalType.Error;
        //        throw new UserThrownException(_swallText);
        //    }

        //}


        public User GetUser(int userID)
        {
            var user = repositoryContext.Users.FirstOrDefault(x => x.ID == userID && x.UserLoginTypeId == AppConstants.UserEntityType.Applicant);

            return user;
        }




    }
}
