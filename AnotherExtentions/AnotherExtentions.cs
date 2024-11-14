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
  }
}
