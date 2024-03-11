using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timeSinceLastPress = 0f;
    private float cooldownTime = 1f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPress += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastPress >= cooldownTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeSinceLastPress = 0f;
        }
    }
}
