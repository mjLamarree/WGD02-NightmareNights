using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EncounterController : MonoBehaviour
{

    public int id;
    public int eventId;

    public GameObject player;
    public GameObject interactableObject;

    [SerializeField] private float spawnDistance = 3.5f;
    [SerializeField] private int maxNumberOfEnemies = 0;
    [SerializeField] private GameObject[] enemyPool = new GameObject[1];
    [SerializeField] private GameObject[] spawnPoints = new GameObject[2];

    private int numberOfSpawnedEnemies = 0;
    private List<GameObject> availableSpawnPoints = new List<GameObject>();

    private void Start() {
        
        if(interactableObject != null)
        {
            DisableInteractableObject(interactableObject);
        }
        
    }

    private void Update()
    {

        if (numberOfSpawnedEnemies != maxNumberOfEnemies)
        {
            LookForAvailableSpawnPoints();

            foreach(GameObject spawnPoint in availableSpawnPoints)
            {
                if (GetDistanceFromSpawnPointToPlayer(spawnPoint) >= spawnDistance 
                    && numberOfSpawnedEnemies != maxNumberOfEnemies)
                {
                    SpawnEnemy(spawnPoint);
                    break;
                }
            }

        }

        if (CheckForEndEncounter()) { EndEncounter(); }

    }

    private void EndEncounter()
    {
        if (interactableObject != null)
        {
            EnableInteractableObject(interactableObject);
        }
        else
        {
            TriggerEventBasedOnEventSystem();
        }

        DisableEncounterController();
    }

    private void TriggerEventBasedOnEventSystem()
    {
        switch (eventId)
        {
            case 1:
                FirstAreaEvents.current.ButtonTrigger();
                break;
            case 2:
                SecondAreaEventSystem.current.TriggerEndEncounter(id);
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    private bool CheckForEndEncounter()
    {

        bool allEnemiesAreSlained = true;

        if(numberOfSpawnedEnemies == maxNumberOfEnemies)
        {
            foreach(GameObject spawnPoint in spawnPoints)
            {
                if(spawnPoint.transform.childCount != 0)
                {
                    allEnemiesAreSlained = false;
                    break;
                } 
            }

            if (allEnemiesAreSlained)
            {
                return true;
            }
            
        }

        return false;

    }

    private void SpawnEnemy(GameObject spawnLocation)
    {
        Instantiate(DetermineEnemyType(), spawnLocation.transform);
        numberOfSpawnedEnemies++;
        availableSpawnPoints.Remove(spawnLocation);
    }

    private void LookForAvailableSpawnPoints()
    {

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(spawnPoints[i].transform.childCount == 0 && availableSpawnPoints.Contains(spawnPoints[i]) == false) { 
                availableSpawnPoints.Add(spawnPoints[i]);
            }
        }

    }

    private GameObject DetermineEnemyType()
    {
        int randomIndex = (enemyPool.Length == 1) ? 0 : UnityEngine.Random.Range(0, enemyPool.Length-1);
        return enemyPool[randomIndex];
    }

    private float GetDistanceFromSpawnPointToPlayer(GameObject currentSpawnPoint)
    {
        float x1 = currentSpawnPoint.transform.position.x;
        float y1 = currentSpawnPoint.transform.position.y;

        float x2 = player.transform.position.x;
        float y2 = player.transform.position.y;

        return Mathf.Sqrt(Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2));
    }

    void DisableEncounterController() { this.gameObject.SetActive(false); }

    private void DisableInteractableObject(GameObject interactableObject)
    {
        /*Button.GetComponent<TilemapCollider2D>().enabled = false;
        Button.GetComponent<TilemapRenderer>().enabled = false;*/
        interactableObject.SetActive(false);
    }

    private void EnableInteractableObject(GameObject interactableObject)
    {
        /*Button.GetComponent<TilemapCollider2D>().enabled = true;
        Button.GetComponent<TilemapRenderer>().enabled = true;*/
        interactableObject.SetActive(true);
    }

}
