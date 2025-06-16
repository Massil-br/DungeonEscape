using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
#endif
using UnityEngine;

public class AnimationScript : MonoBehaviour
{   
    public GameObject Camera;
   private float _horizontalSpeed =0 ;
   private  Rigidbody rb ; 
   private  Animator animator;

   private string _animationState = "State";

   void Start(){
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
   }

    void Update()
    {
        _horizontalSpeed = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;


        if (_horizontalSpeed > 0.1f){
            if (GetComponent<PlayerController2>().IsRunning){
                animator.SetInteger(_animationState, 2);
            }else {
                animator.SetInteger(_animationState ,1);
                
            }
        }else{
            animator.SetInteger(_animationState, 0);
            
        }
    }
}
