using System;
using IOTProject.IOTProject.Domain.People;

namespace IOTProject.IOTProject.Domain.HeartRates
{
    public class HeartRate
    {
        public Guid Id { get; private set; }
        public Person Person { get; private set; }
        public int HeartRateValue { get; private set; }
        public DateTime DateOfOccurrence { get; private set; }

        public HeartRate(Person person, int heartRateValue)
        {
            Id = Guid.NewGuid();
            Person = person;
            HeartRateValue = heartRateValue;
            DateOfOccurrence = DateTime.Now;
        }

        public HeartRate(Guid id, Person person, int heartRateValue, DateTime dateOfOccurrence)
        {
            Id = id;
            Person = person;
            HeartRateValue = heartRateValue;
            DateOfOccurrence = dateOfOccurrence;
        }
    }
}
