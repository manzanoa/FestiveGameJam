using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu, credits, instructions;

    public void ToCredits()
    {
        mainMenu.SetActive(false);
        instructions.SetActive(false);
        credits.SetActive(true);
    }

    public void ToInstructions()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false);
        instructions.SetActive(true);
        
    }

    public void ToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        instructions.SetActive(false);
    }
}
