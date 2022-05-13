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
    Vector3 velocityLastFrame = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        distToGround = playerCollider.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        // calculates velocity
        Vector3 direction = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
        velocity = direction * speed;

        // activates jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded() && (jumpPressed == false)) {
            jumpPressed = true;
        }

        //Debug.DrawRay(transform.position + Vector3.left * (transform.localScale.x - 0.01f) / 2, Vector3.down, Color.red, distToGround);

        //print(IsGrounded());
    }

    private void FixedUpdate() {

        // jump
        if (jumpPressed == true && IsGrounded()) {
            playerRigidbody.velocity += Vector3.up * jumpForce;
            jumpPressed = false;
        }

        // checks if player is on ground, then moves.
        if (IsGrounded()) {
            playerRigidbody.velocity += velocity * Time.fixedDeltaTime;
        }

        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    // tests if player is on ground (taken from multiple rays, definitely better way to do this.
    bool IsGrounded() {
        return (IsGroundedLeft() || IsGroundedRight() || IsGroundedCentre());
    }

    bool IsGroundedRight() {
        return Physics.Raycast(transform.position + Vector3.right * (transform.localScale.x) / 2, Vector3.down, distToGround);
    }
    bool IsGroundedLeft() {
        return Physics.Raycast(transform.position + Vector3.left * (transform.localScale.x) / 2, Vector3.down, distToGround);
    }
    bool IsGroundedCentre() {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
