using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public void GetAnAxe()
    {
        // Get the axe
        GameManager.GlobalInstance.NumOfAxes++;
        Destroy(gameObject);
    }
}
