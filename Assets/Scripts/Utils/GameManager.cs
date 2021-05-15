using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  void Start() {
    Exit.OnExit += HandleExit;
  }
  private void OnDestroy() {
    Exit.OnExit -= HandleExit;
  }
  void HandleExit(Exit exit, Player player) {
    Debug.Log($"M@ [{GetType()}] {exit}{player} : exit");   // M@: 
  }
}
