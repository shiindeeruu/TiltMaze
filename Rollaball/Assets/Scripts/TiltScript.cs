using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TiltScript : MonoBehaviour
{
    public Transform Joystick;
    public float joyMove = 0.1f;

    public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
    public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");

    //public JoeJeff character;

    public Renderer jumpHighlight;

    private Vector3 movement;
    private bool jump;
    private float glow;
    private SteamVR_Input_Sources hand;
    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {

        Vector2 m = moveAction[hand].axis;
        //transform.Rotate(new Vector3(m.x, 0, m.y));
        transform.Rotate(new Vector3(0, 0, 0));



    }
}



