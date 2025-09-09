using System.Text.RegularExpressions;

namespace AnotherExtentions
{
  public static class AnotherExtentions
  {
    public static V Val<K, V>(this IDictionary<K, V> dic, K key) where V : class
    {
      if (dic.ContainsKey(key))
        return dic[key];

      return null;
    }

    public static V ValOrSet<K, V>(this IDictionary<K, V> dic, K key, Func<V> create) where V : class
    {
      if (!dic.ContainsKey(key))
        dic[key] = create();

      return dic[key];
    }

    public static string Join(this IEnumerable<string> list, string separator)
    {
      return string.Join(separator, list.ToArray());
    }

    public static void ForEach(this int number, Action<int> action)
    {
      for (int i = 0; i < number; i++)
      {
        action(i);
      }
    }

    public static TimeSpan Seconds(this int number)
    {
      return TimeSpan.FromSeconds(number);
    }

    public static TimeSpan Minutes(this int number)
    {
      return TimeSpan.FromMinutes(number);
    }

    public static TimeSpan UntilNow(this DateTime then)
    {
      return DateTime.Now - then;
    }

    public static double PercentOf(this double number, double percent)
    {
      return number * percent / 100.0;
    }

    public static double PercentOf(this int number, double percent)
    {
      return number * percent / 100.0;
    }

    public static double AsPercentOf(this double number, double total)
    {
      return number * 100.0 / total;
    }

    // find regex matches in text
    public static List<Match> RegexMatches(this string text, string pattern)
    {
      return Regex.Matches(text, pattern).ToList();
    }

    public static bool In(this string text, List<string> strs)
    {
      return strs.Contains(text, StringComparer.OrdinalIgnoreCase);
    }
  }
}
