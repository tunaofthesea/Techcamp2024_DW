using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera cam;
    public LayerMask clickableLayer;
    public Canvas objectCanvas;

    private IClickable previousObject;

    public bool disable;

    public static InputManager instance;

    private GameObject objectPanel;
    private Animator objectPanelAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        objectPanel = objectCanvas.transform.GetChild(0).gameObject;
        objectPanelAnim = objectPanel.GetComponent<Animator>();
    }

    private void Update()
    {
        if (disable)
        {
            return;
        }

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 10, clickableLayer))
        {
            if (previousObject != null)
            {
                previousObject.OffPointer();
                previousObject = null;

                objectPanelAnim.Play("InteractionPanel_close");
            }
            return;
        }

        IClickable triggeredObject = hit.collider.gameObject.GetComponent<IClickable>();

        if (previousObject != null && previousObject != triggeredObject)
        {
            previousObject.OffPointer();
            previousObject = null;
        }

        if (triggeredObject != null)
        {
            triggeredObject.OnPointer();
            previousObject = triggeredObject;

            objectPanelAnim.Play("InteractionPanel_open");

            GameObject hitObject = hit.collider.gameObject;
            Vector3 anchorPosition = Vector3.Lerp(hitObject.transform.position, ray.origin, 0.5f);

            float minDistance = 1f; // The minimum distance at which the scale will be at its smallest
            float maxDistance = 10f; // The maximum distance at which the scale will be at its largest

            // Your calculated distance
            float distance = Vector3.Distance(hitObject.transform.position, ray.origin);

            // Normalize the distance to a value between 0 and 1
            float normalizedDistance = Mathf.Clamp((distance - minDistance) / (maxDistance - minDistance), 0f, 1f);

            // Define your scale range
            float minScale = 0.1f;
            float maxScale = 0.5f;

            // Lerp the scale based on the normalized distance
            float scale = Mathf.Lerp(minScale, maxScale, normalizedDistance);

            // Apply the scale to your canvas
            objectCanvas.transform.localScale = new Vector3(scale, scale, scale);

            objectCanvas.transform.position = anchorPosition + new Vector3(0.1f, 0.1f, 0);//hit.collider.gameObject.transform.position + new Vector3(0.5f, 0.5f, -0.5f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                triggeredObject.OnClick();
                objectPanelAnim.Play("InteractionPanel_close");
                ObjectHolder.instance.HoldObject(hitObject);
            }
        }
    }
}