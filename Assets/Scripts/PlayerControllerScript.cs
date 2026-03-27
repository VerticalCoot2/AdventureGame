using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : CreateEntity
{
    GameObject Player; //Bacon
    Rigidbody2D rb;
    CircleCollider2D circCol;

    [SerializeField] float jumpForce = 400;
    [SerializeField] float horizontalMove;
    [SerializeField] bool jump = false;

    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    [SerializeField] GameObject barbSword;
    [SerializeField] GameObject tankShield;
    [SerializeField] GameObject mageBook;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circCol = GetComponent<CircleCollider2D>();
        Player = this.gameObject;
    }
    private void Start()
    {
        BarbarianClass();
        //TankClass();
        //MageClass();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * agility;

        if (horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if (horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        if(Input.GetKeyDown(jumpKey)) jump = true;
    }

    void FixedUpdate()
    {
        Moving(horizontalMove, jump);  
    }

    void Moving(float movement, bool canJump)
    {
        rb.velocity = new Vector2(movement * 3 * agility * Time.fixedDeltaTime, rb.velocity.y);

        if(canJump && circCol.IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canJump;
        }
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
        var sword = Instantiate(barbSword, gameObject.transform);
        sword.transform.position += new Vector3(0.6f, 0.3f, 0);
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
