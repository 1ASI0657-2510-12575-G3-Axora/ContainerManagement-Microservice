using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.ContainerManagement.Infrastructure.Repositories
{
	public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
	{
		private readonly ApplicationDbContext context;

		// Priority 0: No filter
		// Priority 1: Only AlertType: 1, 2, 4, 8, 9
		// Priority 2: Only AlertType: 1, 2

		private IQueryable<Notification> FilterByPriority(IQueryable<Notification> notifications, int priority)
		{
			switch (priority)
			{
				case 1:
					return notifications.Where(n => 
					n.AlertType == AlertType.TemperatureThresholdExceeded ||
					n.AlertType == AlertType.HumidityThresholdExceeded ||
					n.AlertType == AlertType.ContainerLinked ||
					n.AlertType == AlertType.TemplateAssigned ||
					n.AlertType == AlertType.ContainerActivated);
				case 2:
					return notifications.Where(n => n.AlertType == AlertType.TemperatureThresholdExceeded ||
					n.AlertType == AlertType.HumidityThresholdExceeded);
				default:
					return notifications;
			}
		}

		public async Task<ICollection<Notification>> GetNotificationsByAccount(int accountId, int priority, int limit)
		{
			var notifications = context.Notifications
				.Where(n => n.AccountId == accountId)
				.OrderByDescending(n => n.IssuedAt);

			var filteredNotifications = FilterByPriority(notifications, priority);

			return await filteredNotifications.Take(limit).ToListAsync();
		}

		public NotificationRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<ICollection<Notification>> GetNotificationsByGroup(int groupId, int priority, int limit)
		{
			var notifications = context.Notifications
				.Where(n => n.GroupId == groupId)
				.OrderByDescending(n => n.IssuedAt);

			var filteredNotifications = FilterByPriority(notifications, priority);

			return await filteredNotifications.Take(limit).ToListAsync();
		}

		public async Task<ICollection<Notification>> GetNotificationsByContainer(int containerId, int priority, int limit)
		{
			var notifications = context.Notifications
				.Where(n => n.ContainerId == containerId)
				.OrderByDescending(n => n.IssuedAt);

			var filteredNotifications = FilterByPriority(notifications, priority);

			return await filteredNotifications.Take(limit).ToListAsync();
		}

		public async Task<int> GetAmountOfNotificationsByContainer(int containerId, int priority = 1)
		{
			var notifications = context.Notifications
				.Where(n => n.ContainerId == containerId);
			var filteredNotifications = FilterByPriority(notifications, priority);
			return await filteredNotifications.CountAsync();
		}

		public Task<Notification?> GetLatestNotificationByContainer(int containerId)
		{
			return context.Notifications
				.Where(n => n.ContainerId == containerId)
				.OrderByDescending(n => n.IssuedAt)
				.FirstOrDefaultAsync();
		}

		public Task<int> GetAmountOfNotificationsByGroup(int groupId, int priority = 1)
		{
			var notifications = context.Notifications
				.Where(n => n.GroupId == groupId);
			var filteredNotifications = FilterByPriority(notifications, priority);
			return filteredNotifications.CountAsync();
		}

		public Task<Notification?> GetLatestNotificationByGroup(int groupId)
		{
			return context.Notifications
				.Where(n => n.GroupId == groupId)
				.OrderByDescending(n => n.IssuedAt)
				.FirstOrDefaultAsync();
		}

		public Task<int> GetAmountOfNotificationsByAccount(int accountId, int priority = 1)
		{
			var notifications = context.Notifications
				.Where(n => n.AccountId == accountId);
				var filteredNotifications = FilterByPriority(notifications, priority);
			return filteredNotifications.CountAsync();
		}

		public Task<Notification?> GetLatestNotificationByAccount(int accountId)
		{
			return context.Notifications
				.Where(n => n.AccountId == accountId)
				.OrderByDescending(n => n.IssuedAt)
				.FirstOrDefaultAsync();
		}
	}
}
