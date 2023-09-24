using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 RotateAroundY(this Vector3 vectorToRotate, float angle)
    {
        return new Vector3(
            vectorToRotate.x * Mathf.Cos(angle * Mathf.Deg2Rad) - vectorToRotate.z * Mathf.Sin(angle * Mathf.Deg2Rad),
            vectorToRotate.y,
            vectorToRotate.z * Mathf.Cos(angle * Mathf.Deg2Rad) + vectorToRotate.x * Mathf.Sin(angle * Mathf.Deg2Rad));
    }
}	