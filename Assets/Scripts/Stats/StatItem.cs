using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatItem : MonoBehaviour {
  [SerializeField] protected float StartValue;
  [SerializeField] protected float currentValue;

  public event Action onUpdated;

  protected List<StatMod> mods = new List<StatMod>();

  void Start() {
    _value = StartValue;
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
  public void Increment(float value) {
    Value = _value + value;
  }
  public void Decrement(float value) {
    Value = _value - value;
  }
  protected void UpdateValueCache() {
    float modValue = mods.Aggregate(0f, (acc, mod) => acc + mod.value);
    currentValue = _value + modValue;
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

}
