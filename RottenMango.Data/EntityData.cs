using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace RottenMango.Data
{
    public class EntityData<T> where T : class, new()
    {
        #region Context

        private static void PrintSQL(string sql)
        {
            Debug.WriteLine(sql);
        }

        protected RottenMangoEntities CreateContext()
        {
            var context = new RottenMangoEntities();
            context.Database.Log = PrintSQL;
            
            context.Configuration.ProxyCreationEnabled = false;

            return context;
        }

        #endregion
    }
}