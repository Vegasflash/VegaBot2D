using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManaScript : MonoBehaviour
{
    public GameObject manaPool;
    public GameObject sage;
    public Image currentManaPool;
    public Text ratioText;


    public void UpdateMagicPower(float maxManaPoint, float manaPoint)
    {
        float ratio = manaPoint / maxManaPoint;
        currentManaPool.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + "%";
    }
}
