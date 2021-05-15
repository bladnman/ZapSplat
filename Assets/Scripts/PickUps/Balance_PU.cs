using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance_PU : StatModPickup {
  public override StatItem GetStat(GameObject source) {
    return MUtil.GetStat<STAT_Balance>(source);
  }
}
