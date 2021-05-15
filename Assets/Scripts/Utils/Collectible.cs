using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
  [SerializeField] protected bool IsRemovedAfterCollection = true;

  // override me
  public virtual void DoCollection(GameObject collector) { }
  // override me
  public virtual bool IsCollectableBy(GameObject collector) {
    return collector.TryGetComponent<Player>(out _);
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
