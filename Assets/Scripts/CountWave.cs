using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountWave : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.isAnim = true;
    }
    private void Update()
    {
        if (GameManager.isAnim == true)
        {
            anim.SetBool("isCountWave", true);
            StartCoroutine("lol");
        }
    }
    IEnumerator lol()
    {
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("isCountWave", false);
        GameManager.isAnim = false;
    }
}
