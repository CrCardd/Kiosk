using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class UserAuthAttribute() : BaseAuth(TokenType.User, TokenPurpose.Access)
{}