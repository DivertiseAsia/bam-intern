using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RarityScript : MonoBehaviour
{
    [Header("Set Icon")]
    [SerializeField] Sprite _commonStar;
    [SerializeField] Sprite _rareStar;
    [SerializeField] Sprite _epicStar;
    [SerializeField] Sprite _legendaryStar;

    public static Sprite commonStar;
    public static Sprite rareStar;
    public static Sprite epicStar;
    public static Sprite legendaryStar;

    [Header("Set Color")]
    [SerializeField] Color _commonColor = Color.gray;
    [SerializeField] Color _rareColor = Color.magenta;
    [SerializeField] Color _epicColor = Color.green;
    [SerializeField] Color _legendaryColor = Color.yellow;

    public static Color commonColor = Color.gray;
    public static Color rareColor = Color.magenta;
    public static Color epicColor = Color.green;
    public static Color legendaryColor = Color.yellow;

    private void Start()
    {
        commonStar = _commonStar;
        rareStar = _rareStar;
        epicStar = _epicStar;
        legendaryStar = _legendaryStar;

        commonColor = _commonColor;
        rareColor = _rareColor;
        epicColor = _epicColor;
        legendaryColor = _legendaryColor;

    }
}
