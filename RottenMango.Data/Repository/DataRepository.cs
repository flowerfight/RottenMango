using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottenMango.Data.Repository
{
    public class DataRepository
    {
        #region DailySummary
        private static DailySummary _dailySummary;

        public static DailySummary DailySummary
        {
            get
            {
                if (_dailySummary == null)
                    _dailySummary = new DailySummary();

                return _dailySummary;
            }
        }
        #endregion

        #region ProcessSnapShotData
        private static ProcessSnapshot _processSnapshot;

        public static ProcessSnapshot ProcessSnapshot
        {
            get
            {
                if (_processSnapshot == null)
                    _processSnapshot = new ProcessSnapshot();

                return _processSnapshot;
            }
        }
        #endregion
    }
}
