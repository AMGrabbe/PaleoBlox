using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float widthInUnityUnits = 16f;
    [SerializeField] float ScreenBoundaryMin = 1f;
    [SerializeField] float ScreenBoundaryMax = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXPositionInUnits = Input.mousePosition.x / Screen.width * widthInUnityUnits;
        Vector3 paddlePosition = new Vector3(mouseXPositionInUnits, transform.position.y, 0);
        paddlePosition.x = Mathf.Clamp( mouseXPositionInUnits, ScreenBoundaryMin, ScreenBoundaryMax);
        transform.position = paddlePosition;
    }
}
