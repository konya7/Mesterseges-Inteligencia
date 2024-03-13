using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        DeactivaljaRagdoll();
    }

    public void DeactivaljaRagdoll()
    {
        foreach (var merevtest in rigidbodies)
        {
            merevtest.isKinematic = true;
        }
        animator.enabled = true;
    }
    public void AktivaljaRagdoll()
    {
        foreach (var merevtest in rigidbodies)
        {
            merevtest.isKinematic = false;
        }
        animator.enabled = false;
    }
}
