using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NotificationsSystem.Common;
using NotificationsSystem.Domain;
using NotificationsSystem.Domain.CompaniesAggregate;
using NotificationsSystem.Domain.SchedulsAggregate;
using NotificationsSystem.DTOs;
using NotificationsSystem.Helpers;
using NotificationsSystem.Validator;
using NotificationsSystem.ViewModel;
using NotificationsSystem.ViewModels;

namespace NotificationsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class NotificationsController : ControllerBase
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NotificationsController> _logger;
        public IConfiguration _configuration;
        public NotificationsController(IUnitOfWork unitOfWork, ILogger<NotificationsController> logger, IConfiguration iConfig)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _configuration = iConfig;
        }

        [HttpPost("CreateCompany")]
        public  IActionResult  CreateCompany(CompanyDTO model)
        {
            try
            {
                var id = _unitOfWork.Companies.GetAll().Result;
                
                //check if company number is ok
                if (!Validator.Validate.IsDigitsOnly(model.ConmpanyNumber) || model.ConmpanyNumber.Length != 10)
                {
                    _logger.LogError("Company number is not valid!");
                    throw new BadRequestException("Company number is not valid!");
                }

                //Convert market to int
                var market = Enum.GetValues(typeof(Market)).OfType<Market>()
                            .Where(x => x.ToString().Equals(model.Market))
                            .Select(x => (int)x).First();

                //Convert CompanyType to int
                var CompanyType = Enum.GetValues(typeof(CompanyType)).OfType<CompanyType>()
                            .Where(x => x.ToString().Equals(model.CompanyType))
                            .Select(x => (int)x).First();

                var comp = new Company()
                {
                    CompanyType = CompanyType,
                    ConmpanyName = model.ConmpanyName,
                    ConmpanyNumber = model.ConmpanyNumber,
                    CreateDate = DateTime.Now,
                    Market = market,
                    Id = new Guid()
                };

                _unitOfWork.Companies.Add(comp);
                _unitOfWork.Complete();                

                return Ok();
            }
            catch(Exception Ex)
            {
                _logger.LogError(Ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("CreateSchedule")]
        public async Task<ScheduleViewModel> CreateSchedule(CompanyDTO model)
        {
            try
            {
                //get markets from appsettings
                string interval = _configuration.GetSection("NotificationInterval").GetSection(model.Market).Value;

                //get rules from appsettings
                string notificationRules = _configuration.GetSection("NotificationRules").GetSection(model.Market).Value;

                var days = interval.Split(','); 
                
                var rules = notificationRules.Split(',');

                //check available rules
                if(!CheckNotification.Enabled(model.CompanyType,rules)) return null;                    

                foreach (var day in days)
                {
                    var date = DateTime.Now.AddDays(Convert.ToInt32(day));
                    await _unitOfWork.Schedules.Add(new Schedule { CompanyId = model.Id, SendDate = date });
                }

                _unitOfWork.Complete();

                var dates = _unitOfWork.Schedules.GetAll().Result.Where(s => s.CompanyId == model.Id);

                var schedule = new List<string>();
                

                foreach (var date in dates)
                {
                    schedule.Add(date.SendDate.ToString("dd/MM/yyyy"));
                }               

                var schedules = new ScheduleViewModel();

                schedules.CompanyId = model.Id;
                schedules.notifications = schedule;

                return schedules;
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex.Message);
                return null;
            }
        }
    }
}