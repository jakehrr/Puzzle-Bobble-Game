using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MyRigidBody
{
    public float speed;

    // Start is called before the first frame update
    void Update()
    {
        // Euelr angle degree to radian forumla 
        speed = MathsLib.DegreesToRadian(transform.rotation.eulerAngles.z);
        // radian to vector
        force = MathsLib.RadiansToVector(speed);
        // move projectile
        transform.position += force * Time.deltaTime; 
    }
}
