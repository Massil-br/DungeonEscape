using TMPro;
using UnityEngine;

public class PrintGolds : MonoBehaviour
{
    public GameObject player;
    private GoldManager goldManager;
    

    void Start()
    {
        goldManager = player.GetComponent<GoldManager>();
    }

    void Update()
    {
        GetComponent<TMP_Text>().text = goldManager.Gold + " Golds";
    }
}
