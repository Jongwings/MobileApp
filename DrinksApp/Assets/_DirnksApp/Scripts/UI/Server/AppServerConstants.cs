using UnityEngine;
using System.Collections;

public class AppServerConstants  {
	public const string BaseURL = "http://www.jongwings.com/chivita/";

	//Login
	public const string LOGIN = "app/login.php?";
	public const string FB_LOGIN = "login_fb.php?";
	public const string TW_LOGIN = "login_twitter.php?";
	public const string ADD_USER = "app/add-user.php?name=%@&email=%@&usr_name=%@&passw=%@&cnf_pass=%@";
	//profile
	public const string LIST_USER = "app/list-user.php?user_id=%@";

	//Collection
	public const string FEATURE_COLLECTION = "app/feature-collection.php";
	public const string LIST_COLLECTION = "app/list-collection.php";

	//app/list-recipe.php?recipe_id=%@&user_id=%@


	//Home
	//TOp
	public const string LIST_BRAND = "app/list-brand.php";
	//BOTTOM
	public const string FEATURE_COLLECTION1 = "app/feature-collection.php";


	//Search
	public const string LIST_Recipe = "app/list-recipe.php?";

	//My Favourite
	public const string FAVOURITE_Recipe = "app/favourite-recipe.php?";

	//My Creation
	public const string MYCREATIONS_Recipe = "app/my_creation.php?";

	//Search Drinks
	public const string Search_Drinks_Recipe = "app/search-recipe.php?";

	//Search Ingredients
	public const string Search_Ingredients_Recipe = "app/ingredients-search.php?";

	//Post Recipe
	public const string Post_Recipe = "app/user_submission.php?";


	//Rating Recipe
	public const string Rating_Recipe = "app/rate.php?";

	//Sharing Recipe
	public const string Sharing_Recipe = "app/share.php?";

	//Sharing Recipe
	public const string Screenshot_Upload = "app/app/img_upload.php";



}
