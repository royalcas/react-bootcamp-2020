using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthApi.Application.Services;
using HealthApi.Identity;
using HealthApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthApi.WebApi.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _service;
        private readonly IIdentityUserProvider _user;

        public MedicalRecordController(IMedicalRecordService service, IIdentityUserProvider user)
        {
            _service = service;
            _user = user;
        }

        [HttpGet]
        [Route("me/medicalRecord")]
        public ActionResult GetCurrentUserMedicalRecord()
        {
            var medicalRecord = _service.GetMedicalRecordByUser(_user.Id);
            return Ok(medicalRecord);
        }

        [HttpGet]
        [Route("all/medical-record")]
        public ActionResult GetAllMedicalRecord()
        {
            var medicalRecord = _service.GetAll();
            return Ok(medicalRecord);
        }

        [HttpPost]
        [Route("medical-record")]
        public ActionResult Post([FromBody] MedicalRecordItem model)
        {
            _service.Add(model);
            return Ok();
        }

    }
}