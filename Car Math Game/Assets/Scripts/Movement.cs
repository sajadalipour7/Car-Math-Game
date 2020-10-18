using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float ForwardSpeed = 10f;
    [SerializeField] float BackwardSpeed = 10f;
    [SerializeField] float TurnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        

    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, ForwardSpeed* Time.deltaTime, Space.Self);
            //transform.position += Vector3.forward * Time.deltaTime * ForwardSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -BackwardSpeed * Time.deltaTime, Space.Self);
            //transform.position += Vector3.back * Time.deltaTime * BackwardSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * Time.deltaTime * TurnSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * Time.deltaTime * TurnSpeed, 0);
        }
    }
}
