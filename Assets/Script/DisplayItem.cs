using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    SceneManagerScript manager => GetComponent<SceneManagerScript>();
    void Awake()
    {
        report = FindObjectOfType<WishReport>();
        StartCoroutine("ShowItem");
    }

    IEnumerator ShowItem()
    {
        animator.Play("ListComeIn");
        yield return new WaitForSeconds(1);
        foreach (Item item in report.resultItem)
        {

            icon.sprite = item.GetTemplate().itemIcon;
            itemName.text = item.GetTemplate().name;
            itemDescription.text = item.GetTemplate().description;
            Debug.Log(item.GetTemplate().rarity);

            switch ((int)item.GetTemplate().rarity)
            {
                case (int)Rarity.legendary:
                    rarityDisplay.sprite = RarityScript.legendaryStar;
                    background.color = RarityScript.legendaryColor;
                    break;
                case (int)Rarity.epic:
                    rarityDisplay.sprite = RarityScript.epicStar;
                    background.color = RarityScript.epicColor;
                    break;
                case (int)Rarity.rare:
                    rarityDisplay.sprite = RarityScript.rareStar;
                    background.color = RarityScript.rareColor;
                    break;
                default:
                    rarityDisplay.sprite = RarityScript.commonStar;
                    background.color = RarityScript.commonColor;
                    break;
            }

            animator.Play("ItemIn");

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
