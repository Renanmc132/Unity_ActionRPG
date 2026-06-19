using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Transform player;

    private float moveSpeed = 3f;
    private Vector2 direction;
    private bool isChasing;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            direction = player.transform.position - transform.position;

            _rb.linearVelocity = direction.normalized * moveSpeed;
        }
        else
        {
            _rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            if (player == null)
                player = collision.transform;

            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChasing = false;

        }
    }


}
