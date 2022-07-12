using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMenu : MonoBehaviour
{
    public Button openButton;
    private bool isChest;
    //public GameObject buttonContainer;
    public Animator animator;
    public bool chestOpened;

    [SerializeField] private GameObject blessingMenu;
    [SerializeField] private GameObject textboxOne;
    [SerializeField] private GameObject textboxTwo;
    [SerializeField] private GameObject textboxThree;
    [SerializeField] private GameObject textboxFour;
    [SerializeField] private GameObject blessingOneTitle;
    [SerializeField] private GameObject blessingTwoTitle;
    [SerializeField] private GameObject blessingThreeTitle;
    [SerializeField] private GameObject blessingFourTitle;
    //[SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        isChest = false;
        Button btn = openButton.GetComponent<Button>();
        animator = GetComponent<Animator>();
        animator.SetBool("Pressed", false);
        chestOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenBlessingMenu()
    {
        if (chestOpened == true)
        {
            blessingMenu.SetActive(true);
        }
    }

    private void OpenChest()
    {
        animator.SetBool("Pressed", true);
        chestOpened = true;
        OpenBlessingMenu();
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
