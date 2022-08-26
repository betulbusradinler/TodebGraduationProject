using AutoMapper;
using Business.Abstract;
using Business.Configuration.Response;
using DAL.Abstract;
using DTO.UtilityBillType;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UtilityBillTypeService : IUtilityBillTypeService
    {
        private readonly IUtilityBillTypeRepository _utilityBillTypeRepository;
        private IMapper _mapper;
        public UtilityBillTypeService(IUtilityBillTypeRepository utilityBillTypeRepository, IMapper mapper)
        {
            _utilityBillTypeRepository = utilityBillTypeRepository;
            _mapper = mapper;
        }
        public CommandResponse Register(CreateUtilityBillTypeRegisterRequest request)
        {
            // aynı isimde iki tane fatura tipi olamaz yani fatura tipi adı uniq olmalı
            var isExistData = _utilityBillTypeRepository.Get(x => x.Name == request.Name);
            if (isExistData != null)
            {
                return new CommandResponse()
                {
                    Message = " Bu Fatura Tipi Daha Önceden Eklendi " +
                    "" +
                    "" +
                    "" +
                    "",
                    Status = true
                };
            }
            var utilityBillType = _mapper.Map<UtilityBillType>(request);
            _utilityBillTypeRepository.Add(utilityBillType);
            _utilityBillTypeRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = "Fatura Tipi başarılı şekilde kaydedildi",
                Status = true
            };

        }

        public CommandResponse Delete(DeleteUtilityBillTypeRequest request)
        {
            var utilityBillType = _utilityBillTypeRepository.Get(x => x.Id == request.Id);
            if (utilityBillType == null)
            {
                return new CommandResponse()
                {
                    Message = "Böyle bir fatura tipi bulunamadı",
                    Status = true
                };
            }
            _utilityBillTypeRepository.Delete(utilityBillType);
            _utilityBillTypeRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = "Fatura Tipi başarılı şekilde silindi",
                Status = true
            };
        }

        public IEnumerable<SearchUtilityBillTypeResponse> GetAll()
        {
            var data = _utilityBillTypeRepository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<SearchUtilityBillTypeResponse>(x)).ToList();
            return mappedData;
        }

        public CommandResponse Update(UpdateUtilityBillTypeRequest request)
        {
            var entity = _utilityBillTypeRepository.Get(x => x.Id == request.Id);  //Gelen Id veritabanında var mı onu kontrol ediyoruz. Veritabanından gelen Entity
            if (entity == null)
            {
                return new CommandResponse
                {
                    Status = false,
                    Message = "Böyle bir fatura tipi bulunamadı"
                };
            }
            var mappedEntity = _mapper.Map(request, entity);
            _utilityBillTypeRepository.Update(mappedEntity);
            _utilityBillTypeRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = $"Fatura tipi güncellendi. Fatura Tipi={request.Name}"
            };
        }
    }

}
