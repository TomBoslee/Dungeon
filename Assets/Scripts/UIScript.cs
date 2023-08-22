using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public static bool isPaused = false;
    public static bool isFinished = false;
    public static bool Gameover = false;

    public GameObject GameOverUI;
    public GameObject MapUI;
    public GameObject Health;
    public GameObject PauseUI;
    public TMP_Text help;
    public GameObject WinUI;
    public Slider HealthSlider;
    public TMP_Text HpText;
    public TMP_Text LevelText;
    private int health;
    private int maxHP;
    private int level;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Gameover = false;
    }
    void Update()
    {
        health = player.GetComponent<Player>().GetHp();
        if (health == 0) { Gameover = true; }
        maxHP = player.GetComponent<Player>().GetMaxHp();
        HealthSlider.maxValue = maxHP;
        HealthSlider.value = health;
        HpText.text = health + "/" + maxHP;
        level = player.GetComponent<Player>().GetPlayerLevel();
        LevelText.text = "Player Level:" + level;
        Destroy(help, 10f);
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) { resume(); } else { pause(); }
        }
        if (Input.GetKeyDown(KeyCode.M)) { 
            if (isPaused) { resume(); } else { DisplayMap(); } 
        }
        if(isFinished) { GameWin(); }
        if(Gameover) { GameOver(); }

    }

    private void GameOver() {
        Health.SetActive(false);
        GameOverUI.SetActive(true);
        GameOverUI.GetComponentsInChildren<TMP_Text>()[2].text = "SEED:" + WorldInfo.GetSeed();
        Time.timeScale = 0f;
    }

    private void GameWin() {
        Health.SetActive(false);
        WinUI.SetActive(true);
        WinUI.GetComponentInChildren<TMP_Text>().text = "SEED:" + WorldInfo.GetSeed();
        Time.timeScale = 0f;

    }

    private void pause() { 
        PauseUI.SetActive(true); 
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void DisplayMap() {
        MapUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resume() {
        MapUI.SetActive(false);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu() {
        isPaused = false;
        isFinished = false;
        AddRoom.AmountOfRooms = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
