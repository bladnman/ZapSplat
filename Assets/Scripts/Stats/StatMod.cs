using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMod {
  public float value = 0;
  public float? expirationSec;
  public StatMod(float value) {
    this.value = value;
  }
  public StatMod(float value, float seconds) {
    this.value = value;
    expirationSec = Time.time + seconds;
  }
}
