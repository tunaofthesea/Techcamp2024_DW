using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSimulatorManager : MonoBehaviour
{
    public Transform floorTransform;
    public float frequency = 1.0f; 
    public float magnitude = 0.0f;
    public float entryTime = 3f;
    public float quakeDuration = 10f;
    public float maximumMagnitude = 1.25f;

    public bool isEasingOut;
    private bool easeCalled;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float elapsedTime = 0.0f;

    void Start()
    {
        if (floorTransform != null)
        {
            originalPosition = floorTransform.position;
            originalRotation = floorTransform.rotation;
        }
        //StartCoroutine("Intensify");
    }

    void Update()
    {
        if (floorTransform != null)
        {
            elapsedTime += Time.deltaTime;
            float x = Mathf.PerlinNoise(elapsedTime * frequency, 0) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0, elapsedTime * frequency) * 2.0f - 1.0f;
            float z = Mathf.PerlinNoise(elapsedTime * frequency, elapsedTime * frequency) * 2.0f - 1.0f;


            Vector3 newPosition = originalPosition + new Vector3(x, y / 1.5f, z) * magnitude;
            //floorTransform.rotation *= Quaternion.Euler(newPosition);
            floorTransform.position = newPosition;
        }
        
    }
    private IEnumerator Intensify() 
    {
        AudioManager.Instance.PlaySFX("Earthquake");
        while (true) 
        {
            switch (magnitude) 
            {
                case float n when (n < 1):
                    magnitude += 0.1f;
                    break;
                case float n when (n >= 1 && n < maximumMagnitude):
                    magnitude += 0.025f;
                    break;
                case float n when (n > maximumMagnitude):
                    magnitude -= 0.2f;
                    if (!easeCalled) 
                    {
                        StartCoroutine("EaseOut", quakeDuration);
                        easeCalled = true;
                    }
                    break;

            }
            Debug.Log(magnitude);   
            yield return new WaitForSeconds(0.2f);
        }
    }
    private IEnumerator EaseOut(int x)
    {
        while (true)
        {

            if(isEasingOut)
            {
                StopCoroutine("Intensify");
                yield return new WaitForSeconds(0.2f);
                switch (magnitude)
                {
                    case > 0:
                        magnitude -= 0.1f;
                        break;
                    case <= 0:
                        magnitude = 0;
                        StopCoroutine("EaseOut");
                        transform.position = originalPosition;
                        AudioManager.Instance.sfxSource.Stop();
                        this.enabled = false;
                        break;
                }
            }
            else
            {
                yield return new WaitForSeconds(x);
                isEasingOut = true;
            }
              
        }
    }
}
