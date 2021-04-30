using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public Vector3 CentrePoint;
    public float Radius = 0.3f;
    public Vector2 minExtent;
    public Vector2 maxExtent;

    public bool CircleIntersects(BoundingCircle otherCircle)
    {
        Vector2 VectorToOtherCircle = otherCircle.CentrePoint - CentrePoint;

        float CombinedRadiusSq = otherCircle.Radius + Radius;
        CombinedRadiusSq *= CombinedRadiusSq;

        return VectorToOtherCircle.sqrMagnitude <= CombinedRadiusSq;
    }

    public static bool BoxIntersects(AABB box1, AABB box2)
    {
        return !(box2.left > box1.right
            || box2.right < box1.left
            || box2.top < box1.bottom
            || box2.bottom > box1.top);
    }

    public float top
    {
        get
        {
            return maxExtent.y + transform.position.y;
        }
    }

    public float bottom
    {
        get
        {
            return minExtent.y + transform.position.y;
        }
    }
    public float right
    {
        get
        {
            return maxExtent.x + transform.position.x;
        }
    }

    public float left
    {
        get
        {
            return minExtent.x + transform.position.x;
        }
    }

}
