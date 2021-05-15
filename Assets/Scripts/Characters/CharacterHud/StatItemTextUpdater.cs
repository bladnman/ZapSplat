using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatItemTextUpdater : MonoBehaviour {

  [Tooltip("Required : Driving Stat")]
  [SerializeField] protected StatItem stat;
  [SerializeField] TMP_Text label;

  void Start() {
    if (stat) {
      stat.onUpdated += HandleStatUpdate;
    }
    UpdateText();
  }
  private void OnDestroy() {
    if (stat) {
      stat.onUpdated -= HandleStatUpdate;
    }
  }
  private void HandleStatUpdate() {
    UpdateText();
  }

  private void UpdateText() {
    if (!IsActive()) return;
    label.text = $"{stat?.GetValue()}";
  }
  bool IsActive() {
    return label != null && stat != null;
  }
}
