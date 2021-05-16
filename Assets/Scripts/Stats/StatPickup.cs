using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPickup : Collectible {
  [SerializeField] protected float amount = 1f;
  public virtual StatItem GetStat(GameObject source) {
    // C H A N G E    M Y    T Y P E
    // DEFINITELY OVERRIDE ME !
    return null;
  }

  public override bool IsCollectableBy(GameObject collector) {
    // is a character
    if (!collector.TryGetComponent<Character>(out _)) return false;

    // has our stat
    return GetStat(collector) != null;
  }
}
