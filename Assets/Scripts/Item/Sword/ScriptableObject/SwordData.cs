using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SwordData", menuName = "Scriptable Objects/SwordData")]
public class SwordData : ScriptableObject
{
    public float baseDamage;
    public string swordName;
    public Color baseColor;
    public Image swordImage;
    
}
