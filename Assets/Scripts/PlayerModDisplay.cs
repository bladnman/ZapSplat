using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModDisplay : MonoBehaviour {
  [SerializeField] Image speedIcon;

  Player player;
  AbilityPack pack;

  void Start() {
    player = GetComponentInParent<Player>();
    pack = GetComponentInParent<AbilityPack>();
    UpdateIcons();
  }
  void UpdateSpeedIcon() {
    bool isModified = pack.GetSpeedMultiplier() != null;
    if (!isModified && speedIcon.enabled) {
      speedIcon.enabled = false;
    } else if (isModified && !speedIcon.enabled) {
      speedIcon.enabled = true;
    }
  }
  void UpdateIcons() {
    UpdateSpeedIcon();
  }
  void Update() {
    UpdateIcons();
  }

  // StartCoroutine(Blink(2.0));

  void Blink(waitTime : float) {
    var endTime = Time.time + waitTime;
    while (Time.time < waitTime) {
      renderer.enabled = false;
      yield WaitForSeconds(0.2);
      renderer.enabled = true;
      yield WaitForSeconds(0.2);
    }
  }
}
