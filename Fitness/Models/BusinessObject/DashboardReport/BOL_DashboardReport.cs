using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.DashboardReport
{
    public static class BOL_DashboardReport
    {
        /// <summary>
        /// this class is used as input for all graphs in dashboard
        /// </summary>
        public class DashboardInput
        {
            public int UserId { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
        }
        /// <summary>
        /// this class is used as the reference to the result of allocatedActivities
        /// </summary>
        public class Activities
        {
            public string Day { get; set; }
            public int Workouts { get; set; }
            public string Type { get; set; }
        }
        /// <summary>
        /// this class is used as the reference to the result of allocatedActivities
        /// </summary>
        public class CaloriesDetails
        {
            public string Day { get; set; }
            public int Calories { get; set; }
            public string Type { get; set; }
        }
    }
}