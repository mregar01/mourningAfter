using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

        public GameObject scoreText;
        public GameObject timeText;
        public GameObject gameOverText;
        public GameObject gameWonText;
        public GameObject noSuspicion;
        public GameObject oneSuspicion;
        public GameObject twoSuspicion;
        public GameObject threeSuspicion;

        private int playerScore = 0;
        public int suspicion = 0;
        public bool playerCarryingBody = false;

        public int gameTime = 20;
        private float gameTimer = 0f;

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;

        void Awake (){ 
                SetLevel (volumeLevel); 
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider"); 
                if (sliderTemp != null){ 
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>(); 
                        sliderVolumeCtrl.value = volumeLevel; 
                }
        }

        void Start(){
                UpdateScore();
                gameOverText.SetActive(false); 
                gameWonText.SetActive(false);
                noSuspicion.SetActive(true);
                oneSuspicion.SetActive(false);
                twoSuspicion.SetActive(false);
                threeSuspicion.SetActive(false);
                UpdateTime(); 

                pauseMenuUI.SetActive(false); // audio
                GameisPaused = false;
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }

        void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20); 
                volumeLevel = sliderValue; 
        } 

        public void AddScore(int points){
                playerScore += points;
                UpdateScore();
        }

        public void UpdatePlayerCarryingBody(bool carryingbody) {
                playerCarryingBody = carryingbody;
        }

        public bool getPlayerCarryingBody() {
                return playerCarryingBody;
        }

        void FixedUpdate(){
                gameTimer += 0.01f;
                if (gameTimer >= 1f){
                                gameTime -= 1;
                                gameTimer = 0;
                                UpdateTime();
                }
                if (gameTime <= 0 || suspicion >= 4){ 
                                print("game over");
                                gameTime = 0; 
                                gameOverText.SetActive(true);
                }
                if (playerScore >=5) {
                        gameTime = 0;
                        gameWonText.SetActive(true);
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

        public void StartGameEasy(){
                SceneManager.LoadScene("Scene1");
        }

        public void StartGameMedium(){
                SceneManager.LoadScene("Scene2");
        }

        public void StartGameHard(){
                SceneManager.LoadScene("Scene3");
        }

        public void StartGameImpossible(){
                SceneManager.LoadScene("Scene4");
        }

        public void OpenCredits(){
                SceneManager.LoadScene("Credits");
        }

        public void RestartGame(){ 
                Time.timeScale = 1f; 
                // Add commands to zero-out any scores or other stats before restarting 
                SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame(){ 
                #if UNITY_EDITOR 
                UnityEditor.EditorApplication.isPlaying = false; 
                #else 
                Application.Quit(); 
                #endif 
        }
}