using UnityEngine;

public class PlaceObjectsOnCurvee : MonoBehaviour
{
    public GameObject objectToPlace;
    public int numberOfObjects = 10;
    public float radius = 1f;

    void Start()
    {
        PlaceObjects();
    }

    void PlaceObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float theta = (Mathf.PI / 2) * i / (numberOfObjects - 1);
            Vector3 position = new Vector3(Mathf.Cos(theta) * radius, 0, Mathf.Sin(theta) * radius);
            Instantiate(objectToPlace, position, Quaternion.identity);
        }
    }
}