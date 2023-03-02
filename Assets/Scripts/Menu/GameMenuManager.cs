using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private Transform leftHand;
    [SerializeField] private GameObject menu;
    [SerializeField] private InputActionProperty showButton;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private ActionBasedContinuousTurnProvider continuousTurn;
    [SerializeField] private ActionBasedSnapTurnProvider snapTurn;
    [SerializeField] private XROriginSO xrOrigin;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        if(xrOrigin.ContinuousTurn)
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
        if(showButton.action.WasPressedThisFrame() && (leftHand.eulerAngles.z > 40 && leftHand.eulerAngles.z < 140))
        {
            menu.SetActive(!menu.gameObject.activeSelf);
        }
        else if (menu.gameObject.activeSelf && (leftHand.eulerAngles.z < 40 || leftHand.eulerAngles.z > 140))
        {
            menu.SetActive(!menu.gameObject.activeSelf);
        }
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

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
