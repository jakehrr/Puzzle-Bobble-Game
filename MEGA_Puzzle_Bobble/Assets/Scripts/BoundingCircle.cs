using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingCircle : MonoBehaviour
{
    public Vector3 CentrePoint;
    public float Radius = 0.3f;

    private MyVector3 Force;
    MyVector3 acceleration;
    MyVector3 velocity;
    public float mass = 1;

    // Update is called once per frame
    void Update()
    {
        IsColliding();
    }


    public void IsColliding()
    {
        CentrePoint = transform.position;
        BoundingCircle[] allCirclesInScene = FindObjectsOfType<BoundingCircle>();

        foreach (BoundingCircle c in allCirclesInScene)
        {
            if (c != this)
            {
                if (Intersects(c))
                {
                    Debug.Log(gameObject.name + " is intersecting with " + c.gameObject.name);


                }
            }
        }
    }
    public bool Intersects(BoundingCircle otherCircle) 
    {
        Vector3 VectorToOtherCircle = otherCircle.CentrePoint - CentrePoint;

        float CombinedRadiusSq = otherCircle.Radius + Radius;
        CombinedRadiusSq *= CombinedRadiusSq;

        return VectorToOtherCircle.sqrMagnitude <= CombinedRadiusSq;
    }
}
