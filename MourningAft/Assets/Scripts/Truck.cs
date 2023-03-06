using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public bool playerInRadiusTruck;
    public GameHandler gameHandlerObj;
    private string truckDetectionTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){ 
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRadiusTruck) {
            print("player close to truck");
        } else {
            print("player far from truck");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag(truckDetectionTag)){
            playerInRadiusTruck = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag(truckDetectionTag)){
            playerInRadiusTruck = false;
        }
    }
}
