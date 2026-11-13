using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StopScript : MonoBehaviour
{
    [SerializeField] Renderer target;
    [SerializeField] TextMeshProUGUI checkTxt;
    [Tooltip("Lineをここに入れる")][SerializeField] Transform judgeLine;
    [Header("水色の部分(下)")][SerializeField] float hitMin = 0.45f;
    [Header("水色の部分(上)")][SerializeField] float hitMax = 0.70f;

    static readonly int TargetTimeId = Shader.PropertyToID("_TargetTime");
    static readonly int WaveNumberId = Shader.PropertyToID("_Wave_Number");
    static readonly int FrequencyId = Shader.PropertyToID("_Frequency");
    static readonly int PowerId = Shader.PropertyToID("_Power");

    [Header("比較用")][SerializeField] float time = 0.0f;
    float speed = 1f;
    Material myShaderMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myShaderMaterial = target.material;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        myShaderMaterial.SetFloat(TargetTimeId, time);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            float g = GradientPosition(judgeLine.position);
            if (g >= hitMin && g <= hitMax) 
                OnHit(); 
            else 
                OnMiss();
        }
    }
    float GradientPosition(Vector3 worldPos)
    {
        Vector3 wave = myShaderMaterial.GetVector(WaveNumberId);
        float x = Vector3.Dot(wave, worldPos) - time * myShaderMaterial.GetFloat(FrequencyId);
        x -= Mathf.Floor(x);                     // Fraction
        
        return Mathf.Pow(x, myShaderMaterial.GetFloat(PowerId)); // Power
    }

    void OnHit() 
    {
        speed *= 1.2f; 
        Debug.Log("Hitttttt!!!!");
        checkTxt.text = ("Hittttt!");
        CancelInvoke();
        Invoke("ResetTxt", 0.3f);
    } 
    void OnMiss() 
    { 
        speed = 1f; 
        Debug.Log("Oh No......");
        checkTxt.text = ("Oh No......");
        CancelInvoke();
        Invoke("ResetTxt", 0.3f);
    }

    void ResetTxt()
    {
        checkTxt.text = ("Check");
    }
}
