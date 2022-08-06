using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleporter : MonoBehaviour
{
    private int counter = 0;
    private int random;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            counter++;
           if(counter != 5)
            {
                random = Random.Range(2, 6);
                SceneManager.LoadScene(random);
            }
           if(counter == 5)
            {
                counter = 0;
                random = Random.Range(6, 9);
                SceneManager.LoadScene(random);

            }    
        }
        //Debug.Log("Sign");
    }

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
