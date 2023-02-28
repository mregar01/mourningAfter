using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class StudentSpawner : MonoBehaviour {

      //Object variables
      public GameObject studentPrefab;
      public Transform spawnPoint1;
      public Transform spawnPoint2;
      public Transform spawnPoint3;
      public Transform spawnPoint4;
      public Transform spawnPoint5;
      private Transform spawnPoint; 

      //Timing variables
      public float spawnRangeStart = 110.5f;
      public float spawnRangeEnd = 112.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnStudent();
                  spawnTimer =0f;
            }
      }

      void spawnStudent(){
            int SPnum = Random.Range(1, 5);
            if (SPnum == 1){ spawnPoint = spawnPoint1;}
            else if (SPnum == 2){ spawnPoint = spawnPoint2;}
            else if (SPnum == 3){ spawnPoint = spawnPoint3;}
            else if (SPnum == 4){ spawnPoint = spawnPoint4;}
            else if (SPnum == 5){ spawnPoint = spawnPoint5;}
            Instantiate(studentPrefab, spawnPoint.position, Quaternion.identity);
      }
}