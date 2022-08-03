using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour
{
    //dex titles
    [SerializeField] private Text agilityTitle;
    [SerializeField] private Text invigorationTitle;
    [SerializeField] private Text momentumTitle;
    [SerializeField] private Text vitalityTitle;

    //dex descriptions
    [SerializeField] private Text agilityDesc;
    [SerializeField] private Text invigorationDesc;
    [SerializeField] private Text momentumDesc;
    [SerializeField] private Text vitalityDesc;

    //Element titles
    [SerializeField] private Text fireTitle;
    [SerializeField] private Text windTitle;
    [SerializeField] private Text earthTitle;
    [SerializeField] private Text healTitle;

    //Element descriptions
    [SerializeField] private Text fireDesc;
    [SerializeField] private Text windDesc;
    [SerializeField] private Text earthDesc;
    [SerializeField] private Text HealDesc;

    //Might titles
    [SerializeField] private Text alacrityTitle;
    [SerializeField] private Text enduranceTitle;
    [SerializeField] private Text fortitudeTitle;
    [SerializeField] private Text powerTitle;

    //Might descriptions
    [SerializeField] private Text alacrityDesc;
    [SerializeField] private Text enduranceDesc;
    [SerializeField] private Text fortitudeDesc;
    [SerializeField] private Text powerDesc;

    //Wisdom titles
    [SerializeField] private Text acuityTitle;
    [SerializeField] private Text expansionTitle;
    [SerializeField] private Text insightTitle;
    [SerializeField] private Text knowledgeTitle;

    //Wisdom descriptions
    [SerializeField] private Text acuityDesc;
    [SerializeField] private Text expansionDesc;
    [SerializeField] private Text insightDesc;
    [SerializeField] private Text knowledgeDesc;

    [SerializeField] private GameObject pauseMenuButtonContainer;
    [SerializeField] private GameObject statMenu;

   public void loadstats()
    {
        
    }
}
