using UnityEngine;

public class OpenWeaponShop : MonoBehaviour
{
    public GameObject ShopCanva;
    public GameObject ShopChoice;
    public GameObject SwordShop;
    


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
        SwordShop.SetActive(false);

    }
}
