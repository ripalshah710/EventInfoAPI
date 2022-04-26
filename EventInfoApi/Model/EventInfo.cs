using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventInfoApi.Model
{
    public class EventInfo
    {
        public EventBasicDetails basicDetails { get; set; }
       public List<EventAudience> eventAudiences { get; set; }
        public List<EventSubject> eventSubjects { get; set; }

    }
    public class EventBasicDetails
    {
        public string title { get; set; }
        public string description { get; set; }
        public string eventTypeDisplay { get; set; }
        public int eventTypeID { get; set; }
        public int eventTypeEnabled { get; set; }
        public string eventTypeCode { get; set; }
        public int eventTypeSort { get; set; }
        public int active { get; set; }
        public string dimensions { get; set; }
        public string standards { get; set; }      
       

    }
   
    public class EventAudience
    {
        public int item_pk { get; set; }
        public string display { get; set; }
        public string code { get; set; }
        public int sort { get; set; }
        public int enabled { get; set; }
    }
    public class EventSubject
    {
        public int item_pk { get; set; }
        public string display { get; set; }
        public string code { get; set; }
        public int sort { get; set; }
        public int enabled { get; set; }
    }

}
