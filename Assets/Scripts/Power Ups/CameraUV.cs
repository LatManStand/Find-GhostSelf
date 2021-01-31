using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraUV : MonoBehaviour
{
    public float duration;
    public Gradient colors;
    public Sprite triggeredSprite;

    private bool triggered;
    private float timeTriggered;
    private SpriteRenderer sr;
    public Light2D light;

    private void Start()
    {
        light = GetComponentInChildren<Light2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.CompareTag("Character"))
        {
            //sr.color = triggeredColor;
            InvokeRepeating(nameof(Caught), 0, 0.05f);
            timeTriggered = Time.time;
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggered && collision.gameObject.CompareTag("Character"))
        {
            CancelInvoke(nameof(Caught));
            light.color = colors.Evaluate(0);
            triggered = false;

        }
    }

    private void Caught()
    {
        if (Time.time < timeTriggered + duration)
        {
            light.color = colors.Evaluate((Time.time - timeTriggered) / duration);
        }
        else
        {
            //Pasan que cosas
            sr.sprite = triggeredSprite;
            GameManager.instance.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
