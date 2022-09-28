using ContosEMS.Data;
using ContosEMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Repositories
{
    public class NotificationRepository
    {
        private EMSDbContext _context;
        public NotificationRepository(EMSDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Notification> AllNotifications()
        {
            return this._context.Notifications;
        }
        public IEnumerable<Notification> AllActiveNotifications()
        {
            return this._context.Notifications.Where(n => n.Status.Equals("active"));
        }

        public IEnumerable<Notification> AllDismissedNotifications()
        {
            return this._context.Notifications.Where(n => n.Status.Equals("dismissed"));
        }

        public IEnumerable<Notification> AllCompletedNotifications()
        {
            return this._context.Notifications.Where(n => n.Status.Equals("completed"));
        }
        public string DismissNotification(int id)
        {
            this._context.Notifications.First(n => n.Id.Equals(id)).Status = "dismissed";
            this._context.SaveChanges();
            return "Notification dismissed successfully.";
        }
        public string CompleteNotification(int id)
        {
            this._context.Notifications.First(n => n.Id.Equals(id)).Status = "completed";
            this._context.SaveChanges();
            return "Notification completed successfully.";
        }
        public string RaiseNotification(Notification notification)
        {
            this._context.Notifications.Add(notification);
            this._context.SaveChanges();
            return "Notification raised successfully";
        }
    }
}
