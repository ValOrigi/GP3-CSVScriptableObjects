using UnityEngine;
using UnityEditor;
using System.IO;

public class WeaponCSVReader
{
    public static string weaponCSVPath = "/Editor/CSV files/WeaponCSV.csv";

    [MenuItem("Utilities/Generate Weapon SO")]
    public static void GenerateWeapons() 
    {
        string[] WeaponDatas = File.ReadAllLines(Application.dataPath + weaponCSVPath);

        foreach (string weaponData in WeaponDatas)
        {
            string[] data = weaponData.Split(',');
            
            WeaponSo weapon = ScriptableObject.CreateInstance<WeaponSo>();
            weapon.weaponName = data[0];
            weapon.damage = int.Parse(data[1]);
            weapon.durability = int.Parse(data[2]);

            AssetDatabase.CreateAsset(weapon, $"Assets/SO/Weapons/{weapon.weaponName}.asset");
        }

        bool displayMessage = EditorUtility.DisplayDialog
            (
                "Confirm Save Scriptable Object",
                "Are you sure you want to save this Data to a Scriptable Object?",
                "Yes", // True
                "No" // False
            );

        if (displayMessage)
            AssetDatabase.SaveAssets();
        else
            return;
    }
}
