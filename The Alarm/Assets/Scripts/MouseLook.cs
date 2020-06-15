using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform PlayerBody;
    public Animator MainCamAnimator;

    float xRot = 0f;

    public static float sensitivity = 100f;


    bool bCanLook = false;


    public GameObject FlashLight;
    public AudioSource FlashLightClick;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(Begin());
    }

    private void Update()
    {
        CheckFlashlightSwitch();
        if(bCanLook)
        {
            float MouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRot -= MouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);

            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * MouseX);

        }
    }

    void CheckFlashlightSwitch()
    {
        if(Input.GetKeyDown(KeyCode.E) && GameManager.bHasFlashlight)
        {
            if(!GameManager.FlashlightIsOn)
            {
                FlashLight.SetActive(true);
                GameManager.FlashlightIsOn = true;
                FlashLightClick.Play();
            }
            else
            {
                FlashLight.SetActive(false);
                GameManager.FlashlightIsOn = false;
                FlashLightClick.Play();
            }
        }
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(4.89f);
        bCanLook = true;
        Destroy(MainCamAnimator);
    }
}
