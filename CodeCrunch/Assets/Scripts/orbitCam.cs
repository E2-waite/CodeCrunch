﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitCam : MonoBehaviour
{
    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    public float velocityX = 0.0f;
    public float velocityY = 0.0f;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    void LateUpdate()
    {
        if (target)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                velocityX += xSpeed * Input.touches[0].deltaPosition.x * distance * 0.02f;
                velocityY += ySpeed * Input.touches[0].deltaPosition.y * 0.02f;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            //rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            //RaycastHit hit;
            //if (Physics.Linecast(target.position, transform.position, out hit))
            //{
            //distance -= hit.distance;
            //}
            //Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            //Vector3 position = rotation * negDistance + target.position;

            if(Input.touchCount == 0)
            {
                velocityX = 0.02f;
                velocityY = -0.02f;
            }
            transform.rotation = rotation;
            //transform.position = position;
            velocityX = Mathf.Clamp(velocityX, -0.5f, 0.5f);
            velocityY = Mathf.Clamp(velocityY, -0.5f, 0.5f);
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);

        }
    }
    //public static float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360F)
    //        angle += 360F;
    //    if (angle > 360F)
    //        angle -= 360F;
    //    return Mathf.Clamp(angle, min, max);
    //}
}
