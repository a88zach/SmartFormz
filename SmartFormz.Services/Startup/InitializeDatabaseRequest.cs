using System;
using System.Data.Entity;
using SmartFormz.Business.Exceptions;
using SmartFormz.Data.Infrastructure;

namespace SmartFormz.Services.Startup
{
    public class InitializeDatabaseMessage : IMessage
    {
        
    }
    public class InitializeDatabaseRequest : IRequest<InitializeDatabaseMessage>
    {
        public InitializeDatabaseMessage Message { get; set; }

        public InitializeDatabaseRequest()
        {
            Message = new InitializeDatabaseMessage();
        }

        public void Execute()
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
