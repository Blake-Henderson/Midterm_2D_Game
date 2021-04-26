using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class WinScreenScript : MonoBehaviour
{
    /// <summary>
    /// The text for the score
    /// </summary>
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        int score = GameManager.instance.score;
        scoreText.text = "SCORE: " + score;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
