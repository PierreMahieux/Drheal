using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 15f;
    private void Start()
    {
        if (!controller)
        {
            controller=this.GetComponent<CharacterController>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z")){

            Vector3 move = transform.forward;
            //Debug.Log("pouet");

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {

            Vector3 move = transform.right;
            //Debug.Log("pouet");

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKey("q"))
        {

            Vector3 move = transform.right;
            //Debug.Log("pouet");

            controller.Move(move * -speed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {

            Vector3 move = transform.forward;
            //Debug.Log("pouet");

            controller.Move(move * -speed * Time.deltaTime);
        }
    }
}
