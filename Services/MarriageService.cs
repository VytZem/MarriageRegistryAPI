using AutoMapper;
using MarriageRegistryAPI.Models;
using MarriageRegistryAPI.Persistence.Entities;
using MarriageRegistryAPI.Persistence.Repositories.Interfaces;
using MarriageRegistryAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Services
{
    public class MarriageService : IMarriageService
    {
        private readonly IMarriageRepository _marriageRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        
        public MarriageService(IMarriageRepository marriageRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _marriageRepository = marriageRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<MarriageModel>> GetAllMarriageRecordsAsync()
        {
            var marriages = await _marriageRepository.ListAllAsync();
            var marriagesModel = _mapper.Map<List<MarriageModel>>(marriages);

            foreach (var marriage in marriagesModel)
            {
                var persons = await _personRepository.GetPersonsByMarriageId(marriage.MarriageId);
                marriage.Persons = _mapper.Map<List<PersonModel>>(persons);
            }

            return marriagesModel;

        }

        public async Task<int> CreateMarriageRecordAsync(MarriageModel marriageModel)
        {
            var validator = new MarriageModelValidator(_marriageRepository, _personRepository);
            var validationResult = await validator.ValidateAsync(marriageModel);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var marriage = _mapper.Map<Marriage>(marriageModel);

            var result = await _marriageRepository.AddAsync(marriage);

            foreach (var spouse in marriageModel.Persons)
            {
                var person = _mapper.Map<Person>(spouse);
                person.MarriageId = result.MarriageId;
                await _personRepository.AddAsync(person);
            }

            return result.MarriageId;
        }

    }
}
