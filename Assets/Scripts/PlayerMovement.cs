using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbilityPack))]
public class PlayerMovement : MonoBehaviour {
  [SerializeField] float speed = 10f;
  public float GetSpeed() { return pack.GetSpeed(speed); }

  AbilityPack pack;

  private void Start() {
    pack = GetComponent<AbilityPack>();
  }

  void Update() {
    var xDelta = 0f;
    var yDelta = 0f;
    if (Input.GetAxis("Horizontal") != Mathf.Epsilon) {
      xDelta = Input.GetAxis("Horizontal") * GetSpeed() * Time.deltaTime;
    }
    if (Input.GetAxis("Vertical") != Mathf.Epsilon) {
      yDelta = Input.GetAxis("Vertical") * GetSpeed() * Time.deltaTime;
    }

    if (xDelta != 0 || yDelta != 0) {
      transform.position = new Vector3(
        transform.position.x + xDelta,
        transform.position.y + yDelta,
        transform.position.z);

      if (xDelta > 0.0 && transform.localScale.x > 0 ||
          xDelta < 0.0 && transform.localScale.x < 0) {
        var curScale = transform.localScale;
        transform.localScale = new Vector3(curScale.x * -1, curScale.y, curScale.z);
      }
    }
  }
}
