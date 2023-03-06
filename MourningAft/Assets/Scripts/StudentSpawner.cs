using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class StudentSpawner : MonoBehaviour {

      //Object variables
      public Student[] students;
      public Transform[] spots;

      //Timing variables
      public float spawnRangeStart = 110.5f;
      public float spawnRangeEnd = 112.2f;
      private float timeToSpawn;
      private float spawnTimer = 10;
      public GameHandler gameHandlerObj;
      
      void Start()
      {
          if (GameObject.FindWithTag("GameHandler") != null){ 
                gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
          }
      }

      void FixedUpdate()
      {
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnStudent();
                  spawnTimer = 0f;
            }
      }

      public void spawnStudent(){
            int randomSpot = Random.Range(0, spots.Length);
            int randomStudent = Random.Range(0, students.Length);
            int isaboy = Random.Range(0, 1);
            Student currStudent = students[randomStudent];
            
            if (isaboy == 1){
                currStudent.isBoy = true;
            } else {
                currStudent.isBoy = false;
            }
            
            
            if (gameHandlerObj.gameTime % 7 == 0) {
                currStudent.isAlive = false;
                currStudent.wasKilled = false;
            } else {
                currStudent.isAlive = true;
                currStudent.wasKilled = false;
            }
            
            Instantiate(currStudent, spots[randomSpot].position, Quaternion.identity);
      }
}