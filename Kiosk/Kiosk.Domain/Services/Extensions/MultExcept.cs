namespace Kiosk.Domain.Services.Extensions;

public static class MultExceptExtension
{
    public static IEnumerable<T> MultExcept<T>(this IEnumerable<T> a, IEnumerable<T> b)
    {
        var groupB = b.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var list = new List<T>();

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