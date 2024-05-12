using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDemo
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "SO/Inventory")]
    public class InventorySO : ScriptableObject
    {
        public List<InventoryItemSO> inventoryItems = new List<InventoryItemSO>();
    }
}
