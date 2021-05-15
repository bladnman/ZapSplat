using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModPickup : StatPickup {
  [SerializeField] protected float durationSeconds = 10f;

  public override void DoCollection(GameObject collector) {
    if (durationSeconds > 0) {
      GetStat(collector)?.AddModValue(amount, durationSeconds);
    } else {
      GetStat(collector)?.AddModValue(amount);
    }
  }
}
