using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody physics;
    public float speed = 5f;
    public float jump = 5f;
    bool onGround;

    private void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        Vector3 velocity = physics.linearVelocity;
        velocity.x = horizontal;
        velocity.z = vertical;

        if (onGround && Input.GetButton("Jump"))
        {
            velocity.y = jump;
        }

        physics.linearVelocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
