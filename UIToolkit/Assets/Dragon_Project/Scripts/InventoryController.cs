using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDemo
{
    public class InventoryController : MonoBehaviour
    {
        // m_ 멤버 변수 : 클래스 내에서만 사용되는 변수
        private UIDocument m_InventoryUIDocument;
        // VisualElement로 되어있는 inventory_contents를 찾기 위한 변수
        private VisualElement m_InventoryContents;
        // m_InventoryContents의 자식 요소들을 담기 위한 리스트
        private List<Button> m_InventoryButtons = new List<Button>();
        
        [SerializeField] private InventorySO m_InventorySO;
        
        private Button m_InventoryCancelButton;
        
        void Awake()
        {
            // InitUI();
        }

        private void Start()
        {
            InitUI();
            InitInventoryButtons();
            InitButtons();
            // HideAllInventoryButtons();
            InitInventory();
        }
        
        // UI Init
        private void InitUI()
        {
            m_InventoryUIDocument = GetComponent<UIDocument>();
            
            var root = m_InventoryUIDocument.rootVisualElement;
            if (root == null)
            {
                Debug.LogError("InventoryController.InitUI() : root is null");
                return;
            }
            
            m_InventoryContents = root.Q<VisualElement>("inventory-contents");
        }
        
        // InventoryButtons을 초기하는 함수
        private void InitInventoryButtons()
        {
            foreach (VisualElement visualElement in m_InventoryContents.Children())
            {
                // Debug.Log("visualElement.name : " + visualElement.name);
                foreach (var element in visualElement.Children())
                {
                    // Debug.Log("visualElement.name : " + element.name);
                    // Debug.Log("visualElement.type : " + element.GetType());
                    
                    // 타입을 추론하는 문법
                    if (element is Button)
                    {
                        // as 타입을 변환하는 문법
                        m_InventoryButtons.Add(element as Button);
                    }
                }
            }
        }
        
        private void InitButtons()
        {
            m_InventoryCancelButton = m_InventoryUIDocument.rootVisualElement.Q<Button>("inventory-cancel-button");
            m_InventoryCancelButton.clicked += OnInventoryCancelButtonClicked;
        }
        
        private void OnInventoryCancelButtonClicked()
        {
            m_InventoryUIDocument.rootVisualElement.visible = false;
        }
        
        // 모든 버튼들을 visible을 none으로 만드는 함수
        private void HideAllInventoryButtons()
        {
            foreach (var button in m_InventoryButtons)
            {
                button.visible = false;
            }
        }

        private void InitInventory()
        {
            for (int i = 0; i < m_InventorySO.inventoryItems.Count; i++)
            {
                m_InventoryButtons[i].text = m_InventorySO.inventoryItems[i].itemName;
            }
        }
    }
}
