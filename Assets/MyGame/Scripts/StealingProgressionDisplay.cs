using UnityEngine;

public class StealingProgressionDisplay : MonoBehaviour
{
    public GameObject Chest;
    private float ProgressionBarWidth;
    private float backGroundWidth;

    private GoldChest goldChest;

    private void Start() {

        goldChest = Chest.GetComponent<GoldChest>();
        backGroundWidth = GetComponentInParent<RectTransform>().rect.width;
    }

    void Update()
    {
        ProgressionBarWidth = backGroundWidth * (goldChest.StealTimer / goldChest.StealTime);

        RectTransform progressionBarRect = GetComponent<RectTransform>();
        progressionBarRect.sizeDelta = new Vector2(ProgressionBarWidth, progressionBarRect.sizeDelta.y);
    }





}
