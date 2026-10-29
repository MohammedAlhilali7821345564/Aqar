
namespace Aqar.Domain.Common;

public partial class Attachment
{//مرفقات متعددة الأغراض ترتبط بأي entity عبر (entity_type + entity_id) — تصميم polymorphic.
    public long AttachmentId { get; set; }

    public string EntityType { get; set; } = null!;

    public int EntityId { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? ContentType { get; set; }

    public long? FileSize { get; set; }

    public int? UploadedBy { get; set; }

    public DateTime UploadedAt { get; set; }

    public virtual User? UploadedByNavigation { get; set; }
}