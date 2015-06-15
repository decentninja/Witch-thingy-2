﻿using UnityEngine;
using System.Collections;

public class lookscr : MonoBehaviour {
     public float sensitivityX = 15F;
     public float sensitivityY = 15F;

     public float minimumX = -360F;
     public float maximumX = 360F;

     public float minimumY = -60F;
     public float maximumY = 60F;

     float rotationX = 0F;
     float rotationY = 0F;

     Quaternion originalRotation;

     void Update()
     {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * -sensitivityY;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
     }

     void Start()
     {
         originalRotation = transform.localRotation;
         Cursor.visible = false;
     }

     public static float ClampAngle(float angle, float min, float max)
     {
         if (angle < -360F)
             angle += 360F;
         if (angle > 360F)
             angle -= 360F;
         return Mathf.Clamp(angle, min, max);
     }
}
