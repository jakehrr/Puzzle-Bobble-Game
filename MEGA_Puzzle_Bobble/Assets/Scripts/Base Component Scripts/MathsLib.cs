using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsLib : MonoBehaviour
{ 
    public static float VectorToRadians(Vector2 V)
    {
        float rv = 0.0f;

        rv = Mathf.Atan(V.y / V.x);

        return rv;
    }
    
    public static Vector2 RadiansToVector(float angle)
    {
        Vector2 rv = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        return rv; 
    }

    public static MyVector3 EulerAnglesToDirection(MyVector3 EulerAngles)
    {
        MyVector3 rv = new MyVector3(0,0,0);

        rv.z = Mathf.Cos(EulerAngles.y) * Mathf.Cos(EulerAngles.x);
        rv.y = Mathf.Sin(EulerAngles.x);
        rv.x = Mathf.Sin(EulerAngles.y) * Mathf.Cos(EulerAngles.x); 

        return rv; 
    }

    public static MyVector3 VectorCrossProduct(MyVector3 A, MyVector3 B)
    {
        MyVector3 C = new MyVector3(0, 0, 0);

        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }

    public static MyVector3 VecLerp(MyVector3 A, MyVector3 B, float t)
    {
        return A * (1.0f - t) + B * t; 
    }

    public static MyVector3 RotateVertex(float angle, MyVector3 Axis, MyVector3 Vertex)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

       
        return rv; 
    }

    public static MyVector3 RotateVertexAroundAxis(float Angle, MyVector3 v, MyVector3 N)
    {
        MyVector3 NPrime = (N * Mathf.Cos(Angle)) +
            v * MyVector3.VectorDot(N, v) * (1.0f - Mathf.Cos(Angle)) +
            VectorCrossProduct(v, N) * Mathf.Sin(Angle); 

        return NPrime; 
    }
}

public class Matrix4by4
{
    public float[,] values;
    public float angle; 

    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new Vector4(1, 0, 0, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1));
        }
    }

    public Vector4 GetRow(int rowIndex)
    {
        return new Vector4(values[0, rowIndex],
            values[1, rowIndex],
            values[2, rowIndex],
            values[3, rowIndex]); 
    }

    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4]; 
        // Column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        // Column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        // Column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        // Column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }

    public Matrix4by4(MyVector3 column1, MyVector3 column2, MyVector3 column3, MyVector3 column4)
    {
        values = new float[4, 4]; 
        // Column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0; 

        // Column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        // Column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        // Column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }

    public static Vector4 operator *(Matrix4by4 lhs, Vector4 rhs)
    {
        Vector4 rv = new Vector4();

        rv.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * rhs.w;
        rv.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * rhs.w;
        rv.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * rhs.w;
        rv.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * rhs.w;

        return rv; 
    }

    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {
        Matrix4by4 rv = Identity;

        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                rv.values[i, j] = lhs.values[i, 0] * rhs.values[0, j] + lhs.values[i, 1] * rhs.values[1, j] + lhs.values[i, 2] * rhs.values[2, j] + lhs.values[i, 3] * rhs.values[3, j];  
            }
        }
        return rv; 
    }

    public Matrix4by4 TranslationInverse()
    {
        Matrix4by4 rv = Identity;

        rv.values[0, 3] = -values[0, 3];
        rv.values[1, 3] = -values[1, 3];
        rv.values[2, 3] = -values[2, 3];

        return rv;
    }

    public Matrix4by4 rotationInverse()
    {
        return new Matrix4by4(GetRow(0), GetRow(1), GetRow(2), GetRow(3)); 
    }

    public Matrix4by4 ScaleInverse()
    {
        Matrix4by4 rv = Identity;

        rv.values[0, 0] = 1.0f / values[0, 0];
        rv.values[1, 1] = 1.0f / values[1, 1];
        rv.values[2, 2] = 1.0f / values[2, 2];

        return rv; 
    }
}

public class Quat
{
    public float w;
    public MyVector3 v;

    public Quat()
    {
        w = 0.0f;
        v = new MyVector3(0, 0, 0);
    }

    public Quat(float angle, MyVector3 Axis)
    {
        float halfAngle = angle / 2;
        w = Mathf.Cos(halfAngle);

        v = Axis * Mathf.Sin(halfAngle);
        //x = v.x;
        //y = v.y;
        //z = v.z;
    }

    public Quat(MyVector3 position)
    {
        w = 0.0f;
        v = new MyVector3(position.x, position.y, position.z);
    }

    public static Quat operator*(Quat lhs, Quat rhs)
    {
        Quat rv = new Quat();

        rv.w = lhs.w * rhs.w - MyVector3.VectorDot(lhs.v, rhs.v);

        rv.v = rhs.v * lhs.w + lhs.v * rhs.w + MathsLib.VectorCrossProduct(lhs.v, rhs.v);

        return rv; 
    }

    public Quat Inverse()
    {
        Quat rv = new Quat();

        rv.w = w; 
        

        return rv; 
    }
}
