using System.Data.Entity;
using SmartFormz.Business.Models.Folder;

namespace SmartFormz.Data.Infrastructure
{

    public class SmartFormzContextInitializer : DropCreateDatabaseAlways<SmartFormzContext>
    {
        protected override void Seed(SmartFormzContext context)
        {
            context.Folder.Add(new Folder
            {
                FolderId = 1,
                Name = "Root"
            });
        }
    }
}
