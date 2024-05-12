using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitDemo
{
    public class UIViewBase : IDisposable
    {
        protected VisualElement m_TopElement;
        
        public VisualElement Root => m_TopElement;
        
        public UIViewBase(VisualElement topElement)
        {
            m_TopElement = topElement ?? throw new ArgumentNullException(nameof(topElement));
        }

        public void Dispose()
        {
            
        }
    }
}
