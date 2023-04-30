using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Menu : MonoBehaviour
{
    [SerializeField] private Panel _continueScreen;
    [SerializeField] private Panel _restartScreen;
    [SerializeField] private Panel _exitScreen;
    [SerializeField] private Panel _mainMenuScreen;

    public event UnityAction<int> LevelStarted;

    public void Exit()
    {
        Application.Quit();
    }

    public void Open(Screen panelnumber)
    {
        Time.timeScale = 0;

        switch(panelnumber)
        {
            case Screen.MainMenu:
            {
                ActivatePanel(_mainMenuScreen);
                break;
            }

            case Screen.ContinueScreen:
            {
                ActivatePanel(_continueScreen);
                break;
            }

            case Screen.ExitScreen:
            {
                ActivatePanel(_exitScreen);
                break;
            }

            case Screen.RestartScreen:
            {
                ActivatePanel(_restartScreen);
                break;
            }
        }
        
    }

    public void Close(Panel panel)
    {
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartLevel(int levelNumber)
    {
        Time.timeScale = 1;
        LevelStarted?.Invoke(levelNumber);
    }

    private void ActivatePanel(Panel panel)
    {
        panel.gameObject.SetActive(true);
    }

    public enum Screen
    {
        MainMenu = 0,
        ContinueScreen,
        RestartScreen,
        ExitScreen
    }
}
