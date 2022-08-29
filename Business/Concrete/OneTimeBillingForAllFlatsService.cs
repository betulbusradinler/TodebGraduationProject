using AutoMapper;
using Business.Abstract;
using Business.Configuration.Response;
using DAL.Abstract;
using DTO.Flat;
using DTO.User;
using DTO.UtilityBill;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    //Tüm dairelere tek seferde fatura atama 
    public class OneTimeBillingForAllFlatsService : IOneTimeBillingForAllFlatsService
    {
        private readonly IOneTimeBillingForAllFlatsRepository _utilityBillRepository;
        private readonly IFlatRepository _flatRepository;
        private IMapper _mapper;

        public OneTimeBillingForAllFlatsService
            (IOneTimeBillingForAllFlatsRepository utilityBillRepository, IMapper mapper, IFlatRepository flatRepository)
        {
            _utilityBillRepository = utilityBillRepository;
            _flatRepository = flatRepository;
            _mapper = mapper;
        }

        public CommandResponse Register(CreateUtilityBillRequestForAllFlats request)
        {

            // Böyle bir fatura daha önce kaydedilmiş mi
            var utilityBill1 = _utilityBillRepository.Get(x => x.UtilityBillNo == request.UtilityBillNo);

            if (utilityBill1 != null)
            {
                return new CommandResponse()
                {
                    Message = "Fatura daha önceden kayıt edilmiş",
                    Status = false
                };
            }

            var utilityBill = _mapper.Map<UtilityBill>(request);


            var data = _flatRepository.GetAll(); // Tüm veriler geldi
            var mappedData = data.Select(x => _mapper.Map<SearchFlatResponse>(x)).Where(x => x.State).ToList(); //Durumu 1 olan daireleri çektik
            for(int i=0; i<mappedData.Count(); i++)
            {
                utilityBill.Id = mappedData.ElementAt(i).Id;
                _utilityBillRepository.Add(utilityBill);
                _utilityBillRepository.SaveChanges();
            }

            return new CommandResponse()
            {
                Message = "Fatura başarılı bir şekilde kaydedildi",

                Status = true
            };
        }
    }
}


//var validator = new CreateUtilityBillRequestValidator();
//validator.Validate(request).ThrowIfException();

//var mappedData = data.Select(x => _mapper.Map<SearchFlatResponse>(x)).ToList();
// var flat = data.Select(x =>).ToList();
// flat repository ile durumu 1 olan kullanıcıları çekicem 
// fatura ücret vs hepsine ATIYCAM