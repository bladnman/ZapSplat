using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHudIcon : MonoBehaviour {
  [SerializeField] GameObject character;
  StatItem stat;
  void Start() {
    var parent = gameObject.GetComponentInParent(typeof(Character)) as Character;
    character = parent?.gameObject;
    stat = GetStat();
    if (stat) {
      stat.onUpdated += HandleStatUpdate;
    }
  }
  private void OnDestroy() {
    if (stat) {
      stat.onUpdated -= HandleStatUpdate;
    }
  }
  private void HandleStatUpdate() {
    UpdateIcon();
  }
  private void UpdateIcon() {
    // gameObject.SetActive(!gameObject.activeSelf);
    gameObject.SetActive(stat.HasMods());
  }



  //
  // OVERRIDES
  //
  protected virtual StatItem GetStat() {
    return MUtil.GetStat<STAT_MoveSpeed>(character);
  }

}
