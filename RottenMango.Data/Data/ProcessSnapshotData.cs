using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Linq;


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
                    avgMemory = 0,
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
                    1,
                    1,
                    1,
                    item.avgCPU,
                    _start
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

    }
}