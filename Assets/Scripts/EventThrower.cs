using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventThrower : MonoBehaviour
{
    public UnityEvent eventos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventos.Invoke();
    }

    public void Caballo()
    {
        GameManager.instance.hasHorse = true;
    }

    public void Cepillo()
    {
        GameManager.instance.hasToothbrush = true;
    }
}
