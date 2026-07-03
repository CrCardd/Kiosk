using Kiosk.Domain.Common.Enums;

namespace Kiosk.Application.Payloads.Provider;

public record CreatePayload
{
    public required string Subject {get;init;}
    public required string Email {get;init;}
    public required string Name {get;init;}
    public required string Picture {get;init;}
    public required ProviderType Type {get;init;}
    public required Guid OrganizationId {get;init;}
}