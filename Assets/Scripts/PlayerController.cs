using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Vector2 moveDir;
    public Vector2 faceDir;
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
            {
                moveDir = Vector2.left;
                faceDir = moveDir;
            }    

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDir = Vector2.right;
                faceDir = moveDir;
            }   
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDir = Vector2.down;
                faceDir = moveDir;
            }   
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDir = Vector2.up;
                faceDir = moveDir;
            }   
        }
        //if the player is not confused, it will move in the direction that the player press
        else if(!isConfused)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveDir = Vector2.right;
                faceDir = moveDir;
            }   
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDir = Vector2.left;
                faceDir = moveDir;
            }   
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDir = Vector2.up;
                faceDir = moveDir;
            }   
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDir = Vector2.down;
                faceDir = moveDir;
            }   
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            //Mutiple function when F is pressed
            //1. if there is a tree in front of the player, the player will cut the tree
            if(CanDestoryTree(faceDir))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, faceDir, 1.0f, detectLayer);
                hit.collider.GetComponent<Tree>().ChangeTreeSprite(transform.position + (Vector3)faceDir * 1.0f);
            }
            else if(CanDestoryWater(faceDir))//turn if into else if then it works why?!
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, faceDir, 1.0f, detectLayer);
                hit.collider.GetComponent<Water>().DestoryWater(transform.position + (Vector3)faceDir * 1.0f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isConfused = !isConfused;
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

    private bool CanDestoryWater(Vector2 faceDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, faceDir, 1.0f, detectLayer);
        if(GameManager.GlobalInstance.NumOfWoods > 0 && hit.collider.GetComponent<Water>() != null)
        {
            return true;
        }
        else return false;
    }

    private bool CanDestoryTree(Vector2 faceDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, faceDir, 1.0f, detectLayer);
        if(GameManager.GlobalInstance.NumOfAxes > 0 && hit.collider.GetComponent<Tree>() != null)
        {
            return true;
        }
        else return false;
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
            else if(hit.collider.GetComponent<Water>() != null)//there is water in front of the player
                return false;
            else if(hit.collider.GetComponent<Axe>() != null)//there is an axe in front of the player
            {
                hit.collider.GetComponent<Axe>().GetAnAxe();//then the axe will be destoryed and the NumOfAxes will add 1
                return true;
            }
        }
        return false;
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
    }
    private void IsOnIce()
    {

    }
}
