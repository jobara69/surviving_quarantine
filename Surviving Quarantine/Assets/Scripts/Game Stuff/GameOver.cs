using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI daysText;
    [SerializeField] private TimeOfTheDay tod;

    private void Start()
    {
        daysText.text = tod.GetComponent<TimeOfTheDay>().days.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("New Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
