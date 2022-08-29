using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.ChatValidation;
using DAL.Abstract;
using DTO.Chat;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private IMapper _mapper;
        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _mapper = mapper;
            _chatRepository = chatRepository;
        }
        public CommandResponse Register(CreateChatRegisterRequest request)
        {
            var validator = new CreateChatRequestValidator();
            validator.Validate(request).ThrowIfException();

            var chat = _mapper.Map<Chat>(request);
            _chatRepository.Add(chat);
            _chatRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = "Mesaj başarılı bir şekilde gönderildi",

                Status = true
            };

        }
        public IEnumerable<SearchChatResponse> GetAll()
        {
            var data = _chatRepository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<SearchChatResponse>(x)).ToList();
            return mappedData;

        }

        public CommandResponse Update(UpdateChatRequest request)
        {
            var validator = new UpdateChatRequestValidator();
            validator.Validate(request).ThrowIfException();  // validate işlemi önce yapıldı çünkü gelen Id 0 dan büyük mü kontrolünü sağlaması için.

            var mappedEntity = _mapper.Map<Chat>(request);
            _chatRepository.Update(mappedEntity);
            _chatRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = $"{request.Subject} Konulu mesajınız güncellendi"
            };

        }

        public CommandResponse Delete(DeleteChatRequest request)
        {
            var data = _chatRepository.Get(x => x.Id == request.Id); // Silinmek istenen kullanıcı kontrolünü yaptım.
            if (data == null) //Gelen data boş ise böyle bir kullanıcı yok
            {
                return new CommandResponse()
                {
                    Message = "Böyle bir kullanıcı bulunamadı",
                    Status = false
                };
            }
            // Değilse veri tabanından silme işlemleri
            _chatRepository.Delete(data);
            _chatRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = "Kullanıcı silindi",
                Status = true
            };
        }
    }
}
