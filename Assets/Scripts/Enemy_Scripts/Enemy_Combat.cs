using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    [Header("Attack")]
    public Transform attackPoint;
    public float attackPointSize = 0.66f;
    public LayerMask playerLayer;
    private float forceKnockback = 10;
    private float stunTime = .2f;


    private int damage = -1;
    
    

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackPointSize, playerLayer);

        if(hits.Length > 0)
        {
            hits[0].gameObject.GetComponent<PlayerHealth>().ChangeHealth(damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, forceKnockback, stunTime);
        }
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(attackPoint.position, attackPointSize);
    //}

}
