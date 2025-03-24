using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private SkinDatabase skinDB;
    [SerializeField] private Text NameText;
    [SerializeField] private SpriteRenderer skinSprite;
    private int selectedOption = 0;
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

    public void NextOption() {
        selectedOption++;

        if (selectedOption >= skinDB.SkinChangerCount) {
            selectedOption = 0;
        }
        UpdateSkin(selectedOption);
        Save();
    }

    public void BackOption() {
        selectedOption--;
        if (selectedOption < 0) {
            selectedOption = skinDB.SkinChangerCount - 1;
        }
        UpdateSkin(selectedOption);
        Save();
    }
    public void UpdateSkin(int selectedOption) {
        Skin skin = skinDB.GetCharacter(selectedOption);
        skinSprite.sprite = skin.characterSprite;
        NameText.text = skin.characterName;
    }

    private void Load() {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save() {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
