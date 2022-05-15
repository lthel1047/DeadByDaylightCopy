using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsViewChange : MonoBehaviour {

	public GameObject btn;

	public GameObject suvivor;
	public GameObject killer;

	void Start ()
	{
		
	}
	
	void Update () {
		
	}

	public void OnClick()
	{
		if(suvivor.activeSelf)
		{
			btn.SendMessage("ChangeView", killer);
		}
		else
			btn.SendMessage("ChangeView", suvivor);
	}
}
