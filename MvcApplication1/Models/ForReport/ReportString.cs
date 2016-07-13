using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models.ForReport
{
    public class ReportString
    {
        public string[][] TTT = new string[4][]; //COUNT
        public string[][] RRR = new string[4][]; //SUM

        public string[][] RaschetCount = new string[4][];
        public string[][] RaschetSum = new string[4][];
    }
}