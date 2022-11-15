using System;
using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    //Events Stuff

    public delegate void diceEvents(int s);
    public event diceEvents DiceRolled;

    //Code Stuff

    private Sprite[] diceSides;
    private SpriteRenderer rend;

    public bool goodLuck, badLuck, normalLuck;

    //Managers Stuff

    MapManager mapManager;

    private void Awake()
    {
        mapManager = GameObject.Find("GameManager").GetComponent<MapManager>();
    }

    private void Start () 
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");

        int selectedLuck = PlayerPrefs.GetInt("selectedLuck");

        if (selectedLuck == 1)
        {
            goodLuck = true;
            badLuck = false;
            normalLuck = false;
        }
        else if (selectedLuck == 2)
        {
            goodLuck = false;
            badLuck = true;
            normalLuck = false;
        }
        else if (selectedLuck == 3)
        {
            goodLuck = false;
            badLuck = false;
            normalLuck = true;
        }
    }
	
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        if (goodLuck && mapManager.currentTilePosition <= 3)
        {
            int finalSide = 0;

            int valueToSet = 3 - mapManager.currentTilePosition;
            rend.sprite = diceSides[valueToSet - 1];
            finalSide = valueToSet;

            DiceRolled?.Invoke(finalSide);
        }
        else if (goodLuck && mapManager.currentTilePosition > 3)
        {
            int randomDiceSide = 0;
            int finalSide = 0;

            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = UnityEngine.Random.Range(0, 5);

                rend.sprite = diceSides[randomDiceSide];

                yield return new WaitForSeconds(0.05f);
            }

            finalSide = randomDiceSide + 1;

            DiceRolled?.Invoke(finalSide);
        }
        else if (badLuck && mapManager.currentTilePosition >= 6 && mapManager.currentTilePosition < 9)
        {
            int finalSide = 0;

            int valueToSet = 8 - mapManager.currentTilePosition;
            rend.sprite = diceSides[valueToSet - 1];
            finalSide = valueToSet;

            DiceRolled?.Invoke(finalSide);
        }
        else if (badLuck && mapManager.currentTilePosition < 6)
        {
            int randomDiceSide = 0;
            int finalSide = 0;

            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = UnityEngine.Random.Range(0, 5);

                rend.sprite = diceSides[randomDiceSide];

                yield return new WaitForSeconds(0.05f);
            }

            finalSide = randomDiceSide + 1;

            DiceRolled?.Invoke(finalSide);

        }
        else if (normalLuck)
        {
            int randomDiceSide = 0;
            int finalSide = 0;

            for (int i = 0; i <= 20; i++)
            {
                randomDiceSide = UnityEngine.Random.Range(0, 5);

                rend.sprite = diceSides[randomDiceSide];

                yield return new WaitForSeconds(0.05f);
            }

            finalSide = randomDiceSide + 1;

            DiceRolled?.Invoke(finalSide);
        }

    }
}
