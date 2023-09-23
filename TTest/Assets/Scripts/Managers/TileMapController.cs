using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    public Tilemap Map;

    public bool ValidatorMove(Vector3 postion)
    {
        Vector2  mousePositiion = Camera.main.ScreenToWorldPoint(postion);
        mousePositiion = Camera.main.ScreenToWorldPoint(mousePositiion);
        Vector3Int gridPosition = Map.WorldToCell(mousePositiion);
        if(Map.HasTile(gridPosition)) { 
            return true;
        }
        else
        {
            return false;
        }
    }
}
