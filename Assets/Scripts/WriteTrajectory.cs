using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WriteTrajectory : MonoBehaviour
{
    //Managers Stuff

    private GameManager gameManager;
    private MapManager mapManager;

    //Code Stuff

    private GameObject textContainer;
    private TMP_Text trajectoryText;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        mapManager = FindObjectOfType<MapManager>();
        textContainer = GameObject.Find("TrajectoryText");
        trajectoryText = textContainer.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        trajectoryText.text = "  [ " + "0" + " ]  ";
    }

    private void OnEnable()
    {
        gameManager.reset += ResetTrajectory;
        mapManager.OnSaveTrajectory += DrawTrajectory;
    }

    private void OnDisable()
    {
        gameManager.reset -= ResetTrajectory;
        mapManager.OnSaveTrajectory += DrawTrajectory;
    }

    public void DrawTrajectory(int position)
    {
        trajectoryText.text += "  [  " + (position + 1) + " ]  ";
    }

    public void ResetTrajectory()
    {
        trajectoryText.text = "  [ " + "0" + " ]  ";
    }
}
