using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScriptPhone : MonoBehaviour
{
    [SerializeField] private float floatSpeed;
    private Animator textAnimator;
    [SerializeField] private TextMeshProUGUI xpTextBoredom;
    [SerializeField] private GameObject[] spawn;
    private int randomChoice;


    private void Start()
    {
        textAnimator = GetComponent<Animator>();

        randomChoice = Random.Range(0, spawn.Length);
        xpTextBoredom.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
    }

    private void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(0, floatSpeed, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

        textAnimator.SetBool("Enable", false);
        this.enabled = false;
        transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
    }

    public void SpawnObject()
    {
        textAnimator.SetBool("Enable", true);
    }
}
