if ($args.Count -le 0){$baseUrl = "./"}
else{$baseUrl = $args}

dotnet ef database update $args --project $baseUrl/Kiosk.Infrastructure --startup-project $baseUrl/Kiosk.Api