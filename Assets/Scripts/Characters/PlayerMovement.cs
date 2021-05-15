using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(STAT_MoveSpeed))]
public class PlayerMovement : MonoBehaviour {

  float GetSpeed() {
    return moveSpeedStat.Value;
  }

  StatItem moveSpeedStat;

  private void Start() {
    moveSpeedStat = MUtil.GetStat<STAT_MoveSpeed>(gameObject);
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
