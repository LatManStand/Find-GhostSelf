using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TutorialAlpha : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color color;
    public Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 72)
        {
            color = sr.color;
            color.a = Mathf.LerpUnclamped(0, 1, (72 - transform.position.x) / 72);
            sr.color = color;
            light.intensity = color.a;
        }
    }
}
