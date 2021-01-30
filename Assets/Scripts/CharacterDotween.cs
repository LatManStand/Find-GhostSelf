using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterDotween : MonoBehaviour
{
    public float sway;
    public float duration;
    private SpriteRenderer sr;
    void Start()
    {
        transform.DOMoveY(transform.position.y + sway, duration)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1,LoopType.Yoyo);
    }
}
