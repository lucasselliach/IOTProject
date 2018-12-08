using System;
using System.Net;
using IOTProject.CoreProject.Core.Notifications;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Services;
using IOTProject.IOTProject.Webservice.Controllers.PeopleController.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IOTProject.IOTProject.Webservice.Controllers.PeopleController
{
    [Route("iotproject")]
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;

        public PersonController(INotificationHandler<DomainNotification> notifications, IPersonService personService) : base(notifications)
        {
            _personService = personService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("People")]
        public IActionResult Get()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _personService.GetPeople());
            }
            catch (Exception exc)
            {
                return CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Person")]
        public IActionResult GetPerson(Guid personId)
        {
            try
            {
                if (personId.Equals(Guid.Empty)) return CreateResponse(HttpStatusCode.BadRequest, "Object 'personid' is empty.");

                return CreateResponse(HttpStatusCode.OK, _personService.GetPersonById(personId));
            }
            catch (Exception exc)
            {
                return CreateResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Person/Create")]
        public IActionResult Post([FromBody]PersonPostViewModel personPostViewModel)
        {
            try
            {
                if (personPostViewModel == null) return CreateResponse(HttpStatusCode.BadRequest, "Object 'personPostViewModel' is empty.");

                _personService.CreatePerson(personPostViewModel.Name,
                                            personPostViewModel.Email,
                                            personPostViewModel.BirthDate,
                                            personPostViewModel.IsFitness,
                                            personPostViewModel.IsSmoker,
                                            personPostViewModel.HasCardiovascularDisease,
                                            personPostViewModel.HasHighCholesterol,
                                            personPostViewModel.HasDiabetes);

                return CreateResponse(HttpStatusCode.OK, "Person has been created.");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("Person/Delete")]
        public IActionResult Delete(Guid personId)
        {
            try
            {
                if (personId.Equals(Guid.Empty)) return CreateResponse(HttpStatusCode.BadRequest, "Object 'personid' is empty.");

                _personService.DeletePerson(personId);

                return CreateResponse(HttpStatusCode.OK, "Person has been deleted.");
            }
            catch (Exception err)
            {
                return CreateResponse(HttpStatusCode.BadRequest, err.Message);
            }
        }
    }
}
