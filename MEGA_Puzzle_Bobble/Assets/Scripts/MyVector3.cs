using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3 
{
    public float x, y, z; 

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public MyVector3(Vector3 vector)
    {
        this.x = vector.x;
        this.y = vector.y;
        this.z = vector.z;

    }

    public static MyVector3 AddVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = a.x + b.x;
        rv.y = a.y + b.y;
        rv.z = a.z + b.y;

        return rv; 
    }

    public static MyVector3 operator+(MyVector3 a, MyVector3 b)
    {
        return AddVector(a, b);
    }

    public static MyVector3 SubtractVector(MyVector3 a, MyVector3 b)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = a.x - b.x;
        rv.y = a.y - b.y;
        rv.z = a.z - b.y;

        return rv;
    }

    public float Length()
    {
        float rv = 0.0f;

        rv = Mathf.Sqrt(x * x + y * y + z * z);

        return rv;
    }

    public Vector3 ToUnityVector()
    {
        Vector3 rv = new Vector3(x, y, z);

        return rv;
    }

    public float LengthSq()
    {
        float rv = 0.0f;

        rv = x + y * y + z * z;

        return rv;
    }

    public static MyVector3 ScaleVector(MyVector3 v, float scalar)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = v.x * scalar;
        rv.y = v.y * scalar;
        rv.z = v.z * scalar;
        
        return rv; 
    }

    public static MyVector3 operator*(MyVector3 v, float scalar)
    {
        return ScaleVector(v, scalar);
    }

    public static MyVector3 DivideVector(MyVector3 v, float dividor)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = v.x / dividor;
        rv.y = v.y / dividor;
        rv.z = v.z / dividor;

        return rv; 
    }

    public static MyVector3 operator/(MyVector3 v, float dividor)
    {
        return DivideVector(v, dividor); 
    }

    public MyVector3 NormalizedVector()
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv = DivideVector(this, Length());

        return rv; 
    }

    public static float VectorDot(MyVector3 a, MyVector3 b, bool ShouldNoramlize = true)
    {
        float rv = 0.0f;

        if (ShouldNoramlize)
        {
            MyVector3 normA = a.NormalizedVector();
            MyVector3 normB = b.NormalizedVector();
            rv = normA.x * normB.x + normA.y * normB.y + normA.z * normB.z;
        }
        else
        {
            rv = a.x * b.x + a.y * b.y + a.z * b.z;
        }
        return rv; 
    }
}
