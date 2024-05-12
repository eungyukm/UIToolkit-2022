using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDemo
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "SO/InventoryItem")]
    public class InventoryItemSO : ScriptableObject
    {
        public string itemName;
    }
}
