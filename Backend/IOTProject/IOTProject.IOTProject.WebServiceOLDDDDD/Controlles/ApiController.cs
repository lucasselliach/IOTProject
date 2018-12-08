using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IOTProject.CoreProject.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOTProject.IOTProject.WebService.Controlles
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected IActionResult CreateResponse(HttpStatusCode code, object result)
        {
            switch (code)
            {
                case HttpStatusCode.OK:
                    if (_notifications.HasNotifications()) return Ok(new { success = false, data = _notifications.GetNotifications() });
                    if (result == null) return Ok(new { success = false, data = "Nenhum resultado gerado no request." });
                    return Ok(new { success = true, data = result });

                case HttpStatusCode.BadRequest:
                    return BadRequest(result);

                default:
                    return BadRequest(result);
            }
        }
    }
}
