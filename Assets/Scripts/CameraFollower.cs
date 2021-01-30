using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject character;
    public float yPos;
    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        position = character.transform.position;
        position.y = yPos;
        position.z -= 20;
        transform.position = position;
    }
}
