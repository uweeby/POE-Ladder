using System;
using System.Xml;

namespace Notifications
{
    public class ScheduledToastNotification
    {
        private string Content;
        private DateTime DeliveryTime;
        private bool HourNotification;
        private bool FifteenMinuteNotification;

        public ScheduledToastNotification(string notificationText, DateTime deliveryTime)
        {
            Content = notificationText;
            DeliveryTime = deliveryTime;
            HourNotification = false;
            FifteenMinuteNotification = false;
        }

        public string GetContent()
        {
            return Content;
        }

        public DateTime GetDeliveryTime()
        {
            return DeliveryTime;
        }

        public bool GetHourNotification()
        {
            return HourNotification;
        }

        public void SetHourNotification(bool value)
        {
            this.HourNotification = value;
        }

        public bool GetFifteenMinuteNotification()
        {
            return FifteenMinuteNotification;
        }

        public void SetFifteenMinuteNotification(bool value)
        {
            this.FifteenMinuteNotification = value;
        }
    }
}
