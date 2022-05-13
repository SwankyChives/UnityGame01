using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    Vector3 velocity;
    Rigidbody playerRigidbody;
    float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))).normalized;
        velocity = direction * speed;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            playerRigidbody.AddForce(0, jumpForce, 0);
        }
    }

    private void FixedUpdate() {
        playerRigidbody.transform.Translate(velocity * Time.fixedDeltaTime);
        distToGround = transform.localScale.y / 2;
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
