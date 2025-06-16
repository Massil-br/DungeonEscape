using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{   

    public GameObject interract;

    public GameObject player;

    private bool _playerInTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            interract.SetActive(true);
            _playerInTrigger = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        interract.SetActive(false);
        _playerInTrigger = false;
    }


    

    // Update is called once per frame
    void Update()
    {
        if(_playerInTrigger && Input.GetKeyDown(KeyCode.E) && player.GetComponent<GoldManager>().ObjectiveComplete){
            SceneManager.LoadSceneAsync(2);
        }
    }
}
