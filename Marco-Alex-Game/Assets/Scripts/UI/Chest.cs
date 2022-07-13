using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject textBox;
    public string textContent;
    public Text text;

    private Blessing[] blessings;

    [SerializeField] private GameObject blessingMenu;

    private Text[] descriptions;
    private Text[] titles;

    private Animator animator;
    private bool chestOpened;

    public Blessing[] Blessings { get => blessings; set => blessings = value; }


    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        textBox.CompareTag("Chest");
        animator.GetComponent<Animator>();
        animator.SetBool("Pressed", false);
    }


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            text.text = textContent;
            textBox.SetActive(true);
        }
        //Debug.Log("Sign");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.SetActive(false);
        }
        //Debug.Log("Left sign");
    }

    public void OpenChest()
    {
        animator.SetBool("Pressed", true);
        chestOpened = true;
        OpenBlessingMenu();
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
        for (int i = 0; i < Blessings.Length; i++)
        {
            if (randomNumber != i)
            {
                descriptions[index].text = Blessings[i].Description;
                titles[index].text = Blessings[i].BlessingName;
                index++;
            }
        }
    }
}
