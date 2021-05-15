using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

  [SerializeField] ParticleSystem exitFX;

  public static event Action<Exit, Player> OnExit;


  protected virtual bool DoesPassCriteria(Player player) {
    return true;
  }

  protected virtual void TouchedByPlayer(Player player, Transform touchTransform) {
    if (!DoesPassCriteria(player)) {
      Debug.Log($"M@ [{GetType()}] YOU DO NOT MEET CRITERIA FOR THIS EXIT");   // M@: 
      return;
    }

    if (exitFX != null) {
      var fx = Instantiate(exitFX, touchTransform.position, touchTransform.rotation);
    }
    player.DidExit();

    if (OnExit != null) {
      OnExit(this, player);
    }
  }

  protected virtual void OnTriggerEnter2D(Collider2D other) {
    if (!other.gameObject.TryGetComponent<Player>(out Player player)) return;
    TouchedByPlayer(player, other.transform);
  }
}
