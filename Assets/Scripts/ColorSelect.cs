using UnityEngine;
using System.Collections;

// This controls the GUI used for the color selecting.
public class ColorSelect : MonoBehaviour {

	public float rotateZAmount;			//How much will the wheel rotate?

	// Rotates the wheel so that the selected color is at the top while the comp color of that is at the bottom.
	public void RotateWheel()
	{
		if(Mathf.Abs(gameObject.transform.GetChild(0).transform.rotation.z + rotateZAmount) >= 360f)
			gameObject.transform.GetChild(0).transform.Rotate(0,0,0);
		else
			gameObject.transform.GetChild(0).transform.Rotate(0,0,rotateZAmount);
	}
}
