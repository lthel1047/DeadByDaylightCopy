# DeadByDaylightCopy

* #### UI를 채우는 코드이다.  
* ##### 어렵지 않은 코드이지만 이 코드를 생각해내서 만들었을땐 스스로 생각해내 만든 것에 만족 했다.
* ##### 사용 할 때는 아웃라인을 4분할을 하여 모두 적용시키며 모두 움직이는 방향이 달라야 한다.
* ##### 좌,우, 위, 아래가 중심에서 시작해 바깥으로 나가며 채우며 커서를 치웠을땐 다시 0으로 초기화되며 UI는 꺼진다.

'''

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

---
