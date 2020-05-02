
using TodoList.Domain.Models;

namespace TodoList.Domain.Services.Communication
{
    public class ToDoResponse : BaseResponse<ToDo>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public ToDoResponse(ToDo toDo) : base(toDo) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ToDoResponse(string message) : base(message) { }
    }
}
