using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuChoices : MonoBehaviour
{ 
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject skillPanel;
    [SerializeField] private GameObject statPanel;
    [SerializeField] private GameObject volumePanel;
    [SerializeField] private GameObject pauseMenuButtonContainer;
    
    public void OpenVolumePanel()
    {
        volumePanel.SetActive(true);
        pauseMenuButtonContainer.SetActive(false);
    }

    public void CloseVolumePanel()
    {
        volumePanel.SetActive(false);
        pauseMenuButtonContainer.SetActive(true);
    }
    public void OpenStatPanel()
    {
        statPanel.SetActive(true);
        pauseMenuButtonContainer.SetActive(false);
    }
   
    public void CloseStatPanel()
    {
        statPanel.SetActive(false);
        pauseMenuButtonContainer.SetActive(true);
    }

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
