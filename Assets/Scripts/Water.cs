using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    //public Sprite newSprite;
    public Tilemap waterTilemap;
    public TileBase grassTile;
    public TileBase groundTile;
    public void ChangeWaterSprite(Vector3 position)
    {
        Debug.Log("RockInWater");
        Vector3Int tilePosition = waterTilemap.WorldToCell(position);// Get the tile position where the rock was pushed into
        waterTilemap.SetTile(tilePosition, grassTile);// Change the water in tileposition to grass
        waterTilemap.gameObject.layer = LayerMask.NameToLayer("Default");// Change the layer of the tilemap to default
        // Disable collider for the specified position
    }
    public void DestoryWater(Vector3 position)
    {
        Debug.Log("WoodOnWater");
        Vector3Int tilePosition = waterTilemap.WorldToCell(position);// Get the tile position where the rock was pushed into
        waterTilemap.SetTile(tilePosition, groundTile);// Change the water in tileposition to grass
        waterTilemap.gameObject.layer = LayerMask.NameToLayer("Default");// Change the layer of the tilemap to default
        // Disable collider for the specified position
    } 
    public void DisableColliderAtPosition()
    {
        // Disable collider for the specified position
        //tilemap.GetComponent<TilemapCollider2D>().SetTileFlags(disabledPosition, TileFlags.None);
        //Collider2D collider = tilemap.GetComponent<TilemapCollider2D>().SetColliderType(disabledPosition, Tile.ColliderType.None);
    }
}
