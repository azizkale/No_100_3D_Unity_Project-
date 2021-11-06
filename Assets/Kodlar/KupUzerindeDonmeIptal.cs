using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KupUzerindeDonmeIptal : MonoBehaviour
{
    AnaKupRotation anaKupRotasyon;

    void Start()
    {
        anaKupRotasyon = GameObject.FindGameObjectWithTag("anaKupTag").GetComponent<AnaKupRotation>();
    }


    void OnMouseDown()
    {
        anaKupRotasyon.zeminDonmeKontrol = true;

    }

   
}
