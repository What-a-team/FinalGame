using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalBoxs;
    public int finishedBoxs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetStage();
    }

    public void Win()
    {
        if(finishedBoxs == totalBoxs)
        {
            print("YOU WIN!");
            StartCoroutine(LoadNextStage());
        }
    }

    public void ResetStage()
    //It was private in the tutorial, but I need to call it from PlayerController.cs in order to reset the stage when the player falls into the pit
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
