using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] GameObject[] panel;
    [SerializeField] Image[] upgradeOne,upgradeTwo,upgradeThree;
    [SerializeField] Sprite fullUpgrade;
    static int index = 0,upgradeScoreOne = -1,upgradeScoreTwo = -1,upgradeScoreThree = -1;
    public void Plus()
    {
        if(index == 0 && upgradeScoreOne < 4)
        {
            upgradeScoreOne++;
            upgradeOne[upgradeScoreOne].sprite = fullUpgrade;
        }
        if(index == 1 && upgradeScoreTwo < 4)
        {
            upgradeScoreTwo++;
            upgradeTwo[upgradeScoreTwo].sprite = fullUpgrade;
        }
        if(index == 2 && upgradeScoreThree < 4)
        {
            upgradeScoreThree++;
            upgradeThree[upgradeScoreThree].sprite = fullUpgrade;
        }
    }
    public void RightButtonChange()
    {
        if(index < panel.Length-1)
        {
            panel[index].SetActive(false);
            panel[index+=1].SetActive(true);
        }
        else
        {
            panel[index].SetActive(false);
            panel[index = 0].SetActive(true);
        }
    }
    public void LeftButtonChange()
    {
        if(index <= panel.Length-1 && index > 0)
        {
            panel[index].SetActive(false);
            panel[index-=1].SetActive(true);
        }
        else
        {
            panel[index].SetActive(false);
            panel[index = panel.Length-1].SetActive(true);
        }
    }
}
