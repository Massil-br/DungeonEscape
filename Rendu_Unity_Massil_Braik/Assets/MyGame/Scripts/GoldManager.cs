using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int Gold;
    public int GoldObjective;

    public int GoldGeneration;

    private float _timer = 0f;

    public bool ObjectiveComplete = false;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1){
            Gold += GoldGeneration;
            _timer =0;
        }
    }

}
