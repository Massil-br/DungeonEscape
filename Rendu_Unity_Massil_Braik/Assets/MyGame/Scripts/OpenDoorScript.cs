using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{   
    public GameObject InterractionMessage;
    public GameObject Door;
    public GameObject StartRotation, EndRotation;
    public float duration = 1f;

    private bool _isPlayerInTrigger = false;
    private float _timer = 0f;
    private bool _doorOpen = false;
    private bool _isAnimating = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            InterractionMessage.SetActive(true);
            _isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            InterractionMessage.SetActive(false);
            _isPlayerInTrigger = false;
        }
    }

    void Update()
    {
        if (_isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !_isAnimating)
        {
            _isAnimating = true;
            _timer = 0f;
        }

        if (_isAnimating)
        {
            _timer += Time.deltaTime;
            float progress = Mathf.Clamp01(_timer / duration);

            if (!_doorOpen)
                Door.transform.rotation = Quaternion.Lerp(StartRotation.transform.rotation, EndRotation.transform.rotation, progress);
            else
                Door.transform.rotation = Quaternion.Lerp(EndRotation.transform.rotation, StartRotation.transform.rotation, progress);

            
            if (_timer >= duration)
            {
                _isAnimating = false;
                _doorOpen = !_doorOpen; 
            }
        }
    }
}
