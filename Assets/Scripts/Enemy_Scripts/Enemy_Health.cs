using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

    private int currentHealth;
    private int maxHealth = 5;

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < 0) { 
            
            Destroy(gameObject);
        }

    }



}
