using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] GameObject rotationPanel, livesPanel, reloadPanel;
    int count = 1;
    void Start()
    {
        rotationPanel.SetActive(true);
    }
    private void Update()
    {
        
    }
    public void RightButtonChange()
    {
        if(count == 3)
        {
            count = 1;
        }
        else
        {
           count++; 
        }
        SetActive();
    }
    public void LeftButtonChange()
    {
        if(count == 1)
        {
            count = 3;
        }
        else
        {
            count--;
        }
        SetActive();
    }
    void SetActive()
    {
        if(count == 1)
        {
            rotationPanel.SetActive(true);
        }
        else
        {
            rotationPanel.SetActive(false);
        }
        if(count == 2)
        {
            livesPanel.SetActive(true);
        }
        else
        {
            livesPanel.SetActive(false);
        }
        if (count == 3)
        {
            reloadPanel.SetActive(true);
        }
        else
        {
            reloadPanel.SetActive(false);
        }
    }
    public void GetUp()
    {

    }
    public void GetMiddle()
    {
        
    }
    public void GetDown()
    {
        
    }
}
