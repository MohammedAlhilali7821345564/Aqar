
namespace Aqar.Application.DTOs.Common
{
    public class AttachmentDto
    {
        public string EntityType { get; set; } = null!;

        public int EntityId { get; set; }

        public string FileName { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public string? ContentType { get; set; }
    }
}
