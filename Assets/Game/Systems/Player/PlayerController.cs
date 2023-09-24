using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving = false;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private MovementController dMovementController;
}