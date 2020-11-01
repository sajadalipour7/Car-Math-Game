using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedText;

    [SerializeField] AudioSource audioSource;

    [SerializeField] Transform finishCube;

    [SerializeField] float forwardSpeed = 20f;
    [SerializeField] float backwardSpeed = 20f;
    [SerializeField] float turnSpeed = 100f;

    [SerializeField] ButtonPressed leftPressed;
    [SerializeField] ButtonPressed rightPressed;

    [SerializeField] Button changeTiltButton;


    [SerializeField] float tiltAmount = 2f;

    private bool tiltMode = false;

    Vector3 finishLine;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            tiltAmount = 2.5f;
        }
        speedText.text = "Speed : " + ((int)(forwardSpeed)).ToString() + " KM/h";
        finishLine = finishCube.position;
        
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(finishLine, transform.position)<15f)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

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
        if (tiltMode)
        {
            transform.Rotate(0, tiltAmount * Input.acceleration.x, 0);
        }
    }

    public void ChangeSpeed(float amount)
    {
        if (amount > 0)
        {
            turnSpeed -= 2;
            audioSource.Play();
        }
        else
        {
            turnSpeed += 2;
        }
        forwardSpeed += amount;
        audioSource.volume += amount / 20;
        speedText.text = "Speed : " + ((int)(forwardSpeed)).ToString() + " KM/h";
    }


    public void changeTiltMode()
    {
        if (tiltMode)
        {
            tiltMode = false;
            rightPressed.gameObject.SetActive(true);
            leftPressed.gameObject.SetActive(true);
            changeTiltButton.GetComponentInChildren<Text>().text = "Tilt";

        }
        else
        {
            tiltMode = true;
            rightPressed.gameObject.SetActive(false);
            leftPressed.gameObject.SetActive(false);
            changeTiltButton.GetComponentInChildren<Text>().text = "Steer";
        }
    }

    

    

}
