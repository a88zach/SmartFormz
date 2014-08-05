using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormz.Business.Models.Folder;

namespace SmartFormz.Business.DataInterfaces
{
    public interface IFolderRepository : IRepository<Folder, long>
    {
        ICollection<Folder> GetChildFolders(long parentId);
    }
}
