using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextFieldChangeEventThrower : MonoBehaviour {

  public static event Action<string> OnTextFieldChanged = delegate { };

  [SerializeField]
  protected string fieldId = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
