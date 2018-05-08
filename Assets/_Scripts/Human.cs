using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Singleton<Human>
{
    [Header("Human Sprites")]
    [SerializeField] private GameObject LookingDown;
    [SerializeField] private GameObject LookingUp;

    [Header("Timing")]
    [SerializeField] private float LookUpCueDelay = 1.0f;
    [SerializeField] private float LookUpTime = 3.5f;
    [SerializeField] private float MinLookUpTime = 2.0f;
    [SerializeField] private float MaxLookUpTime = 5.0f;


    private float _lookupTimer;
    private bool _isIdling;


    public bool isLookingUp { get; protected set; }


	void Start ()
    {
        LookingUp.SetActive(false);
        LookingDown.SetActive(true);

        isLookingUp = false;
        _isIdling = true;
        ResetLookupTimer();
	}
	
	void Update ()
    {
        if(_lookupTimer < 0 && _isIdling)
        {
            _isIdling = false;
            StartCoroutine(LookUpwards());
        }

        _lookupTimer -= Time.deltaTime;
	}
    private void ResetLookupTimer()
    {
        _lookupTimer = UnityEngine.Random.Range(MinLookUpTime, MaxLookUpTime);
        _isIdling = true;
    }

    public IEnumerator LookUpwards()
    {
        // TODO: Play Sound effect/give cue
        Debug.Log("ABOUT TO LOOK UP");
        yield return new WaitForSeconds(LookUpCueDelay);

        Debug.Log("LOOKING UP!");
        isLookingUp = true;
        LookingUp.SetActive(true);
        LookingDown.SetActive(false);

        yield return new WaitForSeconds(LookUpTime);
        Debug.Log("LOOKING DOWN");

        isLookingUp = false;
        LookingUp.SetActive(false);
        LookingDown.SetActive(true);
        ResetLookupTimer();

        yield return null;
    }
}
