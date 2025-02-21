using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeScene : MonoBehaviour
{
    private float loadingTime = 3f; // Время загрузки в секундах
    [SerializeField] private Image progressBar; // Ссылка на Image для заполнения прогресс-бара

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
            yield return null; // Ждем следующего кадра
        }

        // После завершения загрузки переходим на игровую сцену
        SceneManager.LoadScene("Landscape");
    }
}
