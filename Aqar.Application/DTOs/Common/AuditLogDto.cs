
namespace Aqar.Application.DTOs.Common
{
    public class AuditLogDto
    {
        public long AuditId { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; } = null!;
        public string EntityType { get; set; } = null!;
        public string? EntityId { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? IpAddress { get; set; }
    }
}
