using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private Animation anim;
    public int Damage;

    void Start()
    {
        anim = GetComponent<Animation>();        
        GameObject player = GameObject.Find("Player");
        Damage = player.GetComponent<BaseClassScript>().damage;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            // BaseClassScript EnemyClass = collision.gameObect.GetComponent<BaseClassScript>();
            var EnemyClass = collision.gameObject.GetComponent<BaseClassScript>();
            
            EnemyClass.health -= Damage;

            if (EnemyClass.health <= 3)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            if (EnemyClass.health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
