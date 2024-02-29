using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public List<GameObject> target;

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject optionScreen;

    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;
    // [SerializeField] GameObject gun;
    // [SerializeField] GameObject mouse;
    [SerializeField] GameObject gunCtrl;

    

    public Button restartGame;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI overtext;

    public float spawnRate = 1.0f;
    public int score = 0;

    public bool isGameActive = false;
    
    public bool paused;


    private void AdjustGameUpdateFrequency(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }

    private void Start() {
        Instance = this;
        // StartCoroutine(SpawnTarget());
        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            ChangePaused();
        }

        if(score < 0 ) {
            GameOVer();
        }
    }
    IEnumerator SpawnTarget() {

        while(isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int randomTarget = Random.Range(0, target.Count);

            Instantiate(target[randomTarget]);
        }
    }

    public void StartGame(float difficulty){
        isGameActive = true;
        startScreen.SetActive(false);
        gunCtrl.SetActive(true);
        score = 0;
        spawnRate = difficulty;
        AdjustGameUpdateFrequency(0.5f);
        StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void ChooseDiffclt() {
        titleScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    

    public void OptionsSetting() {
        optionScreen.SetActive(true);
    }

    void ChangePaused() {
        if(!paused) {
            paused = true;
            pauseScreen.SetActive(true);
            AdjustGameUpdateFrequency(0f);
        } else {
            paused =false;
            pauseScreen.SetActive(false);
            AdjustGameUpdateFrequency(0.5f);
        }
    }

    public void GameOVer() {
        isGameActive = false;
        gunCtrl.SetActive(false);
        gameOverScreen.SetActive(true);
        AdjustGameUpdateFrequency(0.5f);
    }

    

    public void mainButton() {
        pauseScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
