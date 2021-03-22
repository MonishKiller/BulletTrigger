using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private GameObject[] player_Pistol = new GameObject[2];
    bool setTrue = true;
    bool setFalse = false;
 
    public void ShowCurrentGunPlayer(int playerIndex) {
      player_Pistol[playerIndex].GetComponentInChildren<Pistol>().selectedPistol=setTrue;
    }
    public void HideAllGunPlayer() {
        for (int i = 0; i < player_Pistol.Length; i++)
        {
            player_Pistol[i].GetComponentInChildren<Pistol>().selectedPistol = setFalse;
            player_Pistol[i].GetComponentInChildren<Pistol>().refilled = setFalse;
        }
    }
    public void ShowAllGunPlayer() {
        for (int i = 0; i < player_Pistol.Length; i++)
            player_Pistol[i].GetComponentInChildren<Pistol>().selectedPistol = setTrue;

    }
}
