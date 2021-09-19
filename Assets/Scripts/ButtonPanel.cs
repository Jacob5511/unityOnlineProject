using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    private bool isButtonPanel = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void ButtonPanelVoid()
    {
        if (isButtonPanel == false)
        {
            isButtonPanel = true;
            anim.SetBool("isButtonPanelOpen", true);
            anim.SetBool("isButtonPanelClose", false);
        }
        else
        {
            isButtonPanel = false;
            anim.SetBool("isButtonPanelOpen", false);
            anim.SetBool("isButtonPanelClose", true);
        }
    }
}
