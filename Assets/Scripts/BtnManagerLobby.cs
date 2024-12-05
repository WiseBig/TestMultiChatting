using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManagerLobby : MonoBehaviour
{
    public GameObject openMoney;

    public void OpenMoney()
    {
        openMoney.gameObject.SetActive(true);
    }
    public void CloseMoney()
    {
        openMoney.gameObject.SetActive(false);
    }
}
