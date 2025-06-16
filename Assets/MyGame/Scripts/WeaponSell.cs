using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSell : MonoBehaviour
{   
    public GameObject player;
    public GameObject TextBonusHealth;
    public int Price;
    
    public int BonusDamage;

    public bool ItemSold = false;

    public void Start()
    {   
        if (!ItemSold){
            GetComponent<TMP_Text>().text = Price +"";
        }
        TextBonusHealth.GetComponent<TMP_Text>().text = "Golds :  + " + BonusDamage;
        
    }

    public void Buy(){
       if (player.GetComponent<GoldManager>().Gold >= Price && ItemSold ==false){
            player.GetComponent<GoldManager>().Gold -= Price;
            player.GetComponent<PlayerStats>().AttackDamage += BonusDamage;
            ItemSold = true;
            GetComponent<TMP_Text>().text = "Sold";
       }
    }
   
}