using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float moveDirectionRotationalOffset = 30f;
    public FloatingJoystick floatingJoystick;
    public PlayerController playerController;

    public bool IsMoving => playerController.IsMoving;
    public Rigidbody GetRigid => rb;

    private Rigidbody rb;
    public bool canMove;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }
    
    void FixedUpdate() {
        if (floatingJoystick == null) return;

        if (canMove) {
            Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;

            if (moveDirectionRotationalOffset != 0) 
                direction = direction.RotateAroundY(moveDirectionRotationalOffset);

            direction = Vector3.ClampMagnitude(direction, 1f);

            if (direction == Vector3.zero) {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                playerController.IsMoving = false;
            }
            else 
            {
                playerController.IsMoving = true;
            }

            float oldMagnitude = direction.magnitude;

            Vector3 dirNorm = direction.normalized;
            Vector3 forwardLerped = Vector3.Lerp(transform.forward, dirNorm, rotationSpeed * oldMagnitude * Time.fixedDeltaTime);
            Vector3 currentVel = forwardLerped * (oldMagnitude * movementSpeed * 100 * Time.fixedDeltaTime);

            rb.velocity = new Vector3(currentVel.x, rb.velocity.y, currentVel.z);
            transform.forward = forwardLerped;
        }
    }
}