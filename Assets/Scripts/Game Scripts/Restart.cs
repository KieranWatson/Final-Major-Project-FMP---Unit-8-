using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("End Game");
            Restart1();
        }
    }

    void Restart1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
