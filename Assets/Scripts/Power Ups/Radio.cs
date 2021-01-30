using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    private bool triggered;
    private GameObject character;
    private AudioSource aS;
    private AudioClip ac;
    private CircleCollider2D col;

    private void Start()
    {
        col = GetComponent<CircleCollider2D>();
        aS = GetComponent<AudioSource>();
        ac = aS.clip;
        Loop();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            //float aux = (character.transform.position - transform.position).magnitude;
            aS.volume = Mathf.Sqrt(Mathf.LerpUnclamped(1f, 0f, (character.transform.position - transform.position).magnitude / col.radius));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.CompareTag("Character"))
        {
            triggered = true;
            character = collision.transform.GetChild(0).gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggered && collision.gameObject.CompareTag("Character"))
        {
            aS.volume = 0f;
            triggered = false;
            character = null;
        }
    }

    private void Loop()
    {
        aS.PlayOneShot(ac);
        Invoke(nameof(Loop), aS.clip.length - 0.4f);
    }
}
