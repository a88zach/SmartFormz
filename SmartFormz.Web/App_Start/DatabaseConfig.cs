using System;
using System.Data.Entity;
using SmartFormz.Business.Exceptions;
using SmartFormz.Data.Infrastructure;

namespace SmartFormz.Web
{
    public class DatabaseConfig
    {
        public static void InitDb()
        {
            try
            {
                Database.SetInitializer(new SmartFormzContextInitializer());
                var db = new SmartFormzContext();
                db.Database.Initialize(true);

            }
            catch (Exception ex)
            {
                throw new DatabaseNotInitializedException("Could not create or migrate database", ex);
            }
        }
    }
}