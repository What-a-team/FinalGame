using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    public void ChangePitSprite()
    {
        Debug.Log("Pit collides with Rock");
        GetComponent<SpriteRenderer>().sprite = newSprite;//reload the Pit using Grass
        GetComponent<BoxCollider2D>().enabled = false;//disable the collider
        GetComponent<SpriteRenderer>().sortingOrder = -10;//set the sorting order to -10 same as the usual grass
    }

}
