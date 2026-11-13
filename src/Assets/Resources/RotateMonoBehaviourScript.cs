using UnityEngine;

public class RotateMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationSpeed = 360.0f * Time.deltaTime / 10.0f;
        this.transform.Rotate(0, rotationSpeed, 0);
    }
}
