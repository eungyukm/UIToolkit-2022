using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DragonProject
{
    [CreateAssetMenu(fileName = "EquipmentSO", menuName = "DragonProject/EquipmentSO", order = 1)]
    public class EquipmentSO : ScriptableObject
    {
        public string name;
        public int damage;
        public Sprite imgae;
    }
}
