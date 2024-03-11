using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float xAxisRange = 10f;
    [SerializeField]
    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        KeepPlayerInBounds();
    }

    void KeepPlayerInBounds()
    {
        if(transform.position.x < -xAxisRange)
            transform.position = new Vector3(-xAxisRange, transform.position.y, transform.position.z);
        
        if(transform.position.x > xAxisRange)
            transform.position = new Vector3(xAxisRange, transform.position.y, transform.position.z);
    }
}
