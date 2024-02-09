using UnityEngine;

public class RoadGizmo : MonoBehaviour
{
    public bool isCurved = false;

    void OnDrawGizmos()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogWarning("RoadGizmo script needs a MeshRenderer component to work properly.");
            return;
        }

        Bounds bounds = meshRenderer.bounds;

        if (isCurved)
        {
            Vector3 edgeMidPoint1 = new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y, bounds.center.z);
            Vector3 edgeMidPoint2 = new Vector3(bounds.center.x, bounds.center.y, bounds.center.z + bounds.extents.z);

            float radius = bounds.extents.x;

            Vector3 previousPoint = edgeMidPoint1;
            int segments = 20;
            for (int i = 1; i <= segments; i++)
            {
                float angle = Mathf.Lerp(0, 90, (float)i / segments) * Mathf.Deg2Rad;
                Vector3 nextPoint = bounds.center + new Vector3(Mathf.Cos(angle) * radius, bounds.center.y, Mathf.Sin(angle) * radius);
                Gizmos.DrawLine(previousPoint, nextPoint);
                previousPoint = nextPoint;
            }
        }
        else
        {

            Vector3 startPoint = new Vector3(bounds.center.x, bounds.center.y, bounds.center.z - bounds.extents.z);
            Vector3 endPoint = new Vector3(bounds.center.x, bounds.center.y, bounds.center.z + bounds.extents.z);
            Gizmos.DrawLine(startPoint, endPoint);
        }
    }
}
