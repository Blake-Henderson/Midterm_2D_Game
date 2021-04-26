using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Author: Blake Henderson
//Date : 4/20/2021
public class Player_Controller : MonoBehaviour
{
    /// <summary>
    /// Speed of the player
    /// </summary>
    public float speed = 10;
    /// <summary>
    /// how many seconds between shots for the player
    /// </summary>
    public float shotSpeed = 0.75f;
    /// <summary>
    /// how fast the target takes damage
    /// </summary>
    public float damageTime = 0.5f;
    /// <summary>
    /// The actual projectile in the form of a prefab
    /// </summary>
    public GameObject projectile;
    /// <summary>
    /// Where the projectiles spawn
    /// </summary>
    public GameObject spawn;
    // <summary>
    /// Rigid body of the player
    /// </summary>
    private Rigidbody2D rb2d;
    /// <summary>
    /// This timer is for calculating the time between shots
    /// </summary>
    private float shotTimer = 0.0f;
    /// <summary>
    /// This timer is for calculating the time between contact damage
    /// </summary>
    private float damageTimer = 0.0f;
    /// <summary>
    /// Used to flip the player character
    /// </summary>
    private bool facingRight = true;
    /// <summary>
    /// Triggers the player taking damage
    /// </summary>
    private bool takingDamage = false;
    // Update is called once per frame
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (shotTimer >= shotSpeed)
            {
                Instantiate(projectile, spawn.transform.position, calcShotAngle());
                shotTimer = 0.0f;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        shotTimer += Time.deltaTime;
        damageTimer += Time.deltaTime;
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (mousePos.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else
       if (mousePos.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        if (takingDamage)
        {
            if (damageTimer >= damageTime)
            {
                GameManager.instance.takeDamage(1);
                damageTimer = 0.0f;
            }
        }
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.MovePosition(rb2d.position + (movement * speed * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            SceneManager.LoadScene("Win_Scene");
        }
        if (collision.tag == "Enemy")
        {
            takingDamage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            takingDamage = false;
        }
    }

    /// <summary>
    /// This calculates the angle of the shot
    /// </summary>
    /// <returns>The angle of the shot</returns>
    private Quaternion calcShotAngle()
    {
        Vector2 mouseScreen = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mouseScreen);
        float angle = Mathf.Atan2(mousePos.y - spawn.transform.position.y,
            mousePos.x - spawn.transform.position.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle);
    }
    /// <summary>
    /// flips the player sprite
    /// </summary>
    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1,
               transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

}
