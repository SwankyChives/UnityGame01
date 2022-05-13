using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysMaster : MonoBehaviour {
    
    public GameObject upArrow;
    public GameObject upArrowPress;
    public GameObject leftArrow;
    public GameObject leftArrowPress;
    public GameObject rightArrow;
    public GameObject rightArrowPress;
    public GameObject spacebar;
    public GameObject spacebarPress;
    
    // Start is called before the first frame update
    void Start() {
        
        
        
    }

    // Update is called once per frame
    void Update() {
        
        // up arrow
        if (Input.GetKey(KeyCode.UpArrow)) {
            upArrow.SetActive(false);
            upArrowPress.SetActive(true);
        } else {
            upArrow.SetActive(true);
            upArrowPress.SetActive(false);
        }
        
        // left arrow
        if (Input.GetKey(KeyCode.LeftArrow)) {
            leftArrow.SetActive(false);
            leftArrowPress.SetActive(true);
        } else {
            leftArrow.SetActive(true);
            leftArrowPress.SetActive(false);
        }

        // right arrow
        if (Input.GetKey(KeyCode.RightArrow)) {
            rightArrow.SetActive(false);
            rightArrowPress.SetActive(true);
        } else {
            rightArrow.SetActive(true);
            rightArrowPress.SetActive(false);
        }

        // spacebar
        if (Input.GetKey(KeyCode.Space)) {
            spacebar.SetActive(false);
            spacebarPress.SetActive(true);
        } else {
            spacebar.SetActive(true);
            spacebarPress.SetActive(false);
        }
    }
}
