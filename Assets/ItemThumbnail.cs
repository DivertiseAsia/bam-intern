using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        rarityDisplay.enabled = true;
        switch ((int)rarity)
        {
            case (int)Rarity.legendary:
                rarityDisplay.sprite = RarityScript.legendaryStar;
                postItBg.color = RarityScript.legendaryColor;
                break;
            case (int)Rarity.epic:
                rarityDisplay.sprite = RarityScript.epicStar;
                postItBg.color = RarityScript.epicColor;
                break;
            case (int)Rarity.rare:
                rarityDisplay.sprite = RarityScript.rareStar;
                postItBg.color = RarityScript.rareColor;
                break;
            case (int)Rarity.common:
                rarityDisplay.sprite = RarityScript.commonStar;
                postItBg.color = RarityScript.commonColor;
                break;
            default:
                thumbImage.enabled = false;
                rarityDisplay.enabled = false;
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
