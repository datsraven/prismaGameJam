using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainPanel;

    public GameObject CreditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowCredits()
    {
        CreditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        CreditsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
