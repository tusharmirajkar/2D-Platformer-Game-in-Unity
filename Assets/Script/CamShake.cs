using UnityEngine;
using Unity.Cinemachine;

public class CamShake : MonoBehaviour
{
    public CinemachineCamera cam;
    private float shakeTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0f)
            {
                CinemachineBasicMultiChannelPerlin Perlin = cam.GetComponent<CinemachineBasicMultiChannelPerlin>();
                Perlin.AmplitudeGain = 0f;
            }
        }
        
    }

    public void Shake(float intensity, float duration)
    {
        shakeTime = duration;
        CinemachineBasicMultiChannelPerlin Perlin =cam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        Perlin.AmplitudeGain = intensity;
    }
}
