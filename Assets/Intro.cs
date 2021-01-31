using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject video;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        video.SetActive(true);
        yield return new WaitForSeconds(98.0f);
        GameManager.instance.LoadScene("MainRoom");
    }
}
