using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServeController : MonoBehaviour {

	public GameObject DrinkFilledGlass;
	public InputField recipeInputField;
	public GameObject serveText;
	public GameObject celebrationImage;
	public Button serveButton;

	[Header("Spl One")]
	public Sprite SplOneGlass1;
	public Sprite SplOneGlass2;
	public Sprite SplOneGlass3;

	[Header("Spl Two")]
	public Sprite SplTwoGlass1;
	public Sprite SplTwoGlass2;
	public Sprite SplTwoGlass3;

	[Header("Spl Three")]
	public Sprite SplThreeGlass1;
	public Sprite SplThreeGlass2;
	public Sprite SplThreeGlass3;

	[Header("Default")]
	public Sprite DefaultGlass1;
	public Sprite DefaultGlass2;
	public Sprite DefaultGlass3;

	// Checks if there is anything entered into the input field.
	void LockInput(InputField input)
	{
		if (input.text.Length > 0) 
		{
			Debug.Log("Text has been entered");
			serveButton.interactable = true;
			serveText.gameObject.SetActive(true);
		}
		else if (input.text.Length == 0) 
		{
			Debug.Log("Main Input Empty");
		}
	}

	public void Start()
	{
		//Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
		//Passes the main input field into the method when "LockInput" is invoked
		recipeInputField.onEndEdit.AddListener(delegate{LockInput(recipeInputField);});
		serveButton.interactable = false;
	}


	void OnEnable()
	{
		switch(GameMenuController.Instance.ChooseGlassState)
		{
		case GameMenuController.ChooseGlass.none:
			{
				if(GameMenuController.MakeItSpl.none == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = DefaultGlass1;
				}
				else if(GameMenuController.MakeItSpl.one == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplOneGlass1;
				}
				else if(GameMenuController.MakeItSpl.two == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplTwoGlass1;

				}
				else if(GameMenuController.MakeItSpl.three == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplThreeGlass1;

				}
			}
			break;
		case GameMenuController.ChooseGlass.one:
			{
				if(GameMenuController.MakeItSpl.none == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = DefaultGlass1;
				}
				else if(GameMenuController.MakeItSpl.one == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplOneGlass1;

				}
				else if(GameMenuController.MakeItSpl.two == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplTwoGlass1;

				}
				else if(GameMenuController.MakeItSpl.three == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplThreeGlass1;

				}
			}
			break;
		case GameMenuController.ChooseGlass.two:
			{
				if(GameMenuController.MakeItSpl.none == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = DefaultGlass2;
				}
				else if(GameMenuController.MakeItSpl.one == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplOneGlass2;

				}
				else if(GameMenuController.MakeItSpl.two == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplTwoGlass2;

				}
				else if(GameMenuController.MakeItSpl.three == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplThreeGlass2;

				}
			}
			break;
		case GameMenuController.ChooseGlass.three:
			{
				if(GameMenuController.MakeItSpl.none == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = DefaultGlass3;

				}
				else if(GameMenuController.MakeItSpl.one == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplOneGlass3;

				}
				else if(GameMenuController.MakeItSpl.two == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplTwoGlass3;

				}
				else if(GameMenuController.MakeItSpl.three == GameMenuController.Instance.MakeItSplState)
				{
					DrinkFilledGlass.GetComponent<Image>().sprite = SplThreeGlass3;

				}
			}
			break;
		}
	}


	public void OnclickBack()
	{
		GameMenuController.Instance.servePanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
	}

	public void OnClickNext()
	{
		celebrationImage.gameObject.SetActive(true);
		serveText.gameObject.SetActive(false);
	}
}
