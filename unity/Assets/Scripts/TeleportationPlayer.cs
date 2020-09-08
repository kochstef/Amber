using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCounting = false;
    private float countdown = 0f;
    private float timeTillTeleport = 2f;
    public Transform cam;
    [SerializeField] private float distanceOfRay;
    private GameObject animationObject;
    private GameObject tempObject;
    private Transform teleportPosition;
    
    private float scaleXOriginal;
    private float scaleZOriginal;
    
    void Start()
    {
       
       
    }
    
    
    
    public Transform CheckTeleport()
    {
        RaycastHit hit;
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
       // var endPosition = cam.transform.position + transform.forward * distanceOfRay;
        
       // Debug.DrawLine(transform.position, endPosition, Color.magenta);
       /* if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            
            // Do something with the object that was hit by the raycast.
        }
        */

        if (Physics.Raycast(cam.transform.position, fwd, out hit, 100) && hit.collider.CompareTag("Teleportation Platform"))
        {
            Debug.Log("ölkasdf");
            isCounting = true;
        }
        else
        {
            if (tempObject != null)
            {
                animationObject = null;
                Destroy(tempObject);
            }

            isCounting = false;
            countdown = 0.0f;
            return null;
            //listObject.SetActive(false);
        }

        if (countdown >= timeTillTeleport)
        {
            if (tempObject != null)
            {
                animationObject = null;
                Destroy(tempObject);
            }

            return teleportPosition;
            /* if(!listObject.activeSelf)
             {
                 GameManager.instance.IncrementCounterLookedAtList();
             }
             animationObject.SetActive(false);
             listObject.SetActive(true);*/
            //deactivate loading list
        }

        if (isCounting)
        {
            foreach (Transform trans in hit.transform)
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
            if(tempObject == null)
            {
                tempObject = Instantiate(animationObject, hit.collider.transform.position, Quaternion.identity);
               // tempObject.transform.SetParent(hit.transform, false);

                tempObject.GetComponent<MeshRenderer>().enabled = true;
            }
            countdown += Time.deltaTime;
            
            float size = ((100 / timeTillTeleport) * countdown) / 100;
                
            tempObject.transform.localScale = new Vector3(scaleXOriginal * size, tempObject.transform.localScale.y , scaleZOriginal* size);
            
        }
        else
        {
           if(tempObject != null)
           {
               animationObject = null;
                Destroy(tempObject);
           }
        }
        
    

        return null;
    }
    // Update is called once per frame
    void Update()
    {
        Transform trans = CheckTeleport();
        if (trans != null)
        {
            Debug.Log("Teleport");
           transform.position = trans.position;
        }
    }
}
