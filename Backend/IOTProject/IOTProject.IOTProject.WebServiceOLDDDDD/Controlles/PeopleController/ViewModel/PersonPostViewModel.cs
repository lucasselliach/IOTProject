using System;

namespace IOTProject.IOTProject.WebService.Controlles.PeopleController.ViewModel
{
    public class PersonPostViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsFitness { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasCardiovascularDisease { get; set; }
        public bool HasHighCholesterol { get; set; }
        public bool HasDiabetes { get; set; }
    }
}
