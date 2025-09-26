using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SwordData", menuName = "Scriptable Objects/SwordData")]
public class SwordData : ScriptableObject
{
    public int baseDamage;
    public string swordName;
    public Color baseColor;
    public Sprite swordImage;


    [Header("인벤토리 연동")]
    public string coverName;
    public string sliderName;
    public string swordLevel;

    
}
