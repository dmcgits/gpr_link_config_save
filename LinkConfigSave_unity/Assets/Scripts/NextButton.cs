using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextButton : MonoBehaviour {

	public static event Action OnNextRequested = delegate {};

	private void OnMouseUpAsButton() {
		OnNextRequested();
	}
}
