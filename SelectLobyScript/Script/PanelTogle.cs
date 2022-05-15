using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTogle : MonoBehaviour {

    public GameObject panel1 = null;
    public GameObject panel2 = null;
    public GameObject panel3 = null;
    public void OnClick()
    {
        if (panel1 != null)
        {
            panel3.SetActive(false);
            panel2.SetActive(false);
            panel1.SetActive(true);
        }else if (panel2 != null)
        {
            panel3.SetActive(false);
            panel2.SetActive(true);
            panel1.SetActive(false);
        }
        else if (panel3 != null)
        {
            panel3.SetActive(true);
            panel2.SetActive(false);
            panel1.SetActive(false);
        }
    }

 
}
