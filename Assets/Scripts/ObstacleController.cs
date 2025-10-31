using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private List<Tile> obstacleTiles = new List<Tile>();

    // <-- added: list of unit sprites you can assign in the Inspector
    [SerializeField] private SpriteRenderer spriteRenderer = new SpriteRenderer();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
