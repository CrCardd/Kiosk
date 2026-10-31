using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class OrganizationAuthAttribute() : BaseAuth(TokenType.Organization, TokenPurpose.Access)
{}