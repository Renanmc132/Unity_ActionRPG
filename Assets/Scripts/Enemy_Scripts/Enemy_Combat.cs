using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    [Header("Attack")]
    public Transform attackPoint;
    public float attackPointSize = 0.66f;
    public LayerMask playerLayer;


    private int damage = -1;
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(damage);
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackPointSize, playerLayer);

        if(hits.Length > 0)
            hits[0].gameObject.GetComponent<PlayerHealth>().ChangeHealth(damage);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(attackPoint.position, attackPointSize);
    //}

}
