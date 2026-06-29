namespace Kiosk.Infrastructure.Services.Extensions;

public static class MultExceptExtension
{
    public static IEnumerable<Guid> MultExcept<Guid>(this IEnumerable<Guid> a, IEnumerable<Guid> b)
    {
        var groupB = b.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var list = new List<Guid>();

        foreach (var ai in a)
        {
            if (groupB.TryGetValue(ai, out var count) && count > 0)
                groupB[ai]--;
            else
                list.Add(ai);
        }
        return list;
    }
}