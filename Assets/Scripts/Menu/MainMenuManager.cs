using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject intro;
    [SerializeField] private GameObject controls;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private ActionBasedContinuousTurnProvider continuousTurn;
    [SerializeField] private ActionBasedSnapTurnProvider snapTurn;
    [SerializeField] private XROriginSO xrOrigin;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        if (xrOrigin.ContinuousTurn)
        {
            continuousTurn.enabled = true;
            snapTurn.enabled = false;
        }
        else if (!xrOrigin.ContinuousTurn)
        {
            continuousTurn.enabled = false;
            snapTurn.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        transform.LookAt(new Vector3(head.position.x, transform.position.y, head.position.z));
        transform.forward *= -1;
    }

    public void ShowControls()
    {
        intro.SetActive(false);
        controls.SetActive(true);
    }

    public void ShowMenu()
    {
        controls.SetActive(false);
        menu.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void HideSettings()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();
    }

    public void SetTurnType(int index)
    {
        if (index == 0)
        {
            continuousTurn.enabled = true;
            snapTurn.enabled = false;
        }
        else if (index == 1)
        {
            continuousTurn.enabled = false;
            snapTurn.enabled = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
