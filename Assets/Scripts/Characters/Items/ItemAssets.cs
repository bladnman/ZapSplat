using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// This script will be attached to an empty
// gameObject that links in all the sprites
// https://youtu.be/2WnAOV7nHW0?t=543
//

public class ItemAssets : MonoBehaviour {

  public static ItemAssets Instance { get; private set; }
  private void Awake() {
    Instance = this;
  }

  [SerializeField] public Sprite keyBlue;
  [SerializeField] public Sprite keyRed;
  [SerializeField] public Sprite keyYellow;
  [SerializeField] public Sprite keyGreen;
}
