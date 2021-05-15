
using UnityEngine;

public class MUtil {
  public static StatItem GetStat<T>(GameObject sourceObject)
    where T : StatItem {
    if (sourceObject == null) return null;
    return (StatItem)sourceObject.GetComponent<T>();
  }
  public static bool TryGetStat<T>(GameObject sourceObject, out StatItem stat)
    where T : StatItem {
    if (sourceObject == null) {
      stat = null;
      return false;
    }
    stat = GetStat<T>(sourceObject);
    return stat != null;
  }
}
