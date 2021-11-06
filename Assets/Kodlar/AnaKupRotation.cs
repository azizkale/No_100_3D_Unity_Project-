using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnaKupRotation : MonoBehaviour
{
    public float rotateSpeed = 0.5f;

    public bool zeminDonmeKontrol = true; // oyuncuyu Zemin0 dan başlamak zorunda bırakır. ilk tıklama ile true olur ve anaKup artık donebilir

    public bool altiDRotasyonKontrol = false;
    public Text altiDRotasyonButtonText;

    OyunKontrolKod oyunKontrol;

    private void Start()
    {
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrolTag").GetComponent<OyunKontrolKod>();
    }

    void Update()
    {
        if (zeminDonmeKontrol)
        {
            AnaKupDondurme();
        }
    }

   

    public void AnaKupDondurme()
    {
        if (Input.touchCount == 1)
        {

            Touch touchZero = Input.GetTouch(0);

            //Rotate the model based on offset
            Vector3 localAngle = transform.localEulerAngles;           
            localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
            transform.localEulerAngles = localAngle;
           
        }

        if (altiDRotasyonKontrol)
        {
            if (Input.touchCount == 1)
            {
                Touch touchZero = Input.GetTouch(0);

                //Rotate the model based on offset
                Vector3 localAngle = transform.localEulerAngles;
                localAngle.z -= rotateSpeed * -touchZero.deltaPosition.y;
                localAngle.x = 0;
                transform.localEulerAngles = localAngle;
            }
        }
       
    }
    public void AltiDRotasyonKontrolFonk()
    {
        if (altiDRotasyonKontrol == true)
        {
            altiDRotasyonKontrol = false;
            altiDRotasyonButtonText.text = "4D Oynama";
            oyunKontrol.anaKup.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 90f));
        }
        else if (altiDRotasyonKontrol == false)
        {
            altiDRotasyonKontrol = true;
            altiDRotasyonButtonText.text = "6D Oynama";
        }
    }
}
