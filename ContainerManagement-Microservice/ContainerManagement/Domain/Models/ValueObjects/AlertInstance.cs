namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public class AlertInstance
    {
        public int Id { get; set;  }
        public int AlertId { get; set; }
        public int OccurenceCount { get; set; }
        public int AcknowledgingUserId { get; set; }
        public DateTime AcknowledgementDate { get; set; } = new DateTime(1970, 1, 1);
        public bool ForcedDismissal { get; set; } = false;
        public DateTime TriggeredDate { get; set; } = new DateTime(1970, 1, 1);

        public AlertInstance(
            int alertId,
            int occurenceCount,
            DateTime acknowledgementDate
            )
        {
               AlertId = alertId;
            OccurenceCount = occurenceCount;
            AcknowledgementDate = acknowledgementDate;
        }

        public void Acknowledge(int userId)
        {
            AcknowledgingUserId = userId;
            AcknowledgementDate = DateTime.UtcNow;
        }

        public void Dismiss(bool forced)
        {
            ForcedDismissal = forced;
        }
    }
}
