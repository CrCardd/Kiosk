using Kiosk.Domain.Common.Enums;

namespace Kiosk.Api.Common.Auth;

public class SegmentAuthAttribute() : BaseAuth(TokenType.Segment, TokenPurpose.Access)
{}