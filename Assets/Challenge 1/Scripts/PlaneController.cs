using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 25f;
    public float rotationSpeed = 100f;

    public float verticalInput;

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);
    }
}
