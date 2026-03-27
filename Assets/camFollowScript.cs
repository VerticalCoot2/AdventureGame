using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollowScript : MonoBehaviour
{
    Transform player;
    void Awake()
    {
        player = GameObject.Find("Bacon").transform;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3
        (
            Mathf.Lerp(transform.position.x, player.position.x, 0.1f),
            transform.position.y,
            -1
        );
        if(player.position.y >= 0)
        {
            transform.position = new Vector3
            (
                transform.position.x,
                Mathf.Lerp(transform.position.y, player.position.y, 0.2f),
                -1
            );
        }
    }
}
