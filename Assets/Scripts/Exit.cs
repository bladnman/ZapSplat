using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
  [SerializeField] ParticleSystem exitFX;

  public static event Action<Exit, Player> OnExit;
  private void OnTriggerEnter2D(Collider2D other) {
    Player player = other.gameObject.GetComponent<Player>();

    // TOUCHED BY PLAYER
    if (player != null) {
      TouchedByPlayer(player, other.transform);
    }

  }
  void TouchedByPlayer(Player player, Transform touchTransform) {
    if (!DoesPassCriteria(player)) {
      Debug.Log($"M@ [{GetType()}] YOU DO NOT MEET CRITERIA FOR THIS EXIT");   // M@: 
      return;
    }

    Debug.Log($"M@ [{GetType()}] touched the exit. nice work");   // M@: 


    if (exitFX != null) {
      var fx = Instantiate(exitFX, touchTransform.position, touchTransform.rotation);
    }
    player.DidExit();

    if (OnExit != null) {
      OnExit(this, player);
    }

  }
  bool DoesPassCriteria(Player player) {
    return true;
  }
}
