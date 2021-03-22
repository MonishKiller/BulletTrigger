using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject[] cam = new GameObject[5];
    [SerializeField] private GameObject AmmoText;
    [SerializeField] private GameObject BounceText;
    [SerializeField] private Material defaultMat;
   
    private ShootManager shootManager;
    private bool mainCameraOnorNot;
    private void Start()
    {
        TurnOnMainCamera();
        shootManager = this.gameObject.GetComponent<ShootManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && mainCameraOnorNot)
        {
            Cursor.visible=true;
            Mouse_Click();
        }
        if (mainCameraOnorNot == false && Input.GetKeyDown(KeyCode.Escape)) {
            TurnOnMainCamera();
           
        }
    }
   

    private void TurnOnMainCamera() {
        AmmoText.SetActive(false);
        BounceText.SetActive(false);
        cam[0].gameObject.SetActive(false);
        cam[1].gameObject.SetActive(false);
        cam[2].gameObject.SetActive(false);
        cam[3].gameObject.SetActive(false);
        cam[4].gameObject.SetActive(false);
        
        mainCamera.gameObject.SetActive(true);
        mainCameraOnorNot = true;

    }
    private void TurnOnPlayerCamera(int playerIndex) {

        cam[playerIndex].gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        mainCameraOnorNot = false;
        AmmoText.SetActive(true);
        BounceText.SetActive(true);

    }



    private void Mouse_Click()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000000.0f))
        {
            if (hit.transform != null)
            {
                
                for (int i = 0; i < cam.Length; i++) {
                    if (hit.transform.tag == cam[i].transform.root.tag) {
                        TurnOnPlayerCamera(i);
                        shootManager.HideAllGunPlayer();
                        shootManager.ShowCurrentGunPlayer(i);
                    }
                }
                Debug.Log(hit.transform.name);

            }


        }
    }

}
