using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
	GameObject[] ui;

	private void Awake()
	{
		ui = GameObject.FindGameObjectsWithTag("LobbyUI");
	}

	void Start ()
	{

	}
	
	void Update ()
	{
	}

	public void PanelOn()
	{
		foreach(GameObject i in ui)
		{
			i.GetComponent<MouseOverCheck>().SelectPanel();
		}
	}

	public void PanelClose()
	{
		foreach (GameObject i in ui)
		{
			i.SendMessage("ClosePanel");
		}
	}
}

