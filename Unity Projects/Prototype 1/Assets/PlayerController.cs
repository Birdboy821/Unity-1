using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower = 25.0f;
    [SerializeField] float turnSpeed = 105.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move vehicle based on horizontal speed
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        //Move vehicle forward on Vertical input
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedometer.SetText("Speed: " + speed + "mph");
        rpm = Mathf.Round((speed % 30)*40);
        rpmText.SetText("RPM: " + rpm);
    }
    
}
