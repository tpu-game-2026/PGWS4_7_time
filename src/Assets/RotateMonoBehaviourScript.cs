using UnityEngine;

public class RotateMonoBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //                   360で一周  1秒で1増える  1周の秒数
        float rotationSpeed = 360.0f * Time.deltaTime / 10.0f;
        this.transform.Rotate(0, rotationSpeed, 0);
    }
}
