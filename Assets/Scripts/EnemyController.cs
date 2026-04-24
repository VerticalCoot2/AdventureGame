using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : CreateEntity
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");

        if (Random.Range(0,2) == 0)
        {
            DefaultEnemy();
        }
        else
        {
            HardEnemy();
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 2f * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    private void DefaultEnemy()
    {
        health = 1;
        strength = 10;
        agility = 1;
        inteligence = 0;
        damage = 100;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void HardEnemy()
    {
        health = 4;
        strength = 10;
        agility = 1;
        inteligence = 0;
        damage = 100;
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
