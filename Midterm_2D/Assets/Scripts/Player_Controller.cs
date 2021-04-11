using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.MovePosition(rb2d.position + (movement * speed * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Win")
        {
            SceneManager.LoadScene("Win_Scene");
        }
    }

    }
