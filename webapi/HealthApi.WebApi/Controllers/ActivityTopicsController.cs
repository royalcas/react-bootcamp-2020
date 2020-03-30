using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTopicsController : ControllerBase
    {
        private readonly List<PreventionActivityTopic> _activities;
        private const string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
        public ActivityTopicsController()
        {
            this._activities = new List<PreventionActivityTopic>();
            _activities.Add(new PreventionActivityTopic() { Name = "Nutritional and food supplementation", Benefits = description });
            _activities.Add(new PreventionActivityTopic() { Name = "Dental hygiene education and oral health services", Benefits = description });
            _activities.Add(new PreventionActivityTopic() { Name = "Yoga", Benefits = description });
            _activities.Add(new PreventionActivityTopic() { Name = "Jogging", Benefits = description });
            _activities.Add(new PreventionActivityTopic() { Name = "Running", Benefits = description });
            _activities.Add(new PreventionActivityTopic() { Name = "Thermal", Benefits = description });
            _activities.Add(new PreventionActivityTopic() { Name = "Walking", Benefits = description });
        }

        [HttpGet]
        [Route("me")]
        public ActionResult GetByUser()
        {
            var tip = _activities.TakeLast(3);
            return Ok(tip);
        }


        [HttpGet]
        [Route("suggestions")]
        public ActionResult GetSuggestions()
        {
            var tip = _activities.Take(4);
            return Ok(tip);
        }
    }
}