using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;  // Sensibilité uniforme pour la rotation
    public float JumpHeight;
    private int _objectsUnderPlayer =0;

    public bool IsRunning = false;

    private float maxRotationAngle = 90f;
    private float _currentXRotation = 0f;

    private GameObject mainCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;  // Optionnel, pour cacher le curseur pendant le jeu
        mainCamera = GameObject.Find("MainCamera");
    }

    void Update()
    {   
        // Empêche les valeurs négatives pour les objets sous le joueur
        if (_objectsUnderPlayer < 0)
        {
            _objectsUnderPlayer = 0;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift)){
            MoveSpeed *=2;
            IsRunning = true;
        }

        // Rotation horizontale du joueur avec la sensibilité (X)
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed;  // Utilisation d'Input.GetAxis pour la rotation horizontale
        transform.Rotate(0, mouseX, 0);

        // Déplacement du joueur
        Vector3 CurrentSpeed = transform.forward * Input.GetAxis("Vertical") * MoveSpeed 
                             + transform.right * Input.GetAxis("Horizontal") * MoveSpeed;
        CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;  // Utilisation de .velocity pour une mise à jour plus réaliste

        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && _objectsUnderPlayer > 0)
        {
            CurrentSpeed.y += JumpHeight;
        }

        // Mise à jour de la vitesse du Rigidbody
        GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

        // Gestion de la caméra pour l'orientation verticale
        CameraVerticalHandler();

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            MoveSpeed /=2;
            IsRunning = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _objectsUnderPlayer++;
    }

    private void OnTriggerExit(Collider other)
    {
        _objectsUnderPlayer--;
    }

    private void CameraVerticalHandler()
    {
        // Récupère la différence de mouvement de la souris sur l'axe Y (vertical)
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed;  // Utilisation d'Input.GetAxis pour l'axe vertical

        // Applique la rotation verticale et la limite d'angle
        _currentXRotation -= mouseY;
        _currentXRotation = Mathf.Clamp(_currentXRotation, -maxRotationAngle, maxRotationAngle);

        // Applique la rotation verticale de la caméra (axe X)
        mainCamera.transform.localEulerAngles = new Vector3(_currentXRotation, mainCamera.transform.localEulerAngles.y, 0);
    }
}
