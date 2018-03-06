using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLog.Models
{
    public interface IPhotoRepository
    {
         Task<IEnumerable<Photo>> GetPhotosAsync(int taskId);
    }
}