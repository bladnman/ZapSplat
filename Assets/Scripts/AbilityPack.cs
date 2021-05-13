using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPack : MonoBehaviour {


  public event Action ModsUpdated;

  // 
  //  SPEED
  //
  public AbilityMod speedMod = new AbilityMod();

  public void SetSpeedMultiplier(float multiplier, float seconds = 5f) {
    speedMod = new AbilityMod(multiplier, seconds);
    if (ModsUpdated != null) {
      ModsUpdated();
      // M@ make this work... we need a timer to update after seconds
    }
  }
  public float? GetSpeedMultiplier() {
    return speedMod?.GetValue();
  }
  public float? GetSpeedMultiplierExDate() {
    return speedMod.GetExDate();
  }
  public float GetSpeed(float baseSpeed = 0f) {
    var value = GetSpeedMultiplier();
    return value == null ? baseSpeed : baseSpeed * (float)value;
  }


}

public class AbilityMod {
  float? goodUntil;
  float value = 0;

  public AbilityMod() { }
  public AbilityMod(float value, float seconds = 10f) {
    this.goodUntil = Time.time + seconds;
    this.value = value;
  }
  public float? GetValue() {
    if (IsOld()) return null;
    return value;
  }
  public bool IsOld() {
    return goodUntil != null && goodUntil < Time.time;
  }
  public float? GetExDate() {
    return goodUntil;
  }
}
