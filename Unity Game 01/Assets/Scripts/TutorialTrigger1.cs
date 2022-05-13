using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger1 : MonoBehaviour {
    
    public GameObject floor9;
    public GameObject textwall1;
    public GameObject textwall2;
    
    // Start is called before the first frame update
    void Start() {
        
        floor9.SetActive(false);
        textwall1.SetActive(true);
        textwall2.SetActive(false);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        
        
        
    }

    void OnTriggerEnter(Collider other) {
        floor9.SetActive(true);
        textwall1.SetActive(false);
        textwall2.SetActive(true);
        gameObject.SetActive(false);
        //print("Object entered the trigger");
    }
}
