using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatItem : MonoBehaviour {
  [SerializeField] protected float StartValue;

  [Header("Debugging")]
  [SerializeField] protected float currentValue;
  [SerializeField] protected float minExpirationSec = -1;

  public event Action onUpdated;

  protected List<StatMod> mods = new List<StatMod>();

  void Start() {
    _value = StartValue;
    UpdateValueCache();
  }
  private void Update() {
    // no expirations ahead
    if (minExpirationSec == -1) return;

    // nothing expired
    if (minExpirationSec > Time.time) return;

    // something expired
    DealWithExpiredItem();
  }
  void DealWithExpiredItem() {
    PurgeExpiredMods();
    UpdateValueCache();
  }

  //
  // VALUE
  //
  private float _value = 0;
  public float Value {
    get {
      return currentValue;
    }
    set {
      _value = value;
      UpdateValueCache();
    }
  }
  public float GetValue() {
    return Value;
  }
  public void Increment(float value) {
    Value = _value + value;
  }
  public void Decrement(float value) {
    Value = _value - value;
  }
  protected void UpdateValueCache() {
    PurgeExpiredMods();

    float modValue = GetTotalModValue();
    currentValue = _value + modValue;

    minExpirationSec = GetMinExpiration() ?? -1;

    if (onUpdated != null) {
      onUpdated();
    }
  }

  //
  // MODS
  //
  public void AddModValue(float value) {
    this.AddMod(new StatMod(value));
  }
  public void AddModValue(float value, float seconds) {
    this.AddMod(new StatMod(value, seconds));
  }
  public void AddMod(StatMod mod) {
    mods.Add(mod);
    UpdateValueCache();
  }
  public void AddMods(StatMod[] mods) {
    this.mods.AddRange(mods);
    UpdateValueCache();
  }
  public void ClearMods() {
    mods.Clear();
    UpdateValueCache();
  }
  public bool HasMods() {
    return mods.Count > 0;
  }
  void PurgeExpiredMods() {
    mods.RemoveAll(mod => mod.expirationSec != -1 & mod.expirationSec <= Time.time);
  }

  //
  // UTILS
  //
  public float GetTotalModValue() {
    return mods.Aggregate(0f, (acc, mod) => acc + mod.value);
  }
  public float? GetMinExpiration() {
    var expiringMods = mods.Where(mod => mod.expirationSec != null);
    if (expiringMods.Count() < 1) return null;
    return expiringMods.Min(mod => (float)mod.expirationSec);
  }
  public float? GetMaxExpiration() {
    var expiringMods = mods.Where(mod => mod.expirationSec != null);
    if (expiringMods.Count() < 1) return null;
    return expiringMods.Max(mod => (float)mod.expirationSec);
  }

}
