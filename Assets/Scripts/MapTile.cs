using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] public int pos;

    [Header("Tile tipe")]
    [SerializeField] public bool normal;
    [SerializeField] public bool bad;
    [SerializeField] public bool good;

    [Header("Tile transporter positon")]
    [SerializeField] public int transportPosition;
}
