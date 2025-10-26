using UnityEngine;
using UnityEngine.SceneManagement; // To load scenes
using TMPro; // For TextMeshPro UI messages

public class DoorLock : MonoBehaviour
{
    public float interactDistance = 3.0f; 
    public string winSceneName = "WinScene"; 
    public TextMeshProUGUI messageText;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (messageText)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
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
        // Optional: you can add a door animation or sound here

        // Load the Win Scene
        SceneManager.LoadScene(winSceneName);
    }

    void ShowLockedMessage()
    {
        if (messageText)
        {
            messageText.text = "Door is locked. Find the key!";
            messageText.gameObject.SetActive(true);

            // Hide the message after 2 seconds
            CancelInvoke(nameof(HideMessage));
            Invoke(nameof(HideMessage), 2f);
        }
    }

    void HideMessage()
    {
        if (messageText)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
