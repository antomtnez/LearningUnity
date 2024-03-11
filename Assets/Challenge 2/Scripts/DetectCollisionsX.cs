using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("The dog get the ball");
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
