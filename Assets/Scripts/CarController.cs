using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CarController : MonoBehaviour
{
    public float horsePower = 20f;
    public float turnSpeed = 45f;

    private float horizontalInput;
    private float forwardInput;

    private Rigidbody _rb;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;

    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    private int wheelsOnGround;

    void Start(){
        _rb = GetComponent<Rigidbody>();
        Debug.Log($"{_rb.centerOfMass} , myVar: {centerOfMass.transform.position}");
        //_rb.centerOfMass = centerOfMass.transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if(IsOnGround()){
            Speedometer();
            RPM();
        
            //Rotates the car based on horizontal input
            if(speed >= 1) 
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    void FixedUpdate() {
        if(IsOnGround()) MoveCar();
    }

    void MoveCar(){
        //Moves the car forward based on vertical input
        _rb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
    }

    void Speedometer(){
        speed = Mathf.Round(_rb.velocity.magnitude * 3.6f);
        speedometerText.SetText($"Speed: {speed} km/h");
    }

    void RPM(){
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText($"RPM: {rpm}");
    }

    bool IsOnGround(){
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels){
            if(wheel.isGrounded)
                wheelsOnGround++;
        }

        if(wheelsOnGround == 4) return true;
        return false;
    }
}
