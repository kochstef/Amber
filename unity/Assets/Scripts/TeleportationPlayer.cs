using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeTillTeleport = 2f;

    public Transform cam;
    public Transform shoppingCart;

    //  [SerializeField] private float distanceOfRay;
    private float countdown = 0.0f;
    private float countdownLookInterrupt;
    private GameObject animationObject;
    private GameObject tempObject = null;
    private Transform teleportPosition;
    public float timeToInterruptLookAtList = 0.1f;

    private float scaleXOriginal;
    private float scaleZOriginal;


    //TODO: GET RID OF THAT UGLY BOOLEAN
    private bool teleportToCashierDesk = false;


    private Transform CheckTeleport()
    {
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(cam.transform.position, fwd, out var hit, 100,
                1 << LayerMask.NameToLayer("Teleportation")) &&
            hit.collider.CompareTag("Teleportation Platform"))
        {
            countdownLookInterrupt = timeToInterruptLookAtList;
            countdown += Time.deltaTime;
            simpleAnimation(hit);

            if (countdown < timeTillTeleport)
            {
                return null;
            }

            stopSimpleAnimation();
            teleportToCashierDesk = false;
            countdown = 0.0f;
            return teleportPosition;
        }

        if (Physics.Raycast(cam.transform.position, fwd, out hit, 100,
                1 << LayerMask.NameToLayer("Teleportation")) &&
            hit.collider.CompareTag("Teleportation Platform Cashier"))
        {
            countdownLookInterrupt = timeToInterruptLookAtList;
            countdown += Time.deltaTime;
            simpleAnimation(hit);

            if (countdown < timeTillTeleport)
            {
                return null;
            }

            teleportToCashierDesk = true;
            stopSimpleAnimation();
            countdown = 0.0f;
            return teleportPosition;
        }

        if (countdownLookInterrupt < 0.0f)
        {
            stopSimpleAnimation();
            countdown = 0.0f;
        }
        countdownLookInterrupt -= Time.deltaTime;

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
                    teleportToCashierDesk = false;
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

    private void teleportPlayer(Transform trans)
    {
        transform.position = new Vector3(trans.position.x, transform.position.y, trans.position.z);
    }

    private void teleportShopingCart()
    {
        if (!teleportToCashierDesk)
        {
            GameObject shoppingCardPosition = GameObject.FindGameObjectWithTag("PositionShoppingCart");
            if (shoppingCardPosition != null)
            {
                shoppingCart.position = new Vector3(shoppingCardPosition.transform.position.x, shoppingCart.position.y,
                    shoppingCardPosition.transform.position.z);
            }
        }
        else
        {
            GameObject shoppingCardPosition = GameObject.FindGameObjectWithTag("Shopping Cart Position Cashier");
            if (shoppingCardPosition != null)
            {
                shoppingCart.position = new Vector3(shoppingCardPosition.transform.position.x, shoppingCart.position.y,
                    shoppingCardPosition.transform.position.z);
            }
        }
    }

// Update is called once per frame
    void Update()
    {
        //TODO: change this to one call only 
        if (GameManager.Instance.TeleportEnabled)
        {
            Transform teleport_point = CheckTeleport();
            if (teleport_point != null)
            {
                teleportPlayer(teleport_point);
                teleportShopingCart();
                Debug.Log("Teleport");
            }
        }

/*  teleport_point = CheckTeleportCashierDesk();
  if (teleport_point != null)
  {
      teleportPlayer(new Vector3(teleport_point.position.x, transform.position.y, teleport_point.position.z));
      TeleportShopingCart();
      Debug.Log("Teleport");
  }*/
    }
}