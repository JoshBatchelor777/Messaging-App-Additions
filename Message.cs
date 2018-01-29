using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bewander.ViewModels;
using Bewander.DAL;
using Newtonsoft.Json;

namespace Bewander.Models
{
    [Table("Message")]
    public class Message
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }

        public int? RelationshipID { get; set; }

        public string Content { get; set; }

        public string UserID { get; set; }

        public DateTime DateTime { get; set; }

        public Message() { }

        public Message(int relationshipID, string content, string userID)
        {
            RelationshipID = relationshipID;
            Content = content;
            UserID = userID;
            DateTime = DateTime.Now;
            TimeStamp(DateTime);
        }

        public string TimeStamp(DateTime postDate)
        {
            TimeSpan span = DateTime.Now - postDate;

            string datePosted = "Just now";
            if (span.Days > 30)
            {
                return String.Format("{0: MMM d, yyyy}", postDate); // Jan 1 1992
            }

            else if (span.Days > 0)
            {
                return String.Format("{0} {1} ago", span.Days, span.Days == 1 ? "day" : "days"); // 1 day : 2 days
            }

            else if (span.Hours > 0)
            {
                return String.Format("{0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours"); // 1 hr : 2 hrs
            }
            // Attempting to force a time span in minutes.
            else if (span.Minutes > 0 && span.Minutes <= 2)
            {
                return String.Format("{0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes"); // 1 min : 2 mins
            }

            else if (span.Seconds > 0)
            {
                return String.Format("{0} {1}", span.Seconds, span.Seconds == 1 ? "second" : "seconds"); // 1 second : 2 seconds
            }

            if (span.Minutes > 5)
            {
                return String.Format("{0} mins ago", span.Minutes);
            }

            return (datePosted);
        }
    }
}