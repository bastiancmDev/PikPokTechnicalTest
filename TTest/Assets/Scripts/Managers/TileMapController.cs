using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    public Tilemap Map;

    public bool ValidatorMove(Vector3 postion)
    {        
        var ray = Camera.main.ScreenPointToRay(new Vector3(postion.x, postion.y, Camera.main.nearClipPlane)); ;
        if (Physics.Raycast(ray, out var hitInfo))
        {

            if (hitInfo.collider.tag == "CeilToMove")
            {
                Debug.DrawRay(ray.origin, hitInfo.point);
                var mousePositiion = hitInfo.point;
                return true;
            }
            else
            {
                return false;
            }
        }
        else{
            return false;
        }
        
    }

    public Vector3 GetPostionToMove(Vector3 postion)
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(postion.x, postion.y, Camera.main.nearClipPlane)); ;
        if (Physics.Raycast(ray, out var hitInfo))
        {
            if(hitInfo.collider.tag == "CeilToMove")
            {
                Debug.DrawRay(ray.origin, hitInfo.point);
                var mousePositiion = hitInfo.point;
                return mousePositiion;
            }
            else
            {
                return Vector3.zero;
            }
            
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void Start()
    {
        InitTileMap();
    }

    private void InitTileMap()
    {
        Map = GameObject.Find("GroundTileMap").GetComponent<Tilemap>(); 
    }
}
