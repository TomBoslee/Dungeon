using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField seed;
    public TMP_Dropdown difficulty;

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        WorldInfo.SetSeed(seed.text);
    }

    public void SetDifficulty(int i) { WorldInfo.SetDifficulty(i);}

    public void StopGame()
    {
        Application.Quit();
    }
}
