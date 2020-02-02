using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 15f;
    internal bool canMove = true;

    public float sensitivityX = 1F;
    public float sensitivityY = 1F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    //float rotationY = 0F;
    Quaternion originalRotation;

    private void Start()
    {
        if (!controller)
        {
            controller=this.GetComponent<CharacterController>();
        }

		//if (rigidbody)
		//    rigidbody.freezeRotation = true;
        originalRotation = transform.localRotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey("z"))
            {
                Vector3 move = transform.forward;
                controller.Move(move * speed * Time.deltaTime);
            }

            if (Input.GetKey("d"))
            {
                Vector3 move = transform.right;
                controller.Move(move * speed * Time.deltaTime);
            }

            if (Input.GetKey("q"))
            {
                Vector3 move = transform.right;
                controller.Move(move * -speed * Time.deltaTime);
            }

            if (Input.GetKey("s"))
            {
                Vector3 move = transform.forward;
                controller.Move(move * -speed * Time.deltaTime);
            } 
        }


        //rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        //rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //rotationX = ClampAngle(rotationX, minimumX, maximumX);
        //rotationY = ClampAngle(rotationY, minimumY, maximumY);
        //Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        //Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
        //transform.localRotation = originalRotation * xQuaternion * yQuaternion;

        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation = originalRotation * xQuaternion;
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
