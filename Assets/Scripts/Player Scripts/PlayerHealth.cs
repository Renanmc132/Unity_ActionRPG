using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    private int health = 3;

    private void Awake()
    {
        currentHealth = health;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
