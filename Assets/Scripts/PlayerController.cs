using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 moveDir;
    public LayerMask detectLayer;//the layers that the raycast will detect 
    //remeber to set the layer that you want the player to interact with to in the Unity editor(because I forget to do that )
    //public float mHeroSpeed = 20f;
    void Update()
    {
        Vector3 p = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            moveDir = Vector2.right;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            moveDir = Vector2.left;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveDir = Vector2.up;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            moveDir = Vector2.down;

        if(moveDir != Vector2.zero)
        {
            if(CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }
        moveDir = Vector2.zero;
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, detectLayer);//1.0f is the distance of raycast and detectLayer is the layer of the rock

        if (!hit)//no rock in front of the player or no wall in front of the box
        {    
            Debug.Log("No box in front of the player");
            return true;
        }
        else
        {
            if (hit.collider.GetComponent<Rock>() != null)//there is a rock in front of the player
                return hit.collider.GetComponent<Rock>().CanMoveToDir(dir);
            else return false;
        }
    }

    void Move(Vector2 dir)
    {
        transform.Translate(dir);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sheep"))
        {
            FindObjectOfType<GameManager>().Win();
            /*FindObjectOfType<GameManager>().finishedBoxs++;
            FindObjectOfType<GameManager>().CheckFinish();
            GetComponent<SpriteRenderer>().color = finishColor;*/
        }
        if(collision.CompareTag("Pit"))
        {
            FindObjectOfType<GameManager>().ResetStage();//I don't know why it doesn't work when I collide with the pit
        }
    }
}
