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
        [Route("FindSlots")]
        public IActionResult FindSlots([FromBody] AppointmentDto searchslot)
        {

            var result = _AppointmentRepositoryBL.FindSlots(searchslot);


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

        [HttpPost]
        [Route("UpdateUser")]
        [AllowAnonymous]
        public IActionResult UpdateUser([FromBody] AppointmentDto dto)
        {
            
            var result = _AppointmentRepositoryBL.UpdateUser(dto);
            return Ok(result);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("CancelAppointment")]
        public IActionResult CancelAppointment([FromBody] int id)
        {

            var result = _AppointmentRepositoryBL.CancelAppointment(id);


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

        [HttpGet]
        [AllowAnonymous]
        [Route("GetPatientAppointments")]
        public IActionResult GetPatientAppointments(int id)
        {

            var result = _AppointmentRepositoryBL.GetPatientAppointments(id);


            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GetSalonList")]
        public IActionResult GetSalonList([FromBody] SearchDoctorFilterDto searchDoctorFilterDto)
        {

            var result = _AppointmentRepositoryBL.GetSalonList(searchDoctorFilterDto);


            return Ok(result);
        }
    }
}
