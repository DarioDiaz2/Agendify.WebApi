using Agendify.Abstactions;

namespace Agendify.Abstaction
{
    public interface IDbContext<T> : IDbOperation<T> where T : class
    {

    }
}
