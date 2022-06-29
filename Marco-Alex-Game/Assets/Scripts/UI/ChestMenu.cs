using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMenu : MonoBehaviour
{
    public Button openButton;
    private bool isChest;
    public GameObject buttonContainer;
    public Animator animator;
   

    // Start is called before the first frame update
    void Start()
    {
        buttonContainer.SetActive(false);
        isChest = false;
        Button btn = openButton.GetComponent<Button>();
        animator = GetComponent<Animator>();
        animator.SetBool("Pressed", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        OpenChest();
    }

    private void OpenChest()
    {
        animator.SetBool("Pressed", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            isChest = true;
            buttonContainer.SetActive(true);
        }
        Debug.Log("chest");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            isChest = false;
            buttonContainer.SetActive(false);
        }
        Debug.Log("Left chest");
    }
}
