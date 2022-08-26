using AutoMapper;
using Business.Abstract;
using Business.Configuration.Response;
using DAL.Abstract;
using DTO.Flat;
using DTO.User;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _flatRepository;
        private IMapper _mapper;
        public FlatService(IFlatRepository flatRepository, IMapper mapper)
        {
            _flatRepository = flatRepository;
            _mapper = mapper;   
        }

        public CommandResponse Delete(DeleteFlatRequest request)
        {
            // validasyon yapmıycam böyle bir id var mı kontrol edicem

            var flat = _flatRepository.Get(x => x.Id == request.Id);
            if(flat == null)
            {
                return new CommandResponse()
                {
                    Message = "Böyle bir kullanıcı bulunamadı",
                    Status = false
                };
            }
            _flatRepository.Delete(flat);
            _flatRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = "Daire başarılı şekilde silindi",
                Status = true
            };

        }

        public IEnumerable<SearchFlatResponse> GetAll()
        {
            var data = _flatRepository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<SearchFlatResponse>(x)).ToList();
            return mappedData;
        }

        // Daire kayıt
        public CommandResponse Register(CreateFlatRegisterRequest request)
        {
            // tane alan var boş girilmemesi gerekn temel daire özel alanlar
            // validasyonlarını yap.
            var entity = _flatRepository.Get(x => x.No == request.No); // Aynı daire numarası varsa
            if(entity != null)
            {
                return new CommandResponse()
                {
                    Message = "Daire daha önceden kaydedilmiş",
                    Status = false
                };
            }
            var flat = _mapper.Map<Flat>(request);
            _flatRepository.Add(flat);     // Daire eklendi
            _flatRepository.SaveChanges(); // Veritabanına gitti

            return new CommandResponse()  
            {
                Message = "Daire başarılı şekilde kaydedildi",
                Status = true
            };
        }

        // Daire Güncelleme
        public CommandResponse Update(UpdateFlatRequest request)
        {
            // Güncelleme yaparken gerekli bir validasyon işlemi var mı?
            // tane alan var boş girilmemesi gerekn temel daire özel alanlar
            // validasyonlarını yap.
            var entity = _flatRepository.Get(x => x.Id == request.Id); // Bu id de bir kayıt var mı
            if (entity == null)
            {
                return new CommandResponse
                {
                    Status = false,
                    Message = "Böyle bir kullanıcı bulunamadı"
                };
            }
            var mappedEntity = _mapper.Map(request, entity);
            _flatRepository.Update(mappedEntity);
            _flatRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = $"Daire başarılı bir şekilde silindi. Name={request.No}"
            };
        }
    }
}
