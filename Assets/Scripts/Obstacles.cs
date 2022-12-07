using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _rotateSpeed = 10;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate( Vector3.forward * _rotateSpeed * Time.deltaTime);
    }
}
