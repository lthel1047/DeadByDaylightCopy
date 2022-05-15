using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togleButton : MonoBehaviour {
    public GameObject setPanel;
    public GameObject Canvers;
    DissolveCharacter dissolve;

    private bool isActive;
    private void Start()
    {
        dissolve = GetComponent<DissolveCharacter>();
    }

    public void Panel()
    {
        if (setPanel.activeSelf)
        {
            if (!IsEscPlay)
                StartCoroutine("EscPlay");
        }
        else
        {
            if (!IsPlaySelect)
                StartCoroutine("PlaySelect");
        }

    }


    bool IsPlaySelect = false;
    IEnumerator PlaySelect()
    {
        IsPlaySelect = true;
        yield return dissolve.StartCoroutine("SelectPlay");

        if (Canvers != null)
        {
            isActive = Canvers.activeSelf;

            Canvers.SetActive(!isActive);
        }

        if (setPanel != null)
        {
            isActive = setPanel.activeSelf;

            setPanel.SetActive(!isActive);

        }

        IsPlaySelect = false;
    }

    bool IsEscPlay = false;
    IEnumerator EscPlay()
    {
        IsEscPlay = true;

        yield return dissolve.StartCoroutine("CancelPlay");
        if (setPanel != null)
        {
            isActive = setPanel.activeSelf;

            setPanel.SetActive(!isActive);

        }

        if (Canvers != null)
        {
            isActive = Canvers.activeSelf;

            Canvers.SetActive(!isActive);
        }
        IsEscPlay = false;
    }
}
