using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject ga = null;
    public GameObject panel = null;
    // Use this for initialization
    public void OnClick()
    {
        if (ga != null)
        {
            ga.SetActive(true);
            
        }
        if (panel != null)
            panel.SetActive(false);

    }
}
