using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDemo
{
    public class UIViewManager : MonoBehaviour
    {
        private UIHomeInfoView m_HomeInfoView;

        private void Start()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            m_HomeInfoView = new UIHomeInfoView(root);
            Print();
        }

        private void Print()
        {
            Debug.Log("Name : " + m_HomeInfoView.Root.name);
        }
    }
}
