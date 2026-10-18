using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); // A and D
        float z = Input.GetAxis("Vertical");   // W and S
        rb.AddForce(new Vector3(x, 0, z) * speed);
    }
}