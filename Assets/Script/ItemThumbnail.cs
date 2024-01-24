using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class ItemThumbnail : MonoBehaviour
{
    [Header("Reference Item")]
    [SerializeField] public ItemTemplateScriptableObject itemTemplate;
    [Header("Element Field")]
    [SerializeField] private Image thumbImage;
    [SerializeField] private Rarity rarity;
    [SerializeField] private Image rarityDisplay;
    [SerializeField] private Image postItBg;
    [SerializeField] private TMP_Text itemName;
    public bool itemEnable;

    private RarityScript rarityScript;


    private void Start()
    {
        rarityScript = RarityScript.instance;
    }
    private void Update()
    {
        if (itemTemplate == null)
        {
            thumbImage.enabled = false;
            itemName.text = "None";
            itemName.ForceMeshUpdate();
            return;
        }

        thumbImage.enabled = true;
        thumbImage.sprite = itemTemplate.itemIcon;
        rarity = itemTemplate.rarity;
        DisplayRarity(rarity);
        itemName.text = itemTemplate.name;
        itemName.ForceMeshUpdate();
        SetAlpha(itemEnable);
    }

    private void DisplayRarity(Rarity rarity)
    {
        rarityDisplay.gameObject.SetActive(true);
        switch ((int)rarity)
        {
            case (int)Rarity.legendary:
                rarityDisplay.sprite = rarityScript.legendaryStar;
                postItBg.color = rarityScript.legendaryColor;
                break;
            case (int)Rarity.epic:
                rarityDisplay.sprite = rarityScript.epicStar;
                postItBg.color = rarityScript.epicColor;
                break;
            case (int)Rarity.rare:
                rarityDisplay.sprite = rarityScript.rareStar;
                postItBg.color = rarityScript.rareColor;
                break;
            case (int)Rarity.common:
                rarityDisplay.sprite = rarityScript.commonStar;
                postItBg.color = rarityScript.commonColor;
                break;
            default:
                thumbImage.enabled = false;
                rarityDisplay.gameObject.SetActive(false);
                postItBg.color = Color.white;
                break;
        }
    }

    private void SetAlpha(bool flag)
    {
        SetAlpha(thumbImage, flag);
        SetAlpha(postItBg, flag);
        SetAlpha(rarityDisplay, flag);
        SetAlpha(itemName, flag);
    }

    private void SetAlpha(Image image, bool flag)
    {
        if (flag)
        {
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, 1);
        }
        else
        {
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, 0.5f);
        }
    }
    private void SetAlpha(TMP_Text text, bool flag)
    {
        if (flag)
        {
            text.color = new Vector4(text.color.r, text.color.g, text.color.b, 1);
        }
        else
        {
            text.color = new Vector4(text.color.r, text.color.g, text.color.b, 0.5f);
        }
    }
}
