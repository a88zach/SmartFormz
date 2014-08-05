using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Folder;

namespace SmartFormz.Data.Repositories
{
    public class FolderRepository : BaseRepository<Folder, long>, IFolderRepository
    {
        public ICollection<Folder> GetChildFolders(long parentId)
        {
            return DbContext.Folder.Where(x => x.ParentId == parentId).ToList();
        }
    }
}
