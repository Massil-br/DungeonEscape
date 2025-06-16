using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPassSell : MonoBehaviour
{

    public GameObject player;
    public GameObject TextBonusHealth;

    public int Price;
    public bool ItemSold = false;




    public void Start()
    {   
        Price = player.GetComponent<GoldManager>().GoldObjective;


        if (!ItemSold){
            GetComponent<TMP_Text>().text = Price +"";
        }
        TextBonusHealth.GetComponent<TMP_Text>().text = "Buy this ticket to finish the game";
        
    }
     public void Buy(){
       if (player.GetComponent<GoldManager>().Gold >= Price && ItemSold ==false){
            player.GetComponent<GoldManager>().Gold -= Price;
            player.GetComponent<GoldManager>().ObjectiveComplete = true;
            ItemSold = true;
            GetComponent<TMP_Text>().text = "Sold";
       }
    }

}