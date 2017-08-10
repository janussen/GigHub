using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }

        public Notification()
        {
        }

        public Notification(Gig gig, NotificationType type)
        {
            if (gig == null) { throw new ArgumentNullException("gig"); }

            DateTime = DateTime.Now;
            Gig = gig;
            Type = type;
        }

        public Notification(Gig gig, NotificationType type, string newVenue, DateTime newDateTime)
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
    }
}