using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    Vector3 velocity;
    Rigidbody playerRigidbody;
    Collider playerCollider;
    float distToGround;
    bool jumpPressed;
    bool isGrounded;
    public event Action Text1;
    public event Action Text2;
    public event Action Text3;

    //Vector3 velocityLastFrame = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        distToGround = playerCollider.bounds.extents.y + 0.1f;
        playerRigidbody.velocity = Vector3.zero;
        //distToGround = playerCollider.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        // calculates velocity
        Vector3 direction = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
        velocity = direction * speed;

        // activates jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && (jumpPressed == false)) {
            jumpPressed = true;
        }

        //Debug.DrawRay(transform.position + Vector3.left * (transform.localScale.x - 0.01f) / 2, Vector3.down, Color.red, distToGround);

        //print(IsGrounded());
    }

    private void FixedUpdate() {

        // jump
        if (jumpPressed == true && isGrounded && RayIsGrounded()) {
            playerRigidbody.velocity += Vector3.up * jumpForce;
            jumpPressed = false;
        }

        // checks if player is on ground, then moves.
        if (isGrounded) {
            playerRigidbody.velocity += velocity * Time.fixedDeltaTime;
        }

        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    // tests if player is on ground (taken from multiple rays, definitely better way to do this.
    
    bool RayIsGrounded() {
        return (RayIsGroundedLeft() || RayIsGroundedRight() || RayIsGroundedCentre());
    }

    bool RayIsGroundedRight() {
        return Physics.Raycast(transform.position + Vector3.right * (transform.localScale.x - 0.01f) / 2, Vector3.down, distToGround);
    }
    bool RayIsGroundedLeft() {
        return Physics.Raycast(transform.position + Vector3.left * (transform.localScale.x - 0.01f) / 2, Vector3.down, distToGround);
    }
    bool RayIsGroundedCentre() {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }

    void OnCollisionEnter(Collision floorCollision) {
        if (floorCollision.gameObject.tag == "floor") {
            isGrounded = true;
        }
    }

    void OnCollisionStay(Collision floorCollision) {
        if (floorCollision.gameObject.tag == "floor") {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision floorCollision) {
        if (floorCollision.gameObject.tag == "floor") {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider triggerCollider) {
        //makes the text appearences dynamically
        if (triggerCollider.gameObject.tag == "text1") {
            Text1();
        }
        if (triggerCollider.gameObject.tag == "text2") {
            Text2();
        }
        if (triggerCollider.gameObject.tag == "text3") {
            Text3();
        }
        if (triggerCollider.gameObject.tag == "Finish") {
            Application.Quit();
        }
        if (triggerCollider.gameObject.tag == "Respawn") {
            SceneManager.LoadScene("Concept");
        }
    }
}
