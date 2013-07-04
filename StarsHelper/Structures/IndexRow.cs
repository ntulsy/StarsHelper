using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsHelper.Structures
{
    public class IndexRow
    {
        public string Type { get; set; }
        public WeekDays Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Venue { get; set; }
        public bool[] IsScheduledInWeek { get; set; }


        public IndexRow()
        {
            IsScheduledInWeek = new bool[13];
            for (int i = 0; i < 13; i++)
            {
                IsScheduledInWeek[i] = false;
            }
        }
    }

    

}
