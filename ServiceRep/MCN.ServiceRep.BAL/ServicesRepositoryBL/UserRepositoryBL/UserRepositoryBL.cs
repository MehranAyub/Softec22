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
        private readonly SwallResponseWrapper _swallResponseWrapper;
        private readonly SwallText _swallText;
        public static int DEFAULT_USERID = 1;

        public UserRepositoryBL(RepositoryContext repository) : base(repository)
        {
            _swallResponseWrapper = new SwallResponseWrapper();
            _swallText = new SwallText();
            repositoryContext = repository;
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
                Address = dto.Address,
                FirstName = dto.FirstName,
                IsActive = true,
                LastName = dto.LastName,
                LoginFailureCount = 0,
                Password = dto.Password,
                UpdatedBy = DEFAULT_USERID,
                IsEmailVerified = true,
                Phone=dto.Phone,
                Latitude=dto.Latitude,
                Longitude=dto.Longitude,
                UserLoginTypeId =dto.LoginType,
                Description=dto.Description,
                SalonId=dto.SalonId
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


        public string FileUpload(FileDto dto)
        {
            var record = repositoryContext.Files.FirstOrDefault(x => x.UserId == dto.UserId);

            if (record == null)
            {
                var img="";
                var obj = new Files();
                obj.DocumentId = dto.DocumentId;
                obj.FileType = dto.FileType;
                obj.DataFiles =dto.DataFiles;
                obj.Name = dto.Name;
                obj.CreatedOn = dto.CreatedOn;
                obj.UserId = dto.UserId;
                repositoryContext.Files.Add(obj);
            }

            else
            {
                record.DataFiles = dto.DataFiles; 
                repositoryContext.Update(record);
            }
            repositoryContext.SaveChanges();


            var image= "data:image/png;base64," + Convert.ToBase64String(dto.DataFiles);
            try
            {

                return image;
                //return new SwallResponseWrapper()
                //{
                //    SwallText = null,
                //    StatusCode = 200,
                //    Data = image
                //};
            }
            catch (Exception ex)
            {
                return "error";
                //return new SwallResponseWrapper()
                //{
                //    SwallText = null,
                //    StatusCode = 404,
                //    Data = ex
                //};
            }

        }


        public string SalonLogo(FileDto dto)
        {
            var record = repositoryContext.Salon.FirstOrDefault(x => x.RegisterBy == dto.UserId);

            if (record == null)
            {
               
                return "null";
            }

            else
            {
                var image = "data:image/png;base64," + Convert.ToBase64String(dto.DataFiles);

                record.SalonLogo = image;
                repositoryContext.Update(record);
                repositoryContext.SaveChanges();
                return image;
            }
          

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
            var user = repositoryContext.Users.FirstOrDefault(x => x.ID == userID && x.UserLoginTypeId == UserEntityType.Doctor);

            return user;
        }

        public SwallResponseWrapper GetProfileImg(int userID)
        {
            var user = repositoryContext.Files.FirstOrDefault(x => x.UserId==userID);
            

            if (user == null)
            {
               
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = null
                };
            }
            else
            {
                var image = "data:image/png;base64," + Convert.ToBase64String(user.DataFiles);
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = image
                };
            }

        }

        public SwallResponseWrapper RegisterSalon(SalonDto dto)
        {
            var record = repositoryContext.Salon.FirstOrDefault(x => x.RegisterBy == dto.RegisterBy);
            var user = repositoryContext.Users.FirstOrDefault(x => x.ID == dto.RegisterBy);
            if (record == null)
            {
                Salon salon = new Salon
                {
                    Name = dto.Name,
                    RegisterBy = dto.RegisterBy,
                    Address = dto.Address,
                    Introduction = dto.Introduction,
                    About = dto.About
                };

                repositoryContext.Add(salon);

            }
            else
            {

                record.Name = dto.Name;
                record.RegisterBy = dto.RegisterBy;
                record.Address = dto.Address;
                record.Introduction = dto.Introduction;
                record.About = dto.About;
                repositoryContext.Update(record);
            }
           
            repositoryContext.SaveChanges();
            record = repositoryContext.Salon.FirstOrDefault(x => x.RegisterBy == dto.RegisterBy);
            user.SalonId = record.ID;
            repositoryContext.Update(record);
            repositoryContext.SaveChanges();


            return new SwallResponseWrapper()
            {
                SwallText = LoginUser.UserCreatedScuccessfully,
                StatusCode = 200,
                Data = dto
            };
        }


        public SwallResponseWrapper GetSalon(int userID)
        {
            var user = repositoryContext.Salon.FirstOrDefault(x => x.RegisterBy == userID);


            if (user == null)
            {

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = null
                };
            }
            else
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = user
                };
            }

        }

        public SwallResponseWrapper Salon(int id)
        {
            var user = repositoryContext.Salon.FirstOrDefault(x => x.ID == id);


                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = user
                };
           

        }
        public SwallResponseWrapper GetBarbers(int SalonId)
        {
            var user = repositoryContext.Users.Where(x => x.SalonId == SalonId && x.Description!=null).ToList();


            if (user == null)
            {

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 404,
                    Data = null
                };
            }
            else
            {
                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = user
                };
            }

        }

      

        public string RemoveBarber(int userID)
        {
            var user = repositoryContext.Users.FirstOrDefault(x => x.ID == userID);
            repositoryContext.Appointment.RemoveRange(repositoryContext.Appointment.Where(x => x.DoctorId == user.ID));
            repositoryContext.AvailSlots.RemoveRange(repositoryContext.AvailSlots.Where(x => x.BarberID == user.ID));
            repositoryContext.Users.Remove(user);
            repositoryContext.SaveChanges();
            return "Barber Removed Successfully";
        }

        public SwallResponseWrapper SearchBarbers(int SalonId)
        {
            var user = repositoryContext.Users.Where(x => x.SalonId == SalonId).ToList();
            var file = repositoryContext.Files.ToList();

            var data = (from U in user
                        join F in file on U.ID equals F.UserId into fil
                        from File in fil.DefaultIfEmpty()
                        select new
                        {
                            ID=U.ID,
                            FirstName = U.FirstName,
                            LastName = U.LastName,
                            Phone = U.Phone,
                            Address = U.Address,
                            Image  = (File == null || File.DataFiles == null ? "God dammit work" : "data:image/png;base64," + Convert.ToBase64String(File.DataFiles))
                        }
                        ).ToList();

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 200,
                    Data = data
                };


        }

        public int GetSalonID(int userID)
        {
            var user = repositoryContext.Users.FirstOrDefault(x => x.ID == userID).SalonId;
          
            return (int)user;
        }

    }
}

  

    
