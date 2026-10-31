using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class RegisterAuthAttribute() : BaseAuth(TokenType.User, TokenPurpose.Register)
{}