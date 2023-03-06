using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CopPatrolHit : MonoBehaviour {
    
       public float speed;
       public Transform[] moveSpots;
       public Transform copNPC;
       private int randomSpot;
       private float waitTime;
       public float startWaitTime;
       private string detectionTag = "Player";
       public bool playerInRadius;
       public float raidus; // radius
       public GameHandler gameHandlerObj;
       
       void Start(){
           if (GameObject.FindWithTag("GameHandler") != null){ 
                 gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
           }
           waitTime = startWaitTime;
           randomSpot = Random.Range(0, moveSpots.Length);
       }
       
       void Update(){
           transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
           if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
               if (waitTime <= 0){
                   randomSpot = Random.Range(0, moveSpots.Length);
                   waitTime = startWaitTime;
               } else {
                   waitTime -= Time.deltaTime;
               } 
           }
           
        //    if (playerInRadius){
        //        print("player found");
        //        gameHandlerObj.suspicion = 5;
        //        print(gameHandlerObj.suspicion);
        //    } else {
        //        print("player lost");
        //        gameHandlerObj.suspicion = 0;
        //        print(gameHandlerObj.suspicion);
        //    }
       }
       
       private void OnTriggerEnter2D(Collider2D collision){
           if (collision.CompareTag(detectionTag)){
                playerInRadius = true;
                if (gameHandlerObj.getPlayerCarryingBody()) {
                    print("Policeman: found player carrying a body");
                }
                copNPC = collision.gameObject.transform;
           }
       }
       
       private void OnTriggerExit2D(Collider2D collision){
           if (collision.CompareTag(detectionTag)){
               playerInRadius = false;
               copNPC = null;
           }
       }
      
}