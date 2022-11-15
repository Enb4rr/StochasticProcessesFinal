using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WriteMatrix : MonoBehaviour
{
    //Managers Stuff

    private GameManager gameManager;
    private MapManager mapManager;

    //Code Stuff

    private GameObject textContainer;
    private TMP_Text matrixText;

    public bool goodLuck, badLuck, normalLuck;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        mapManager = FindObjectOfType<MapManager>();
        textContainer = GameObject.Find("MatrixText");
        matrixText = textContainer.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        int selectedLuck = PlayerPrefs.GetInt("selectedLuck");

        if(selectedLuck == 1)
        {
            goodLuck = true;
            badLuck = false;
            normalLuck = false;
        }
        else if(selectedLuck == 2)
        {
            goodLuck = false;
            badLuck = true;
            normalLuck = false;
        }
        else if(selectedLuck == 3)
        {
            goodLuck = false;
            badLuck = false;
            normalLuck = true;
        }

        if (goodLuck)
        {
            matrixText.text = "{ 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 }";
        }
        else if (normalLuck)
        {
            matrixText.text = "{ 0 , 0.16 , 0.16 , 0.16, 0.16 , 0.16 , 0.16 , 0 , 0 , 0 }";
        }
        else if (badLuck)
        {
            matrixText.text = "{ 0 , 0.16 , 0.16 , 0.16, 0.16 , 0.16 , 0.16 , 0 , 0 , 0 }";
        }
    }

    private void OnEnable()
    {
        gameManager.reset += ResetMatrix;
        mapManager.OnSaveTrajectory += DrawMatrix;
    }

    private void OnDisable()
    {
        gameManager.reset -= ResetMatrix;
        mapManager.OnSaveTrajectory += DrawMatrix;
    }

    public void DrawMatrix(int position)
    {
        matrixText.text += "  [  " + (position + 1) + " ]  ";

        if (goodLuck)
        {
            switch (position + 1)
            {
                case 1:
                    matrixText.text = "{ 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 }"; 
                    break;

                case 2:
                    matrixText.text = "{ 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 }";
                    break;

                case 3:
                    matrixText.text = "{ 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 }"; 
                    break;

                case 4:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 }";
                    break;

                case 5:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 }";
                    break;

                case 6:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0.32 , 0.16 , 0.16 , 0.16 , 0.16 }";
                    break;

                case 7:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0.48 , 0.16 , 0.16 , 0.16 }";
                    break;
                case 8:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0.64 , 0.16 , 0.16 }";
                    break;

                case 9:
                    matrixText.text = "{ 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 }";
                    break;

                case 10:
                    matrixText.text = "{ 1 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 1 }";
                    break;
            }
        }
        else if (normalLuck)
        {
            switch (position + 1)
            {
                case 1:
                    matrixText.text = "{ 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0 , 0 , 0 }";
                    break;

                case 2:
                    matrixText.text = "{ 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0 , 0 }";
                    break;

                case 3:
                    matrixText.text = "{ 0 , 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0 }";
                    break;

                case 4:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 }";
                    break;

                case 5:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 }";
                    break;

                case 6:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0.32 , 0.16 , 0.16 , 0.16 , 0.16 }";
                    break;

                case 7:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0.48 , 0.16 , 0.16 , 0.16 }";
                    break;
                case 8:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0.64 , 0.16 , 0.16 }";
                    break;

                case 9:
                    matrixText.text = "{ 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 }";
                    break;

                case 10:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 }";
                    break;
        }
    }
        else if (badLuck)
        {
            switch (position + 1)
            {
                case 1:
                    matrixText.text = "{ 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0 , 0 , 0 }";
                    break;

                case 2:
                    matrixText.text = "{ 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0 , 0 }";
                    break;

                case 3:
                    matrixText.text = "{ 0 , 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0 }";
                    break;

                case 4:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 }";
                    break;

                case 5:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 , 0.16 }";
                    break;

                case 6:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 }";
                    break;

                case 7:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 }";
                    break;

                case 8:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0 }";
                    break;

                case 9:
                    matrixText.text = "{ 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 }";
                    break;

                case 10:
                    matrixText.text = "{ 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 }";
                    break;
            }
        }
    }

    public void ResetMatrix()
    {
        if (goodLuck)
        {
            matrixText.text = "{ 0 , 0 , 0 , 1 , 0 , 0 , 0 , 0 , 0 , 0 }";
        }
        else if (normalLuck)
        {
            matrixText.text = "{ 0 , 0.16 , 0.16 , 0.16, 0.16 , 0.16 , 0.16 , 0 , 0 , 0 }";
        }
        else if (badLuck)
        {
            matrixText.text = "{ 0 , 0.16 , 0.16 , 0.16, 0.16 , 0.16 , 0.16 , 0 , 0 , 0 }";
        }
    }
}
