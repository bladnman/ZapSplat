using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

  public Inventory inventory;

  private void Awake() {
    inventory = new Inventory();
  }

  public void DidExit() {
    gameObject.SetActive(false);
  }
  public void DidRespawn() { }
}
