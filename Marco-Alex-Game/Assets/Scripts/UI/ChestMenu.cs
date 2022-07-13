using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMenu : MonoBehaviour
{
    //public Button openButton;
    private bool isChest;
    //public GameObject buttonContainer;
    public Animator animator;
    public bool chestOpened;

    [SerializeField] private Blessing[] blessings;
    [SerializeField] private Text[] descriptions;
    [SerializeField] private Text[] titles;

    [SerializeField] private GameObject blessingMenu;

    // Start is called before the first frame update
    void Start()
    {
        isChest = false;
        //Button btn = openButton.GetComponent<Button>();
        animator = GetComponent<Animator>();
        animator.SetBool("Pressed", false);
        chestOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBlessingMenu()
    {
        if (chestOpened == true)
        {
            DisplayBlessingUI();
            blessingMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    public void DisplayBlessingUI()
    {
        int index = 0;
        int randomNumber = Random.Range(0, 4);
        for (int i = 0; i < blessings.Length; i++)
        {
            if (randomNumber != i)
            {
                descriptions[index].text = blessings[i].Description;
                titles[index].text = blessings[i].BlessingName;
                index++;
            }
        }
    }

    void OnClickButtonOne()
    {
        
    }

     public void OpenChest()
    {
        animator.SetBool("Pressed", true);
        chestOpened = true;
        OpenBlessingMenu();
    }
    

    
    public void DisplayBlessingDescriptions(string desc)
    {
        //desc = blessings.Description;
    }

    public void DisplayBlessingTitle(string desc)
    {
        //desc = blessings.BlessingName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            isChest = true;  
            
        }
        Debug.Log("chest");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            isChest = false;
        }
        Debug.Log("Left chest");
    }
}
