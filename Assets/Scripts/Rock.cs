using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private void Start()
    {

    }

    public bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir * 0.5f, dir, 0.5f);
        //The default value of the layerMask parameter in Physics2D.Raycast is DefaultRaycastLayers
        //DefaultRaycastLayers is a predefined layer mask that includes all layers except for the Ignore Raycast layer. 
        //You can use the DefaultRaycastLayers value if you want the raycast to interact with objects on all layers except the Ignore Raycast layer. 
        //Alternatively, you can specify a custom layer mask to define which layers the raycast should consider for collision detection.
        
        if (!hit)//there is nothing in front of the rock
        {
            transform.Translate(dir);
            return true;
        }
        
        if (hit.collider.GetComponent<Pit>() != null)//there is a pit in front of the rock
        {
            //Destory the rock and the pit will turn into grass
            hit.collider.GetComponent<Pit>().ChangePitSprite();
            Destroy(gameObject);
            return true;
        }
        
        if(hit.collider.GetComponent<Water>() != null)//there is water in front of the rock
        {
            //Destory the rock and the water will turn into grass
            hit.collider.GetComponent<Water>().ChangeWaterSprite(transform.position+ (Vector3)dir * 1.0f);
            Destroy(gameObject);
            return true;
        }
        
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            FindObjectOfType<GameManager>().finishedBoxs--;
            GetComponent<SpriteRenderer>().color = originColor;
        }
    }*/
}
