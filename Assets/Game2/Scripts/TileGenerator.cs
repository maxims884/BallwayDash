using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _tilePrefabWithBonus;
    [SerializeField] private int maxCount;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    private float speed = 3;
    private float maxSpeed = 40;
    private float countTimer = 0;
    private System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start ");
        _tiles.First().speed = speed;
        for (int i = 0; i < maxCount; i++)
        {
            GenerateTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_tiles.Count < maxCount)
        {
            GenerateTile();
        }
    }

    void FixedUpdate()
    {
        if (countTimer > 500)
        {
            countTimer = 0;
            IncreaseSpeed();
        }
        countTimer++;
    }

    private void GenerateTile()
    {
        int IsNeedBonusTile = getRand(1, 5);
        GameObject _prefab;
        if (IsNeedBonusTile == 3)
        {
            _prefab = _tilePrefabWithBonus;
        } else { _prefab = _tilePrefab;  }

        GameObject newTileObject = Instantiate(_prefab, _tiles.Last().transform.position + Vector3.forward * _tilePrefab.transform.localScale.z, Quaternion.identity);
        Tile newTile = newTileObject.GetComponent<Tile>();
        newTile.speed = speed;
        int IsNeedAddHole = getRand(3, 7);
        float HoleSize = 0;
        if (IsNeedAddHole == 5)
        {
            HoleSize = getRand(5, 12);   
        }
        newTile.transform.position = new Vector3(newTile.transform.position.x, newTile.transform.position.y, newTile.transform.position.z + HoleSize);
        _tiles.Add(newTile);
    }

    private void OnTriggerEnter(Collider other)
    {
        _tiles.Remove(other.GetComponent<Tile>());
        Destroy(other.gameObject);
    }

    private void IncreaseSpeed()
    {
        if(speed < maxSpeed)
        {
            speed += 0.1f;
            for (int i = 0; i < _tiles.Count; i++)
            {
                Tile tile = _tiles[i];
                tile.speed = speed;
            }
        }
    }

    private int getRand(int minValue, int maxValue)
    {
       return rand.Next(minValue, maxValue);
    }
}
