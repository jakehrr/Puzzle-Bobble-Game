using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixStuff : MonoBehaviour
{
    private GameObject matrixCube;
    Vector3[] ModelSpaceVertices;
    public float angle;

    public Vector3 Position = Vector3.zero;
    public Vector3 Rotation = Vector3.zero;
    public Vector3 Scale = new Vector3(1, 1, 1);

    void Start()
    {
        matrixCube = GameObject.Find("Matrix Cube");

        MeshFilter MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        TRS();
    }

    void TRS()
    {
        Matrix4by4 M = translateMatrix() * (rotationMatrix() * scaleMatrix());

        Vector3[] TransformedVertcies = new Vector3[ModelSpaceVertices.Length];

        for (int i = 0; i < TransformedVertcies.Length; i++)
        {
            TransformedVertcies[i] = M * new Vector4(ModelSpaceVertices[i].x, ModelSpaceVertices[i].y, ModelSpaceVertices[i].z, 1); 
        }
        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = TransformedVertcies;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }

    Matrix4by4 translateMatrix()
    {
            Vector3[] TransformedVertcies = new Vector3[ModelSpaceVertices.Length];

        Matrix4by4 translateMatrix = new Matrix4by4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, 1, 0),
            new MyVector3(0, 0, 1),
            new MyVector3(Position.x, Position.y, Position.z));
     
        return translateMatrix; 
    }

    Matrix4by4 rotationMatrix()
    {
        Matrix4by4 rollMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(Rotation.x), Mathf.Sin(Rotation.x), 0),
            new MyVector3(-Mathf.Sin(Rotation.x), Mathf.Cos(Rotation.x), 0),
            new MyVector3(0, 0, 1),
            new MyVector3(0,0,0));

        Matrix4by4 pitchMatrix = new Matrix4by4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, Mathf.Cos(Rotation.y), Mathf.Sin(Rotation.y)),
            new MyVector3(0, -Mathf.Sin(Rotation.y), Mathf.Cos(Rotation.y)),
            new MyVector3(0, 0, 0));

        Matrix4by4 yawMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(Rotation.z), 0, -Mathf.Sin(Rotation.z)),
            new MyVector3(0, 1, 0),
            new MyVector3(Mathf.Sin(Rotation.z), 0, Mathf.Cos(Rotation.z)),
            new MyVector3(0, 0, 0));

        Matrix4by4 R = yawMatrix * (pitchMatrix * rollMatrix);

        return R;
    }

    Matrix4by4 scaleMatrix()
    {
        Vector3[] TransformedVertcies = new Vector3[ModelSpaceVertices.Length];

        Matrix4by4 scaleMatrix = new Matrix4by4(new MyVector3(Scale.x, 0, 0), new MyVector3(0, Scale.y, 0), new MyVector3(0, 0, Scale.z), new MyVector3(0, 0, 0));

        MeshFilter MF = GetComponent<MeshFilter>();

        return scaleMatrix; 
    }
}
