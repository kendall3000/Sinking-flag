using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform target; // Assign the player here in the inspector
    public float smoothing = 5f; // How smoothly the camera catches up to the target's movement
    public Vector3 offset; // Offset from the target (maintain your desired z-axis distance here)

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        // Ensure the camera only changes its x and y positions, not z.
        smoothedPosition.z = transform.position.z;

        transform.position = smoothedPosition;
    }
}
