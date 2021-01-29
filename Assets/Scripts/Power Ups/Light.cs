using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private bool triggered;
    private GameObject character;
    private SpriteRenderer sr;
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
            float aux = (character.transform.position - transform.position).magnitude;
            color.a = Mathf.LerpUnclamped(1f, 0f, aux / col.radius);
            sr.color = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.CompareTag("Character"))
        {
            triggered = true;
            character = collision.gameObject;
            sr = character.GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggered && collision.gameObject.CompareTag("Character"))
        {
            color = sr.color;
            color.a = 0f;
            sr.color = color;
            triggered = false;
            character = null;
            sr = null;
        }
    }
}
