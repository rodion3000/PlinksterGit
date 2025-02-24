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
    

    public void Resize()
    {
        // Увеличиваем размер кнопки
        transform.DOScale(scaleFactor, duration).OnComplete(() =>
        {
            // Подвигаем соседние объекты
            MoveAdjacentObjects();
        });
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
}
