using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordGhachSystem : MonoBehaviour
{
    public GameObject[] swordObjes;
    public GameObject[] viewSwordObjec;
    public RawImage[] swordImage;

    public void GhachSword()
    {
        List<GameObject> selectSwords = new List<GameObject>();

        for (int i = 0; i < 4; i++) //리스트에 랜덤 객체 4개를 넣기
        {
            int swapSword = Random.Range(0, swordObjes.Length);
            selectSwords.Add(swordObjes[swapSword]);
        }

        for (int i = 0; i < 4; i++) //4개의 이미지를 띄우고 해당 객체와 맞는 이미지를 활성화 
        {
            viewSwordObjec[i].SetActive(true); 

        }
    }
}
