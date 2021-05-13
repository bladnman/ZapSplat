using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_PU : Collectible {
  [SerializeField] float multiplier = 2.0f;

  public override void DoCollection(GameObject collector) {
    base.DoCollection(collector);

    if (!collector.TryGetComponent<AbilityPack>(out var pack)) return;

    pack.SetSpeedMultiplier(multiplier);
  }
}
