using System.Data.Entity;
using SmartFormz.Business.Models.Folder;

namespace SmartFormz.Data.Infrastructure
{

    public class SmartFormzContextInitializer : DropCreateDatabaseAlways<SmartFormzContext>
    {
        protected override void Seed(SmartFormzContext context)
        {
            LoadDefaultFolders(context);
        }

        private void LoadDefaultFolders(SmartFormzContext context)
        {
            var rootFolder = new Folder
            {
                FolderId = 1,
                Name = "Root"
            };
            var mainFolder = new Folder
            {
                Name = "Main Forms",
                Parent = rootFolder
            };
            var specialFolder = new Folder
            {
                Name = "Special Forms",
                Parent = rootFolder
            };
            var mainSubFolder = new Folder
            {
                Name = "Main Sub Forms",
                Parent = mainFolder
            };
            var specialSubFolder = new Folder
            {
                Name = "Special Sub Forms",
                Parent = specialFolder
            };

            context.Folder.Add(mainSubFolder);
            context.Folder.Add(specialSubFolder);
        }
    }
}
