if ($args.Count -le 0){$baseUrl = "./"}
else{$baseUrl = $args}

dotnet ef migrations add $args --project "$baseUrl/Kiosk.Infrastructure" --startup-project "$baseUrl/Kiosk.Api"