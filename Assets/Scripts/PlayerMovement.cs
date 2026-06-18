using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Animator _anim;
    private int direction = 1;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }



    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _anim.SetFloat("xInput", Mathf.Abs(horizontalInput));
        _anim.SetFloat("yInput", Mathf.Abs(verticalInput));

        if (horizontalInput > 0 && direction != 1 || horizontalInput < 0 && direction != -1)
            Flip();

        _rb.linearVelocity = new Vector2(horizontalInput,verticalInput).normalized * moveSpeed;



    }


    private void Flip()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction,transform.localScale.y,transform.localScale.z);
    }



}
