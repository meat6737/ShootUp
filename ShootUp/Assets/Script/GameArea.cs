using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour {
  
    private void OnMouseEnter()
    {
        GameControl.Instance.Hold();
        
    }
    private void OnMouseExit()
    {
        GameControl.Instance.Restore();       
    }
}
