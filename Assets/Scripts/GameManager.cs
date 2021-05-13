using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  void Start() {
    Collectible.OnCollected += HandleCollectibleCollected;
    Exit.OnExit += HandleExit;
  }
  private void OnDestroy() {
    Collectible.OnCollected -= HandleCollectibleCollected;
    Exit.OnExit -= HandleExit;
  }
  void HandleCollectibleCollected(Collectible collectible) {
    Debug.Log($"M@ [{GetType()}] {collectible} : collectible");   // M@: 
  }
  void HandleExit(Exit exit, Player player) {
    Debug.Log($"M@ [{GetType()}] {exit}{player} : exit");   // M@: 
  }
}
