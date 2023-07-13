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

    private bool rockPushed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            Destroy(collision.gameObject);
            rockPushed = true;

            // Get the tile position where the rock was pushed into
            Vector3Int tilePosition = waterTilemap.WorldToCell(collision.transform.position);

            // Change the tile to grass
            waterTilemap.SetTile(tilePosition, grassTile);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && rockPushed)
        {
            // Allow the player to walk on the transformed water tile (now grass)
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
    public void ChangeWaterSprite(Vector3 position)
    {
        Vector3Int tilePosition = waterTilemap.WorldToCell(position);// Get the tile position where the rock was pushed into
        waterTilemap.SetTile(tilePosition, grassTile);// Change the water in tileposition to grass
        //Change the layer of the water here to grass
        waterTilemap.gameObject.layer = default;
    }
}
