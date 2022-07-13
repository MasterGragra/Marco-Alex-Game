using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{ 
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject pauseMenuButtonContainer;
    


    public void OpenControlPanel()
    {
        controlPanel.SetActive(true);
        pauseMenuButtonContainer.SetActive(false);
    }

    public void CloseControlPanel()
    {
        controlPanel.SetActive(false);
        pauseMenuButtonContainer.SetActive(true);
    }

 
}
