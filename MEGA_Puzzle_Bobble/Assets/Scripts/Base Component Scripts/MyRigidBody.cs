using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidBody : MonoBehaviour
{
    public Vector3 force;
    Vector3 acceleration;
    Vector3 velocity;
    public float mass = 1;
   // const float GBA_DeltaTime = 0.0167f; 

    // Update is called once per frame
    void FixedUpdate()
    {
        acceleration = force / mass;

        velocity += acceleration * Time.deltaTime; //GBA_DeltaTime;

        transform.position += velocity * Time.deltaTime; // GBA_DeltaTime;
    }
}
