using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    
    
    
    
    public Transform doorLeft;
    public Transform doorRight;
    public float rotationSpeed = 0.05f;
    public bool openDoors = false;
    public GameObject itemListTextField;
    public GameObject looksAtListTextField;
    public TextMeshPro timeText;
    public Transform spawnPositionItemList;
    private Quaternion toLeft;

    private Quaternion toRight;
    // Start is called before the first frame update

    public void OpenDoor()
    {
        openDoors = true;
    }

    public void ShowList(List<string> correctItemsList, List<string> wrongItemsList, float time, List<string> listLooksAtList)
    {
        GameObject lastItem = itemListTextField;
        lastItem.transform.position = spawnPositionItemList.transform.position;
        float offset = 0.0f;
        bool first = true;
        foreach (var str in correctItemsList)
        {
            if (!first)
            {
                lastItem = Instantiate(lastItem, transform);
                lastItem.transform.position = new Vector3(spawnPositionItemList.position.x,
                    spawnPositionItemList.position.y + offset, spawnPositionItemList.position.z);
                offset -= 0.096f;
            }
            else
            {
                lastItem = Instantiate(lastItem, transform);
                lastItem.transform.position = new Vector3(spawnPositionItemList.position.x,
                    spawnPositionItemList.position.y + offset, spawnPositionItemList.position.z);
                offset -= 0.096f;
            }

            lastItem.GetComponent<TextFieldItemEndUI>().SetText(str);
            lastItem.GetComponent<TextFieldItemEndUI>().SetWrongRight(true);

            first = false;
        }

        foreach (var str in wrongItemsList)
        {

            if (!first)
            {
                lastItem = Instantiate(lastItem, transform);
                lastItem.transform.position = new Vector3(spawnPositionItemList.position.x,
                    spawnPositionItemList.position.y + offset, spawnPositionItemList.position.z);
                offset -= 0.096f;
            }
            else
            {
                lastItem = Instantiate(lastItem, transform);
                lastItem.transform.position = new Vector3(spawnPositionItemList.position.x,
                    spawnPositionItemList.position.y + offset, spawnPositionItemList.position.z);
                offset -= 0.096f;
            }
            lastItem.GetComponent<TextFieldItemEndUI>().SetText(str);
            lastItem.GetComponent<TextFieldItemEndUI>().SetWrongRight(false);
            first = false;
        }

        
        
        if (listLooksAtList.Count == 0)
        {
            looksAtListTextField.SetActive(false);
        }
        
        first = true;  
        lastItem = looksAtListTextField;
        foreach (var str in listLooksAtList)
        {
            if (!first)
            {
                lastItem = Instantiate(lastItem, transform);
                lastItem.transform.position = new Vector3(lastItem.transform.position.x,
                    lastItem.transform.position.y - 0.096f, lastItem.transform.position.z);
            }
            lastItem.GetComponent<EndUiLooksAtList>().SetText(str);
            first = false;
        }
        

        string minSec = string.Format("{0}:{1:00}", (int) time / 60, (int) time % 60);
        SetTime(minSec);
    }

    public void SetTime(string str)
    {
        timeText.text = str;
    }

    void Start()
    {
        toRight = Quaternion.Euler(doorRight.rotation.x, 380f, doorRight.rotation.z);
        toLeft = Quaternion.Euler(doorLeft.rotation.x, -380f, doorLeft.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoors)
        {
            doorRight.rotation = Quaternion.Lerp(doorRight.rotation, toRight, Time.deltaTime * rotationSpeed);
            doorLeft.rotation = Quaternion.Lerp(doorLeft.rotation, toLeft, Time.deltaTime * rotationSpeed);
        }
    }
}