using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int gold = 0;
    private int levelCounter = 0;
    private int enemyCounter = 0;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject teleporter;

    public static GameManager Instance { get => instance; set => instance = value; }
    public int Gold { get => gold; set => gold = value; }
    public int EnemyCounter { get => enemyCounter; set => enemyCounter = value; }

    [SerializeField] private Blessing[] might;
    [SerializeField] private Blessing[] wisdom;
    [SerializeField] private Blessing[] elements;
    [SerializeField] private Blessing[] dexterity;

    [SerializeField] private Blessing[] fire;
    [SerializeField] private Blessing[] wind;
    [SerializeField] private Blessing[] earth;
    [SerializeField] private Blessing[] healing;

    [SerializeField] private GameObject[] lesserChests;
    [SerializeField] private GameObject[] greaterChests;

    [SerializeField] private GameObject greaterChestContainer;
    [SerializeField] private GameObject lesserChestContainer;

    [SerializeField] private bool bossroom = false;

    [SerializeField] private GameObject pauseMenu;


    void SpawnLesserChest()
    {
        lesserChestContainer.SetActive(true);
        int index = 0;
        int randomNumber = Random.Range(0, 4);
        if(randomNumber != 0)
        {
            lesserChests[index].GetComponent<Chest>().Blessings = might;
            index++;
        }
        if (randomNumber != 1)
        {
            lesserChests[index].GetComponent<Chest>().Blessings = wisdom;
            index++;
        }
        if (randomNumber != 2)
        {
            lesserChests[index].GetComponent<Chest>().Blessings = dexterity;
            index++;
        }
        if (randomNumber != 3)
        {
            lesserChests[index].GetComponent<Chest>().Blessings = elements;
            index++;
        }
    }

    void SpawnGreaterChest()
    {
        greaterChestContainer.SetActive(true);
        int index = 0;
        int randomNumber = Random.Range(0, 3);
        if (randomNumber != 0)
        {
            greaterChests[index].GetComponent<Chest>().Blessings = fire;
            index++;
        }
        if (randomNumber != 1)
        {
            greaterChests[index].GetComponent<Chest>().Blessings = wind;
            index++;
        }
        if (randomNumber != 2)
        {
            greaterChests[index].GetComponent<Chest>().Blessings = earth;
            index++;
        }
        if (randomNumber != 3)
        {
            greaterChests[index].GetComponent<Chest>().Blessings = healing;
            index++;
        }
    }

    public void GamePaused()
    {
        if (pauseMenu == true)
        {
            Time.timeScale = 1;
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    void Start()
    {
        foreach(GameObject enemy in enemies)
        {
            EnemyCounter++;
        }
        if (bossroom) SpawnGreaterChest();
        else SpawnLesserChest();
        lesserChestContainer.SetActive(false);
        greaterChestContainer.SetActive(false);
    }
    private void Update()
    {
        if(EnemyCounter <= 0)
        {
            teleporter.SetActive(true);
        }
    }
}
