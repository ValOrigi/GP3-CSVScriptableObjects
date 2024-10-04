using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponSo : ScriptableObject
{
    public string weaponName;
    public int damage;
    public int durability;
}
