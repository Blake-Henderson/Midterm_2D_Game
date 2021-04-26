using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Blake Henderson
//Date : 4/20/2021
public class Projectile : MonoBehaviour
{
    /// <summary>
    /// The force behind the bullet
    /// </summary>
    public int thrust = 100;
    /// <summary>
    /// The time it takes the bullet to despwan
    /// </summary>
    public float despawnTime = 1.0f;
    /// <summary>
    /// The rigid body of the projectile
    /// </summary>
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        BulletDepawn();
        //transform.rotation.Set(0f, 0f, 90f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(transform.right * thrust);
    }
    /// <summary>
    /// Despawns the bullet after a given number of time.
    /// </summary>
    private void BulletDepawn()
    {
        Destroy(gameObject, despawnTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Loot")
        {
            Destroy(gameObject);
        }
    }
}