using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUV : MonoBehaviour
{
    public float duration;
    public Gradient colors;

    private bool triggered;
    private float timeTriggered;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
            sr.color = colors.Evaluate(0);
            triggered = false;

        }
    }

    private void Caught()
    {
        if (Time.time < timeTriggered + duration)
        {
            sr.color = colors.Evaluate((Time.time - timeTriggered) / duration);
        }
        else
        {
            //Pasan que cosas

        }
    }
}
