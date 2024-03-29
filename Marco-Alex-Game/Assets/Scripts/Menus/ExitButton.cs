using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject blessingMenuUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject teleporter;
    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void CloseBlessingMenu()
    {
        blessingMenuUI.SetActive(false);
        Time.timeScale = 1;
        teleporter.SetActive(true);
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; 
    }
}
