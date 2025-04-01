using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharThrowObj : MonoBehaviour
{
    public Transform charCam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUp;
    public float throwUpwardForce;
    
    public bool readyToThrow;
    private void Start()
    {
        readyToThrow = true;

    }
    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0) 
        {
            Throw();
        }
    }
    private void Throw() 
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, charCam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDIrection = charCam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(charCam.position, charCam.forward, out hit, 500F))
        {
            forceDIrection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDIrection * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        //totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }
    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
