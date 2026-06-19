using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform player;

    [Header("Player Detection")]
    public Transform detectionPoint;
    public float detectionArea = 4.31f;
    public LayerMask playerLayer;

    [Header("Attack")]
    private float attackRange = 1.2f;
    private float attackCooldown = 2;
    private float attackCooldownTimer;


    private float moveSpeed = 3f;
    private EnemyState enemyState;
    private int direction = 1;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        ChangeState(EnemyState.isIdle);
    }

    private void Update()
    {
        CheckForPlayer();

        if(attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (enemyState == EnemyState.isChasing)
        {
            Chase();
        }
        else if(enemyState == EnemyState.isAttacking)
        {
            _rb.linearVelocity = Vector2.zero;
        }
    }

    private void Chase()
    {
         if (player.transform.position.x > transform.position.x && direction == -1 || player.transform.position.x < transform.position.x && direction == 1)
            Flip();

        Vector2 moveDirection = player.transform.position - transform.position;

        _rb.linearVelocity = moveDirection.normalized * moveSpeed;
    }

    private void Flip()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(detectionPoint.position,detectionArea,playerLayer);

        if(players.Length > 0)
        {
            player = players[0].transform;

            if (Vector2.Distance(player.transform.position, transform.position) < attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.isAttacking);
            }else if(Vector2.Distance(player.transform.position, transform.position) > attackRange)
            {
                ChangeState(EnemyState.isChasing);
            }

        }
        else
        {
            ChangeState(EnemyState.isIdle);
            _rb.linearVelocity = Vector2.zero;
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
        else if (enemyState == EnemyState.isAttacking)
        {
            _anim.SetBool("isAttacking", false);
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
        else if (enemyState == EnemyState.isAttacking)
        {
            _anim.SetBool("isAttacking", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectionPoint.position, detectionArea);
    }

}


public enum EnemyState
{
    isIdle,
    isChasing,
    isAttacking
}




