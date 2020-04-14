using System.Threading.Tasks;

namespace ToDo.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
