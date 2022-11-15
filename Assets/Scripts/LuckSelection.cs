using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LuckSelection : MonoBehaviour
{
    [SerializeField]
    Button goodLuckB, badLuckB, normalLuckB;

    public int selectedLuck = 3;
    public void OnPressedGoodLuck()
    {
        TMP_Text text1 = badLuckB.GetComponentInChildren<TMP_Text>();
        TMP_Text text2 = normalLuckB.GetComponentInChildren<TMP_Text>();
        TMP_Text text3 = goodLuckB.GetComponentInChildren<TMP_Text>();

        text1.color = Color.gray;
        text2.color = Color.gray;
        text3.color = Color.black;

        selectedLuck = 1;
        PlayerPrefs.SetInt("selectedLuck", selectedLuck);
    }

    public void OnPressedBackLuck()
    {
        TMP_Text text1 = goodLuckB.GetComponentInChildren<TMP_Text>();
        TMP_Text text2 = normalLuckB.GetComponentInChildren<TMP_Text>();
        TMP_Text text3 = badLuckB.GetComponentInChildren<TMP_Text>();

        text1.color = Color.gray;
        text2.color = Color.gray;
        text3.color = Color.black;

        selectedLuck = 2;
        PlayerPrefs.SetInt("selectedLuck", selectedLuck);
    }

    public void OnPressedNormalLuck()
    {
        TMP_Text text1 = goodLuckB.GetComponentInChildren<TMP_Text>();
        TMP_Text text2 = badLuckB.GetComponentInChildren<TMP_Text>();
        TMP_Text text3 = normalLuckB.GetComponentInChildren<TMP_Text>();

        text1.color = Color.gray;
        text2.color = Color.gray;
        text3.color = Color.black;

        selectedLuck = 3;
        PlayerPrefs.SetInt("selectedLuck", selectedLuck);
    }
}
