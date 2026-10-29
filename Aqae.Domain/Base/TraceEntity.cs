
namespace Aqar.Domain.Base
{
    public abstract class TraceEntity
    {
    public int? CreatedBy { get; set; }  
    public DateTime CreatedAt { get; set; }  
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    }
}
