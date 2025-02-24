using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResizeElement : MonoBehaviour
{
    public float scaleFactor = 1.2f; // Коэффициент увеличения
    public float duration = 0.01f; // Длительность анимации
    public Vector3 offset = new Vector3(0.5f, 0, 0); // Смещение для соседних объектов

    private Vector3 originalScale; // Исходный размер
    private Vector3[] originalPositions; // Исходные позиции соседних объектов
    private bool isScaledUp = false; // Состояние увеличения

    private void Start()
    {
        originalScale = transform.localScale; // Сохраняем исходный размер
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
        originalPositions = new Vector3[adjacentObjects.Length];

        for (int i = 0; i < adjacentObjects.Length; i++)
        {
            if (adjacentObjects[i] != gameObject)
            {
                originalPositions[i] = adjacentObjects[i].transform.position; // Сохраняем исходные позиции
            }
        }
    }

    private void MoveAdjacentObjects()
    {
        // Получаем все соседние объекты (например, по тегу или по имени)
        GameObject[] adjacentObjects = GameObject.FindGameObjectsWithTag("Achivment");

        foreach (GameObject obj in adjacentObjects)
        {
            if (obj != gameObject)
            {
                Debug.Log("Moving object: " + obj.name);
            
                // Вычисляем направление от увеличивающегося объекта к соседнему объекту
                Vector3 direction = (obj.transform.position - transform.position).normalized;
            
                // Увеличиваем расстояние, на которое мы хотим отодвинуть объекты
                float distance = 20.0f; // Задайте нужное расстояние
                Vector3 targetPosition = obj.transform.position + direction * distance;

                // Перемещаем объект
                obj.transform.DOMove(targetPosition, duration);
            }
        }
    }

    private void RestoreAdjacentObjectsPositions()
    {
        // Получаем все соседние объекты (например, по тегу или по имени)
        GameObject[] adjacentObjects = GameObject.FindGameObjectsWithTag("Achivment");

        for (int i = 0; i < adjacentObjects.Length; i++)
        {
            if (adjacentObjects[i] != gameObject)
            {
                // Возвращаем объект на исходную позицию
                adjacentObjects[i].transform.DOMove(originalPositions[i], duration);
            }
        }
    }
}
