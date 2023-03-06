using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    
    public bool isAlive;
    public bool isBoy;
    public bool wasKilled;
    public Student studentObj; 
    
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
                if (waitTime <= 0){
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                } else {
                    waitTime -= Time.deltaTime;
                } 
            }
        }

    }
    
}
