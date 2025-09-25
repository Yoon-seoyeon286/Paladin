using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordGhachSystem : MonoBehaviour
{
    public GameObject[] swordObjects;
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

    }
}
