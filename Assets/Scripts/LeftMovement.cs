using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    PlayerMovement playerMovement;

    [SerializeField] float speed;
    BoxCollider2D collider;

    float groundWidth;

    void Start()
    {
        playerMovement = GameObject.Find("Bird").GetComponent<PlayerMovement>();

        if (gameObject.CompareTag("Ground"))
        {
            collider = GetComponent<BoxCollider2D>();
            groundWidth = collider.size.x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isDead && playerMovement.isStart)
        {
            MoveLeft();
        }

        if (gameObject.CompareTag("Ground"))
        {
            GroundReset();
        }

        if (gameObject.CompareTag("Obstacle") && gameObject.transform.position.x <= -2)
        {
            Destroy(gameObject);
        }
    }

    void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    void GroundReset()
    {
        if (transform.position.x <= -groundWidth)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
        }
    }

}
