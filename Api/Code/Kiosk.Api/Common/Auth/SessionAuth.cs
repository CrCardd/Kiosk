using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class SessionAuthAttribute() : BaseAuth(TokenType.Session, TokenPurpose.Access)
{}