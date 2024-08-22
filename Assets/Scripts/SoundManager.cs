using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    // Variables
    private AudioClip success;
    private AudioClip click;
    private AudioClip pistol;
    private AudioClip shotGun;
    private AudioClip pop;

    // Getters and Setters
    public AudioClip Success
    {
        get { return success; }
        set
        {
            success = value;
        }
    }
    public AudioClip Pistol
    {
        get { return pistol; }
        set
        {
            pistol = value;
        }
    }
    public AudioClip Click
    {
        get { return click; }
        set
        {
            click = value;
        }
    }
   
   
    public AudioClip ShotGun
    {
        get { return shotGun; }
        set
        {
           shotGun = value;
        }
    }
    public AudioClip Pop
    {
        get { return pop; }
        set
        {
            pop = value;
        }
    }
    // Singleton instance property
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<SoundManager>();
                    singletonObject.name = "SoundManager";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
}