using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayDoor : MonoBehaviour
{
    public UnityEvent eventos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventos.Invoke();
    }
}
