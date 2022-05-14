using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger1 : MonoBehaviour {
    
    public GameObject playerReference; 
    Rigidbody playerRigidbody;
    public GameObject floor9;
    public GameObject textwall1;
    public GameObject textwall2;
    public GameObject basicPlatform2;
    // dynamic text spawns
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    PlayerController player;

    private Vector3 newTextSpawn;
    public float textSpawnDist;

    // Start is called before the first frame update
    void Start() {
        floor9.SetActive(false);
        textwall1.SetActive(true);
        textwall2.SetActive(false);
        gameObject.SetActive(true);
        player = FindObjectOfType<PlayerController>();
        player.Text1 += Text1Action; 
        player.Text2 += Text2Action; 
        player.Text3 += Text3Action; 
        playerRigidbody = playerReference.GetComponent<Rigidbody>();
    }

    void Update() {
        //playerRigidbody.velocity.normalized;
        newTextSpawn = playerReference.transform.position + (playerRigidbody.velocity.normalized * textSpawnDist);
    }

    void OnTriggerEnter(Collider other) {
        floor9.SetActive(true);
        textwall1.SetActive(false);
        textwall2.SetActive(true);
        basicPlatform2.transform.Translate(Vector3.left * 0.5f);
    }

    

    public void Text1Action() {
        text1.transform.position = newTextSpawn;
    }
    public void Text2Action() {
        text2.transform.position = newTextSpawn;
    }
    public void Text3Action() {
        text3.transform.position = newTextSpawn;
    }
}
