using UnityEngine;

public class HealthBarDisplay : MonoBehaviour
{   
    public GameObject Player;
    private float healthBarWidth;
    private float backGroundWidth;
    private PlayerStats playerStats;

    

    private void Start()
    {
        playerStats = Player.GetComponent<PlayerStats>();
        backGroundWidth = GetComponentInParent<RectTransform>().rect.width;
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBarWidth = backGroundWidth * (playerStats.Health / (float)playerStats.MaxHealth);

        RectTransform healthBarRect = GetComponent<RectTransform>();
        healthBarRect.sizeDelta = new Vector2(healthBarWidth, healthBarRect.sizeDelta.y);
    }


}


