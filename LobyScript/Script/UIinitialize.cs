using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinitialize : MonoBehaviour {


	RectTransform rtf;

	float x;
	float y;

	void Start ()
	{
		rtf = GetComponent<RectTransform>();
		y = Screen.height / 10f;
		x = Screen.width / 6f;

		rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
		rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);

	}
	
	void Update ()
	{
	}
}
