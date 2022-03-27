using MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.AppointmentRepositoryBLs.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCN.WebAPI.Areas.Appointments
{

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

            private readonly IAppointmentRepositoryBL _AppointmentRepositoryBL;
            private IHttpContextAccessor _accessor;
            private string _IpAddress;
            private string _baseuri;
            private IConfiguration _config;

            public AppointmentsController(IAppointmentRepositoryBL AppointmentRepositoryBL, IHttpContextAccessor accessor, IConfiguration config)
            {
            _AppointmentRepositoryBL = AppointmentRepositoryBL;
                _accessor = accessor;
                _config = config;
                _IpAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            }

            [HttpPost]
            [AllowAnonymous]
            [Route("SearchDoctor")]
            public IActionResult SearchDoctor([FromBody] SearchDoctorFilterDto searchDoctorFilterDto)
            {

                var result = _AppointmentRepositoryBL.searchDoctors(searchDoctorFilterDto);


                return Ok(result);
            }

        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterAppointment")]
        public IActionResult RegisterAppointment([FromBody] AppointmentDto searchDoctorFilterDto)
        {

            var result = _AppointmentRepositoryBL.RegisterAppointment(searchDoctorFilterDto);


            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterTimeSlot")]
        public IActionResult RegisterTimeSlot([FromBody] AppointmentDto searchDoctorFilterDto)
        {

            var result = _AppointmentRepositoryBL.RegisterTimeSlot(searchDoctorFilterDto);


            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetDoctor")]
        public IActionResult GetDoctor(int id)
         {

            var result = _AppointmentRepositoryBL.GetDoctor(id);


            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetSpecialities")]
        public IActionResult GetSpecialities()
        { 
            var result = _AppointmentRepositoryBL.GetSpecialities(); 
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("SaveSpecialities")]
        public IActionResult SaveSpecialities([FromBody]SpecialitiesDto specialitiesDto)
        {

            var result = _AppointmentRepositoryBL.SaveSpecialities(specialitiesDto);


            return Ok(result);
        }
         

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAppointments")]
        public IActionResult GetAppointments(int id)
        {

            var result = _AppointmentRepositoryBL.GetAppointments(id);


            return Ok(result);
        }

    }
}
