using System.Threading.Tasks;

namespace ProgrammingLog.Models
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}