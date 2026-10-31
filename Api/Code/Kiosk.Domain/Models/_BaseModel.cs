
namespace Kiosk.Domain.Models;

public class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DisabledAt { get; set; } = null;
}

public class BaseModelWithSegment : BaseModel
{
    public Guid SegmentId { get; set; }
    public SegmentModel Segment { get; set; } = null!;
}

public class BaseModelWithOrganization : BaseModel
{
    public Guid OrganizationId { get; set; }
    public OrganizationModel Organization { get; set; } = null!;
}