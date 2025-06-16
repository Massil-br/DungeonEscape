using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldGeneratorSell : MonoBehaviour
{   
    public GameObject player;
    public GameObject TextBonusHealth;
    public int Price;
    
    public int BonusGold;

    public bool ItemSold = false;

    public void Start()
    {   
        if (!ItemSold){
            GetComponent<TMP_Text>().text = Price +"";
        }
        TextBonusHealth.GetComponent<TMP_Text>().text = "Gold + " + BonusGold + "/s";
        
    }

    public void Buy(){
       if (player.GetComponent<GoldManager>().Gold >= Price && ItemSold ==false){
            player.GetComponent<GoldManager>().Gold -= Price;
            player.GetComponent<GoldManager>().GoldGeneration += BonusGold;
            ItemSold = true;
            GetComponent<TMP_Text>().text = "Sold";
       }
    }
   
}
