using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
  public static event Action<Collectible> OnCollected;

  public virtual bool IsCollectableBy(GameObject collector) {
    return collector.TryGetComponent<Player>(out _);
  }
  public virtual void DoCollection(GameObject collector) {
    if (OnCollected != null) {
      OnCollected(this);
    }
    Destroy(gameObject);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    GameObject collector = other.gameObject;
    if (!IsCollectableBy(collector)) return;
    DoCollection(collector);
  }
}
