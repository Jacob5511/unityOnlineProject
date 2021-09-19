using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.isGame = true;
        GameManager.lives = 3;
        GameManager.countEnemy = 0;
        GameManager.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
