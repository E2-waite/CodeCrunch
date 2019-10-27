using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    private Vector3 _newPosition;
    public float magnitude;
    private float speedx;
    private float speedy;

    void Start()
    {
        speedx = Random.Range(1f, 2f);
        magnitude = Random.Range(-0.5f, 0.5f);
        speedy = Random.Range(0.01f, 0.1f);
    }

    void Update()
    {
        _newPosition = transform.position;
        _newPosition.x += (Mathf.Cos(Time.time) * Time.deltaTime * speedx) * magnitude;
        _newPosition.y -= Time.deltaTime * speedy;
        transform.position = _newPosition;
    }
}
