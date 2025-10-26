using UnityEngine;
using UnityEngine.SceneManagement; // To load scenes
using TMPro; // For TextMeshPro UI messages
using System.Collections; // For coroutine

public class DoorLock : MonoBehaviour
{
    public float interactDistance = 3.0f; 
    public string winSceneName = "WinScene"; 
    public TextMeshProUGUI messageText;
    public AudioSource doorAudio; // assign in Inspector

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("player").transform;

        if (messageText)
            messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.HasKey)
            {
                OpenDoor();
            }
            else
            {
                ShowLockedMessage();
            }
        }
    }

    void OpenDoor()
    {
        // Play door sound if assigned
        if (doorAudio)
            doorAudio.Play();

        // Delay scene load so the sound can be heard
        StartCoroutine(LoadWinSceneAfterDelay(1f)); // 1 second delay
    }

    IEnumerator LoadWinSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(winSceneName);
    }

    void ShowLockedMessage()
    {
        if (messageText)
        {
            messageText.text = "Door is locked. Find the key!";
            messageText.gameObject.SetActive(true);

            CancelInvoke(nameof(HideMessage));
            Invoke(nameof(HideMessage), 2f);
        }
    }

    void HideMessage()
    {
        if (messageText)
            messageText.gameObject.SetActive(false);
    }
}
