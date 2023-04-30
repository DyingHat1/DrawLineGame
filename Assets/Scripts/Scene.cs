using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Scene : MonoBehaviour
{
    [SerializeField] private List<PlayerMovement> _players;
    [SerializeField] private Menu _menu;

    private bool _eventWasInvoked = false;

    private void OnEnable()
    {
        _menu.LevelStarted += OnLevelStarted;

        if (_players.Count > 0)
            foreach (PlayerMovement player in _players)
            {
                player.Win += OnWin;
                player.Lose += OnLose;
            }
    }

    private void OnDisable()
    {
        _menu.LevelStarted -= OnLevelStarted;

        if (_players.Count > 0)
            foreach (PlayerMovement player in _players)
            {
                player.Win -= OnWin;
                player.Lose -= OnLose;
            }
    }

    private void OnWin()
    {
        if (_eventWasInvoked == false)
        {
            if (SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
                _menu.Open(Menu.Screen.ContinueScreen);
            else
                _menu.Open(Menu.Screen.ExitScreen);

            _eventWasInvoked = true;
        }
    }

    private void OnLose()
    {
        if (_eventWasInvoked == false)
        {
            _menu.Open(Menu.Screen.RestartScreen);
            _eventWasInvoked = true;
        }
    }

    private void OnLevelStarted(int sceneId)
    {
        DOTween.Clear(true);
        SceneManager.LoadScene(sceneId);
    }
}
