using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu]
public class SkinDatabase : ScriptableObject
{
    public Skin[] skins;
    public int SkinChangerCount {
        get{
            return skins.Length;
        }
    }
    public Skin GetCharacter(int index) {
        return skins[index];
    }
}
