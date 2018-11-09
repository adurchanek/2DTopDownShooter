using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] tilePrefabs;

    public GameObject parent;

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    private void CreateLevel()
    {
        string[] mapData = ReadLevelText();
        int mapXSize = mapData[0].Length;
        int mapYSize = mapData.Length;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for(int y = 0; y < mapYSize; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for (int x = 0; x < mapXSize; x++)
            {
                PlaceTile(newTiles[x].ToString(),x, y, worldStart);
            }
        }
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        GameObject newTile = Instantiate(tilePrefabs[int.Parse(tileType)]);
        newTile.transform.position = new Vector3(worldStart.x + TileSize * x, worldStart.y - TileSize * y);
        newTile.transform.parent = parent.transform;

    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }

	// Use this for initialization
	void Start () {
        CreateLevel();
	}
	
}
