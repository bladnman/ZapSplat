using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  void Start() {
    Collectible.OnCollected += HandleCollectibleCollected;
  }
  private void OnDestroy() {
    Collectible.OnCollected -= HandleCollectibleCollected;
  }
  void HandleCollectibleCollected(Collectible collectible) {
    Debug.Log($"M@ [{GetType()}] {collectible} : collectible");   // M@: 
  }
}
