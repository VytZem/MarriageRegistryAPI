using FluentValidation;
using MarriageRegistryAPI.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Models
{
    public class MarriageModelValidator : AbstractValidator<MarriageModel>
    {
        private readonly IMarriageRepository _marriageRepository;
        private readonly IPersonRepository _personRepository;

        public MarriageModelValidator(IMarriageRepository marriageRepository, IPersonRepository personRepository)
        {
            _marriageRepository = marriageRepository;
            _personRepository = personRepository;

            RuleFor(m => m.MarriageDate)
            .NotNull().WithMessage("Marriage date is required");

            RuleForEach(m => m.Persons).ChildRules(
                persons =>
                    persons.RuleFor(p => p.FirstName)
                    .NotEmpty().WithMessage("Firstname is required")
                    .NotNull().WithMessage("Firstname is required")
                    .MaximumLength(200).WithMessage("Firstname must not exceed 200 characters")
            );

            RuleForEach(m => m.Persons).ChildRules(
                persons =>
                    persons.RuleFor(p => p.LastName)
                    .NotEmpty().WithMessage("Lastname is required")
                    .NotNull().WithMessage("Lastname is required")
                    .MaximumLength(200).WithMessage("Lastname must not exceed 200 characters")
            );

            RuleForEach(m => m.Persons).ChildRules(
                persons =>
                    persons.RuleFor(p => p.PersonalCode)
                    .NotEmpty().WithMessage("Personal code is required")
                    .NotNull().WithMessage("Personal code is required")
                    .MaximumLength(20).WithMessage("Lastname must not exceed 20 characters")
            );

            RuleFor(m => m)
                .Must(PersonsUnique)
                .WithMessage("Person cannot marry himself.");

            RuleFor(m => m)
                .MustAsync(PersonsNotMarried) 
                .WithMessage("Person cannot marry multiple persons.");
        }

        private async Task<bool> PersonsNotMarried(MarriageModel model, CancellationToken cancellationToken)
        {
            var result = true;

            foreach (var personModel in model.Persons)
            {
                var person = await _personRepository.GetByPersonalCode(personModel.PersonalCode);

                if(person?.MarriageId != null)
                {
                    result = false;
                }
            }

            return  result;
        }


        private bool PersonsUnique(MarriageModel model)
        {
            return !(model.Persons.GroupBy(m => m.PersonalCode).Any(o => o.Count() > 1));
        }
    }
}
