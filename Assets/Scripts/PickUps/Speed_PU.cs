using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_PU : Collectible {
  [SerializeField] float amount = 2.0f;

  StatItem GetStat(GameObject source) {
    return MUtil.GetStat<STAT_MoveSpeed>(source);
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
