using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyunKontrolKod : MonoBehaviour
{
    public GameObject kup; // tüm zeminleri oluşturan tekli küp
    public GameObject anaKup; // oyun oynanan küp

  
    public GameObject zemin0;
    public GameObject zemin1;
    public GameObject zemin2;
    public GameObject zemin3;
    public GameObject zemin4;
    public GameObject zemin5;

    Vector3 vec0;
    Vector3 vec1;
    Vector3 vec2;
    Vector3 vec3;
    Vector3 vec4;
    Vector3 vec5;

    GameObject clone;
    public Texture2D[] textures;
    public GameObject[] clonelar;
    public Texture2D[] sayilar;
  
    
    public List<GameObject> clonelarZemin0 = new List<GameObject>();
    public List<GameObject> clonelarZemin1 = new List<GameObject>();
    public List<GameObject> clonelarZemin2 = new List<GameObject>();
    public List<GameObject> clonelarZemin3 = new List<GameObject>();
    public List<GameObject> clonelarZemin4 = new List<GameObject>();
    public List<GameObject> clonelarZemin5 = new List<GameObject>();
    

        

    void Start()
    {      

        zemin0.transform.position = new Vector3(0f, 0f, 0f);
        zemin0.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        
        KupleriOlusturma(zemin0, vec0, 0);
        KupleriOlusturma(zemin1, vec1, 1);
        KupleriOlusturma(zemin2, vec2, 2);
        KupleriOlusturma(zemin3, vec3, 3);
        KupleriOlusturma(zemin4, vec4, 4);
        KupleriOlusturma(zemin5, vec5, 5);

        zemin1.transform.position = new Vector3(0f, 12.89f, -2.1f);
        zemin1.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));

        zemin2.transform.position = new Vector3(0f, -2.06f, -12.95f);
        zemin2.transform.rotation = Quaternion.Euler(new Vector3(90f, 90f, 90f));

        zemin3.transform.position = new Vector3(0f, 10.81f, -15f);
        zemin3.transform.rotation = Quaternion.Euler(new Vector3(0f, -180f, 180f));

        zemin4.transform.position = new Vector3(2.1f, 12.88f, 0f);
        zemin4.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));

        zemin5.transform.position = new Vector3(12.9f, 12.88f, 0f);
        zemin5.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));

        anaKup.transform.position = new Vector3(7.45f, 6.9f, -7.45f);
        anaKup.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 90f));
        
    }


   
    public void KupleriOlusturma(GameObject zemin, Vector3 vec, int zeminno)
    {
        int sayac = 0;
        for (int i = 0; i < 16; i++)
        {
            vec.z = zemin.transform.rotation.z - i;
            for (int j = 0; j < 16; j++)
            {                
                vec.x = zemin.transform.rotation.z + j;
                clone = Instantiate(kup, vec, Quaternion.identity) as GameObject;
                clone.transform.SetParent(zemin.transform);
                clone.name = (sayac + 256 * zeminno).ToString();

                // her clone küp zemin no suna göre ayrı bir List<> e eklenir. numaralar düz gözüksün diye rotasyon verilir.
                if (zemin == zemin0)
                {
                    clonelarZemin0.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 90f));
                }
                else if (zemin == zemin1)
                {
                    clonelarZemin1.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                }
                else if (zemin == zemin2)
                {
                    clonelarZemin2.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                }
                else if (zemin == zemin3)
                {
                    clonelarZemin3.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                }
                else if (zemin == zemin4)
                {
                    clonelarZemin4.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                }
                else if (zemin == zemin5)
                {
                    clonelarZemin5.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
                }

                clone.transform.localScale = new Vector3(1f, 1f, 1f);
                clonelar[sayac + 256 * zeminno] = clone;
                clone.GetComponent<Renderer>().material.mainTexture = textures[1];
                clone.tag = "mavi";
               
                //fazlalık küplerin meshRenderer ları kapatılır.
                if (sayac >= 0 && sayac <= 47 || sayac >= 208 && sayac <= 255 || sayac % 16 == 0 || sayac % 16 == 1 || sayac % 16 == 2 || sayac % 16 == 13 || sayac % 16 == 14 || sayac % 16 == 15)
                {   
                    // gösterilmeyen kup ler tıklamalara tepki vermesi önlenir
                    Destroy(clone.GetComponent<BoxCollider>());
                    clone.GetComponent<MeshRenderer>().enabled = false;
                }
                sayac++;
            }
           
        }
        
    }

   
}
