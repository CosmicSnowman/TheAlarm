using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHandler : MonoBehaviour
{
    public static bool LookingAtNote;

    public GameObject NoteUI;
    public GameObject NoteGO;
    public GameObject EToExitText;


    private void Update()
    {
        LookAtNote();
    }

    private void LookAtNote()
    {
        if(LookingAtNote)
        {
            NoteUI.SetActive(true);
            NoteGO.SetActive(false);
            EToExitText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                LookingAtNote = false;
            }
        }
        else
        {
            NoteUI.SetActive(false);
            NoteGO.SetActive(true);
            EToExitText.SetActive(false);
        }
    }
}
