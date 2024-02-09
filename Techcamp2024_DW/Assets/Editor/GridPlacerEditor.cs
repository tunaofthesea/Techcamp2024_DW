using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridPlacer))]
public class GridPlacerEditor : Editor
{
    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        GridPlacer gridPlacer = (GridPlacer)target;

        HandleMouseInput(gridPlacer);

        sceneView.Repaint();
    }

    private void HandleMouseInput(GridPlacer gridPlacer)
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDown && e.button == 0) // Left mouse button
        {
            Debug.Log("zAA");
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gridPlacer.placeableLayer))
            {
                var placeable = hit.collider.gameObject.GetComponent<IPlaceable>();
                if (placeable != null && placeable.CanBePlaced())
                {
                    gridPlacer.isPlacing = true;
                    gridPlacer.currentPlaceable = placeable;
                    gridPlacer.startPosition = hit.collider.gameObject.transform.position;
                    e.Use();
                }
            }
        }
    }
}