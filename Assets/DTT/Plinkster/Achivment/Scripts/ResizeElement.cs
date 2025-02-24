using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResizeElement : MonoBehaviour
{
    public float scaleFactor = 1.2f; // Коэффициент увеличения
    public float duration = 0.01f; // Длительность анимации
    public float distance = 20.0f; // Расстояние для смещения соседних объектов

    private Vector3 originalScale; // Исходный размер
    private List<Vector3> originalPositions; // Исходные позиции соседних объектов
    private bool isScaledUp = false; // Состояние увеличения

    private void Start()
    {
        originalScale = transform.localScale; // Сохраняем исходный размер
        originalPositions = new List<Vector3>(); // Инициализируем список
    }

    public void Resize()
    {
        if (!isScaledUp)
        {
            // Увеличиваем размер кнопки
            transform.DOScale(originalScale * scaleFactor, duration).OnComplete(() =>
            {
                // Сохраняем исходные позиции соседних объектов
                SaveAdjacentObjectsPositions();
                // Подвигаем соседние объекты
                MoveAdjacentObjects();
            });
        }
        else
        {
            // Возвращаем размер кнопки обратно
            transform.DOScale(originalScale, duration).OnComplete(() =>
            {
                // Возвращаем соседние объекты на исходные позиции
                RestoreAdjacentObjectsPositions();
            });
        }

        isScaledUp = !isScaledUp; // Переключаем состояние
    }

    private void SaveAdjacentObjectsPositions()
    {
        // Получаем все соседние объекты (например, по тегу или по имени)
        GameObject[] adjacentObjects = GameObject.FindGameObjectsWithTag("Achivment");
        originalPositions.Clear(); // Очищаем список перед сохранением

        foreach (GameObject obj in adjacentObjects)
        {
            if (obj != gameObject)
            {
                originalPositions.Add(obj.transform.position); // Сохраняем исходные позиции
            }
        }
    }

    private void MoveAdjacentObjects()
    {
        // Получаем все соседние объекты (например, по тегу или по имени)
        GameObject[] adjacentObjects = GameObject.FindGameObjectsWithTag("Achivment");
        int index = 0; // Индекс для списка оригинальных позиций

        foreach (GameObject obj in adjacentObjects)
        {
            if (obj != gameObject && index < originalPositions.Count)
            {
                Debug.Log("Moving object: " + obj.name);
            
                // Вычисляем направление от увеличивающегося объекта к соседнему объекту
                Vector3 direction = (obj.transform.position - transform.position).normalized;
                Vector3 targetPosition = obj.transform.position + direction * distance;

                // Перемещаем объект
                obj.transform.DOMove(targetPosition, duration);
                index++; // Увеличиваем индекс
            }
        }
    }

    private void RestoreAdjacentObjectsPositions()
    {
        // Получаем все соседние объекты (например, по тегу или по имени)
        GameObject[] adjacentObjects = GameObject.FindGameObjectsWithTag("Achivment");
        int index = 0; // Индекс для списка оригинальных позиций

        foreach (GameObject obj in adjacentObjects)
        {
            if (obj != gameObject && index < originalPositions.Count)
            {
                // Возвращаем объект на исходную позицию
                obj.transform.DOMove(originalPositions[index], duration);
                index++; // Увеличиваем индекс
            }
        }
    }
}
