using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    [HideInInspector] public bool wasActive = false;
    public ParticleSystem rainParticle;
    [HideInInspector] public bool isRaining = false;
    public GameObject[] eletricObject;
    public GivingSignal[] eletricSignal;
    [SerializeField] private GameObject lightsOutText;
    public bool wasRaining = false;

    public void CalculateRain()
    {
        int choise = Random.Range(0, 2);
        Debug.Log(choise);
        this.enabled = false;
        wasActive = true;

        switch (choise)
        {
            case 0:
                
                break;
            case 1:
                isRaining = true;
                rainParticle.Play();
                break;
        }

        if (isRaining)
        {
            int choise_ = Random.Range(0, 2);
            Debug.Log(choise_ + " CHANCE OF BLACKOUT");
            switch (choise_)
            {
                case 0:
                    break;
                case 1:
                    wasRaining = true;
                    lightsOutText.SetActive(true);
                    StartCoroutine(lightsOutEnd());
                    for (int i = 0; i < eletricObject.Length; i++)
                    {
                        eletricObject[i].SetActive(false);
                    }
                    for (int i = 0; i < eletricSignal.Length; i++)
                    {
                        eletricSignal[i].cooldownCanvasAnim.SetBool("Enable", true);
                    }
                    break;
            }
        }
    }

    private IEnumerator lightsOutEnd()
    {
        yield return new WaitForSeconds(2f);
        lightsOutText.SetActive(false);
    }
}
