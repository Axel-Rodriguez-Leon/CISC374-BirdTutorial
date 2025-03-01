using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CharacterController characterController;
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.5f;
    private float currentShakeTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TriggerShake()
    {
        currentShakeTime = shakeDuration;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentShakeTime > 0 && characterController.birdIsAlive == false)
        {
            Vector3 shakeOffset = Random.insideUnitCircle * shakeIntensity;
            transform.position += shakeOffset;
            currentShakeTime -= Time.deltaTime;
        }
    }
}
