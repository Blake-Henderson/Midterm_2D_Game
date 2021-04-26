using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// The health of the enemy
    /// </summary>
    public int health = 3;
    /// <summary>
    /// The points awarded for killing the enemy
    /// </summary>
    public int pointValue = 25;
    /// <summary>
    /// Breif time between when the enemey can take damage to prevent double impacts
    /// </summary>
    public float damageTime = 0.1f;
    /// <summary>
    /// The timer
    /// </summary>
    private float timer = 0.0f;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(health <= 0)
        {
            GameManager.instance.addToScore(pointValue);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            if (timer >= damageTime)
            {
                health--;
                timer = 0.0f;
            }
        }
    }
}
