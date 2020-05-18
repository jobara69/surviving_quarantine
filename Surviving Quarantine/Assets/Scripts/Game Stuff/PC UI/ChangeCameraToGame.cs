using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraToGame : MonoBehaviour
{
    [SerializeField] private GameObject cameraMainAppearing;
    [SerializeField] private GameObject cameraMainController;
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private GameObject computerUI;
    [SerializeField] private BoredomBar boredomBar;
    [SerializeField] private GameObject spaceInvaders;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject GameControllUI;
    private float previousMultiplier;

    public void OpenGame()
    {
        previousMultiplier = boredomBar.timeMultiplier;
        boredomBar.timeMultiplier = 500;
        computerUI.SetActive(false);
        cameraMainAppearing.SetActive(true);
        cameraMainController.SetActive(false);
        cameraUI.SetActive(false);
        spaceInvaders.SetActive(true);
        if (endGameUI.activeSelf == true)
        {
            endGameUI.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void CloseGame()
    {
        boredomBar.timeMultiplier = previousMultiplier;
        cameraMainController.SetActive(true);
        cameraUI.SetActive(true);
        spaceInvaders.SetActive(false);
        if (GameControllUI.activeSelf == false)
        {
            GameControllUI.SetActive(true);
        }
        Time.timeScale = 1f;
    }
}
