using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

namespace UIToolkitDemo
{
    public class MainMenuController : MonoBehaviour
    {
        private UIDocument m_MainMenuUIDocument;
        // 루트 찾기
        private VisualElement m_MainMenuRoot;
        private VisualElement m_ScrollContainer;
        private VisualElement m_ShildContainer;
        private VisualElement m_SwordContainer;
        private VisualElement m_HeroesContainer;
        
        private Button m_ScrollButton;
        private Button m_ShildButton;
        private Button m_SwordButton;
        private Button m_HeroesButton;
        
        private VisualElement m_Heroes_Image;
        private Button m_PrevButton;
        private Button m_NextButton;

        private Texture2D SwordMasterImg;
        private Texture2D MagicMasterImg;
        private Texture2D HealMasterImg;
        
        private enum MainMenuState
        {
            Scroll,
            Shild,
            Sword,
            Heroes
        }
        
        private MainMenuState m_MainMenuState;

        private void Awake()
        {
            ResourcesLoad();
        }


        void Start()
        {
            m_MainMenuUIDocument = GetComponent<UIDocument>();
            m_MainMenuRoot = m_MainMenuUIDocument.rootVisualElement;
            
            m_ScrollContainer = m_MainMenuRoot.Q<VisualElement>("main__scroll");
            m_ShildContainer = m_MainMenuRoot.Q<VisualElement>("main__shild");
            m_SwordContainer = m_MainMenuRoot.Q<VisualElement>("main__sword");
            m_HeroesContainer = m_MainMenuRoot.Q<VisualElement>("main__heroes");

            m_ScrollButton = m_MainMenuRoot.Q<Button>("main__left-scroll-button");
            m_ShildButton = m_MainMenuRoot.Q<Button>("main__left-shild-button");
            m_SwordButton = m_MainMenuRoot.Q<Button>("main__left-sword-button");
            m_HeroesButton = m_MainMenuRoot.Q<Button>("main__left-heroes-button");
            
            m_Heroes_Image = m_MainMenuRoot.Q<VisualElement>("main__heroes-image");
            m_PrevButton = m_MainMenuRoot.Q<Button>("main__heroes-prev-button");
            m_NextButton = m_MainMenuRoot.Q<Button>("main__heroes-next-button");
            
            UIInit();
            
        }

        private void UIInit()
        {
            SetMainMenuState(MainMenuState.Scroll);
            OnClickButtonEvent();
        }
        
        private void SetMainMenuState(MainMenuState state)
        {
            m_MainMenuState = state;
            m_ScrollContainer.style.display = DisplayStyle.None;
            m_ShildContainer.style.display = DisplayStyle.None;
            m_SwordContainer.style.display = DisplayStyle.None;
            m_HeroesContainer.style.display = DisplayStyle.None;
            
            switch (m_MainMenuState)
            {
                case MainMenuState.Scroll:
                    m_ScrollContainer.style.display = DisplayStyle.Flex;
                    break;
                case MainMenuState.Shild:
                    m_ShildContainer.style.display = DisplayStyle.Flex;
                    break;
                case MainMenuState.Sword:
                    m_SwordContainer.style.display = DisplayStyle.Flex;
                    break;
                case MainMenuState.Heroes:
                    m_HeroesContainer.style.display = DisplayStyle.Flex;
                    break;
            }
        }

        private void OnClickButtonEvent()
        {
            m_ScrollButton.clicked += () => SetMainMenuState(MainMenuState.Scroll);
            m_ShildButton.clicked += () => SetMainMenuState(MainMenuState.Shild);
            m_SwordButton.clicked += () => SetMainMenuState(MainMenuState.Sword);
            m_HeroesButton.clicked += () => SetMainMenuState(MainMenuState.Heroes);
            m_PrevButton.clicked += () => OnClickPrevButton();
            m_NextButton.clicked += () => OnClickNextButton();
        }

        private void ResourcesLoad()
        {
            SwordMasterImg = Resources.Load("Img/Sword_Master") as Texture2D;
            MagicMasterImg = Resources.Load("Img/Magic_Master") as Texture2D;
            HealMasterImg = Resources.Load("Img/Heal_Master") as Texture2D;

            if (SwordMasterImg != null)
            {
                Debug.Log("SwordMasterImg.name  : "  + SwordMasterImg.name);
            }
            else
            {
                Debug.Log("SwordMasterImg is null");
            }
        }
        
        private void OnClickPrevButton()
        {
            m_Heroes_Image.style.backgroundImage = new StyleBackground(SwordMasterImg);
        }
        
        private void OnClickNextButton()
        {
            m_Heroes_Image.style.backgroundImage = new StyleBackground(MagicMasterImg);
        }
    }
}
