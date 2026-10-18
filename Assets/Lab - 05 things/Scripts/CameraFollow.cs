using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // the ball
    public float smoothTime = 0.2f; // higher = slower, smoother camera

    Vector3 offset;
    Vector3 velocity;

    void Start()
    {
        // remember how far the camera is from the ball right now
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}