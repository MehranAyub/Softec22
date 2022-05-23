using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MCN.Common.AttribParam;
using MCN.Core.Entities.Entities;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos;
using MCN.ServiceRep.BAL.ViewModels;
using MCN.ServiceRep.BAL.ViewModels.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using static MCN.Common.AttribParam.SwallTextData;

namespace MCN.WebAPI.Areas.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepositoryBL _UserRepositoryBL;
        private IHttpContextAccessor _accessor; 
        private string _IpAddress;
        private string _baseuri;
        private IConfiguration _config;
        private readonly IHostingEnvironment hostingEnvironment;

        public UsersController(IUserRepositoryBL UserRepositoryBL, IHttpContextAccessor accessor, IConfiguration config, IHostingEnvironment env)
        {
            _UserRepositoryBL = UserRepositoryBL;
            _accessor = accessor;
            _config = config;
            hostingEnvironment = env;
            _IpAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(); 
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ValidateEmail")]
        public IActionResult ValidateEmail([FromQuery]string Email, string Url, string RoleType)
        {

            var result = _UserRepositoryBL.IsValidUserEmail(Email, Url, RoleType);


            return Ok(result);
        }

    
        [HttpGet]
        [AllowAnonymous]
        [Route("VerifyEmailPasscode")]
        public IActionResult ValidateEmailPasscode(string emailPasscode, string email)
        {
            
                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                IActionResult response = Unauthorized();
                var result = _UserRepositoryBL.IsValidEmailPasscode(emailPasscode, ip, email);
            if (result == null)
            {
                return Ok(new SwallResponseWrapper { Data = null, StatusCode = 401, SwallText = new LoginUser().SwallTextEmailPasscodeFailure });
            }
                var tokenString = GenerateJSONWebToken((User)result.Data);
                //return Ok(new UserResult { token = tokenString, User = (User)result.Data,message=result. });
                return Ok(new SwallResponseWrapper { Data = new UserResult { token = tokenString, User = (User)result.Data }, StatusCode = result.StatusCode, SwallText = result.SwallText });
            
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ValidateEmailPassword")]
        public IActionResult ValidateEmailPassword(string password, string email)
        {

            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            IActionResult response = Unauthorized();
            var result = _UserRepositoryBL.IsValidPassword(password,email,ip);
            if (result.Data == null)
            {
                return Ok(new SwallResponseWrapper { Data = null, StatusCode = 401, SwallText = new LoginUser().SwallTextEmailPasswordFailure });
            }
            var tokenString = GenerateJSONWebToken((User)result.Data);
            //return Ok(new UserResult { token = tokenString, User = (User)result.Data,message=result. });
            return Ok(new SwallResponseWrapper { Data = new UserResult { token = tokenString, User = (User)result.Data }, StatusCode = result.StatusCode, SwallText = result.SwallText });

        }


        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, userInfo.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, userInfo.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      
 

        [HttpPost]
        [Route("CreateUser")]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody]CreateUserDto dto)
        {
            dto.IpAddress = _IpAddress;
            dto.BaseURL = _baseuri;
            var result = _UserRepositoryBL.CreateUser(dto);
            return Ok(result);
        }

        //[HttpPost]
        //[Route("FileUpload")]
        //[AllowAnonymous]
        //public IActionResult FileUpload()
        //{

        //    var file = Request.Form.Files[0];
        //    //var folderName = Path.Combine("Resources", "Images");
        //    //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //    if (file.Length > 0)
        //    {
        //        //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //        //var fullPath = Path.Combine(pathToSave, fileName);
        //        //var dbPath = Path.Combine(folderName, fileName);
        //        //using (var stream = new FileStream(fullPath, FileMode.Create))
        //        //{
        //        //    file.CopyTo(stream);
        //        //    return Ok(file);
        //        //}
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //    //var file = HttpContext.Request.Form.Files.Count > 0 ? HttpContext.Request.Form.Files[0] : null;
        //    //if (file!=null && file.Length > 0)
        //    //{
        //    //    var fileName = Path.GetFileName(file.FileName);
        //    //    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        //    //   // var uploads = Path.Combine(hostingEnvironment.EnvironmentName, "uploads");
        //    //    var path = Path.Combine(uploads, fileName);
        //    //    var stream = System.IO.File.Create(path);
        //    //    file.CopyTo(stream);
        //    //}
        //    //return Ok(file);
        //}


        [HttpPost]

        [Route("FileUpload/{id}")]
        [AllowAnonymous]
        public string FileUpload(int id)
        {
            var Userid = id;


            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {//Getting FileName
                var fileName = Path.GetFileName(file.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                var objfiles = new FileDto()
                {
                    DocumentId = 0,
                    Name = newFileName,
                    FileType = fileExtension,
                    CreatedOn = DateTime.Now,
                    UserId = Userid
                };

                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    objfiles.DataFiles = target.ToArray();
                }

            var response=    _UserRepositoryBL.FileUpload(objfiles);

             


                return response;
            }
            else
            {
                return "file nt found";
            }

        
        }

        [HttpPost]
        [Route("SalonLogo/{id}")]
        [AllowAnonymous]
        public string SalonLogo(int id)
        {
            var Userid = id;


            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {//Getting FileName
                var fileName = Path.GetFileName(file.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);



                var objfiles = new FileDto()
                {
                    DocumentId = 0,
                    Name = newFileName,
                    FileType = fileExtension,
                    CreatedOn = DateTime.Now,
                    UserId = Userid
                };

                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    objfiles.DataFiles = target.ToArray();
                }

                var response = _UserRepositoryBL.SalonLogo(objfiles);




                return response;
            }
            else
            {
                return "file nt found";
            }


        }
        [HttpPost]
        [Route("ReGenerateEmailVerificationMail")]
        [AllowAnonymous]
        public IActionResult ReGenerateEmailVerificationPasscode(CreateUserDto createUserDto)
        {
          var response=  _UserRepositoryBL.ReGenerateEmailVerificationPasscode(createUserDto, _IpAddress);
            return Ok(response);
        }

        //[HttpPost]
        //[Route("ReGenerateEmailVerificationMail")]
        //[AllowAnonymous]
        //public IActionResult GetImage(int id)
        //{
        //    var response = _UserRepositoryBL.GetImage(id);
        //    return Ok(response);
        //}

        [HttpPost]
        [Route("EmailVerification")]
        [AllowAnonymous]
        public IActionResult EmailVerification([FromBody]EmailVerificationDTO dto)
        {
            var result = _UserRepositoryBL.IsEmailVerified(dto.Passcode, _IpAddress, dto.Email);
            return Ok(result);
        }

     

        [Authorize]
        [HttpGet]
        [Route("TestToken")]
        public IActionResult TestToken()
        {
            //var user= _accessor.HttpContext.User.Claims.Select(x=>x.Value).FirstOrDefault();
            return Ok(new { tok = "token was here" });
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetProfileImg")]
        public IActionResult GetProfileImg(int id)
        {

            var result = _UserRepositoryBL.GetProfileImg(id);
            if (result.Data == null)
            {
                return Ok(new SwallResponseWrapper { Data = null, StatusCode = 401, SwallText = result.SwallText});
            }
           
            return Ok(new SwallResponseWrapper { Data = result, StatusCode = 200, SwallText = result.SwallText });

        }

        [HttpPost]
        [Route("RegisterSalon")]
        [AllowAnonymous]
        public IActionResult RegisterSalon([FromBody] SalonDto dto)
        {
            var result = _UserRepositoryBL.RegisterSalon(dto);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetSalon")]
        public IActionResult GetSalon(int id)
        {

            var result = _UserRepositoryBL.GetSalon(id);
           

            return Ok(result);

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Salon")]
        public IActionResult Salon(int id)
        {

            var result = _UserRepositoryBL.Salon(id);


            return Ok(result);

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetBarbers")]
        public IActionResult GetBarbers(int id)
        {

            var result = _UserRepositoryBL.GetBarbers(id);
           

            return Ok(result);

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("SearchBarbers")]
        public IActionResult SearchBarbers(int id)
        {

            var result = _UserRepositoryBL.SearchBarbers(id);


            return Ok(result);

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetSalonID")]
        public IActionResult GetSalonID(int id)
        {

            var result = _UserRepositoryBL.GetSalonID(id);


            return Ok(result);

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("RemoveBarber")]
        public IActionResult RemoveBarber([FromBody] int id)
        {

            var result = _UserRepositoryBL.RemoveBarber(id);


            return Ok(result);
        }

    }
}
