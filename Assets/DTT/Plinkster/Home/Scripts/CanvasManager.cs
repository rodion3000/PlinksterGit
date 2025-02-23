using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject firstCanvas; // Ссылка на первый Canvas
    public GameObject secondCanvas; // Ссылка на второй Canvas
    [SerializeField] private GameObject achivmenCanvas;

    void Start()
    {
        // Убедитесь, что первый Canvas активен, а второй - неактивен
        firstCanvas.SetActive(true);
        secondCanvas.SetActive(false);
        achivmenCanvas.SetActive(false);
    }

    // Метод для переключения на второй Canvas
    public void SwitchToSecondCanvas()
    {
        firstCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }

    public void SwitchToAchivmenCanvas()
    {
        firstCanvas.SetActive(false);
        achivmenCanvas.SetActive(true);
    }

    // Метод для переключения на первый Canvas
    public void SwitchToFirstCanvas()
    {
        achivmenCanvas.SetActive(false);
        secondCanvas.SetActive(false);
        firstCanvas.SetActive(true);
    }
}
