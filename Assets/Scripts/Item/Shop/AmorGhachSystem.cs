using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmorGhachSystem : MonoBehaviour
{
     public GameObject[] amorObjects;
    public RawImage[] amorLineColor;
    public Image[] amorImage;
    public AmorData[] amorDatas;
    public int pickCount = 4;

    public void GhachSword()
    {
        // swordObjes 배열을 기반으로 새 리스트를 생성.
        List<GameObject> AmorsToShuffle = new List<GameObject>(amorObjects);

        // 피셔-예이츠 셔플 알고리즘을 사용하여 리스트를 무작위로 섞섞.
        for (int i = 0; i < AmorsToShuffle.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, AmorsToShuffle.Count);
            GameObject temp = AmorsToShuffle[i];
            AmorsToShuffle[i] = AmorsToShuffle[randomIndex];
            AmorsToShuffle[randomIndex] = temp;
        }

        //뽑은 4개를 새로운 리스트에 넣기
        List<GameObject> pickedAmors = new List<GameObject>();

        for (int i = 0; i < pickCount; i++)
        {
            pickedAmors.Add(AmorsToShuffle[i]);
        }

        for (int i = 0; i < pickedAmors.Count; i++)
        {
             AmorData currentAmorData = System.Array.Find(amorDatas, data => data.amorName == pickedAmors[i].name);

            if (currentAmorData != null)
            {
                InventoryManager.instance.AddAmor(currentAmorData);
                amorLineColor[i].color = currentAmorData.baseColor;
                amorImage[i].gameObject.SetActive(true);
                amorImage[i].sprite = currentAmorData.amorImage;
              }  

        }

    }

}
