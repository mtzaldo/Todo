namespace Todo.Events
{
    public class OperationResultEventArgs
    {
        public bool Success { get; set; }
        public string Operation { get; set; }
        public string Message { get; set; }

        public OperationResultEventArgs(bool success, string operation, string message)
        {
            Success = success;
            Operation = operation;
            Message = message;
        }
    }
}
