using UnityEngine;
using UnityEditor;
using UnityEngine.Playables;


[ExecuteInEditMode]
public class GridPlacer : MonoBehaviour
{
#if UNITY_EDITOR
    public Camera mainCamera; // Assign your main camera in the inspector.
    public float gridSize = 1.0f; // Change this to match your grid size.
    public LayerMask placeableLayer; // Assign this in the inspector to filter raycast hits.

    public bool isPlacing = false;
    public Vector3 startPosition;
    public IPlaceable currentPlaceable; // Reference to the current IPlaceable object being placed.

    public void Check()
    {
        //
        if (Input.GetMouseButtonDown(0) && !isPlacing)
        {
            Debug.Log("AA");
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, placeableLayer))
            {

                var placeable = hit.collider.gameObject.GetComponent<IPlaceable>();
                if (placeable != null && placeable.CanBePlaced())
                {
                    isPlacing = true;
                    currentPlaceable = placeable;
                    startPosition = hit.collider.gameObject.transform.position;
                }
            }
        }

        if (isPlacing)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, placeableLayer))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.x = Mathf.Round(targetPosition.x / gridSize) * gridSize;
                targetPosition.y = Mathf.Round(targetPosition.y / gridSize) * gridSize;
                targetPosition.z = Mathf.Round(targetPosition.z / gridSize) * gridSize;

                hit.collider.gameObject.transform.position = targetPosition;
            }
        }

        if (Input.GetMouseButtonUp(0) && isPlacing)
        {
            isPlacing = false;
            if (currentPlaceable != null)
            {
                currentPlaceable.Place();
                currentPlaceable = null;
            }
        }
    }

#endif
}
