using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

public class GameHandler : MonoBehaviour {

        public GameObject scoreText;
        public GameObject timeText;
        public GameObject gameOverText;
        private int playerScore = 0;

        public int gameTime = 20;
        private float gameTimer = 0f;

        void Start(){
                UpdateScore();
                gameOverText.SetActive(false); 
                UpdateTime(); 
        }

        public void AddScore(int points){
                playerScore += points;
                UpdateScore();
        }

        void FixedUpdate(){
                gameTimer += 0.01f;
                if (gameTimer >= 1f){
                                gameTime -= 1;
                                gameTimer = 0;
                                UpdateTime();
                }
                if (gameTime <= 0){ 
                                gameTime = 0; 
                                gameOverText.SetActive(true);
                }
        }

        void UpdateScore(){
                Text scoreTextB = scoreText.GetComponent<Text>();
                scoreTextB.text = "" + playerScore;
        }
        
        public void UpdateTime(){
                Text timeTextB = timeText.GetComponent<Text>();
                timeTextB.text = "" + gameTime;
        }
}