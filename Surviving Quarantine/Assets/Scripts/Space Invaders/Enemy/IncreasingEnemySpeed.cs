using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreasingEnemySpeed : MonoBehaviour
{
    [SerializeField] private Enemy[] enemy;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private SpaceMoviment playerScore;
    [SerializeField] private TextMeshProUGUI scorePoints;
    [SerializeField] private TextMeshProUGUI finalScore;
    public int count = 0;


    private void FixedUpdate()
    {
        for (int i = 0; i < enemy.Length; i++)
        { 

            if (enemy[i].dead)
            {
                count++;
                enemy[i].dead = false;
            }
        }

        if (count == 16)
        {
            playerScore.score = int.Parse(scorePoints.text);
            finalScore.text = playerScore.score.ToString();
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            gameUI.SetActive(false);
            endGameUI.SetActive(true);
        }
    }
}
