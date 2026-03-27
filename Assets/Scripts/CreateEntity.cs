using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEntity : BaseClassScript
{
    public CreateEntity()
    {
        className = "Entity";
        health = 10;
        strength = 5;
        inteligence = 11;
        agility = 3;
        damage = strength * inteligence;
        canShoot = false;
    }
}
