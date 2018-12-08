using System;
using System.Net;
using IOTProject.CoreProject.Core.Notifications;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Services;
using IOTProject.IOTProject.Webservice.Controllers.HeartRatesController.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IOTProject.IOTProject.Webservice.Controllers.HeartRatesController
{
    [Route("iotproject")]
    public class HeartRateController : ApiController
    {
        private readonly IHeartRateAppService _heartRateService;

        public HeartRateController(INotificationHandler<DomainNotification> notifications, IHeartRateAppService heartRateService) : base(notifications)
        {
            _heartRateService = heartRateService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("HeartRates")]
        public IActionResult Get(Guid personId)
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _heartRateService.GetHeartRatesByPersonId(personId));
            }
            catch (Exception exc)
            {
                return CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("HeartRate/Create")]
        public IActionResult Post([FromBody]HeartRatePostViewModel heartRatePostViewModel)
        {
            try
            {
                if (heartRatePostViewModel == null) return CreateResponse(HttpStatusCode.BadRequest, "Object 'heartRatePostViewModel' is empty.");

                var person = _heartRateService.GetPersonById(heartRatePostViewModel.PersonId);
                _heartRateService.CreateHeartRate(person, heartRatePostViewModel.HeartRateValue);

                return CreateResponse(HttpStatusCode.OK, "HeartRate has been created.");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }
    }
}
