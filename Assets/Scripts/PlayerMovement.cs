using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 5f;
    private Rigidbody2D rb;




    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontalInput,verticalInput) * moveSpeed;



    }
}
