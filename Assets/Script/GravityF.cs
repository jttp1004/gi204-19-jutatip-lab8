using System;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class GravityF : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.006674f;
    
    public static List<GravityF> GravityObjectslist;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (GravityObjectslist == null)
        {
            GravityObjectslist = new List<GravityF>();
        }
        
        GravityObjectslist.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (GravityF obj in GravityObjectslist)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    void Attract(GravityF Other)
    {
        Rigidbody OtherRB = Other.rb;
        Vector3 direction = rb.position - OtherRB.position;
        float distance = direction.magnitude;
        
        float forceMagnitude = G * (rb.mass * OtherRB.mass / Mathf.Pow(distance, 2));
        Vector3 gavityForce = forceMagnitude * direction.normalized;
        
        OtherRB.AddForce(gavityForce);
    }
}
