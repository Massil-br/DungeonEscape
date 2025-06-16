using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int MaxHealth =20;
    public int Health =20;

    public int MagicPower = 0;

    public int mana = 20;

    public bool IsAlive = true;

    public int AttackDamage=1;

    public int level =1;
    public int xp = 0;

    public int nextLevelXp = 20;

    public float StatsScalingRatio =1.5f;


    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        CheckLevelUp();

    }



    private void CheckHealth(){
        if (Health <= 0){
            IsAlive = false;
            Health = 0;
        }

        if (Health >= MaxHealth){
            Health = MaxHealth;
        }
    }

    private void CheckLevelUp(){
        if (xp >= nextLevelXp){
            level++;
            xp -= nextLevelXp;
            nextLevelXp *= (int)StatsScalingRatio;

            int previousmaxHealth = MaxHealth;
            MaxHealth *= (int)StatsScalingRatio;
            Health += MaxHealth-previousmaxHealth;

            AttackDamage *= (int)StatsScalingRatio;
            mana *=(int)StatsScalingRatio;
            MagicPower +=5;
        }
    }
}
