using System;
using System.Collections.Generic;
using System.Linq;

namespace RottenMango.Data
{
    public class ProcessSnapshotData : EntityData<ProcessSnapshot>
    {
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

        public void Insert( string name, int usingCpu, int usingMemory, DateTime date)
        {
            CreateContext().ProcessSnapshots.Add(
                new ProcessSnapshot()
                {
                    ProcSId = 0,
                    name = name,
                    usingCpu = usingCpu,
                    usingMemory = usingMemory,                   
                    recordTime = date
                }
            );

        }

    }
}