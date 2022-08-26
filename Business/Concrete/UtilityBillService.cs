using AutoMapper;
using Business.Abstract;
using Business.Configuration.Response;
using DAL.Abstract;
using DTO.UtilityBill;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UtilityBillService : IUtilityBillService
    {
        private readonly IUtilityBillRepository _utilityBillRepository;
        private readonly IFlatRepository _flatRepository;
        private IMapper _mapper;
        public UtilityBillService(IUtilityBillRepository utilityBillRepository, IMapper mapper, IFlatRepository flatRepository)
        {
            _utilityBillRepository = utilityBillRepository;
            _mapper = mapper;
            _flatRepository = flatRepository;
        }

        public CommandResponse Register(CreateUtilityBillRequest request)
        {
            // Böyle bir fatura daha önce kaydedilmiş mi
            var utilityBill1 = _utilityBillRepository.Get(x => x.UtilityBillNo == request.UtilityBillNo);
            // Böyle bir daire var mı varsa bu daireye de bu fatura id sini kayıt etmeliyim
            var flat = _flatRepository.Get(x => x.Id == request.FlatId);

            if (utilityBill1 != null || flat == null)
            {
                string message = null;
                if (utilityBill1 != null)
                {
                    message = "Db de böyle bir fatura bulunmakta";
                }
                else
                {
                    message = "Böyle Bir Daire Sistemde bulunmamaktadır!";
                }
                return new CommandResponse()
                {
                    Message = message,
                    Status = false
                };
            }
            var utilityBill = _mapper.Map<UtilityBill>(request);
            _utilityBillRepository.Add(utilityBill);     // Kullanıcı eklendi
            _utilityBillRepository.SaveChanges(); // Veritabanına gitti
            //var flatUtilityBill = _mapper.Map();
            //_flatRepository.Add(flat);
            //_flatRepository.SaveChanges();

            return new CommandResponse()  // response çıktı
            {
                Message = "Fatura başarılı bir şekilde kaydedildi",

                Status = true
            };
        }

        public IEnumerable<SearchUtilityBillResponse> GetAll()
        {

            var data = _utilityBillRepository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<SearchUtilityBillResponse>(x)).ToList();
            return mappedData;
        }

        public CommandResponse Update(UpdateUtilityBillRequest request)
        {
            // Fatura no eklemedim ama fatura no olması lazım uniq bir şekilde
            // Böyle bir fatura var mı kontrolü daire boş olamaz böyle bir daire var mı kontrolü
            var isExistEntity = _utilityBillRepository.Get(x => x.Id == request.Id);
            if (isExistEntity == null)
            {
                return new CommandResponse()
                {
                    Message = "Kayıtlı olmayan fatura no girdiniz",
                    Status = false
                };
            }
            var utilityBill = _mapper.Map<UtilityBill>(request);
            _utilityBillRepository.Update(utilityBill);     // Kullanıcı eklendi
            _utilityBillRepository.SaveChanges(); // Veritabanına gitti

            return new CommandResponse()  // response çıktı
            {
                Message = "Fatura başarılı bir şekilde kaydedildi",
                Status = true
            };
        }

        public CommandResponse Delete(DeleteUtilityBillRequest request)
        {

            var utilityBill = _utilityBillRepository.Get(x => x.UtilityBillNo == request.UtilityBillNo);
            if (utilityBill == null)
            {
                return new CommandResponse()
                {
                    Message = "Böyle bir Fatura bulunamadı",
                    Status = false
                };
            }
            _utilityBillRepository.Delete(utilityBill);
            _utilityBillRepository.SaveChanges();
            return new CommandResponse()
            {
                Message = "Fatura Başarılı bir şekilde silindi",
                Status = true
            };
        }

    }
}
