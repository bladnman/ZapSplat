using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] float speed = 10f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    var xDelta = 0f;
    var yDelta = 0f;
    if (Input.GetAxis("Horizontal") != Mathf.Epsilon)
    {
      xDelta = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }
    if (Input.GetAxis("Vertical") != Mathf.Epsilon)
    {
      yDelta = Input.GetAxis("Vertical") * speed * Time.deltaTime;
    }

    if (xDelta != 0 || yDelta != 0)
    {
      transform.position = new Vector3(
        transform.position.x + xDelta,
        transform.position.y + yDelta,
        transform.position.z);

      if (xDelta > 0.0 && transform.localScale.x > 0 ||
          xDelta < 0.0 && transform.localScale.x < 0)
      {
        var curScale = transform.localScale;
        transform.localScale = new Vector3(curScale.x * -1, curScale.y, curScale.z);
      }
    }

  }
}
