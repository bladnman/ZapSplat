using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatValuePickup : StatPickup {
  public override void DoCollection(GameObject collector) {
    GetStat(collector)?.Increment(amount);
  }
}
