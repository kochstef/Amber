using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{

    public Transform doorLeft;
    public Transform doorRight;
    public float rotationSpeed = 0.05f;
    public bool openDoors = false;
    
    private Quaternion toLeft;
    private Quaternion toRight;
    // Start is called before the first frame update

    public void OpenDoor()
    {
        openDoors = true;
    }
    void Start()
    {
        toRight = Quaternion.Euler(doorRight.rotation.x, 380f, doorRight.rotation.z);
        toLeft = Quaternion.Euler(doorLeft.rotation.x, -380f, doorLeft.rotation.z);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(openDoors){
            doorRight.rotation = Quaternion.Lerp(doorRight.rotation, toRight, Time.deltaTime * rotationSpeed);
            doorLeft.rotation = Quaternion.Lerp(doorLeft.rotation, toLeft, Time.deltaTime * rotationSpeed);
        }
    }
}
