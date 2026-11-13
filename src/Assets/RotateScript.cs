using UnityEngine;

public class RotateScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationSpeed = 360f * Time.deltaTime / 10f;
        this.transform.Rotate(0, rotationSpeed, 0);
    }
}
