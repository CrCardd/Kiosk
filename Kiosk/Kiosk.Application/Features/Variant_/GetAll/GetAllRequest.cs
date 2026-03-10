using System.ComponentModel.DataAnnotations;

namespace Kiosk.Application.Features.Variant_.GetAll;

public record GetAllRequest(
    bool? Available = null
);
