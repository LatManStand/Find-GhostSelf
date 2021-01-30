using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterDotween : MonoBehaviour
{
    public float sway;
    public float duration;
    public GameObject other;
    private SpriteRenderer sr;
    void Start()
    {
        transform.DOLocalMoveY(sway, duration)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
        /*
        other.transform.DOLocalMoveY(sway, duration)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1,LoopType.Yoyo);
            */
    }
}
