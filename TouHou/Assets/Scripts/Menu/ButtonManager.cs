using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip pressed;
    [SerializeField] private  AudioSource source;
    [SerializeField] private string SceneToLoad;
    [SerializeField] private string menu;
    [SerializeField] private bool isLoad;
    [SerializeField] private bool isQuit;
    [SerializeField] private bool isMenu;
    [SerializeField] private bool isAbout;
    [SerializeField] private bool isBack;
    [SerializeField] private bool isResume;
    [SerializeField] private bool hasPressed;
    public bool hasUnpressed;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private PauseMenu pausemenu;
    private Animator animator;
    public float timeUnscaled;

    void Start()
    {
        timeUnscaled = .7f;
        animator = GetComponent<Animator>();
        hasPressed = false;
        hasUnpressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        source.PlayOneShot(pressed);
        hasPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if(isResume || isAbout || isMenu || isLoad || isQuit || isBack)
        {
            hasUnpressed = true;
        }
    }


    void Update()
    {
        if (hasPressed == true)
        {
            timeUnscaled -= Time.unscaledDeltaTime;
            if (timeUnscaled <= 0)
            {
                ButtonPress();
                hasPressed = false;
                hasUnpressed = false;
            }
        }

        if (hasUnpressed == true)
        {
            if(isResume || isQuit)
            {
                animator.Play("Base Layer.Pressedq");
            }
            if(isMenu || isAbout)
            {
                animator.Play("Base Layer.Presseda1");
            }
            if(isBack)
            {
                animator.Play("Base Layer.Pressedb1");
            }
            if (isLoad)
            {
                animator.Play("Base Layer.Pressedp1");
            }
        }
    }       
    void ButtonPress()
    {
        if(isLoad)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        if (isMenu)
        {
            SceneManager.LoadScene(menu);
            Time.timeScale = 1;
        }
        if (isAbout)
        {
            aboutPanel.SetActive(true);
            buttonPanel.SetActive(false);
            timeUnscaled = .7f;
        }
        if (isBack)
        {
            aboutPanel.SetActive(false);
            buttonPanel.SetActive(true);
            timeUnscaled = .7f;
        }
        if (isQuit)
        {
            Application.Quit();
        }
        if(isResume)
        {
            pausemenu.Close();
        }
    }

}
