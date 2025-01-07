
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class TabletSwitchs : UdonSharpBehaviour
{
    public GameObject screen0;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;

    public void SelectSwitch0()
    {
        screen0.SetActive(true);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        ErrorChacker();
    }

    public void SelectSwitch1()
    {
        screen0.SetActive(false);
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        ErrorChacker();
    }

    public void SelectSwitch2()
    {
        screen0.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(true);
        screen3.SetActive(false);
        screen4.SetActive(false);
        ErrorChacker();
    }

    public void SelectSwitch3()
    {
        screen0.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(true);
        screen4.SetActive(false);
        ErrorChacker();
    }

    public void SelectSwitch4()
    {
        screen0.SetActive(false);
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(true);
        ErrorChacker();
    }

    void ErrorChacker()
    {
        if(!screen0.activeSelf && !screen1.activeSelf && !screen2.activeSelf && !screen3.activeSelf && !screen4.activeSelf)
        {
            this.gameObject.transform.position = new Vector3 (0, -101, 0);
            Debug.Log("Tablet Respawned");
        }
    }
}
