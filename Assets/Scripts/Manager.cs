using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public AudioClip pistol;
    public AudioClip shotGun;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Pistol = pistol;
        SoundManager.Instance.ShotGun = shotGun;
    }

    public TextMeshProUGUI single;
    public TextMeshProUGUI multi;
    public Sprite singlePic;
    public Sprite multiPic;
    public Image Orignal;
    public GameObject modeButton;
    public static bool isBrust;
    public void ChangeMode()
    {
        if (!isBrust)
        {
            modeButton.GetComponent<Animator>().SetTrigger("multi");
            single.enabled = false;
            multi.enabled = true;
            Orignal.sprite = multiPic;
            isBrust = true;
        }
        else
        {
            modeButton.GetComponent<Animator>().SetTrigger("single");
            single.enabled = true;
            multi.enabled = false;
            Orignal.sprite = singlePic;
            isBrust = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
