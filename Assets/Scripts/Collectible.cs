using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
  public static event Action<Collectible> OnCollected;
  private void OnTriggerEnter2D(Collider2D other) {

    if (OnCollected != null) {
      OnCollected(this);
    }

    Destroy(gameObject);
  }
}
