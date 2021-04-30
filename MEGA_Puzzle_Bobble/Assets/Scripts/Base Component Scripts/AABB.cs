using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : ObjectCollision
{
    void Update()
    {
        BoxCollision();
    }

    public static bool BoxIntersects(AABB box1, AABB box2)
    {
        return !(box2.left > box1.right
            || box2.right < box1.left
            || box2.top < box1.bottom
            || box2.bottom > box1.top);
    }
}
