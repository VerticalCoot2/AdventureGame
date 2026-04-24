using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawningEnemies : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject FirstSpawn;
    public GameObject SecondSpawn;
    public int MaxNumberOfEnemies = 2;
    private bool allEnemiesSpawned = false;

    private void Start()
    {
        StartCoroutine(Spawning());    
    }

    private void Update()
    {
        if (transform.childCount == 0 && allEnemiesSpawned)
        {
            if (SceneManager.GetActiveScene().name == "Level_1")
            {
                SceneManager.LoadScene("Level_2");
            }
            else 
            {
                SceneManager.LoadScene("Level_1");
            }
        }
    }
    private IEnumerator Spawning()
    {
        Vector2 spawnPoint = new();
        for (int i = 0; i < MaxNumberOfEnemies; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                spawnPoint = new Vector2(FirstSpawn.transform.position.x, FirstSpawn.transform.position.y);
            }
            else
            {
                spawnPoint = new Vector2(SecondSpawn.transform.position.x, SecondSpawn.transform.position.y);
            }
            Instantiate(Enemy, spawnPoint, Quaternion.identity, transform);
            yield return new WaitForSeconds(3f);
        }
        allEnemiesSpawned = true;
    }

}
