using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseWindow : MonoBehaviour
{
    [SerializeField] private GameObject pcUI;
    [SerializeField] private GameObject normalUI;
    private bool canOpen = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            canOpen = false;
        }
    }

    public void OpenWindow()
    {
        if (canOpen)
        {
            pcUI.SetActive(true);
            normalUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void CloseWindow()
    {
        pcUI.SetActive(false);
        normalUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
