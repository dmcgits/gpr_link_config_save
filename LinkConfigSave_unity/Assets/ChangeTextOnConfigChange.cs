using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextOnConfigChange : MonoBehaviour {

	// Use this for initialization
  public void ApplyAdventurerConfig( AdventurerConfig config)
  {
    // apply it 
    Debug.Log("name text field heard about change: " + config.name);
  }
}
