using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullry : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D myRigidBody;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x*bulletSpeed;
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed,0f);

    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Mob")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject); 
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);    
    }
}
