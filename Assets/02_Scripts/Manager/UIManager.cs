using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public PlayerController player;

    public GameObject gamePanel;
    public TextMeshProUGUI PotionText;
    public TextMeshProUGUI moneyText;
    public RectTransform HpGroup;
    public Transform Hpbar;
    
    
    public void Update()
    {
        PotionText.text = string.Format("{0:n0}", player.potionCount);
        moneyText.text = string.Format("{0:n0}", player.playerMoney);
        //1피격시 체력-13

        Hpbar.localPosition = new Vector3(-655f - 13f * (100f - player.playerHealth), 0f);

    }
    
    
    
    
}