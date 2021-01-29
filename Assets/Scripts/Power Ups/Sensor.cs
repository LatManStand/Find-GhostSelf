using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public Sprite onSprite;
    public Color onColor;
    public Sprite offSprite;
    public Color offColor;
    public float duration;

    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            sr.sprite = onSprite;
            sr.color = onColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            CancelInvoke(nameof(Deactivate));
            Invoke(nameof(Deactivate), duration);
        }
    }

    private void Deactivate()
    {
        sr.sprite = offSprite;
        sr.color = offColor;
    }


}
