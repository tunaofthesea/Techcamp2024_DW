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

        // Use camera's forward direction for raycasting
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
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
            MeshRenderer mr = hitObject.GetComponent<MeshRenderer>();

            objectCanvas.transform.position = hit.collider.gameObject.transform.position + new Vector3(0.5f, 0.5f, -0.5f);

            // This could be the "shoot" or "interact" action, happening when the player presses the left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                triggeredObject.OnClick();
                objectPanelAnim.Play("InteractionPanel_close");
            }
        }
    }
}