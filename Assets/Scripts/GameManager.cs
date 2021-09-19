using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText, countEnemyText, livesText, countWaveText;
    public static int score, lives = 3, countEnemy, countWave = 0, timer, scoreUpgradeReloadTime, scoreUpgradeRotationSpeed, scoreUpgradeLives;
    public static bool isGame = true, isAnim;
    void Start()
    {
        InvokeRepeating("Timer",0,1);
        string json = File.ReadAllText(Path.Combine(Application.dataPath, "score.txt"));
        ScoreObject myObject = JsonUtility.FromJson<ScoreObject>(json);
        score = myObject.score;
        countWave = 0;
    }
    void Update()
    {
        if(timer == 5)
        {
            ScoreObject myObject = new ScoreObject();
            myObject.score = score;
            string json = JsonUtility.ToJson(myObject); // преобразование обьекта в json строку
            File.WriteAllText(Path.Combine(Application.dataPath, "score.txt"), json);
            timer = 0;
            print(Application.dataPath);
        }
        countWaveText.text = countWave.ToString();
        livesText.text = lives.ToString();
        countEnemyText.text = countEnemy.ToString();
        scoreText.text = score.ToString();
    }
    void Timer()
    {
        timer++;
        // print(timer);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        lives = 3;
        countEnemy = 0;
        isGame = true;
        score = 0;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
