using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : InteractionObject
{
    private ToggleMoveAndClampTarget objectMover;

    private float heightStart;
    private float heightTarget;

    private int modulus;

    protected override void Start()
    {
        base.Start();
        objectMover = ToggleMoveAndClampTarget.instance;

        heightStart = transform.position.y;
        heightTarget = transform.position.y + 0.4f;
    }


    public override void OnClick()
    {
        base.OnClick();
        objectMover.objectToMove = transform.parent.gameObject;
        objectMover.SetInitialPosition();
        modulus++;
        if(modulus%2 == 0)
        {
            StopAllCoroutines();
            StartCoroutine(MoveDown());
            modulus = 0;
            objectMover.DisableMovement();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(MoveUp());
            objectMover.EnableMovement();
        }
    }


    IEnumerator MoveUp()
    {
        float lerpTime = 0.25f;
        float elapsedTime = 0f;
        Vector3 _startPos = transform.position;
        Vector3 targetPos = new Vector3(transform.position.x, heightTarget, transform.position.z);

        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.parent.position = Vector3.Lerp(_startPos, targetPos, elapsedTime / lerpTime);
            yield return null;
        }

        transform.parent.position = targetPos;
    }

    IEnumerator MoveDown()
    {
        float lerpTime = 0.25f;
        float elapsedTime = 0f;
        Vector3 _startPos = transform.position;
        Vector3 targetPos = new Vector3(transform.position.x, heightStart, transform.position.z);

        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.parent.position = Vector3.Lerp(_startPos, targetPos, elapsedTime / lerpTime);
            yield return null;
        }

        transform.position = targetPos;
    }
}
