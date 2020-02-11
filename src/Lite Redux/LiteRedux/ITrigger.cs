using System.Threading.Tasks;

namespace LiteRedux
{
    public interface ITrigger
    {
        Task HandleAsync(object action, IStore store);
        bool ShouldAction(object action);
    }
}
