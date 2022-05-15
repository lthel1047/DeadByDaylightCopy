using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionPanelManager : MonoBehaviour
{
	public Button[] btn;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	//어떤 버튼이 클릭 됬는지 확인
	public void ClickButton(string name)
	{
		switch(name)
		{
			case SETTING:
				foreach(Button i in btn)
				{
					if (i.name == name) i.SendMessage("TextOn");
					else i.SendMessage("TextOff");
				}
				break;

			case CONTROLS:
				foreach (Button i in btn)
				{
					if (i.name == name) i.SendMessage("TextOn");
					else i.SendMessage("TextOff");
				}

				break;

			case HELPTUTORIALS:
				foreach (Button i in btn)
				{
					if (i.name == name) i.SendMessage("TextOn");
					else i.SendMessage("TextOff");
				}
				break;
		}
	}

	public void Initialize()
	{
		for(int i=0;i<btn.Length;i++)
		{
			if(i==0)
			{
				btn[i].SendMessage("TextOn");
				continue;
			}
			btn[i].SendMessage("TextOff");
		}
	}
	//기호 상수
	const string SETTING = "SettingBtn";
	const string CONTROLS = "ControlsBtn";
	const string HELPTUTORIALS = "HelpTutorialBtn";
}
