using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Upwards motion on action
    public float Thrust = 200f;
    //Not actually speed, but easier to think of it as such
    public float Speed = 10f;
    public bool isDead = false; //Don't need a complex state
    Animator playerAnimator;
    [SerializeField]
    Animator BoyAnimator;
    Rigidbody playerRigid;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isDead)
        {

            return;
        }
        playerRigid.AddForce(Vector3.forward * Speed);

#if UNITY_ANDROID
        if (Input.touches[0].phase == TouchPhase.Began)
	    {
            Flap();
	    }
#endif
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }

    }

    void Flap() 
    {
        playerRigid.velocity = Vector3.zero;
        playerRigid.AddForce(new Vector3(0, Thrust, 0));
        playerAnimator.SetTrigger("Kicking");
        BoyAnimator.SetTrigger("Kicking");
    }



    #region Input
    //Why was input system so broken initially?
    //This would've been so much cleaner
    //public void OnTap(InputAction.CallbackContext context) 
    //{
    //    Flap();
    //}

    #endregion
}
