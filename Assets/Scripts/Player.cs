using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


  public void DidExit() {
    Debug.Log($"M@ [{GetType()}] I Exited!");   // M@: 
    gameObject.SetActive(false);
  }
  public void DidRespawn() {
    Debug.Log($"M@ [{GetType()}] Good to be back!");   // M@: 
  }

}
