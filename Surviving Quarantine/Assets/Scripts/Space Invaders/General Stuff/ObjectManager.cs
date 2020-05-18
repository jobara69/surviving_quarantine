using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private Vector3[] currentPos = new Vector3[65];
    [SerializeField] private SpaceMoviment playerSprite;
    [SerializeField] private Sprite normalPlayerSprite;
    [SerializeField] private RightButton rButton;
    [SerializeField] private LeftButton lButton;
    [SerializeField] private TextMeshProUGUI textUI;

    private void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                currentPos[i] =  objects[i].transform.position;
            }
        }
    }

    public void ActivateAndReturn()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.position = currentPos[i];
            objects[i].SetActive(true);
        }

        playerSprite.GetComponent<SpriteRenderer>().sprite = normalPlayerSprite;
        rButton.OnPointerUp(null);
        lButton.OnPointerUp(null);
        textUI.text = 0.ToString();
        GetComponent<IncreasingEnemySpeed>().count = 0;
    }

}
