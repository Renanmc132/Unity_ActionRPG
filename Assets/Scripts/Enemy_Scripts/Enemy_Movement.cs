using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform player;

    private float moveSpeed = 3f;
    private EnemyState enemyState;
    private int direction = 1;
    private bool isChasing;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        ChangeState(EnemyState.isIdle);
    }

    private void FixedUpdate()
    {
        if (enemyState == EnemyState.isChasing)
        {
            if (player.transform.position.x > transform.position.x && direction == -1 || player.transform.position.x < transform.position.x && direction == 1)
                    Flip();

            Vector2 moveDirection = player.transform.position - transform.position;

            _rb.linearVelocity = moveDirection.normalized * moveSpeed;
        }
        else
        {
            _rb.linearVelocity = Vector2.zero;
        }
    }

    private void Flip()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 

            if (player == null)
                player = collision.transform;

            ChangeState(EnemyState.isChasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeState(EnemyState.isIdle);
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(enemyState == EnemyState.isIdle)
        {
            _anim.SetBool("isIdle", false);
        }else if(enemyState == EnemyState.isChasing)
        {
            _anim.SetBool("isChasing", false);
        }

        enemyState = newState;

        if (enemyState == EnemyState.isIdle)
        {
            _anim.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.isChasing)
        {
            _anim.SetBool("isChasing", true);
        }
    }


}


public enum EnemyState
{
    isIdle,
    isChasing
}




