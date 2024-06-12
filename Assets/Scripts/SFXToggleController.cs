using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXToggleController : MonoBehaviour
{
	public bool isOn;

	public Color onColorBg;
	public Color offColorBg;

	public Image toggleBgImage;
	public RectTransform toggle;

	public GameObject handle;
	private RectTransform handleTransform;

	private float handleSize;
	private float onPosX;
	private float offPosX;

	public float handleOffset;

	public GameObject onIcon;
	public GameObject offIcon;


	public float speed;
	static float t = 0.0f;

	private bool switching = false;

	//this creates a referenc e for audioManager into the controller
	private AudioManager audioManager;
	private Movement movement; //gets movemment script info


	void Awake()
	{
		handleTransform = handle.GetComponent<RectTransform>();
		RectTransform handleRect = handle.GetComponent<RectTransform>();
		handleSize = handleRect.sizeDelta.x;
		float toggleSizeX = toggle.sizeDelta.x;
		onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
		offPosX = onPosX * -1;


		  // Get references from the GameManager
      
        audioManager = GameManager.Instance.audioManager;

	
        if (movement == null)
        {
            Debug.LogError("Movement reference is null in SFXToggleController");
        }

        if (audioManager == null)
        {
            Debug.LogError("AudioManager reference is null in SFXToggleController");
        }
	}


	void Start()
	{
		isOn = PlayerPrefs.GetInt("SFXToggleState", 1) == 1;

		if (isOn)
		{
			toggleBgImage.color = onColorBg;
			handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
			onIcon.gameObject.SetActive(true);
			offIcon.gameObject.SetActive(false);
		}
		else
		{
			toggleBgImage.color = offColorBg;
			handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
			onIcon.gameObject.SetActive(false);
			offIcon.gameObject.SetActive(true);
		}
	}

	void Update()
	{

		if (switching)
		{
			Toggle(isOn);
		}
	}
	//This is where we place the info to activate the audio 
	//The source developer speleld stuff wrong LOL
	public void DoYourStaff()
	{
		Debug.Log(isOn);
		if(audioManager !=null)
		{
			audioManager.ToggleSoundEffects(isOn);
		}
		else
		{
			Debug.LogError("Audiuo manager is null in the method do your staff");
		}
		if(movement != null)
		{
			movement.ToggleJumpSound();
		}
		else
		{
			Debug.LogError("Movement is null in do otyu staff");
		}
	}

	public void Switching()
	{
		switching = true;
	}

	public void Toggle(bool toggleStatus)
	{
		if (!onIcon.activeSelf || !offIcon.activeSelf)
		{
			onIcon.SetActive(true);
			offIcon.SetActive(true);
		}

		if (toggleStatus)
		{
			toggleBgImage.color = SmoothColor(onColorBg, offColorBg);
			Transparency(onIcon, 1f, 0f);
			Transparency(offIcon, 0f, 1f);
			handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
		}
		else
		{
			toggleBgImage.color = SmoothColor(offColorBg, onColorBg);
			Transparency(onIcon, 0f, 1f);
			Transparency(offIcon, 1f, 0f);
			handleTransform.localPosition = SmoothMove(handle, offPosX, onPosX);
		}

	}


	Vector3 SmoothMove(GameObject toggleHandle, float startPosX, float endPosX)
	{

		Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += speed * Time.deltaTime), 0f, 0f);
		StopSwitching();
		return position;
	}

	Color SmoothColor(Color startCol, Color endCol)
	{
		Color resultCol;
		resultCol = Color.Lerp(startCol, endCol, t += speed * Time.deltaTime);
		return resultCol;
	}

	CanvasGroup Transparency(GameObject alphaObj, float startAlpha, float endAlpha)
	{
		CanvasGroup alphaVal;
		alphaVal = alphaObj.gameObject.GetComponent<CanvasGroup>();
		alphaVal.alpha = Mathf.Lerp(startAlpha, endAlpha, t += speed * Time.deltaTime);
		return alphaVal;
	}

	void StopSwitching()
	{
	 if (t > 1.0f)
        {
            switching = false;
            t = 0.0f;
            isOn = !isOn;
            DoYourStaff();
            PlayerPrefs.SetInt("SFXToggleState", isOn ? 1 : 0);
            PlayerPrefs.Save();
        }
	}

}