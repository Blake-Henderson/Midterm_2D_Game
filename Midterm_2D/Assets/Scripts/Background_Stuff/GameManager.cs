using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>
    /// Score of the player
    /// </summary>
    public int score = 0;
    /// <summary>
    /// How much life the player has
    /// </summary>
    public int life = 6;

    void Start()
    {
        resetManager();
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        addToScore(100);
    //        takeDamage(1);
    //    }
    //}

    private void Awake()
    {
        MakeSingleton();
        resetManager();
    }
    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
    /// <summary>
    /// damages player by 'a' amount
    /// </summary>
    /// <param name="a"></param>
    public void takeDamage(int a)
    {
        life -= a;
        if (life > 6)
        {
            life = 6;
        }
        if (life <= 0)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
    /// <summary>
    /// resets the score
    /// </summary>
    public void resetManager()
    {
        score = 0;
        life = 6;
    }
    /// <summary>
    /// Adds to the score
    /// </summary>
    /// <param name="amount"></param>
    public void addToScore(int amount)
    {
        score += amount;
    }
}