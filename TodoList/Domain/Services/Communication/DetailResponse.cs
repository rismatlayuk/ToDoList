using TodoList.Domain.Models;

namespace TodoList.Domain.Services.Communication
{
    public class DetailResponse : BaseResponse<Detail>
    {
        public DetailResponse(Detail detail) : base(detail) { }
        public DetailResponse(string message) : base(message) { }
    }
}
