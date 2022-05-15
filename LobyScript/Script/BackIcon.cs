using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackIcon : MonoBehaviour {

	public GameObject manager;
	public GameObject panel;
	public Image line;
	public Text text;
	Image btn;

	void Start ()
	{
		line.fillAmount = 0;
		btn = GetComponent<Image>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) OnClick();
	}

	public void OnClick()
	{
		StopAllCoroutines();
		manager.SendMessage("PanelClose");
		btn.color -= new Color(0, 0, 0, 100);
		text.color -= new Color(0, 0, 0, 100);
		line.fillAmount = 0f;
		panel.SetActive(false);
	}

	public void OnMouseEnter()
	{
		StopCoroutine("UnFillRect");
		btn.color += new Color(0, 0, 0, 100);
		text.color += new Color(0, 0, 0, 100);
		StartCoroutine("FillRect");
	}

	public void OnMouseExit()
	{
		StopCoroutine("FillRect");
		btn.color -= new Color(0, 0, 0, 100);
		text.color -= new Color(0, 0, 0, 100);
		StartCoroutine("UnFillRect");
	}

	IEnumerator UnFillRect()
	{
		while (true)
		{
			line.fillAmount -= 0.01f;
			if (line.fillAmount <= 0) break;
			yield return null;
		}

		StopCoroutine("UnFillRect");
	}

	IEnumerator FillRect()
	{
		while(true)
		{
			line.fillAmount += 0.01f;
			if (line.fillAmount >= 1f) break;
			yield return null;
		}

		StopCoroutine("FillRect");
	}
}
