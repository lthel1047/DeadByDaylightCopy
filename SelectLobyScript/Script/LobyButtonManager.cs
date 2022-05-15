using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobyButtonManager : MonoBehaviour {

    public Button[] btn;

    public void ClickButton(string name)
    {
        switch (name)
        {
            case KillerIcon:
                
                break;

            case HelpIcon:
                

                break;

            case EvenIcon:
               
                break;
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < btn.Length; i++)
        {
            if (i == 0)
            {
                btn[i].SendMessage("TextOn");
                continue;
            }
            btn[i].SendMessage("TextOff");
        }
    }
    //기호 상수
    const string KillerIcon = "Killer";
    const string HelpIcon = "Help";
    const string EvenIcon = "Even";
}
