using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottenMango.Data
{
    public class DailySummaryData : EntityData<DailySummary>
    {
        //CPU 데이터의 총 갯수
        public int GetCount()
        {
            return CreateContext().DailySummaries.Count(); 
        }

        //데이터 삽입
        public void Insert(
            string name, double totalMemory, double avgMemory, double totalCPU, double avgCPU, DateTime date, int statisticId = 0)
        {
            CreateContext().DailySummaries.Add(
                new DailySummary()
                {
                    statisticId = statisticId,
                    name = name,
                    totalMemory = totalMemory,
                    avgMemory = avgMemory,
                    totalCPU = totalCPU,
                    avgCPU = avgCPU,
                    Date = date
                }
            );

        }
    }
}
