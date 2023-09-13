using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trazo : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _targetPos;
    private float _progress;

    [SerializeField] public float _speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position.WithAxis(Axis.Z, -1);   
    }

    // Update is called once per frame
    void Update()
    {
        _progress += Time.deltaTime * _speed;
        transform.position = Vector3.Lerp(_startPos, _targetPos, _progress);   
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        _targetPos = targetPos.WithAxis(Axis.Z, - 1);
    }
}
