using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float xAxisRange = 10f;
    public GameObject projectilePrefab;

    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        KeepPlayerInBounds();

        LaunchAProjectile();
    }

    void KeepPlayerInBounds()
    {
        if(transform.position.x < -xAxisRange)
            transform.position = new Vector3(-xAxisRange, transform.position.y, transform.position.z);
        
        if(transform.position.x > xAxisRange)
            transform.position = new Vector3(xAxisRange, transform.position.y, transform.position.z);
    }

    void LaunchAProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
