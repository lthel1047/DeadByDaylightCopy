using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIcon : MonoBehaviour
{
	public GameObject manager;
	public GameObject panel;

	private void Awake()
	{
		if(panel.activeSelf) panel.SetActive(false);
	}

	void Start ()
	{

	}
	
	void Update ()
	{
		
	}

	public void IconClickEvent()
	{
		manager.SendMessage("PanelOn");
		panel.SetActive(true);
		panel.SendMessage("Initialize");
	}
}
