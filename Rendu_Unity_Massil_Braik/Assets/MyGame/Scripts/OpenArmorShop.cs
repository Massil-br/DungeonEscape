using UnityEngine;

public class OpenArmorShop : MonoBehaviour
{
    public GameObject ShopCanva;
    public GameObject ShopChoice;
    public GameObject LegsShop;
    public GameObject ChestShop;
    public GameObject GlovesShop;
    public GameObject ShoesShop;
    public GameObject HatShop;


    private void OnTriggerEnter(Collider other) {
       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ShopCanva.SetActive(true);
        ShopChoice.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other){
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ShopCanva.SetActive(false);
        ShopChoice.SetActive(false);
        LegsShop.SetActive(false);
        ChestShop.SetActive(false);
        GlovesShop.SetActive(false);
        ShoesShop.SetActive(false);
        HatShop.SetActive(false);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
