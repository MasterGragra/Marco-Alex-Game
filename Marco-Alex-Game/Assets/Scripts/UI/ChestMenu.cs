using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMenu : MonoBehaviour
{
    public GameObject acceptButton;
    private bool ischest;
    // Start is called before the first frame update
    void Start()
    {
        acceptButton.SetActive(false);
        ischest = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {

            ischest = true;
            acceptButton.SetActive(true);
        }
        Debug.Log("chest");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chest")
        {
            ischest = false;
            acceptButton.SetActive(false);
        }
        Debug.Log("Left chest");
    }
}
