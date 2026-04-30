using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    private Vector2 lastMoveDirection = Vector2.down;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        float speed = moveDirection.magnitude;

        Debug.Log("MoveX: " + moveDirection.x + " MoveY: " + moveDirection.y + " Speed: " + speed);

        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetFloat("Speed", speed);

        if (speed > 0.1f)
        {
            lastMoveDirection = moveDirection;
            animator.SetFloat("LastX", lastMoveDirection.x);
            animator.SetFloat("LastY", lastMoveDirection.y);
        }
    }
}