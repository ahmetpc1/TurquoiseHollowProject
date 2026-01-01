using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float smoothness = 10f;

    private Vector2 moveInput;
    private Vector2 currentVelocity;

    Animator animator;

    MoveDirection currentDirection=MoveDirection.None;
    enum MoveDirection
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        HandleMovement();
        DetectMainDirection();
        SetAnimationTrigger();
    }

    private void HandleMovement()
    {
        Vector2 targetVelocity = moveInput * moveSpeed;

        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, smoothness * Time.deltaTime);

        transform.Translate(currentVelocity * Time.deltaTime);
    }
    void DetectMainDirection()
    {
        if (moveInput == Vector2.zero)
        {
            currentDirection = MoveDirection.None;
            return;
        }

        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            currentDirection = moveInput.x > 0 ? MoveDirection.Right : MoveDirection.Left;
        }
        else
        {
            currentDirection = moveInput.y > 0 ? MoveDirection.Up : MoveDirection.Down;
        }
    }
    void SetAnimationTrigger() 
    {
        switch (currentDirection)
        {
            case MoveDirection.Left:
                animator.SetTrigger("LeftWalk");
                break;

            case MoveDirection.Right:
                animator.SetTrigger("RigthWalk");

                break;

            case MoveDirection.Up:
                animator.SetTrigger("UpWalk");

                break;

            case MoveDirection.Down:
                animator.SetTrigger("DownWalk");
                break;
            case MoveDirection.None:
                animator.SetTrigger("Idle");
                break;
        }


    }
}

