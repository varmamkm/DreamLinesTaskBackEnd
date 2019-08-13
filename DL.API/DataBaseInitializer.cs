using DL.DataAccess;
using DL.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL.API
{
    public class DataBaseInitializer : IDataBaseInitializer
    {
        private DataContext context;
        public DataBaseInitializer(DataContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            using (context)
            {
                context.Database.Migrate();
            }
        }
    }
}
