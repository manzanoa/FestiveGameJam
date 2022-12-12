using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject scoreUI, crosshairs, endMenu;

    [SerializeField]
    Text scoreText, results;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    
    public void UpdateText()
    { 
        scoreText.text = ScoreKeeper.GetScore().ToString();
    }

    public void EndGame()
    {
        scoreUI.SetActive(false);
        crosshairs.SetActive(false);
        endMenu.SetActive(true);
        results.text = "Score: " + ScoreKeeper.GetScore().ToString();
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
