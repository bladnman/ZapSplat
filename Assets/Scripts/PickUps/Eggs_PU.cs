using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs_PU : StatValuePickup {
  public override StatItem GetStat(GameObject source) {
    return MUtil.GetStat<STAT_Eggs>(source);
  }
}
