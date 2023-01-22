using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionController : MonoBehaviour
{
    [SerializeField]
    bool isRed;
    [SerializeField]
    bool isBlue;

    private Shoot shoot;
    private Rigidbody2D rb;
    public float fallSpeed;
    bool inBounds;

    void Start()
    {
        shoot = GameObject.Find("Player").GetComponent<Shoot>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
            rb.velocity = new Vector2(0, -fallSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
        {
            if (isRed)
            {
                shoot.score++;
                Destroy(this.gameObject);

                if (shoot.score == 25)
                {
                    Destroy(this.gameObject);
                    shoot.firePoint2.SetActive(true);
                }

                if (shoot.score == 50)
                {
                    Destroy(this.gameObject);
                    shoot.firePoint1.SetActive(true);
                }
            }
        }
        if (collision.CompareTag("Bound"))
        {
                fallSpeed = Random.Range(0.5f, 2f);
        }
        if (collision.CompareTag("Walll"))
        {
            fallSpeed = 0f;
        }
    }
}
