using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBreakFromFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Break>() != null) 
        {
            Debug.Log(collision.relativeVelocity.magnitude > 3f);
            if (collision.relativeVelocity.magnitude > 2.4f)
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.SendMessage("BreakObject"); //Nested condition idea: When passes 80 degrees of rotation on either x or z
                                                                 //and collides with floor, break.
                //StartCoroutine("EnableCollision");
                //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(3f, collision.transform.position, 2f, 3f, ForceMode.Impulse);
            }
        }
    }
    private IEnumerator EnableCollision()
    {
        //yield return new WaitForSeconds(0.01f);
        //Physics.IgnoreLayerCollision(3,3, false);
        //yield return new WaitForSeconds(0.075f);
        //Physics.IgnoreLayerCollision(3, 3, true);
        yield return null;
    }
}
