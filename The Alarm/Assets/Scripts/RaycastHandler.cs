using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastHandler : MonoBehaviour
{

    public Camera MainCam;


    public GameObject PickUpItemGO;
    public Text PickUpItemText;



    private void Update()
    {
        CheckCast();
    }


    void CheckCast()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCam.transform.position, MainCam.transform.forward, out hit, 50f))
        {
            if(hit.collider.gameObject.GetComponent<Flashlight>())
            {
                PickUpItemText.text = "[G]: Pick Up Flashlight";
                PickUpItemGO.SetActive(true);
                if(Input.GetKeyDown(KeyCode.G))
                {
                    GameManager.bHasFlashlight = true;
                    Destroy(hit.collider.gameObject);
                }
            }
            else
            {
                PickUpItemGO.SetActive(false);
            }

            if(hit.collider.gameObject.GetComponent<Note>())
            {
                GameObject _note = hit.collider.gameObject;
                PickUpItemText.text = "[G]: Look At The Note";
                PickUpItemGO.SetActive(true);
                if(Input.GetKeyDown(KeyCode.G))
                {
                    _note.SetActive(false);
                    NoteHandler.LookingAtNote = true;
                }
                
            }
        }
    }
}
