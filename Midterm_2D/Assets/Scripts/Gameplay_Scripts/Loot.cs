using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    /// <summary>
    /// Determines if loot has already been collected to prevent double looting
    /// </summary>
    public bool collected = false;
    /// <summary>
    /// The point value of collecting the loot
    /// </summary>
    public int pointValue = 100;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collected)
            {
                GameManager.instance.score += pointValue;
                collected = true;
            }
            Destroy(gameObject);
        }
    }
}
