using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float forwardSpeed = 20f;
    [SerializeField] float backwardSpeed = 20f;
    [SerializeField] float turnSpeed = 100f;

    [SerializeField] ButtonPressed leftPressed;
    [SerializeField] ButtonPressed rightPressed;
    [SerializeField] ButtonPressed backwardPressed;
    [SerializeField] ButtonPressed gasPressed;

    enum State { MovingForward , MovingBackward , Nothing};
    State stateOfMovement;
    // Start is called before the first frame update
    void Start()
    {
        stateOfMovement = State.Nothing;
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W) || gasPressed.PublicIsPressed())
        {
            stateOfMovement = State.MovingForward;
            transform.Translate(0, 0, forwardSpeed* Time.deltaTime, Space.Self);
            //transform.position += Vector3.forward * Time.deltaTime * ForwardSpeed;
        }
        else if (Input.GetKey(KeyCode.S) || backwardPressed.PublicIsPressed())
        {
            stateOfMovement = State.MovingBackward;
            transform.Translate(0, 0, -backwardSpeed * Time.deltaTime, Space.Self);
            //transform.position += Vector3.back * Time.deltaTime * BackwardSpeed;
        }
        else
        {
            stateOfMovement = State.Nothing;
        }
        if (Input.GetKey(KeyCode.D) || rightPressed.PublicIsPressed())
        {
            int direction = 1;
            if (stateOfMovement == State.MovingBackward)
            {
                direction = -1;
            }
            transform.Rotate(0, 1 * Time.deltaTime * turnSpeed*direction, 0);
        }
        else if (Input.GetKey(KeyCode.A) || leftPressed.PublicIsPressed())
        {
            int direction = 1;
            if (stateOfMovement == State.MovingBackward)
            {
                direction = -1;
            }
            transform.Rotate(0, -1 * Time.deltaTime * turnSpeed*direction, 0);
        }

    }

}
