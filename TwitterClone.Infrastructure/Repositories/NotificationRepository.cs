
using Microsoft.EntityFrameworkCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TwitterCloneDbContext _context;

        public NotificationRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Notification AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return notification;
        }

        public Notification UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();

            return notification;
        }

        public bool DeleteNotification(Notification notification)
        {
            var existingNotification = _context.Notifications
                .SingleOrDefault(n => n.Id == notification.Id);

            if (existingNotification is null)
                return false;

            _context.Notifications.Remove(existingNotification);
            _context.SaveChanges();

            return true;
        }

        public int DeleteNotificationsByUserId(Guid userId)
        {
            var notifications = _context.Notifications
                .Where(n => n.UserId == userId)
                .ToList();

            if (notifications.Count == 0)
                return 0;

            _context.Notifications.RemoveRange(notifications);
            _context.SaveChanges();

            return notifications.Count;
        }

        public Notification? GetNotificationById(Guid id)
        {
            return _context.Notifications
                .SingleOrDefault(n => n.Id == id);
        }

        public List<Notification> GetNotifications(
            Guid? userId, string? type, bool? isRead)
        {
            var query = _context.Notifications.AsQueryable();

            if (userId.HasValue)
                query = query.Where(n => n.UserId == userId.Value);

            if (type is not null)
            {
                var normalizedType = type.Trim();

                query = query.Where(n => n.Type == normalizedType);
            }

            if (isRead.HasValue)
                query = query.Where(n => n.IsRead == isRead.Value);

            return query.ToList();
        }
    }
}
