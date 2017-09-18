using GigHub.Core.Dto;
using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewUserNotificationsWithArtist(string userId);
        IEnumerable<UserNotification> GetNewNotifications(string userId);
        void MarkAllAsRead();
    }
}
