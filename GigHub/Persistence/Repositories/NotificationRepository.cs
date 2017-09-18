using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Dto;
using System;

namespace GigHub.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNewUserNotificationsWithArtist(string userId)
        {
            return _context.UserNotifications
                    .Where(un => un.UserId == userId && !un.IsRead)
                    .Select(un => un.Notification)
                    .Include(n => n.Gig.Artist)
                    .ToList();
        }

        public IEnumerable<UserNotification> GetNewNotifications(string userId)
        {
            return _context.UserNotifications
                    .Where(un => un.UserId == userId && !un.IsRead)
                    .ToList();
        }

        public void MarkAllAsRead()
        {
            throw new NotImplementedException();
        }
    }
}