using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class PasswordAuthAttribute() : BaseAuth(TokenType.User, TokenPurpose.Password)
{}