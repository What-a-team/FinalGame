using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Color finishColor;
    Color originColor;

    private void Start()
    {
        originColor = GetComponent<SpriteRenderer>().color;
        //FindObjectOfType<GameManager>().totalBoxs++;
    }

    public bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir * 0.5f, dir, 0.5f);

        if (!hit)
        {
            transform.Translate(dir);
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.CompareTag("Sheep"))
        {
            FindObjectOfType<GameManager>().finishedBoxs++;
            FindObjectOfType<GameManager>().CheckFinish();
            GetComponent<SpriteRenderer>().color = finishColor;
        }*/
        if(collision.CompareTag("Pit"))
        {
            //Destroy the rock
            Destroy(gameObject);
        }
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