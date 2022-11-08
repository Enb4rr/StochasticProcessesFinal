using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Transform hidePos, menuPos;
    public GameObject menu, options, credits;

    private List<GameObject> panelsList;

    private void Awake()
    {
        hidePos = GameObject.Find("HidePos").GetComponent<Transform>();
        menuPos = GameObject.Find("MenuPos").GetComponent<Transform>();

        panelsList = new List<GameObject>(3);
    }

    private void Start()
    {
        panelsList.Add(menu);
        panelsList.Add(options);
        panelsList.Add(credits);
    }

    public void SetOptions()
    {
        TurnOff();
        options.gameObject.SetActive(true);
        options.transform.DOMove(menuPos.transform.position, 0.5f, false);
    }

    public void SetCredits()
    {
        TurnOff();
        credits.gameObject.SetActive(true);
        credits.transform.DOMove(menuPos.transform.position, 0.5f, false);
    }

    public void SetMainMenu()
    {
        TurnOff();
        menu.gameObject.SetActive(true);
        menu.transform.DOMove(menuPos.transform.position, 0.5f, false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void TurnOff()
    {
        HideAll();
    }

    private void HideAll()
    {
        foreach(var panel in panelsList)
        {
            panel.transform.DOMove(hidePos.transform.position, 0.1f, false);
        }
    }
}
