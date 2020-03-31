
using HealthApi.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipsController : ControllerBase
    {
        private readonly List<TipModel> _tips;

        public TipsController()
        {
            this._tips = new List<TipModel>();
            _tips.Add(new TipModel() { Title = "COVID-19", Description = "HANDS Wash them often" });
            _tips.Add(new TipModel() { Title = "COVID-19", Description = "ELBOW Cough into it" });
            _tips.Add(new TipModel() { Title = "COVID-19", Description = "FACE Don't touch it" });
            _tips.Add(new TipModel() { Title = "COVID-19", Description = "SPACE Keep safe distance" });
            _tips.Add(new TipModel() { Title = "COVID-19", Description = "HOME Stay if you can" });
        }

        [HttpGet]
        [Route("me")]
        public ActionResult GetByUser() {
            var rand = new Random();
            var tip = _tips.ElementAt(rand.Next(_tips.Count()));
            return Ok(tip);
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_tips);
        }
    }
}