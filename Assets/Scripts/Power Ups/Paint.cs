using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public GameObject leftFoot;
    public GameObject rightFoot;
    private GameObject instantiatedFoot;

    private Transform groundCheck;
    private CharacterController2D charContr;

    public int steps;
    private int currentSteps;
    public float distancePerStep = 1f;
    private float currentDistance = 0f;
    private bool triggered = false;
    private float lastXPosition;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.CompareTag("Character"))
        {
            triggered = true;
            charContr = collision.gameObject.GetComponent<CharacterController2D>();
            groundCheck = charContr.groundCheck;
            lastXPosition = groundCheck.position.x;
            currentSteps = 0;
        }
    }

    private void Update()
    {
        if (triggered)
        {
            currentDistance += Mathf.Abs(groundCheck.position.x - lastXPosition);
            lastXPosition = groundCheck.position.x;
            if (currentDistance > distancePerStep)//&& lastStepTime + minimumStepTime < Time.time)
            {
                if (charContr._grounded)
                {
                    currentDistance = 0f;
                    if (currentSteps % 2 == 0)
                    {
                        instantiatedFoot = Instantiate(leftFoot, groundCheck.position, groundCheck.rotation);
                    }
                    else
                    {
                        instantiatedFoot = Instantiate(rightFoot, groundCheck.position, groundCheck.rotation);
                    }
                    instantiatedFoot.GetComponent<ParticleSystem>().Play();
                    instantiatedFoot.GetComponent<TimedDestroy>().CallDestroy();
                    currentSteps++;

                    if (currentSteps == steps)
                    {
                        triggered = false;
                        
                        //Destroy(this);
                    }
                }
            }
        }
    }
}
