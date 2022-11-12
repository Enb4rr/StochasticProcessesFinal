using System;
using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    public delegate void diceEvents(int s);
    public event diceEvents DiceRolled;

    private Sprite[] diceSides;
    private SpriteRenderer rend;

	private void Start () 
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}
	
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
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
