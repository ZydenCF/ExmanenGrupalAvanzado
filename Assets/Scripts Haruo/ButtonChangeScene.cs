using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChangeScene : MonoBehaviour
{
    [SerializeField] private string nameScene;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(changeScene);
    }
    public void changeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameScene);
    }

#if UNITY_EDITOR
    public SceneAsset asset;
    private void OnValidate()
    {
        nameScene = asset.name;
    }
#endif

}