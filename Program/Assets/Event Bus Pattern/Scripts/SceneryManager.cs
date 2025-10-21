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
        // // LoadScene ; 동기 방식
        // SceneManager.LoadScene(1);  // 실제 작업할 때는 '1'같은 정수 대신 enum으로 하는 게 좋다.(enum도 정수지만, 알아보기 쉽게 하려고.)
        StartCoroutine(TransitionScene(buildIndex));
    }

    public IEnumerator TransitionScene(int index)   // 제대로 작업할 때는 int가 아닌 enum을 사용하는 게 좋음
    {
        slider.value = 0;
    
        screen.SetActive(true);
    
        // LoadSceneAsync ; 비동기 방식
        // <AsyncOperation>
        // - allowSceneActivation
        // 장면이 준비된 즉시 장면이 활성되는 것을 허용하는 변수입니다. boolean을 반환. default값은 true. true면 장면이 넘어감
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        // 페이크 로딩을 하기 위해서 잠시 멈춰주는 것.
        asyncOperation.allowSceneActivation = false;

        // <AsyncOperation>
        // - isDone
        // 해당 동작이 완료되었는 지 나타내는 변수입니다. (읽기 전용)
        while(asyncOperation.isDone == false)   // 아직 완료되지 않았다면
        {
            // <AsyncOperation>
            // - progress
            // 작업의 진행 상태를 나타내는 변수입니다. (읽기 전용)

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

            yield return null;  // null은 프레임 단위
        }

        screen.SetActive(false);
    }
}
