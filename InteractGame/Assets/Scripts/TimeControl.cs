using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private bool isSlowingDown = false;
    private Coroutine currentCoroutine = null;
    public float slowdownPercent;

    void Update()
    {
        // When the space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSlowingDown)
            {
                if (currentCoroutine != null)
                {
                    StopCoroutine(currentCoroutine);
                }
                currentCoroutine = StartCoroutine(ChangeTimeScale(0.2f, 0.2f));
            }
        }

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isSlowingDown)
            {
                if (currentCoroutine != null)
                {
                    StopCoroutine(currentCoroutine);
                }
                currentCoroutine = StartCoroutine(ChangeTimeScale(1.0f, slowdownPercent * 0.01f));
            }
        }
    }

    IEnumerator ChangeTimeScale(float targetScale, float duration)
    {
        isSlowingDown = targetScale != 1.0f;

        float startScale = Time.timeScale;
        float timer = 0.0f;

        while (timer < duration)
        {
            Time.timeScale = Mathf.Lerp(startScale, targetScale, timer / duration);
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = targetScale;
    }

    void OnDestroy()
    {
        
        Time.timeScale = 1.0f;
    }
}
