using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WelcomeScene : MonoBehaviour
{
    private float loadingTime = 3f; // Время загрузки в секундах
    [SerializeField] private Image progressBar; // Ссылка на Image для заполнения прогресс-бара
    [SerializeField] private TextMeshProUGUI loadingPercentageText; // Ссылка на текст для отображения процентов загрузки

    void Start()
    {
        StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
        float elapsedTime = 0f;

        while (elapsedTime < loadingTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / loadingTime);
            progressBar.fillAmount = progress; // Обновляем заполнение прогресс-бара
            loadingPercentageText.text = (progress * 100).ToString("F0") + "%"; // Форматируем текст
            yield return null; // Ждем следующего кадра
        }

        // После завершения загрузки переходим на игровую сцену
        SceneManager.LoadScene("Landscape");
    }
}
