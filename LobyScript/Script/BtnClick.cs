using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour {

	public GameObject Manager;

	public Text on;
	public Text off;

	public GameObject ViewPanel;

	void Start ()
	{
		
	}
	
	void Update ()
	{
	}

	public void OnClick()
	{
		Manager.SendMessage("ClickButton", gameObject.name);
	}
	

	void TextOn()
	{
		ViewPanel.gameObject.SetActive(true);
		on.gameObject.SetActive(true);
		off.gameObject.SetActive(false);
	}

	void TextOff()
	{
		ViewPanel.gameObject.SetActive(false);
		on.gameObject.SetActive(false);
		off.gameObject.SetActive(true);
	}

	//controll option panel Only
	public void ChangeView(GameObject g)
	{
		ViewPanel.gameObject.SetActive(false);
		ViewPanel = g;
		ViewPanel.gameObject.SetActive(true);
	}
}
