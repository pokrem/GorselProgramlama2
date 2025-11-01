using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(move * moveSpeed, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup"))
        {
            Destroy(other.gameObject);
        }
    }
}
