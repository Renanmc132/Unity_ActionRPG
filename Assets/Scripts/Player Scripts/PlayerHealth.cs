using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth = 3;

    public Slider healthSlider;
    private Coroutine updateHealthBar;

    private void Awake()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        StartCoroutine(UpdateHealthBar());

    }

    private IEnumerator UpdateHealthBar()
    {
        while (healthSlider.value >= currentHealth)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, .007f);

            yield return null;
        }

    }

}
