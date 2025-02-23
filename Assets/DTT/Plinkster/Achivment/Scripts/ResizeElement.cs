using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeElement : MonoBehaviour
{
    private RectTransform targetElement; // Объект для изменения размера
    public Vector2 newSize = new Vector2(1.2f, 1.2f); // Новый размер 

    private void Start()
    {
        // Автоматически назначаем targetElement на RectTransform текущего объекта
        targetElement = GetComponent<RectTransform>();
    }

    public void Resize()
    {
        if (targetElement != null)
        {
            
            targetElement.sizeDelta = newSize;
            LayoutRebuilder.ForceRebuildLayoutImmediate(targetElement.parent.GetComponent<RectTransform>());
        }
    }
}
