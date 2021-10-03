using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    Animator anim;
    private bool isAnim = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ButtonPanelVoid()
    {
        if (isAnim == false)
        {
            isAnim = true;
            anim.SetBool("isButtonPanelOpen", true);
            anim.SetBool("isButtonPanelClose", false);
        }
        else
        {
            isAnim = false;
            anim.SetBool("isButtonPanelOpen", false);
            anim.SetBool("isButtonPanelClose", true);
        }
    }
}
