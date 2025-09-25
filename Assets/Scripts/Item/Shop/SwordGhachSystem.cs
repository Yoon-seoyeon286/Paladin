using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordGhachSystem : MonoBehaviour
{
    public GameObject[] swordObjects;
    public RawImage[] swordLineColor;
    public Image[] swordImage;
    public SwordData[] swordDatas;
    public int pickCount = 4;

    public void GhachSword()
    {
        // swordObjes 배열을 기반으로 새 리스트를 생성.
        List<GameObject> swordsToShuffle = new List<GameObject>(swordObjects);

        // 피셔-예이츠 셔플 알고리즘을 사용하여 리스트를 무작위로 섞섞.
        for (int i = 0; i < swordsToShuffle.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, swordsToShuffle.Count);
            GameObject temp = swordsToShuffle[i];
            swordsToShuffle[i] = swordsToShuffle[randomIndex];
            swordsToShuffle[randomIndex] = temp;
        }

        //뽑은 4개를 새로운 리스트에 넣기
        List<GameObject> pickedSwords = new List<GameObject>();

        for (int i = 0; i < pickCount; i++)
        {
            pickedSwords.Add(swordsToShuffle[i]);
        }

        for (int i = 0; i < pickedSwords.Count; i++)
        {
            SwordData currentSwordData = System.Array.Find(swordDatas, data => data.swordName == pickedSwords[i].name);

            if (currentSwordData != null)
            {
                swordLineColor[i].color = currentSwordData.baseColor;
                swordImage[i].gameObject.SetActive(true);
                swordImage[i].sprite = currentSwordData.swordImage;
              }  


        }

    }


}
