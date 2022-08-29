using Business.Configuration.Response;
using DTO.Chat;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IChatService
    {
        CommandResponse Register(CreateChatRegisterRequest request);
        IEnumerable<SearchChatResponse> GetAll();
        CommandResponse Update(UpdateChatRequest request);
        CommandResponse Delete(DeleteChatRequest request);
    }
}
