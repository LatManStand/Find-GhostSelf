using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WindowLight : MonoBehaviour
{
    public float topDemonLight;
    public float alphaMultiplier;

    private bool triggered;
    private GameObject character;
    private SpriteRenderer sr;
    private Light2D demonLight;
    private GameObject demon;
    private CircleCollider2D col;
    private Color color;

    private void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            color = sr.color;
            //float aux = (character.transform.position - transform.position).magnitude;
            color.a = Mathf.LerpUnclamped(1f, 0f, Mathf.Pow((character.transform.position - transform.position).magnitude, 2) / col.radius) * alphaMultiplier;
            sr.color = color;
            demonLight.intensity = Mathf.LerpUnclamped(1f, 0f, Mathf.Pow((character.transform.position - transform.position).magnitude, 2) / col.radius) - topDemonLight;
            if (demonLight.intensity <= 0f)
            {
                demonLight.intensity = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.CompareTag("Character"))
        {
            triggered = true;
            character = collision.transform.GetChild(0).gameObject;
            demon = character.transform.GetChild(0).gameObject;
            demon.SetActive(true);
            demonLight = demon.GetComponent<Light2D>();
            sr = character.GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggered && collision.gameObject.CompareTag("Character"))
        {
            color = sr.color;
            color.a = 0f;
            sr.color = color;
            demon.SetActive(false);
            demonLight.intensity = 0f;
            triggered = false;
        }
    }
}
