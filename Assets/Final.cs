using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
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
        yield return new WaitForSeconds(48.0f);
        GameManager.instance.LoadScene("Creditos");
    }
}
