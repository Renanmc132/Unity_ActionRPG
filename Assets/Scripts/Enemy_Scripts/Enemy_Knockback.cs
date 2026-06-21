using System.Collections;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Enemy_Movement enemyMovement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<Enemy_Movement>();
    }


    public void Knockback(Transform player, float force, float knockbackTime, float stunTime) 
    {
        enemyMovement.ChangeState(EnemyState.isKnockedback);
        Vector2 direction = (transform.position - player.position).normalized;
        _rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackDuration(knockbackTime, stunTime));
    }

    public IEnumerator KnockbackDuration(float knockbackTime, float stunTime)  
    {
        yield return new WaitForSeconds(knockbackTime);
        _rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.ChangeState(EnemyState.isIdle);

    }

}
