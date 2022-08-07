using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleporter : MonoBehaviour
{
    
    private int random;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        
                random = Random.Range(2, 6);
                SceneManager.LoadScene(random);
           
           if(GameManager.Instance.LevelCounter >= 5)
            {
                GameManager.Instance.LevelCounter = 0;
                SceneManager.LoadScene("BossLvlOne");
                
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
