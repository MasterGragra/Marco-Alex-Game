using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject BlessingMenuUI;
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
        BlessingMenuUI.SetActive(false);
    }
}
