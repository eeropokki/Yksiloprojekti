using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public enum PickUpType { Key1, Key2, Mushroom1, Mushroom2 };

    [SerializeField] private int coin;
    [SerializeField] private int superpower;

    [SerializeField] public PickUpType type { get; set; }
}
