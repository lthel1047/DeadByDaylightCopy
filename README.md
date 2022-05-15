# DeadByDaylightCopy

'''
  cs
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
  '''
