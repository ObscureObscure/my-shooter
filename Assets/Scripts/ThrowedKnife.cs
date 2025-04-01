using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowedKnife : MonoBehaviour
{
    private Rigidbody rb;
    private bool targetHit;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.Rotate(0, 180, 0);
        StartCoroutine(deleteKnife());
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (targetHit)
    //    {
    //        return;
    //    }
    //    else 
    //    {
    //        targetHit = true;
    //    }
    //    rb.isKinematic = true;
    //    StartCoroutine(deleteKnife());
    //}

    //private IEnumerator deleteKnife()
    //{
    //    yield return new WaitForSeconds(8f);
    //    Destroy(this.gameObject);
    //}
    private IEnumerator deleteKnife()
    {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);
    }
}
