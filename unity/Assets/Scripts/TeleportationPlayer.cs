using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeTillTeleport = 2f;

    public Transform cam;

    //  [SerializeField] private float distanceOfRay;
    private float countdown = 0.0f;
    private GameObject animationObject;
    private GameObject tempObject = null;
    private Transform teleportPosition;

    private float scaleXOriginal;
    private float scaleZOriginal;


    public Transform CheckTeleport()
    {
        RaycastHit hit;
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(cam.transform.position, fwd, out hit, 100) &&
            hit.collider.CompareTag("Teleportation Platform"))
        {
            countdown += Time.deltaTime;
            simpleAnimation(hit);

            if (countdown < timeTillTeleport)
            {
                return null;
            }
            stopSimpleAnimation();
            return teleportPosition;
        }

        stopSimpleAnimation();
        countdown = 0.0f;
        return null;
    }

    private void simpleAnimation(RaycastHit hit)
    {
        if (animationObject == null)
        {
            foreach (Transform trans in hit.collider.transform)
            {
                if (trans.CompareTag("Teleportation Animation"))
                {
                    scaleXOriginal = trans.localScale.x;
                    scaleZOriginal = trans.localScale.z;
                    animationObject = trans.gameObject;
                    Debug.Log("Found");
                }

                if (trans.CompareTag("Teleportation Point"))
                {
                    teleportPosition = trans;
                }
            }
        }

        if (tempObject == null)
        {
            Debug.Log("Intatiate Animation object");
            tempObject = Instantiate(animationObject, hit.collider.transform.position, Quaternion.identity);
            // tempObject.transform.SetParent(hit.transform, false);
            tempObject.GetComponent<MeshRenderer>().enabled = true;
        }


        float size = ((100 / timeTillTeleport) * countdown) / 100;
        tempObject.transform.localScale = new Vector3(scaleXOriginal * size, tempObject.transform.localScale.y,
            scaleZOriginal * size);
    }

    private void stopSimpleAnimation()
    {
        if (tempObject != null)
        {
            animationObject = null;
            Destroy(tempObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform teleport_point = CheckTeleport();
        if (teleport_point != null)
        {
            Debug.Log("Teleport");
            transform.position = new Vector3(teleport_point.position.x, transform.position.y, teleport_point.position.z);
        }
    }
}