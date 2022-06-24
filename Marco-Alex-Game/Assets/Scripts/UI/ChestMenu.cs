using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMenu : MonoBehaviour
{
    public Button acceptButton;
    private bool ischest;
    public GameObject buttonContainer;
    public GameObject spellCover;
    public Animator animator;
   

    // Start is called before the first frame update
    void Start()
    {
        buttonContainer.SetActive(false);
        ischest = false;
        Button btn = acceptButton.GetComponent<Button>();
        animator = GetComponent<Animator>();
        animator.SetBool("btnPressed", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        spellCover.SetActive(false);
        OpenChest();
    }

    private void OpenChest()
    {
        animator.SetBool("btnPressed", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {

            ischest = true;
            buttonContainer.SetActive(true);

        }
        Debug.Log("chest");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            ischest = false;
            buttonContainer.SetActive(false);
        }
        Debug.Log("Left chest");
    }
}
