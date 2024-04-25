using Application.ViewModels;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IPublishService
    {
        Task<bool> PublishAsync(PublishViewModel model, long userId);
    }
}
