using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAfterExit : MonoBehaviour {
  Vector3 startPosition;
  Player player;

  void Start() {
    startPosition = FindObjectOfType<Player>().transform.position;
    Exit.OnExit += HandleExit;
  }
  private void OnDestroy() {
    Exit.OnExit -= HandleExit;
  }
  void HandleExit(Exit exit, Player player) {
    this.player = player;
    Invoke(nameof(Respawn), 1.0f);
  }
  void Respawn() {
    player.transform.position = startPosition;
    player.gameObject.SetActive(true);
  }
}
