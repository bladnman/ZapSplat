using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyExit : Exit {

  [SerializeField] float requiredAmount = 0f;

  protected override bool DoesPassCriteria(Player player) {
    if (!MUtil.TryGetStat<STAT_Happy>(player.gameObject, out StatItem stat)) return false;

    return stat.GetValue() > requiredAmount;
  }

}
