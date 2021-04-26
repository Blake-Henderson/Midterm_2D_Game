using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIConrol : MonoBehaviour
{
    /// <summary>
    /// life gotten from the game manager
    /// </summary>
    public int life;
    /// <summary>
    /// score gotten from the game manager
    /// </summary>
    public int score;
    /// <summary>
    /// The image for the hearts
    /// </summary>
    public Image hearts;
    /// <summary>
    /// The text for the score
    /// </summary>
    public Text scoreText;
    //Various heart sprites
    public Sprite fullHealth;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;
    public Sprite health5;
    // Update is called once per frame
    void FixedUpdate()
    {
        life = GameManager.instance.life;
        score = GameManager.instance.score;

        switch (life) {
            case 6:
                hearts.sprite = fullHealth;
                break;
            case 5:
                hearts.sprite = health1;
                break;
            case 4:
                hearts.sprite = health2;
                break;
            case 3:
                hearts.sprite = health3;
                break;
            case 2:
                hearts.sprite = health4;
                break;
            case 1:
                hearts.sprite = health5;
                break;
            default:
                break;
        }
        scoreText.text = "Score: " + score;
    }
}
