using UnityEngine;

public class Elevation_Layer : MonoBehaviour
{

    public Collider2D player;

    private void Start()
    {
        Collider2D mountain = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(mountain, player);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }


}
