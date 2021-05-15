using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPickup : MonoBehaviour {
  [SerializeField] protected float amount = 1f;
  [SerializeField] protected bool IsRemovedAfterCollection = true;


  public virtual StatItem GetStat(GameObject source) {
    // C H A N G E    M Y    T Y P E
    // DEFINITELY OVERRIDE ME !
    return null;
  }

  public virtual void DoCollection(GameObject collector) {
    // DEFINITELY OVERRIDE ME !
  }

  public virtual bool IsCollectableBy(GameObject collector) {
    // possibly override me ?

    // is a character
    if (!collector.TryGetComponent<Character>(out _)) return false;
    // has our stat
    return GetStat(collector) != null;
  }

  private void OnTriggerEnter2D(Collider2D other) {
    GameObject collector = other.gameObject;
    if (!IsCollectableBy(collector)) return;

    DoCollection(collector);
    if (IsRemovedAfterCollection) {
      Destroy(gameObject);
    }
  }
}
