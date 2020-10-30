using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMananger : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<tiledatascript> tileDatas;

    private Dictionary<TileBase, tiledatascript> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, tiledatascript>();

        foreach (var tiledatascript in tileDatas)
        {
            foreach (var tile in tiledatascript.tiles)
            {
                dataFromTiles.Add(tile, tiledatascript);

                
            }
        }
    }


    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            int crossCost2 =  dataFromTiles[clickedTile].crossCost;

            print("At position " + gridPosition + " There is a " + clickedTile + "cost of crossing is "+ crossCost2);
        }
    }

    public int GetTilecrossCost(Vector2 wordlPosition)
    {
        Vector3Int gridPosition = map.WorldToCell(wordlPosition);

        TileBase tile = map.GetTile(gridPosition);

        if (tile == null){return 0;}
        else{
        int crossCost2 =  dataFromTiles[tile].crossCost;
        return crossCost2;
        }
    }
}
