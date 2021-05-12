using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySpitter : MonoBehaviour {
  [SerializeField] GameObject beam;
  [SerializeField] float beamDelay = 3f;
  [SerializeField] float duration = 1f;

  float nextToggle;

  void Start() {
    SetNextToggleTime();
  }
  void Toggle() {
    beam.SetActive(!beam.activeSelf);
    SetNextToggleTime();
  }
  void SetNextToggleTime() {
    nextToggle = beam.activeSelf ? Time.time + duration : Time.time + beamDelay;
  }

  // Update is called once per frame
  void Update() {
    if (Time.time >= nextToggle) Toggle();
  }
}
