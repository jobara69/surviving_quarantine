using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField] private float floatSpeed;
    private TextMeshProUGUI thisText;
    private Animator textAnimator;

    private void Start()
    {
        textAnimator = GetComponent<Animator>();
        thisText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(0, floatSpeed, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

        StartCoroutine(waitSecondsToDestroy());
    }

    private IEnumerator waitSecondsToDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
