using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance; // [ ] Точно стоит делать static?

    // [ ] Singleton?

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buySound;
    [SerializeField] private AudioClip balanceSound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBuy() => audioSource.PlayOneShot(balanceSound); // [ ] Разабраться, как работает?
}
