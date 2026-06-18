using System.Collections;
using UnityEngine;

public class Tree_Transparency : MonoBehaviour
{
    private float targetAlpha = 0.5f;

    private SpriteRenderer[] sprites;
    private Coroutine fadeRoutine;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>(true);
    }

    private IEnumerator FadeTo(float target)
    {
        float timer = 0f;
        float duration = 0.3f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            foreach (SpriteRenderer sprite in sprites)
            {
                Color color = sprite.color;

                color.a = Mathf.Lerp(color.a, target, timer / duration);

                sprite.color = color;
            }

            yield return null;
        }

        // Garante que termina exatamente no valor desejado
        foreach (SpriteRenderer sprite in sprites)
        {
            Color color = sprite.color;
            color.a = target;
            sprite.color = color;
        }
    }

    private void StartFade(float alpha)
    {
        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        fadeRoutine = StartCoroutine(FadeTo(alpha));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartFade(targetAlpha);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartFade(1f);
        }
    }


}
