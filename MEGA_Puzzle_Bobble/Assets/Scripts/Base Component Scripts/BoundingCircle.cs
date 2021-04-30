using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingCircle : ObjectCollision
{
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
                if (CircleIntersects(c))
                {
                    Debug.Log(gameObject.name + " is intersecting with " + c.gameObject.name);


                }
            }
        }
    }
}
