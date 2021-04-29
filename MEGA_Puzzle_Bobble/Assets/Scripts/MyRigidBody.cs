using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidBody : MonoBehaviour
{
    public MyVector3 force = new MyVector3(0,0,0);
    MyVector3 acceleration = new MyVector3(0,0,0);
    MyVector3 velocity = new MyVector3(0,0,0);
    public float mass = 1;
    const float GBA_DeltaTime = 0.0167f; 

    // Update is called once per frame
    void Update()
    {
        acceleration = force / mass;

        velocity += acceleration * GBA_DeltaTime;

        transform.position += (velocity * GBA_DeltaTime).ToUnityVector();
    }
}
