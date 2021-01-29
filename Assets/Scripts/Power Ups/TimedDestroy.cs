using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float timeToDie;

    public void CallDestroy()
    {
        Invoke(nameof(Destroy), timeToDie);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
