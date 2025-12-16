using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float smoothness = 10f;

    private Vector2 moveInput;
    private Vector2 currentVelocity;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 targetVelocity = moveInput * moveSpeed;

        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, smoothness * Time.deltaTime);

        transform.Translate(currentVelocity * Time.deltaTime);
    }
}

