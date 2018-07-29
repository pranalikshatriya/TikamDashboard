using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard
{
    
    
    public class ColumnChart
    {
        public List<SeriesItem> series { get; set; }
        string[] colors = new string[] { "#80c9be", "#f2e2cd", "#e99790", "#d7d2cb", "#48697f" };


        public ColumnChart()
        { }

        public ColumnChart(List<SeriesItem> iseries)
        {
            series = iseries;
        }
    }
}