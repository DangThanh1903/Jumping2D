using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSkin : MonoBehaviour
{
    public SkinDatabase skinDB;
    public Image skinSprite;
    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption")) {
            selectedOption = 0;
        }
        else {
            Load();
        }
        UpdateSkin(selectedOption);
    }

    public void UpdateSkin(int selectedOption) {
        Skin skin = skinDB.GetCharacter(selectedOption);
        skinSprite.sprite = skin.characterSprite;
    }

    private void Load() {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
