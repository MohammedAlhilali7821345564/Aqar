
namespace Aqar.Domain.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}

