using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving = false;
    [SerializeField] private Animator characterAnor;
    [SerializeField] private MovementController dMovementController;
    
    private void Update() {
        characterAnor.SetBool(Constants.Animation.Booleans.IsWalking, IsMoving);
    }
}