using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedText;

    [SerializeField] AudioSource audioSource;

    [SerializeField] float forwardSpeed = 20f;
    [SerializeField] float backwardSpeed = 20f;
    [SerializeField] float turnSpeed = 100f;

    [SerializeField] ButtonPressed leftPressed;
    [SerializeField] ButtonPressed rightPressed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speedText.text = "Speed : " + ((int)(forwardSpeed)).ToString() + " KM/h";
        StartCoroutine("SoundStart");
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {

        transform.Translate(0, 0, forwardSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.W) )
        {
            
            transform.Translate(0, 0, forwardSpeed* Time.deltaTime, Space.Self);
            //transform.position += Vector3.forward * Time.deltaTime * ForwardSpeed;
        }
        else if (Input.GetKey(KeyCode.S) )
        {
            
            transform.Translate(0, 0, -backwardSpeed * Time.deltaTime, Space.Self);
            //transform.position += Vector3.back * Time.deltaTime * BackwardSpeed;
        }
        
        if (Input.GetKey(KeyCode.D) || rightPressed.PublicIsPressed())
        {
            transform.Rotate(0, 1 * Time.deltaTime * turnSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.A) || leftPressed.PublicIsPressed())
        {
            
            transform.Rotate(0, -1 * Time.deltaTime * turnSpeed, 0);
        }

    }

    public void ChangeSpeed(float amount)
    {
        forwardSpeed += amount;
        audioSource.volume += amount / 20;
        speedText.text = "Speed : " + ((int)(forwardSpeed)).ToString() + " KM/h";
    }

    IEnumerator SoundStart()
    {
        yield return new WaitForSeconds(2f);
        audioSource.Play();
    }

    

}
