using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Hide_Player : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        EventMangaer.current.OnhitTriggerEnter += Show;
        
    }
    private void Show() {
        gun.SetActive(true);
        cam.SetActive(true);
    }

  
}
