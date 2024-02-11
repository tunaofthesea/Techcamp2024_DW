using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : InteractionObject
{
    public bool hasObject;
    public float distance = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        RaycastHit hit;

        // Attempt to cast a ray upwards from the shelf's position
        if (Physics.Raycast(transform.position, transform.up, out hit, distance))
        {
            // Check if the hit object has an IHoldable component
            IHoldable holdable = hit.collider.GetComponent<IHoldable>();
            hasObject = holdable != null; // Set hasObject based on the presence of an IHoldable

            if(hit.collider.gameObject.GetComponent<BowlingBall>() != null)
            {
                if (hit.collider.gameObject.GetComponent<BowlingBall>().canHarm)
                {
                    distance = 0;
                    StartCoroutine(DestroyShelf());
                }
            }
        }
        else
        {
            // If the raycast didn't hit anything, set hasObject to false
            hasObject = false;
        }

    }

    public override void OnClick()
    {
        if(hasObject)
        {
            return;
        }
        base.OnClick();
        GameObject go = ObjectHolder.instance.CheckObject();
        if (go != null)
        {
            go.transform.position = transform.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Set the color of the gizmo line
        Vector3 direction = transform.up * distance; // Calculate the direction and distance of the ray
        Gizmos.DrawRay(transform.position, direction); // Draw the ray from the object's position upward
    }

    IEnumerator DestroyShelf()
    {
        float randTime = Random.Range(2, 5);
        yield return new WaitForSeconds(randTime);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;


    }
}
