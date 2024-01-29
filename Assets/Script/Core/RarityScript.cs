using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RarityScript", menuName = "Project Exclusive/Rarity")]
public class RarityScript: ScriptableObject
{
    [Header("Star")]
    public Sprite commonStar;
    public Sprite rareStar;
    public Sprite epicStar;
    public Sprite legendaryStar;

    [Header("Color")]
    public Color commonColor = Color.gray;
    public Color rareColor = Color.magenta;
    public Color epicColor = Color.green;
    public Color legendaryColor = Color.yellow;

    public static RarityScript instance;

    private void OnEnable()
    {
        instance = this;
    }
}
