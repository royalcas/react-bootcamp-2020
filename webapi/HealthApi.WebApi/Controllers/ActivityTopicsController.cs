using System.Collections.Generic;
using System.Linq;
using HealthApi.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTopicsController : ControllerBase
    {
        private readonly List<PreventionActivityTopicModel> _activities;
        private const string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
        public ActivityTopicsController()
        {
            this._activities = new List<PreventionActivityTopicModel>();
            _activities.Add(new PreventionActivityTopicModel() { Name = "Nutritional and food supplementation", Benefits = description });
            _activities.Add(new PreventionActivityTopicModel() { Name = "Dental hygiene education and oral health services", Benefits = description });
            _activities.Add(new PreventionActivityTopicModel() { Name = "Yoga", Benefits = description });
            _activities.Add(new PreventionActivityTopicModel() { Name = "Jogging", Benefits = description });
            _activities.Add(new PreventionActivityTopicModel() { Name = "Running", Benefits = description });
            _activities.Add(new PreventionActivityTopicModel() { Name = "Thermal", Benefits = description });
            _activities.Add(new PreventionActivityTopicModel() { Name = "Walking", Benefits = description });
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