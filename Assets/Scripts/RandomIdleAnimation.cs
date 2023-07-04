using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleAnimation : MonoBehaviour
{
    public Animator animator;
    public float minInterval = 5f;
    public float maxInterval = 10f;

    private float nextTriggerTime;

    private void Start()
    {
        nextTriggerTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        if (Time.time >= nextTriggerTime)
        {
            animator.SetTrigger("RandomIdle");
            nextTriggerTime = Time.time + Random.Range(minInterval, maxInterval);
        }
    }
}
