using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnScreen : MonoBehaviour {
  [SerializeField] float margin = 0f;
  Vector2 screenBounds;
  float xMin, xMax;
  float yMin, yMax;

  void Start() {
    // 0,0 in center of camera, so will have to double these values
    var cameraTopRightRect = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    var objectWidthHalf = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    var objectHeightHalf = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    xMin = -1 * cameraTopRightRect.x + objectWidthHalf + margin;
    xMax = cameraTopRightRect.x - objectWidthHalf - margin;
    yMin = -1 * cameraTopRightRect.y + objectHeightHalf + margin;
    yMax = cameraTopRightRect.y - objectHeightHalf - margin;
  }
  void LateUpdate() {
    var pos = transform.position;
    // within screen - bail
    if (pos.x >= xMin && pos.x <= xMax &&
        pos.y >= yMin && pos.y <= yMax) return;

    pos.x = Mathf.Clamp(pos.x, xMin, xMax);
    pos.y = Mathf.Clamp(pos.y, yMin, yMax);

    transform.position = pos;
  }
}
