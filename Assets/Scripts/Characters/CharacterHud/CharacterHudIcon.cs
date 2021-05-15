using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHudIcon : MonoBehaviour {

  [Tooltip("Required : Driving Stat")]
  [SerializeField] protected StatItem stat;

  [Header("Tuning")]
  [SerializeField] float blinkForSec = 3f;
  [SerializeField] float blinksPerSec = 6f;
  [Range(0, 1f)]
  [SerializeField] float blinkingOpacity = 0.4f;

  [Header("Optional")]
  [Tooltip("Optional : Element to be disabled when inactive. Will auto-map.")]
  [SerializeField] protected GameObject objectWithStats;
  [SerializeField] protected string iconName = "Generic Sock";

  protected Image image;
  float startingImageAlpha = 1f;

  void Start() {
    MapObjectWithStats();
    MapVisualComponent();

    if (stat) {
      stat.onUpdated += HandleStatUpdate;
    }

    UpdateIcon();
  }
  private void OnDestroy() {
    if (stat) {
      stat.onUpdated -= HandleStatUpdate;
    }
  }
  private void HandleStatUpdate() {

    SetMaxExpirationSec(stat.GetMaxExpiration() ?? -1);

    UpdateIcon();
  }
  bool IsActive() {
    return image != null && stat != null;
  }
  private void UpdateIcon() {
    image.enabled = stat?.HasMods() ?? false;
  }
  private void DimImage() {
    if (!IsActive()) return;
    var tempColor = image.color;
    tempColor.a = blinkingOpacity;
    image.color = tempColor;
  }
  private void BrightenImage() {
    if (!IsActive()) return;
    var tempColor = image.color;
    tempColor.a = startingImageAlpha;
    image.color = tempColor;
  }
  protected virtual void MapObjectWithStats() {
    if (objectWithStats == null) {
      var characterAncestor = gameObject.GetComponentInParent(typeof(Character)) as Character;
      objectWithStats = characterAncestor?.gameObject;
    }
  }
  protected virtual void MapVisualComponent() {
    if (image == null) {
      image = GetComponent<Image>();
      if (image != null) {
        startingImageAlpha = image.color.a;
      }
    }
  }

  //
  // BLINK
  //
  float maxExpirationSec = -1;
  Coroutine blinkCoroutine;
  Coroutine preBlinkCoroutine;
  void SetMaxExpirationSec(float seconds) {
    // we already track this one
    if (maxExpirationSec == seconds) return;

    maxExpirationSec = seconds;
    RestartBlink();
  }
  void RestartBlink() {
    ClearBlink();
    UpdateIcon();
    ScheduleBlink();
  }
  void ClearBlink() {
    BrightenImage();

    if (preBlinkCoroutine != null) {
      StopCoroutine(preBlinkCoroutine);
      preBlinkCoroutine = null;
    }
    if (blinkCoroutine != null) {
      StopCoroutine(blinkCoroutine);
      blinkCoroutine = null;
    }
  }
  void ScheduleBlink() {

    if (!IsActive()) return;

    float beforeBlinkSec = maxExpirationSec - Time.time;

    // expired!
    if (beforeBlinkSec < 0) return;

    var waitSec = beforeBlinkSec - blinkForSec;
    preBlinkCoroutine = StartCoroutine(WaitAndBlink(waitSec, blinkForSec));
  }
  IEnumerator WaitAndBlink(float waitSec, float blinkSec) {
    yield return new WaitForSeconds(waitSec);
    blinkCoroutine = StartCoroutine(BlinkForSeconds(blinkSec));
  }
  IEnumerator BlinkForSeconds(float seconds) {
    DimImage();
    float waitUntil = Time.time + seconds;
    while (Time.time < waitUntil) {
      image.enabled = !image.enabled;
      yield return new WaitForSeconds(1 / blinksPerSec);
    }
    BrightenImage();
  }
  IEnumerator BlinkUntilCanceled() {
    DimImage();
    while (true) {
      image.enabled = !image.enabled;
      yield return new WaitForSeconds(1 / blinksPerSec);
    }
  }
}
