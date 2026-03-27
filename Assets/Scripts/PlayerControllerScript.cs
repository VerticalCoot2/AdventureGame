using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : BaseClassScript
{
    [SerializeField] GameObject Player; //Bacon
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = this.gameObject;
    }
    private void Start()
    {
        BarbarianClass();
        //TankClass();
        //MageClass();
        StartCoroutine(Launch());
    }
    IEnumerator Launch()
    {
        yield return new WaitForSeconds(5);
        rb.AddForce(new Vector2(50, 200) * 5);
    }
    void BarbarianClass()
    {
        className = "Barbarian";
        health = 15;
        inteligence = 2;
        strength = 15;
        agility = 7;
        damage = strength / inteligence;
        canShoot = false;
    }

    void TankClass()
    {
        className = "Tank";
        health = 25;
        inteligence = 7;
        strength = 8;
        agility = 3;
        damage = strength / agility;
        canShoot = false;
    }
    void MageClass()
    {
        className = "Mage";
        health = 7;
        inteligence = 25;
        strength = 5;
        agility = 10;
        damage = inteligence / health;
        canShoot = true;
    }
}
