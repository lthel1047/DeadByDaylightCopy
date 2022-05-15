using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverCheck : MonoBehaviour {

	public Text centertext;
	public RawImage icon;
	public Text text;
	public Image[] img;
	public float fillsum = 0.005f;
    AudioSource audio;
	Image my;
	
	private void Awake()
	{
        audio = GetComponent<AudioSource>();
		my = GetComponent<Image>();
		centertext.gameObject.SetActive(false);
		if (text.color.a > 100f) text.color = new Color(255, 255, 255, 100);
		if (icon.color.a > 100f) icon.color = new Color(255, 255, 255, 100);
		if (my.color.a > 100f) my.color = new Color(255, 255, 255, 100);
		foreach (Image i in img )
		{
			i.fillAmount = 0;
		}
	}
	
	public void FillBox()
	{
		centertext.gameObject.SetActive(true);
		text.color += new Color(0, 0, 0, 155);
		icon.color += new Color(0, 0, 0, 155);
		StartCoroutine("Fill");
	}

	public void UnFillBox()
	{
		centertext.gameObject.SetActive(false);
		StopCoroutine("Fill");
		text.color -= new Color(0, 0, 0, 155);
		icon.color -= new Color(0, 0, 0, 155);
		foreach (Image i in img)
		{
			i.fillAmount = 0;
		}
	}

	IEnumerator Fill()
	{
		while(true)
		{
			foreach (Image i in img)
			{
				i.fillAmount += fillsum;
			}
			if (img[0].fillAmount == 1) break;
			yield return null;
		}
		StopCoroutine("Fill");
	}

	public void SelectPanel()
	{
		my.color -= new Color(0, 0, 0, 0.1f);
		text.color -= new Color(0, 0, 0, 0.1f);
		icon.color -= new Color(0, 0, 0, 0.1f);
	}

	public void ClosePanel()
	{
		my.color += new Color(0, 0, 0, 0.1f);
		text.color += new Color(0, 0, 0, 0.1f);
		icon.color += new Color(0, 0, 0, 0.1f);
	}
}
