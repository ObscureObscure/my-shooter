using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBlade : MonoBehaviour
{
    public Collider collider;
    public Rigidbody rb;
    private bool targetHit;
    private void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponentInParent<Rigidbody>();
    }
    private void Update()
    {
        Debug.Log(rb.isKinematic);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
        {
            return;
        }
        else
        {
            targetHit = true;
        }
        rb.isKinematic = true;
        Debug.Log(rb.isKinematic);
    }
}
