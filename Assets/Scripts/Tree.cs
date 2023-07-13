using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tree : MonoBehaviour
{
    public Tilemap treeTilemap;
    public TileBase destroyedTreeTile;
    public void ChangeTreeSprite(Vector3 position)
    {
        Debug.Log("DestoryTree");
        Vector3Int tilePosition = treeTilemap.WorldToCell(position);// Get the tile position where the rock was pushed into
        treeTilemap.SetTile(tilePosition, destroyedTreeTile);// Change the water in tileposition to grass
        treeTilemap.gameObject.layer = LayerMask.NameToLayer("Default");// Change the layer of the tilemap to default
        GameManager.GlobalInstance.NumOfAxes--;
        GameManager.GlobalInstance.NumOfWoods++;
    }
}
