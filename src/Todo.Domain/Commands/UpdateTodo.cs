using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Validators;

namespace Todo.Domain.Commands
{
    public class UpdateTodo : Command
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Done { get; set; }
        
        public UpdateTodo(string id, string title, string description, bool? done)
        {
            Id = id;
            Description = description;
            Title = title;
            Done = done;
        }

        public override void Validate()
        {
            ValidationResult = new UpdateTodoValidator().Validate(this);
        }
    }
}