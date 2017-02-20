using UnityEngine;
using System.Collections;

public class GameMenuController : MonoBehaviour {
	[Header("BRANDS")]
	public GameObject brandsPanel;

	[Header("FLAVOURS")]
	public GameObject exoticBrandPanel;
	public GameObject activeBrandsPanel;
	public GameObject hundredBrandsPanel;
	public GameObject happyHourBrandsPanel;
	public GameObject TeaBrandsPanel;

	[Header("ADD DRINKS")]
	public GameObject addDrinksPanel;

	[Header("ADD ONS")]
	public GameObject addOnsPanel;

	[Header("SHAKEUPDRINKS")]
	public GameObject shakeUPDrinksPanel;

	[Header("MIXER")]
	public GameObject pickGlassPanel;
	public GameObject pourAnimationPanel;
	public GameObject makeSpeacialPanel;
	public GameObject servePanel;


	public enum ChooseBrand
	{
		none,
		Active,
		HappyHour,
		Hundred,
		IceTea,
		Exotic
	}

	public enum Active
	{
		none,
		one,
		two,
		three,
		four
	}

	public enum HappyHour
	{
		none,
		one,
		two,
		three,
		four,
		five
	}
	public enum Hundred
	{
		none,
		one,
		two,
		three,
		four,
		five,
		six
	}
	public enum IceTea
	{
		none,
		one
	}

	public enum Exotic
	{
		none,
		one,
		two,
		three,
		four,
		five,
		six,
		seven,
		eight,
		nine,
		ten,
		eleven
	}

	public enum HardDrink
	{
		none,
		one,
		two,
		three,
		four,
		five,
		six,
		seven,
		eight,
		nine
	}

	public enum AddOns
	{
		none,
		one,
		two,
		three
	}

	public enum ChooseGlass
	{
		none,
		one,
		two,
		three
	}

	public enum MakeItSpl
	{
		none,
		one,
		two,
		three
	}

	public AddOns addOnsState;
	public ChooseGlass ChooseGlassState;
	public HardDrink hardDrinksState;
	public ChooseBrand brandState;
	public HappyHour happyHourState;
	public Active activeState;
	public IceTea iceTeaState;
	public Exotic exoticState;
	public Hundred hundredState;
	public MakeItSpl MakeItSplState;


	public static GameMenuController Instance;

	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
