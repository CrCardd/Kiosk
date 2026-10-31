using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class KioskAuthAttribute() : BaseAuth(TokenType.Kiosk, TokenPurpose.Access)
{}