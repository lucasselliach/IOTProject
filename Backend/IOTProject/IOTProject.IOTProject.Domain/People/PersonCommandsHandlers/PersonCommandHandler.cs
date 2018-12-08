using System.Threading;
using System.Threading.Tasks;
using IOTProject.CoreProject.Core.Bus;
using IOTProject.CoreProject.Core.Commands;
using IOTProject.CoreProject.Core.Notifications;
using IOTProject.IOTProject.Domain.People.PersonCommands;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Repositories;
using MediatR;

namespace IOTProject.IOTProject.Domain.People.PersonCommandsHandlers
{
    public class PersonCommandHandler : CommandHandler, INotificationHandler<PersonCreateCommand>, INotificationHandler<PersonEditNameEmailBirthDateCommand>, INotificationHandler<PersonEditHealthInformationCommand>, INotificationHandler<PersonDeleteCommand>
    {
        private readonly IPersonRepository _personRepository;

        public PersonCommandHandler(IMediatorHandler inMemoryBus, INotificationHandler<DomainNotification> notifications, IPersonRepository personRepository) : base(inMemoryBus, notifications)
        {
            _personRepository = personRepository;
        }

        public Task Handle(PersonCreateCommand personCreateCommand, CancellationToken cancellationToken)
        {
            if (!personCreateCommand.IsValid())
            {
                NotifyValidationErrors(personCreateCommand);
                return Task.CompletedTask;
            }

            var newPerson = new Person(personCreateCommand.Name,
                                       personCreateCommand.Email,
                                       personCreateCommand.BirthDate,
                                       personCreateCommand.IsFitness,
                                       personCreateCommand.IsSmoker,
                                       personCreateCommand.HasCardiovascularDisease,
                                       personCreateCommand.HasHighCholesterol,
                                       personCreateCommand.HasDiabetes);

            _personRepository.Create(newPerson);

            return Task.CompletedTask;
        }

        public Task Handle(PersonEditNameEmailBirthDateCommand personEditNameEmailBirthDateCommand, CancellationToken cancellationToken)
        {
            if (!personEditNameEmailBirthDateCommand.IsValid())
            {
                NotifyValidationErrors(personEditNameEmailBirthDateCommand);
                return Task.CompletedTask;
            }
            
            var person = _personRepository.GetById(personEditNameEmailBirthDateCommand.PersonId);
            person.ChangeNameEmailBirthDate(personEditNameEmailBirthDateCommand.Name,
                                            personEditNameEmailBirthDateCommand.Email,
                                            personEditNameEmailBirthDateCommand.BirthDate);
            
            _personRepository.Put(person);

            return Task.CompletedTask;
        }

        public Task Handle(PersonEditHealthInformationCommand personEditHealthInformationCommand, CancellationToken cancellationToken)
        {
            if (!personEditHealthInformationCommand.IsValid())
            {
                NotifyValidationErrors(personEditHealthInformationCommand);
                return Task.CompletedTask;
            }

            var person = _personRepository.GetById(personEditHealthInformationCommand.PersonId);
            person.ChangeHealthInformation(personEditHealthInformationCommand.IsFitness,
                                           personEditHealthInformationCommand.IsSmoker,
                                           personEditHealthInformationCommand.HasCardiovascularDisease,
                                           personEditHealthInformationCommand.HasHighCholesterol, 
                                           personEditHealthInformationCommand.HasDiabetes);

            _personRepository.Put(person);

            return Task.CompletedTask;
        }

        public Task Handle(PersonDeleteCommand personDeleteCommand, CancellationToken cancellationToken)
        {
            if (!personDeleteCommand.IsValid())
            {
                NotifyValidationErrors(personDeleteCommand);
                return Task.CompletedTask;
            }
            
            var person = _personRepository.GetById(personDeleteCommand.PersonId);
            _personRepository.Delete(person);

            return Task.CompletedTask;
        }
    }
}
