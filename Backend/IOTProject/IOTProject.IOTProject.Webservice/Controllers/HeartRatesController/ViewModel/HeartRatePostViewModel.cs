using System;

namespace IOTProject.IOTProject.Webservice.Controllers.HeartRatesController.ViewModel
{
    public class HeartRatePostViewModel
    {
        public Guid PersonId { get; set; }
        public int HeartRateValue { get; set; }
    }
}
