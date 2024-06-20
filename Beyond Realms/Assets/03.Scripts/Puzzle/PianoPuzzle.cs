using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PianoPuzzle : MonoBehaviour
{
    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float deadZone = 0.005f;

    public static PianoPuzzle instance;

    public int passwordNumber = 1;
    public UnityEvent PianoPressed;

    private Vector3 startPos;
    private ConfigurableJoint joint;

    //public AudioSource wrongSound;
    //public AudioSource rightSound;

    //AudioSource sound;

    public bool isPressed = false;

    private void Awake()
    {
        if (PianoPuzzle.instance == null)
        {
            PianoPuzzle.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //sound = GetComponent<AudioSuorce>();
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }
    private void Pressed()
    {
        isPressed = true;
        //sound.Play();
        PianoPressed.Invoke();
    }
    private void Released()
    {
        isPressed = false;
    }

    public void CorrectSound()
    {
        //rightSound.Play();
    }
    public void InCorrectSound()
    {
        //wrongSound.Play();
    }
}
