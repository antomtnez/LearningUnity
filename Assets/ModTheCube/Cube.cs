using UnityEngine;

public class Cube : MonoBehaviour
{
    #region CubeMovementVariables
    private float xAxisRange = 8f;
    private float zAxisRange = 4.5f;
    private float movementSpeed = 2f;
    Vector3 targetPosition = Vector3.zero;
    #endregion
    #region CubeSizeVariables
    private float newScale;
    private float maxScale = 1.3f;
    private float minScale = 0.7f;
    #endregion
    #region CubeRotationVariables
    private float rotationSpeed = 100f;
    private float currentRotationTime = 0f;
    private float rotationTime = 5f;
    private Vector3 targetRotation = Vector3.zero;
    #endregion
    #region CubeColorVariables
    public MeshRenderer Renderer;
    private Color newColor = Color.blue;
    private float currentColoringTime = 0f;
    private float coloringTime = 5f;
    #endregion
    
    void Update()
    {
        CubeMovement();

        CubeResize();
        
        CubeRotation();

        CubeColorChanging();
    }

    void CubeMovement()
    {
        if(Vector3.Distance(transform.position, targetPosition) <= 0.2f)
            targetPosition = new Vector3(Random.Range(-xAxisRange, xAxisRange), transform.position.y, Random.Range(-zAxisRange, zAxisRange));
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    void CubeResize()
    {
        if(transform.localScale.x >= maxScale || transform.localScale.x <= minScale)
            newScale = Random.Range(minScale, maxScale);

        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * newScale, Time.deltaTime);
    }

    void CubeRotation()
    {
        if(currentRotationTime >= rotationTime)
        {
            targetRotation = new Vector3(Random.Range(0, rotationSpeed),Random.Range(0, rotationSpeed), Random.Range(0, rotationSpeed));
            currentRotationTime = 0f;
        }

        transform.Rotate(targetPosition * Time.deltaTime);
        currentRotationTime += Time.deltaTime;
    }

    void CubeColorChanging()
    {
        if(currentColoringTime >= coloringTime)
        {
            newColor = RandomColor();
            currentColoringTime = 0f;
        }
        
        Renderer.material.color = Color.Lerp(Renderer.material.color, newColor, Time.deltaTime);
        currentColoringTime += Time.deltaTime;
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
