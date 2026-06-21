using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Animator _anim;
    private int direction = 1;

    private bool isKnockedback;
    private PlayerCombat _playerCombat;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _playerCombat = GetComponent<PlayerCombat>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            _playerCombat.Attack();
        }
    }

    void FixedUpdate()
    {
        if (!isKnockedback)
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            _anim.SetFloat("xInput", Mathf.Abs(horizontalInput));
            _anim.SetFloat("yInput", Mathf.Abs(verticalInput));

            if (horizontalInput > 0 && direction != 1 || horizontalInput < 0 && direction != -1)
                Flip();

            _rb.linearVelocity = new Vector2(horizontalInput,verticalInput) * moveSpeed;
        }



    }


    private void Flip()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction,transform.localScale.y,transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedback = true;
        _rb.linearVelocity = Vector2.zero;
        Vector2 direction = (transform.position - enemy.position).normalized;
        _rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackDuration(stunTime));

    }

    private IEnumerator KnockbackDuration(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        isKnockedback = false;
    }


}
