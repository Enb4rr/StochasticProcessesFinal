using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

public class MapManager : MonoBehaviour
{
    //Events Stuff

    public delegate void MapEvents(int s);
    public event MapEvents OnSaveTrajectory;

    //Managers Stuff

    private GameManager gameManager;

    //Code Stuff

    [Header("Positions List")]
    [SerializeField] public List<MapTile> tiles;

    private GameObject player;
    private Dice dice;

    private int currentTilePosition;

    private void Awake()
    {
        player = GameObject.Find("Player");
        dice = GameObject.Find("Dice").GetComponent <Dice>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        player.transform.position = tiles[0].transform.position;
        currentTilePosition = 0;
    }

    private void OnEnable()
    {
        dice.DiceRolled += MovePlayer;
        gameManager.reset += ResetMap;
    }

    private void OnDisable()
    {
        dice.DiceRolled -= MovePlayer;
        gameManager.reset -= ResetMap;
    }

    public void MovePlayer(int movement)
    {
        //Get current tile position:

        currentTilePosition = 0;

        foreach (MapTile tile in tiles)
        {
            if (tile.transform.position == player.transform.position)
            {
                break;
            }
            else
            {
                currentTilePosition++;
            }
        }

        //See how much is left to reach end

        if (currentTilePosition + movement <= tiles.Count)
        {
            while (movement > 0)
            {
                MoveToNextTile(currentTilePosition);
                currentTilePosition++;
                movement--;
            }

            OnSaveTrajectory?.Invoke(currentTilePosition);
        }
        else
        {
            Debug.Log("Necestas un " + (10 - currentTilePosition) + " para terminar el juego");
        }
    }

    private void MoveToNextTile(int current)
    {
        player.transform.DOMove(tiles[current + 1].transform.position, 0.5f, false);
    }

    public void ResetMap()
    {
        player.transform.position = tiles[0].transform.position;
        currentTilePosition = 0;
    }
}