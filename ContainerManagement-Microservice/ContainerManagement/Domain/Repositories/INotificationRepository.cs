using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Domain.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        public Task<ICollection<Notification>> GetNotificationsByAccount(int accountId, int priority, int limit);

        public Task<ICollection<Notification>> GetNotificationsByGroup(int groupId, int priority, int limit);

        public Task<ICollection<Notification>> GetNotificationsByContainer(int containerId, int priority, int limit);

		public Task<int> GetAmountOfNotificationsByContainer(int containerId, int priority = 1);

		public Task<Notification?> GetLatestNotificationByContainer(int containerId);

		public Task<int> GetAmountOfNotificationsByGroup(int groupId, int priority = 1);

		public Task<Notification?> GetLatestNotificationByGroup(int groupId);

		public Task<int> GetAmountOfNotificationsByAccount(int accountId, int priority = 1);

		public Task<Notification?> GetLatestNotificationByAccount(int accountId);

		
    }
}
