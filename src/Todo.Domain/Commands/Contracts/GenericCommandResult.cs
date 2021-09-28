namespace Todo.Domain.Commands.Contracts
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }

        public GenericCommandResult()
        {

        }

        public GenericCommandResult(bool success, string message, object payload)
        {
            Success = success;
            Message = message;
            Payload = payload;
        }
    }
}