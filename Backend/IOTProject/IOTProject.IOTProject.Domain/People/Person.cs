using System;

namespace IOTProject.IOTProject.Domain.People
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsFitness { get; private set; }
        public bool IsSmoker { get; private set; }
        public bool HasCardiovascularDisease { get; private set; }
        public bool HasHighCholesterol { get; private set; }
        public bool HasDiabetes { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime AlterDate { get; private set; }
        public DateTime DeleteDate { get; private set; }
        public bool Active { get; private set; }


        public Person(string name, string email, DateTime birthDate, bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            BirthDate = birthDate;
            IsFitness = isFitness;
            IsSmoker = isSmoker;
            HasCardiovascularDisease = hasCardiovascularDisease;
            HasHighCholesterol = hasHighCholesterol;
            HasDiabetes = hasDiabetes;
            CreateDate = DateTime.Now;
            Active = true;
        }

        public Person(Guid id, string name, string email, DateTime birthDate, bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes, DateTime createDate, DateTime alterDate, DateTime deleteDate, bool active)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            IsFitness = isFitness;
            IsSmoker = isSmoker;
            HasCardiovascularDisease = hasCardiovascularDisease;
            HasHighCholesterol = hasHighCholesterol;
            HasDiabetes = hasDiabetes;
            CreateDate = createDate;
            AlterDate = alterDate;
            DeleteDate = deleteDate;
            Active = active;
        }

        public void ChangeNameEmailBirthDate(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AlterDate = DateTime.Now;
        }

        public void ChangeHealthInformation(bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes)
        {
            IsFitness = isFitness;
            IsSmoker = isSmoker;
            HasCardiovascularDisease = hasCardiovascularDisease;
            HasHighCholesterol = hasHighCholesterol;
            HasDiabetes = hasDiabetes;
            AlterDate = DateTime.Now;
        }

        public void Delete()
        {
            Active = false;
            DeleteDate = DateTime.Now;
        }
    }
}
