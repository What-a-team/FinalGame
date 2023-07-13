using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 moveDir;
    public LayerMask detectLayer;//the layers that the raycast will detect 
    //remeber to set the layer that you want the player to interact with to in the Unity editor(because I forget to do that )
    //if the player get to the state of "confused", it will be hard to control the player
    public bool isConfused = false;
    void Update()
    {
        Vector3 p = transform.localPosition;
        //if the player is confused, it will move in a random direction
        if (isConfused)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                moveDir = Vector2.left;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                moveDir = Vector2.right;

            if (Input.GetKeyDown(KeyCode.UpArrow))
                moveDir = Vector2.down;

            if (Input.GetKeyDown(KeyCode.DownArrow))
                moveDir = Vector2.up;
        }
        //if the player is not confused, it will move in the direction that the player press
        else if(!isConfused)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                moveDir = Vector2.right;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                moveDir = Vector2.left;

            if (Input.GetKeyDown(KeyCode.UpArrow))
                moveDir = Vector2.up;

            if (Input.GetKeyDown(KeyCode.DownArrow))
                moveDir = Vector2.down;
        }

        if(moveDir != Vector2.zero)
        {
            if(CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }
        moveDir = Vector2.zero;
    }

    private bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, detectLayer);
        //1.0f is the distance of raycast and detectLayer is those layers that the raycast will detect

        if (!hit)//no rock and no tree in front of the player
        {    
            return true;
        }
        else
        {
            if (hit.collider.GetComponent<Rock>() != null)//there is a rock in front of the player 
                return hit.collider.GetComponent<Rock>().CanMoveToDir(dir);
            else if(hit.collider.GetComponent<Pit>() != null)//there is a pit in front of the player
                return false;
            else return false;
        }
    }

    private void Move(Vector2 dir)
    {
        transform.Translate(dir);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sheep"))
        {
            FindObjectOfType<GameManager>().Win();
        }
        //when player collide with the waterground
        
    }
}
