using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerMoviment : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private InteractablesAsset interactableAsset;
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        ApplyMoviment();
    }

    private void ApplyMoviment()
    {
        Vector2 currentPos = rb.position;
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * moveSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
