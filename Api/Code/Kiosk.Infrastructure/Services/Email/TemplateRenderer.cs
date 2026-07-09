namespace Kiosk.Infrastructure.Services.Email;

public static class TemplateRenderer
{
    public static string Render(string template, Dictionary<string, string> values)
    {
        foreach (var value in values)
        {
            template = template.Replace(
                $"{{{{{value.Key}}}}}",
                value.Value
            );
        }

        return template;
    }
}