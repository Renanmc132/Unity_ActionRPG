using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private Animator _anim;

    private float timer;
    private float attackCooldown = .75f;

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

    public void FisnishAttack()
    {
        _anim.SetBool("isAttacking", false);
    }


}
