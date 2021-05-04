using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLauncher : MonoBehaviour
{
    public GameObject _orbCannon;
    public GameObject[] _bulletPrefab;
    public Transform _shotPoint;
    public MyVector3 _launcherTransform; 
    public int _speed;
    void Update()
    {
        TurretController();
    }

    void TurretController()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////Controls Logic////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.A) && (transform.rotation.eulerAngles.z < 50 || (transform.rotation.eulerAngles.z > 305)))
        {
            transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && (transform.rotation.eulerAngles.z < 55 || (transform.rotation.eulerAngles.z > 310)))
        {
            transform.Rotate(Vector3.back * _speed * Time.deltaTime);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////Shooting Logic////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, 3); 
            Instantiate(_bulletPrefab[index], _shotPoint.position, _shotPoint.rotation);
        }
    }
}


