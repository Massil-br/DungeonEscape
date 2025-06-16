using UnityEngine;

public class GoldBarDisplay : MonoBehaviour
{   
    public GameObject Player;
    private float goldBarWidth;
    private float backGroundWidth;
    private GoldManager playerGold;

    

    private void Start()
    {
        playerGold = Player.GetComponent<GoldManager>();
        backGroundWidth = GetComponentInParent<RectTransform>().rect.width;
        
    }

    // Update is called once per frame
    void Update()
    {
        goldBarWidth = backGroundWidth * (playerGold.Gold / (float)playerGold.GoldObjective);

        if (goldBarWidth >= backGroundWidth){
            goldBarWidth = backGroundWidth;
        }

        RectTransform goldBarRect = GetComponent<RectTransform>();
        goldBarRect.sizeDelta = new Vector2(goldBarWidth, goldBarRect.sizeDelta.y);
    }


}
