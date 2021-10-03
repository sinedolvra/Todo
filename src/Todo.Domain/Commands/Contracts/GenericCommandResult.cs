namespace Todo.Domain.Commands.Contracts
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public object Payload { get; set; }

        public GenericCommandResult(bool success, object message, object payload)
        {
            Success = success;
            Message = message;
            Payload = payload;
        }
    }
}