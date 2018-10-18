using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottenMango.Data
{
    class DailySummaryData : EntityData<DailySummary>
    {
        //CPU 데이터의 총 갯수
        public int GetCount()
        {
            return CreateContext().DailySummaries.Count(); 
        }
    }
}
