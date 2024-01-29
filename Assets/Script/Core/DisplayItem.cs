using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class DisplayItem : MonoBehaviour
{
    [SerializeField] WishReport report;
    ItemTemplateScriptableObject template;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] Image background;
    [SerializeField] Image rarityDisplay;

    Animator animator => GetComponent<Animator>();
    string animationToPlay;

    private RarityScript rarityScript;

    SceneManagerScript manager => GetComponent<SceneManagerScript>();
    void Awake()
    {
        rarityScript = RarityScript.instance;
        report = FindObjectOfType<WishReport>();
        StartCoroutine("ShowItem");
    }

    IEnumerator ShowItem()
    {
        
        animator.Play("ListComeIn");
        yield return new WaitForSeconds(1);
        foreach (Item item in report.resultItem)
        {
            animationToPlay = "ItemIn";
            icon.sprite = item.GetTemplate().itemIcon;
            itemName.text = item.GetTemplate().name;
            itemDescription.text = item.GetTemplate().description;
            Debug.Log(item.GetTemplate().rarity);

            switch ((int)item.GetTemplate().rarity)
            {
                case (int)Rarity.legendary:
                    animationToPlay = "LegendaryItemIn";
                    rarityDisplay.sprite = rarityScript.legendaryStar;
                    background.color = rarityScript.legendaryColor;
                    break;
                case (int)Rarity.epic:
                    rarityDisplay.sprite = rarityScript.epicStar;
                    background.color = rarityScript.epicColor;
                    break;
                case (int)Rarity.rare:
                    rarityDisplay.sprite = rarityScript.rareStar;
                    background.color = rarityScript.rareColor;
                    break;
                default:
                    rarityDisplay.sprite = rarityScript.commonStar;
                    background.color = rarityScript.commonColor;
                    break;
            }

            animator.Play(animationToPlay);

            yield return new WaitForSeconds(2);
            if (Input.anyKey)
            {
                break;
            }
            animator.Play("ItemOut");
            yield return new WaitForSeconds(0.8f);
        }

        gameObject.transform.position = Vector2.up * 500;
        manager.TransverseScene();
    }
}
