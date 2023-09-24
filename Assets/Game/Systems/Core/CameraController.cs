using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform targetTransform;
    [SerializeField] private float smoothTime = 0.3F;
    
    public Vector3 GetOffset => offSet;

    private Vector3 velocity = Vector3.zero;
    private Vector3 offSet;

    private void Start() {
        offSet = transform.position - targetTransform.position;
    }

    private void FixedUpdate() {
        FollowTarget();
    }

    private void FollowTarget() {
        Vector3 targetPosition = targetTransform.position + offSet;

        var dampedPos = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = dampedPos;
    }
}