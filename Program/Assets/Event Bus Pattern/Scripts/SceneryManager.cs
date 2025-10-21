using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : MonoBehaviour
{
    [SerializeField] static SceneryManager instance;

    [SerializeField] Slider slider;
    [SerializeField] GameObject screen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int buildIndex)
    {
        // // LoadScene ; ���� ���
        // SceneManager.LoadScene(1);  // ���� �۾��� ���� '1'���� ���� ��� enum���� �ϴ� �� ����.(enum�� ��������, �˾ƺ��� ���� �Ϸ���.)
        StartCoroutine(TransitionScene(buildIndex));
    }

    public IEnumerator TransitionScene(int index)   // ����� �۾��� ���� int�� �ƴ� enum�� ����ϴ� �� ����
    {
        slider.value = 0;
    
        screen.SetActive(true);
    
        // LoadSceneAsync ; �񵿱� ���
        // <AsyncOperation>
        // - allowSceneActivation
        // ����� �غ�� ��� ����� Ȱ���Ǵ� ���� ����ϴ� �����Դϴ�. boolean�� ��ȯ. default���� true. true�� ����� �Ѿ
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        // ����ũ �ε��� �ϱ� ���ؼ� ��� �����ִ� ��.
        asyncOperation.allowSceneActivation = false;

        // <AsyncOperation>
        // - isDone
        // �ش� ������ �Ϸ�Ǿ��� �� ��Ÿ���� �����Դϴ�. (�б� ����)
        while(asyncOperation.isDone == false)   // ���� �Ϸ���� �ʾҴٸ�
        {
            // <AsyncOperation>
            // - progress
            // �۾��� ���� ���¸� ��Ÿ���� �����Դϴ�. (�б� ����)

            if (asyncOperation.progress >= 0.9f)
            {
                slider.value = Mathf.Lerp(slider.value, 1.0f, Time.deltaTime);

                if (slider.value >= 0.99f)
                {
                    slider.value = 1.0f;

                    asyncOperation.allowSceneActivation = true;

                    yield return new WaitForSeconds(0.1f);
                    screen.SetActive(false);

                    //yield break;
                }
            }

            else
            {
                slider.value = asyncOperation.progress;
            }

            yield return null;  // null�� ������ ����
        }

        screen.SetActive(false);
    }
}
