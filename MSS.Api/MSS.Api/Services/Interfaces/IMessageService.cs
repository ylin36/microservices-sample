namespace MSS.Api.Services.Interfaces
{
    public interface IMessageService
    {
        Task Produce(string message);
    }
}
