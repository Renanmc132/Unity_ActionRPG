using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private Animator _anim;

    private float timer;
    private float attackCooldown = .75f;

    public Transform attackPoint;
    private float attackRadius = 0.66f;
    public LayerMask enemyLayer;
    private int damage = 1;

    [Header("Knockback")]
    private float knockbackForce = 10f;
    private float knockbackTime = .2f;
    private float stunTime = .2f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


    public void Attack()
    {
        if(timer <= 0)
        {
            _anim.SetBool("isAttacking", true);
            timer = attackCooldown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

        if(enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-damage);
            enemies[0].GetComponent<Enemy_Knockback>().Knockback(transform,knockbackForce,knockbackTime,stunTime);
        }
    }

    public void FisnishAttack()
    {
        _anim.SetBool("isAttacking", false);
    }


}
