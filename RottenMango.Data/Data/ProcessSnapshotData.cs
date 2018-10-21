using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;


namespace RottenMango.Data
{
    
    public class ProcessSnapshotData : EntityData<ProcessSnapshot>
    {
        RottenMangoEntities context = new RottenMangoEntities();

        public RottenMangoEntities Getcontext()
        {
            return context;
        }

        //Memory
        public List<ProcessSnapshot> OrederByMemory(bool desc)
        {
            if (desc)
                return CreateContext().ProcessSnapshots.
                    OrderByDescending(x => x.usingMemory).ToList();
            else
                return CreateContext().ProcessSnapshots.
                    OrderBy(x => x.usingMemory).ToList();
        }


        //CPU
        public List<ProcessSnapshot> OrederByCpu(bool desc)
        {
            if (desc)
                return CreateContext().ProcessSnapshots.
                    OrderByDescending(x => x.usingCpu).ToList();
            else
                return CreateContext().ProcessSnapshots.
                    OrderBy(x => x.usingCpu).ToList();
        }

        // 데이터 삽입
        public void Insert(string name, float usingCpu, float usingMemory, DateTime recordTime)
        {
            
            context.ProcessSnapshots.Add(
                new ProcessSnapshot()
                {
                    name = name,
                    usingCpu = usingCpu,
                    usingMemory = usingMemory,                   
                    recordTime = recordTime,
                }
            );
            
        }

        public void SummaryMaker(string start, string end)
        {
            DateTime _start = Convert.ToDateTime(start);
            DateTime _end = DateTime.Now;
                //Convert.ToDateTime(end);

//            var query = from x in context.ProcessSnapshots
//                where (x.recordTime >= _start && x.recordTime <= _end)
//                group x by x.name into g
//                select new { Name = g.Key, Avr = g.Average(y => y.usingCpu) };

            var query = from x in context.ProcessSnapshots
                where (x.recordTime >= _start && x.recordTime <= _end)
                group x by x.name into g
                select new {
                    avgCPU = g.Average(y => y.usingCpu),
                    avgMemory = g.Average(y => y.usingMemory),
                    Date = _start,
                    name = g.Key,
                    statisticId = 1,
                    totalCPU = 1,
                    totalMemory = 1
                    };

            var list = query.ToList();

            DailySummaryData _dailySummary = new DailySummaryData();

            foreach (var item in list)
            {
                _dailySummary.Insert(
                    item.name,
                    item.avgMemory,
                    item.avgCPU,
                    DateTime.Today
                    );
            }

            _dailySummary.getcontext().SaveChanges();






            /*
             *var results = from line in Lines
              group line by line.ProductCode into g
              select new ResultLine {
                ProductName = g.First().Name,
                Price = g.Sum(_ => _.Price).ToString(),
                Quantity = g.Count().ToString(),
              };
             */

        }

        public class SurrmaryInfo
        {
            public string name { get; set; }
            public double avgCPU { get; set; }
            public string avgMemory { get; set; }
            public DateTime Date { get; set; }
        }

        public List<SurrmaryInfo> GetSummary(string condition)
        {
            List<SurrmaryInfo> surrmaryInfos = new List<SurrmaryInfo>();
            int day = 0;

            if (condition == "1일")
            {
                var query = from x in context.ProcessSnapshots
                    where (x.recordTime >= DateTime.Today)
                    group x by x.name into g
                    select new
                    {
                        avgCPU = g.Average(y => y.usingCpu),
                        avgMemory = g.Average(y => y.usingMemory),
                        Date = DateTime.Today,
                        name = g.Key
                    };

                foreach (var item in query)
                {
                    string memory;

                    if (item.avgMemory >= 1024 * 1024)
                    {
                        memory = Math.Round((item.avgMemory / 1024 / 1024), 2).ToString() + " MB";
                    }
                    else if (item.avgMemory >= 1024)
                    {
                        memory = Math.Round((item.avgMemory / 1024), 2).ToString() + " KB";
                    }
                    else
                    {
                        memory = (item.avgMemory).ToString() + " B";
                    }

                    surrmaryInfos.Add(new SurrmaryInfo()
                    {
                        name = item.name,
                        avgCPU = Math.Round(item.avgCPU, 2),
                        avgMemory = memory,
                        Date = item.Date
                    });
                }

                return surrmaryInfos;
            }
            else if (condition == "1주일")
            {
                day = -7;

            }
            else if (condition == "1달")
            {
                day = -30;

            }
            else if (condition == "6달")
            {
                day = -180;

            }
            else if (condition == "1년")
            {
                day = -365;
            }

            DateTime startDay = DateTime.Today.AddDays(day);

            var _query = from x in context.DailySummaries
                where (x.Date >= startDay &&
                       x.Date <= DateTime.Today)
                select x;

            foreach (var item in _query)
            {
                string memory;

                if (item.avgMemory >= 1024 * 1024)
                {
                    memory = Math.Round((item.avgMemory / 1024 / 1024),2).ToString() + " MB";
                }
                else if (item.avgMemory >= 1024)
                {
                    memory = Math.Round((item.avgMemory / 1024), 2).ToString() + " KB";
                }
                else
                {
                    memory = (item.avgMemory).ToString() + " B";
                }

                surrmaryInfos.Add(new SurrmaryInfo()
                {
                    name = item.name,
                    avgCPU = Math.Round(item.avgCPU,2),
                    avgMemory = memory,
                    Date = (DateTime)item.Date
                });
            }

            return surrmaryInfos;
        }
//        public List<string> GetTop10CPUList()
//        {
//            List<string> top10CPUList = new List<string>();
//
//            var query = from x in context.ProcessSnapshots
//                orderby x.usingCpu descending 
//                select x;
//
//            foreach (var item in query.Take(10).ToList())
//            {
//                top10CPUList.Add(item.name);
//            }
//
//            return top10CPUList;
//        }
    }


}