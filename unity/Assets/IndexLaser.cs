using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform index;
    public LineRenderer lineRenderer;
    private bool render = false;
    
    void Start()
    {
        lineRenderer.enabled = false;
        index = gameObject.transform.Find("Bones/Hand_Start/Hand_Index1/Hand_Index2/Hand_Index3/Hand_IndexTip");
    }

    private void renderLine()
    {
        if (index != null)
        {
            //Vector3[] pos = new Vector3[]{index.position, -index.right};
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, index.position);
            lineRenderer.SetPosition(1, (index.right) * 20 + transform.position);
            Debug.DrawRay(index.position, index.right , Color.white);
        }
    }

    public void renderTrue()
    {
        if(!GameManager.Instance.TeleportEnabled) return;
        if (index != null)
        {
            render = true;
            lineRenderer.enabled = true;
            Debug.Log("LINE!!!!!");
        }
    }

    public void renderFalse()
    {
        render = false;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(index == null)
        {
            index = gameObject.transform.Find("Bones/Hand_Start/Hand_Index1/Hand_Index2/Hand_Index3/Hand_IndexTip");
        }

        if (render)
        {
            renderLine();
        }


    }
}
