using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            audioSource.PlayOneShot(sound1);
            SceneManager.LoadScene("Main");
        });
    }
}
