using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private Transform head;
    //[SerializeField] private Input
    [SerializeField] private GameObject menu;
    [SerializeField] private InputActionProperty showButton;
    [SerializeField] private Slider volumeSlider;

    private bool _isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        if(showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!gameObject.activeSelf);
            //menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * distance;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();
    }
}