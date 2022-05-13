using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{

    public GameObject playerReference;
    public float rotX;
    public float rotY;
    public float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerReference.transform.position.x, playerReference.transform.position.y, playerReference.transform.position.z - 15);
    }
}
