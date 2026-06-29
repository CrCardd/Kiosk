# if ($args.Count -le 0){$baseUrl = "./"}
# else{$baseUrl = $args}

dotnet ef migrations add $args --project "./Kiosk.Infrastructure" --startup-project "./Kiosk.Api"