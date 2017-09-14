using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        public Notification()
        {
        }

        private Notification(Gig gig, NotificationType type)
        {
            if (gig == null) { throw new ArgumentNullException("gig"); }

            DateTime = DateTime.Now;
            Gig = gig;
            Type = type;
        }

        private Notification(Gig gig, NotificationType type, string newVenue, DateTime newDateTime)
        {
            if (gig == null) { throw new ArgumentNullException("gig"); }

            DateTime = DateTime.Now;
            Gig = gig;
            Type = type;
            if (gig.Venue != newVenue)
            {
                OriginalVenue = gig.Venue;
            }
            if (gig.DateTime != newDateTime)
            {
                OriginalDateTime = gig.DateTime;
            }
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }

        public static Notification GigUpdated(Gig newGig, string newVenue, DateTime newDateTime)
        {
            return new Notification(newGig, NotificationType.GigUpdated, newVenue, newDateTime);
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }
    }
}