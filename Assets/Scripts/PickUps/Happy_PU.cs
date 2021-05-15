using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happy_PU : Collectible {
  [SerializeField] float amount = 2.0f;

  StatItem GetStat(GameObject source) {
    // C H A N G E    M Y    T Y P E
    return MUtil.GetStat<STAT_Happy>(source);
  }

  public override bool IsCollectableBy(GameObject collector) {
    if (!collector.TryGetComponent<Player>(out _)) return false;
    return GetStat(collector) != null;
  }
  public override void DoCollection(GameObject collector) {
    base.DoCollection(collector);
    GetStat(collector)?.AddModValue(amount);
  }
}
