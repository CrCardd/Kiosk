namespace Kiosk.Domain.Common.Attributes;

public class StringAttribute : Attribute
{
    public string Value { get; }
    public StringAttribute(string value) { Value = value; }
}