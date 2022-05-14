using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockV2 : MonoBehaviour {
    
    public GameObject player;
    public GameObject marker;
    Transform target;
    Rigidbody targetRigidbody;
    Transform playerMarkerTransform;
    Rigidbody playerMarkerRigidbody;
    public float smoothSpeed;
    //  public float markerSmoothSpeed;
    //public float betterMarkerSmoothSpeed;
    public Vector3 offset;
    Vector3 markerSmoothVelocity;
    Vector3 cameraVelocity;
    //Vector3 smoothMarkerVelocity;
    
    public float dampenAmount;
    public float offsetDampen;
    public float markerVelocityScalar;
    Vector3 markerVelocity;
    Vector3 prevPos;

    // Start is called before the first frame update
    void Start() {
        
        target = player.GetComponent<Transform>();
        targetRigidbody = player.GetComponent<Rigidbody>();
        playerMarkerTransform = marker.GetComponent<Transform>();
        playerMarkerRigidbody = marker.GetComponent<Rigidbody>();
        prevPos = playerMarkerTransform.position;
    }

    void Update() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        /*float markerSmoothSpeedCalc = smoothSpeed * targetRigidbody.velocity.magnitude;
        Vector3 targetDirection = targetRigidbody.velocity * dampenAmount;
        Vector3 velocityPosition = target.position + targetDirection;
        Vector3 smoothedMarkerPosition = Vector3.SmoothDamp(target.position, velocityPosition, ref markerVelocity, markerSmoothSpeed * Time.deltaTime);
        Vector3 betterSmoothedMarkerPos = Vector3.SmoothDamp(playerMarker.transform.position, smoothedMarkerPosition, ref smoothMarkerVelocity, betterMarkerSmoothSpeed * Time.deltaTime);
        playerMarker.position = betterSmoothedMarkerPos;*/
        
        //markerVelocity = (playerMarkerTransform.position - prevPos) / Time.fixedDeltaTime;

        //prevPos = playerMarkerTransform.position;


        // finds desired position
        Vector3 targetDirection = targetRigidbody.velocity * dampenAmount;
        Vector3 velocityPosition = target.position + targetDirection;

        
        // 
        markerVelocity = playerMarkerTransform.position - prevPos;
        prevPos = playerMarkerTransform.position;
        
        Vector3 markerPosWithVelocity = playerMarkerTransform.position + (markerVelocity * markerVelocityScalar * Time.fixedDeltaTime);
        
        // Vector3 smoothedMarkerPosition = Vector3.SmoothDamp(target.position, velocityPosition, ref markerSmoothVelocity, markerSmoothSpeed * Time.deltaTime);
        Vector3 relativeOffset = velocityPosition - markerPosWithVelocity;
        Vector3 relativeDesiredOffset = (markerPosWithVelocity + (relativeOffset / 2)) - playerMarkerTransform.position; 
        playerMarkerTransform.Translate(relativeOffset * offsetDampen * Time.fixedDeltaTime);
        print(markerVelocity);

        transform.LookAt(playerMarkerTransform);
        //prevPos = playerMarkerTransform.position;
        //smooths camera position
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref cameraVelocity, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
