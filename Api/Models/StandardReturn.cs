namespace Api.Models
{
    public class StandardReturn<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }

        public StandardReturn(T data, ReturnStatus status = ReturnStatus.Ok)
        {
            Status = status.ToString();
            Data = data;
        }
    }
}
