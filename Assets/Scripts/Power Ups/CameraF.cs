using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraF : MonoBehaviour
{
    public float cooldown;
    private float lastFlash = -5f;
    public Image cameraFlash;
    public float initialAlpha;
    public float alphaChange;
    public float repeatingTime;


    private SpriteRenderer sr;
    private AudioSource aS;
    private bool triggered = false;
    private float currentAlpha;
    private Color auxColor;


    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.CompareTag("Character") && lastFlash + cooldown < Time.time)
        {
            triggered = true;
            aS.PlayOneShot(aS.clip);
            lastFlash = Time.time;
            sr = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
            currentAlpha = initialAlpha;
            auxColor = cameraFlash.color;
            auxColor.a = currentAlpha / 2;
            cameraFlash.color = auxColor;

            auxColor = sr.color;
            auxColor.a = currentAlpha;
            sr.color = auxColor;
            InvokeRepeating(nameof(AlphaModifier), 0f, repeatingTime);
        }
    }

    private void AlphaModifier()
    {
        currentAlpha -= alphaChange;
        if (currentAlpha <= 0.05f)
        {
            CancelInvoke(nameof(AlphaModifier));
            currentAlpha = 0f;
            triggered = false;
        }

        auxColor = cameraFlash.color;
        auxColor.a = currentAlpha / 2;
        cameraFlash.color = auxColor;

        auxColor = sr.color;
        auxColor.a = currentAlpha;
        sr.color = auxColor;

    }


}
