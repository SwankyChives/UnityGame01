using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    Vector3 velocity;
    Rigidbody playerRigidbody;
    Collider playerCollider;
    float distToGround;
    bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        distToGround = playerCollider.transform.localScale.y;
            //transform.localScale.y / 2
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))).normalized;
        velocity = direction * speed;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && (jumpPressed == false)) {
            jumpPressed = true;
        }
    }

    private void FixedUpdate() {
        if (jumpPressed == true) {
            playerRigidbody.AddForce(0, jumpForce, 0);
            jumpPressed = false;
        }
        playerRigidbody.transform.Translate(velocity * Time.fixedDeltaTime, Space.World);
        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
