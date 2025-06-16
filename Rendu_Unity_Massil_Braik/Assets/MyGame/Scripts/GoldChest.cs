using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoldChest : MonoBehaviour
{   

    public GameObject InterractionMessage;

    public GameObject StealingProgressionBar;

    public GameObject CoolDownMessage;

    public GameObject Player;

    private bool _isInTrigger = false;
    

    

    private bool _stealing = false;

    public float StealTimer = 0f;

    public float StealTime = 10f;

    private float _coolDownTimer = 0f;
    public float StealCoolDown = 300f;

    private bool _isStealed = false;

    public int minimumGold;

    public int maximumGold;






    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Player")){
            InterractionMessage.SetActive(true);
            
            _isInTrigger = true;
            
        }
        
    }

    void OnTriggerExit(Collider other)
    {   if (other.gameObject.CompareTag("Player")){
            InterractionMessage.SetActive(false);
            StealingProgressionBar.SetActive(false);
            CoolDownMessage.SetActive(false);
            if (_stealing == true){
                _stealing = false;
                StealTimer = 0;
            }
            _isInTrigger = false;
        }   
    }



  
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isStealed && _isInTrigger){
                _stealing = true;
            }

        if (_stealing){
            if (!StealingProgressionBar.activeSelf){
                StealingProgressionBar.SetActive(true);
            }
            
            StealTimer += Time.deltaTime;
            if (StealTimer >= StealTime){
                Player.GetComponent<GoldManager>().Gold += Random.Range(minimumGold,maximumGold);
                StealTimer = 0;
                _stealing = false;
                _isStealed = true;
                StealingProgressionBar.SetActive(false);
            }
        }


        if (_isStealed){
            CoolDownMessage.SetActive(true);
            _coolDownTimer += Time.deltaTime;
            CoolDownMessage.GetComponent<TMP_Text>().text = "Stealing CoolDown : " + Mathf.CeilToInt(StealCoolDown - _coolDownTimer) + " seconds" ;
            if (_coolDownTimer >= StealCoolDown){
                _isStealed = false;
                _coolDownTimer = 0;
                CoolDownMessage.SetActive(false);
            }
        }
    }



}
