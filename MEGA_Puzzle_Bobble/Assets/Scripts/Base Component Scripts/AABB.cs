using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : ObjectCollision
{
    void Update()
    {
        BoxCollision();
    }

    public void BoxCollision()
    {
     AABB[] boxes = FindObjectsOfType<AABB>();

        foreach (AABB box in boxes)
        {
            if (box != this)
            {
                if (BoxIntersects(this, box))
                {
                    Debug.Log(this.gameObject.name + " is intersecting with " + box.gameObject.name);
                }
            }
        }
    }
}
