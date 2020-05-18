using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConvertScoreToBoredom : MonoBehaviour
{
    [SerializeField] private SpaceMoviment playerScore;
    [SerializeField] private BoredomBar boredomBar;
    [SerializeField] private TextMeshProUGUI boredomText;
    [SerializeField] private RandomSpawn randomSpawn;


    public void ScoreToBore()
    {
        boredomBar.time -= playerScore.score * 1000;
        boredomText.text = "+" + playerScore.score * 1000;
        randomSpawn.CreatingObject(0);
        print(playerScore.score * 100);
    }
}
