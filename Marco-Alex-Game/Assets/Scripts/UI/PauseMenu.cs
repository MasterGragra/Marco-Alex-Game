using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] private GameObject PauseMenuUI;
    private bool pause = false;

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        pause = context.performed;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
        {
            pause = false;
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
}
