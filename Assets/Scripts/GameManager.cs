using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetStage();
        if (Input.GetKeyDown(KeyCode.Q))//quit the game
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.N))//go to next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Input.GetKeyDown(KeyCode.L))//go to last level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Win()
    {
            print("YOU WIN!");
            StartCoroutine(LoadNextStage());
    }

    private void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
