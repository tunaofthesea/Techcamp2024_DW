using System.Collections;
using UnityEngine;

public class ToggleMoveAndClampTarget : MonoBehaviour
{
    public GameObject objectToMove;
    public bool moveOnX = true; // True for movement on X-axis, false for Z-axis
    public float speed = 5f;
    public float maxDistance = 1f;
    public Vector3 startPositionOffset;

    private bool isFollowing = false;
    private Vector3 targetPosition;
    private Vector3 initialPosition;

    public static ToggleMoveAndClampTarget instance;

    private bool _enabled = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if(objectToMove == null) { return; }

        initialPosition = objectToMove.transform.position + startPositionOffset;
    }

    public void SetInitialPosition()
    {
        initialPosition = objectToMove.transform.position + startPositionOffset;
    }

    void Update()
    {
        if (!_enabled)   { return; }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            isFollowing = !isFollowing;
        }

        if (isFollowing)
        {
            UpdateTargetPosition();
        }
        */
        UpdateTargetPosition();
        MoveObjectTowardsTarget();
    }

    public void EnableMovement()
    {
        AudioManager.Instance.PlaySFX("Pick Up");
        _enabled = true;
    }

    public void DisableMovement()
    {
        AudioManager.Instance.PlaySFX("Let Go");
        _enabled = false;
    }


    void UpdateTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (moveOnX)
            {
                targetPosition = new Vector3(hit.point.x, objectToMove.transform.position.y, objectToMove.transform.position.z);
            }
            else
            {
                targetPosition = new Vector3(objectToMove.transform.position.x, objectToMove.transform.position.y, hit.point.z);
            }

            targetPosition = ClampPosition(targetPosition);
        }
    }

    Vector3 ClampPosition(Vector3 targetPos)
    {
        Vector3 offsetFromInitial = targetPos - initialPosition;
        if (moveOnX)
        {
            offsetFromInitial.x = Mathf.Clamp(offsetFromInitial.x, -maxDistance, maxDistance);
            return new Vector3(initialPosition.x + offsetFromInitial.x, targetPos.y, targetPos.z);
        }
        else
        {
            offsetFromInitial.z = Mathf.Clamp(offsetFromInitial.z, -maxDistance, maxDistance);
            return new Vector3(targetPos.x, targetPos.y, initialPosition.z + offsetFromInitial.z);
        }
    }

    void MoveObjectTowardsTarget()
    {
        //if (isFollowing)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
