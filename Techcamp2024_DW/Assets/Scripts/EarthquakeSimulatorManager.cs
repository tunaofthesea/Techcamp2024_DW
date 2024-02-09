using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSimulatorManager : MonoBehaviour
{
    public Transform floorTransform;
    public float frequency = 1.0f; 
    public float magnitude = 0.0f;
    public float entryTime = 3f;

    private Vector3 originalPosition;
    private float elapsedTime = 0.0f;

    void Start()
    {
        if (floorTransform != null)
        {
            originalPosition = floorTransform.position;
        }
        StartCoroutine("Intensify");
    }

    void Update()
    {
        if (floorTransform != null)
        {
            elapsedTime += Time.deltaTime;
            float x = Mathf.PerlinNoise(elapsedTime * frequency, 0) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0, elapsedTime * frequency) * 2.0f - 1.0f;
            float z = Mathf.PerlinNoise(elapsedTime * frequency, elapsedTime * frequency) * 2.0f - 1.0f;

            Vector3 newPosition = originalPosition + new Vector3(x, y, z) * magnitude;
            floorTransform.position = newPosition;
        }
        
    }
    private IEnumerator Intensify() 
    {
        while (true) 
        {
            switch (magnitude) 
            {
                case float n when (n < 1):
                    magnitude += 0.1f;
                    break;
                case float n when (n >= 1 && n < 2):
                    magnitude += 0.025f;
                    break;
                case float n when (n > 2):
                    magnitude -= 0.2f;
                    break;         
            }
            Debug.Log(magnitude);   
            yield return new WaitForSeconds(0.2f);
        }
    }
}
