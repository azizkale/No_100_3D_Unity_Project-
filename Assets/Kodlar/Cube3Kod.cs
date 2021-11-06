using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cube3Kod : MonoBehaviour
{
    public GameObject zemin0;
    public GameObject zemin1;
    public GameObject zemin2;
    public GameObject zemin3;
    public GameObject zemin4;
    public GameObject zemin5;


    Renderer render;
    public GameObject kup;
    OyunKontrolKod oyunKontrol;
    //bool ilkTiklama;
    AnaKupRotation anaKupRotasyon;
    void Start()
    {
        zemin0 = GameObject.FindGameObjectWithTag("zemin0Tag");
        zemin1 = GameObject.FindGameObjectWithTag("zemin1Tag");
        zemin2 = GameObject.FindGameObjectWithTag("zemin2Tag");
        zemin3 = GameObject.FindGameObjectWithTag("zemin3Tag");
        zemin4 = GameObject.FindGameObjectWithTag("zemin4Tag");
        zemin5 = GameObject.FindGameObjectWithTag("zemin5Tag");

        render = GetComponent<Renderer>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrolTag").GetComponent<OyunKontrolKod>();
        anaKupRotasyon= GameObject.FindGameObjectWithTag("anaKupTag").GetComponent<AnaKupRotation>();
    }
    
    void OnMouseDown()
    {
        anaKupRotasyon.zeminDonmeKontrol = false; // ilk tıklama ile anaKup rotasyon serbest olur.      

        // her tıklamada ilgili zemin in adına göre KutularaTiklama() kodu parametre alır ve çalışır.
        if (transform.parent.name == zemin0.name)
            KutularaTiklama(oyunKontrol.clonelarZemin0);

        else if (transform.parent.name == zemin1.name)
            KutularaTiklama(oyunKontrol.clonelarZemin1);

        else if (transform.parent.name == zemin2.name)
            KutularaTiklama(oyunKontrol.clonelarZemin2);

        else if (transform.parent.name == zemin3.name)
            KutularaTiklama(oyunKontrol.clonelarZemin3);

        else if (transform.parent.name == zemin4.name)
            KutularaTiklama(oyunKontrol.clonelarZemin4);

        else if (transform.parent.name == zemin5.name)
            KutularaTiklama(oyunKontrol.clonelarZemin5);

        Debug.Log("zemin adı: " + transform.parent.name + " küp isim: " + this.name + "  tag: " + this.tag);

        // IlkTiktaTumYuzleriTarama() fonksiyonu ilk tıklamada tıklanan zemin haricindeki diğer zeminleri pasif yapar.
        IlkTiktaTumYuzleriTarama(oyunKontrol.clonelarZemin0);
        IlkTiktaTumYuzleriTarama(oyunKontrol.clonelarZemin1);
        IlkTiktaTumYuzleriTarama(oyunKontrol.clonelarZemin2);
        IlkTiktaTumYuzleriTarama(oyunKontrol.clonelarZemin3);
        IlkTiktaTumYuzleriTarama(oyunKontrol.clonelarZemin4);
        IlkTiktaTumYuzleriTarama(oyunKontrol.clonelarZemin5);

        //DigerYuzlerdeOynamaFonk() fonksiyonu current zemindeki tıklanan küpe karşılık gelen diğer zeminkerdeki küpleri aktif yapar. sadece karşılık gelen numaradaki küp aktif (mavi) olur ve current olmayan zeminlerdeki yeşil harici küpler yine pasif (kırmızı) olur.        

        DigerYuzlerdeOynamaFonk(zemin0, oyunKontrol.clonelarZemin0);
        DigerYuzlerdeOynamaFonk(zemin1, oyunKontrol.clonelarZemin1);
        DigerYuzlerdeOynamaFonk(zemin2, oyunKontrol.clonelarZemin2);
        DigerYuzlerdeOynamaFonk(zemin3, oyunKontrol.clonelarZemin3);
        DigerYuzlerdeOynamaFonk(zemin4, oyunKontrol.clonelarZemin4);
        DigerYuzlerdeOynamaFonk(zemin5, oyunKontrol.clonelarZemin5);

        //animasyonlu dönme kodu
        //StartCoroutine(DonmeAnimasyonu());

    }
 
    

    //=====================her tıklamada kutulara numara verme fonksiyonu============================
    int index = 0;// yesil olan küpe sayı verme index i
    public void KutularaTiklama(List<GameObject> clonelarZeminX) // 
    {       
        int syc = System.Int32.Parse(this.name)%256;// clone küpün adının 256 ya bölümünden kalanı, tıklanan yüzdeki küpün List<> deki index numarası yapar. her yüzde 256 küp var. alttaki tıklama kodu her bir yüzey için 256 sayısına göre çalışır

        // altattaki foreach döngüsü yesil olan clone küpe sayı verir
        foreach (GameObject item in clonelarZeminX) // oyunkontrol deki clonelar List<> lerini veriyoruz
        {
            if (item.tag=="yesil")
            {
                index++;
            }
        }

        //alttaki for döngüsü ile  her tıklandığında ilgili yüzeydeki tüm clone küpler taranır ve mavi kırmızı veya yeşil olur.

        for (int i = 0; i < 256; i++)
        {
            if (clonelarZeminX[i].tag != "yesil") // yeşil olan küp rengi değişmesin diye
            {
                render.material.mainTexture = oyunKontrol.sayilar[index];
                tag = "yesil";
                clonelarZeminX[syc].layer = 2; // yeşil küpe tıklanmasın diye                

                if ((i == syc + 3 || i == syc - 3 || i == syc + 48 || i == syc - 48 || i == syc + 30 || i == syc - 30 || i == syc + 34 || i == syc - 34)) // tıklanan seçilir kılavuz kareler belirlenir mavi yapılır
                {
                    clonelarZeminX[i].GetComponent<Renderer>().material.mainTexture = oyunKontrol.textures[1];
                    clonelarZeminX[i].tag = "mavi";
                    clonelarZeminX[i].layer = 0;
                }
              

                else // yeşil ve mavi olmayanlar kırmızı olur
                {
                    clonelarZeminX[i].GetComponent<Renderer>().material.mainTexture = oyunKontrol.textures[2];
                    clonelarZeminX[i].tag = "kirmizi";
                    clonelarZeminX[i].layer = 2;
                }
            }
        }
            index++; // yesil olan küpe sayı verme index i
    }

    //===================== ilk tıkta 6 yüzü de tarama fonksiyonu: ============================
    public void IlkTiktaTumYuzleriTarama( List<GameObject> listZeminX)
    {
        int indexZeminTarama = 0;
        foreach (GameObject item in listZeminX) // tüm zeminleri tarar tıklanan yüzeyi tespit eder(zeminde yeşil veya mavi tag i arar)
        {            
            if (item.tag != "mavi")
                indexZeminTarama++;            
        }
         if(indexZeminTarama==0) //tüm yuzeylerde mavi tag li olan kupleri tag "kırmızı" ve layer "2" olur
        {
            foreach (GameObject item in listZeminX)
            {               
                item.GetComponent<Renderer>().material.mainTexture = oyunKontrol.textures[2];
                item.tag = "kirmizi";
                item.layer = 2;
            }
        }      

    }

    //===================== diğer yüzlerde oynama fonksiyonu ============================    
   

    public void DigerYuzlerdeOynamaFonk(GameObject zemin, List<GameObject> clonelarZeminX)
    {
        // tıklanmayan yüzdeki mavi kutuları kırmızı yapar
        if (this.transform.parent.name != zemin.name)
        {
            foreach (GameObject item in clonelarZeminX)
            {
                if (item.tag == "mavi")
                {
                    item.GetComponent<Renderer>().material.mainTexture = oyunKontrol.textures[2];
                    item.tag = "kirmizi";
                    item.layer = 2;
                }
            }

            // diğer yüzlerdeki tıklanan kutuya karşılık gelen kutuları aktif yapar
            if (clonelarZeminX[System.Int32.Parse(this.name) % 256].tag != "yesil")
                AktifEdenAltFonksiyon(clonelarZeminX[System.Int32.Parse(this.name) % 256]);
        }        
    }

    //=====================kutulara tıklama animasyonu============================
    public IEnumerator DonmeAnimasyonu()
    {
        for (int i = 0; i <= 3; i++)
        {
            this.transform.rotation = Quaternion.Euler(-i * 30, 0, -180);
            yield return new WaitForSeconds(0.1f);
        }      
    }

    //====================diğer yüzlere geçiş fonksiyonunun kullandığı alt fonksiyonlar========================
    //texture ı mavi renk yapar (oyunKontrol.textures[1]), tag i "mavi" yapar, layer ı 0 yapar (aktif eder)

    public void AktifEdenAltFonksiyon(GameObject kup)
    {
        kup.GetComponent<Renderer>().material.mainTexture = oyunKontrol.textures[1];
        kup.tag = "mavi";
        kup.layer = 0;
    }

    //texture ı kırmızı renk yapar (oyunKontrol.textures[2]), tag i "mavi" yapar, layer ı 2 yapar (aktif eder)
    public void PasifEdenAltFonksiyon(int altindex2)
    {
        oyunKontrol.clonelar[altindex2].GetComponent<Renderer>().material.mainTexture = oyunKontrol.textures[2];
        oyunKontrol.clonelar[altindex2].tag = "kirmizi";
        oyunKontrol.clonelar[altindex2].layer = 2;
    }                                
}