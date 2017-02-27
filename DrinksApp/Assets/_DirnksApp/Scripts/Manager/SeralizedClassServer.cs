using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeralizedClassServer
{
	// OFFLINE START


	public class OfflineBradDetails
	{
		public string BrandName { get; set; }
		public string BrandDescription2 { get; set; }
		public string BrandTitle3 { get; set; }
		public string BrandID { get; set; }
		public string BrandBannerImage { get; set; }
		public string BrandTitle2 { get; set; }
		public string BrandDescription1 { get; set; }
		public string BrandDescription3 { get; set; }
		public string BrandTitle1 { get; set; }
		public string BrandThumpImage { get; set; }
	}
	public class OfflineCollectionDetails
	{
		public List<string> RecipesNameInTheCollection { get; set; }
		public string CollectionID { get; set; }
		public List<string> RecipesIDInTheCollection { get; set; }
		public string CollectionName { get; set; }
		public string CollectionImage { get; set; }
	}
	public class OfflineFeatureCollectionDetails
	{
		public string CollectionImage { get; set; }
		public List<string> RecipesIDInTheCollection { get; set; }
		public List<string> RecipesNameInTheCollection { get; set; }
		public string CollectionID { get; set; }
		public string CollectionName { get; set; }
	}
	public class OfflineRecipeDetails
	{
		public string Preparation { get; set; }
		public string RecipeID { get; set; }
		public string Ingeridents { get; set; }
		public string RecipeImage { get; set; }
		public string RecipeName { get; set; }
		public string RecipeBrandName { get; set; }
	}
	//OFFLINE END


	public class Login
	{
		public string returnvalue { get; set; }
		public string user_id { get; set; }	
	}
	[Serializable]
	public class UserList
	{
		public string username { get; set; }
		public string name { get; set; }
		public string email { get; set; }
	}
	[Serializable]
	public class CollectionBrand
	{
		public string collection_id;
		public string collection_name;
		public string recipes_image;
	}

	[Serializable]
	public class KYDBrand
	{
		public string brnad_name { get; set; }
		public string brand_img { get; set; }
		public string brand_thumb_img { get; set; }
		public string brand_title1 { get; set; }
		public string brand_des1 { get; set; }
		public string brand_title2 { get; set; }
		public string brand_des2 { get; set; }
		public string brand_title3 { get; set; }
		public string brand_des3 { get; set; }
		public string brand_id { get; set; }
	}

	[Serializable]
	public class CollectionList
	{
		public string collection_id;
		//
		public string collection_name;
		public string recipes_image;
	}
	[Serializable]
	public class BrandRecipesList
	{
		public string recipes_id { get; set; }
		public string recipes_name { get; set; }
		public string brand_name { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public int rating { get; set; }
		public string recipes_image { get; set; }

	}

	[Serializable]
	public class SearchDrinkListOfRecipes
	{
		public string returnvalue { get; set; }
		public string recipes_id { get; set; }
		public string recipes_name { get; set; }
		public string brand_name { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public int rating { get; set; }
		public string recipes_image { get; set; }
	}

	[Serializable]
	public class SearchPanelDrinksList
	{
		public string recipes_name { get; set; }
		public string recipes_id { get; set; }
		public string rating { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public string recipes_image { get; set; }
	}
	[Serializable]
	public class SearchPanelIngredientsList
	{
		public string recipes_name { get; set; }
		public string recipes_id { get; set; }
		public int rating { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public string recipes_image { get; set; }
	}

	[Serializable]
	public class MyFavouriteRecipes
	{
		public string recipes_name { get; set; }
		public string recipes_id { get; set; }
		public string rating { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public string recipes_image { get; set; }
	}

	[Serializable]
	public class MyCreationRecipes
	{
		public string recipes_name { get; set; }
		public string recipes_id { get; set; }
		public string rating { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public string recipes_image { get; set; }
	}


	[Serializable]
	public class MyRecipes
	{
		public string recipes_name { get; set; }
		public string recipes_id { get; set; }
		public string rating { get; set; }
		public string ingredients { get; set; }
		public string preparation { get; set; }
		public string recipes_image { get; set; }
	}

	[Serializable]
	public class HomeBrand
	{
		public string brnad_name { get; set; }
		public string brand_img { get; set; }
		public string brand_thumb_img { get; set; }
		public string brand_title1 { get; set; }
		public string brand_des1 { get; set; }
		public string brand_title2 { get; set; }
		public string brand_des2 { get; set; }
		public string brand_title3 { get; set; }
		public string brand_des3 { get; set; }
		public string brand_id { get; set; }
	}

	[Serializable]
	public class HomeCollectionList
	{
		public string collection_id;
		public string collection_name;
		public string recipes_image;
	}

	[Serializable]
	public class ConfigGetVersion
	{
		public float IOS_VERSION;
		public float ANDROID_VERSION;
	}

	[Serializable]
	public class CategoryDictionary
	{
		public List<Category> categoryList = new List<Category> ();
		//public List<Topics> topic = new List<Topics> ();
	}

	[Serializable]
	public class Category
	{
		public int category_id;
		public string category_title;
		public int type;
		public string image;
		public int status;
	}

	[Serializable]
	public class Topics
	{
		public int category_id;
		public string category_title;
		public int type;
		public string image;
//		public int parent_category_id;
//		public string created_at;
//		public int status;
	}

	[System.Serializable]
	public class SingleQuizQuestionsList
	{
		public int userQuizId;
		public int quiz_id;
		public List<QuizQuestion> questionList = new List<QuizQuestion>();
		public UserInfo user;
	}

	[System.Serializable]
	public class DuelQuizQuestionsList
	{
		public int userQuizId;
		public int quiz_id;
		public List<QuizQuestion> questionList = new List<QuizQuestion>();
		public UserInfo user;
		public UserInfo opponent;
		public object badge;
		public string after_taste;
	}

	[System.Serializable]
	public class QuizQuestion
	{
		public Question question = new Question();
		public List<Answer> answer = new List<Answer>();
	}

	[System.Serializable]
	public class Question
	{
		public string title;
		public int questionId;
		public int type;
		public string url;
		public string aftertaste;
		public string hint;
	}

	[System.Serializable]
	public class Answer
	{
		public int answer_id;
		public string answer_title;
		public int is_correct;  //1=True, 2=False;
	}

	[System.Serializable]
	public class AnswerSubmit
	{
		public int questionId;
		public int answerId;
	}

	[System.Serializable]
	public class ScoreCallback
	{
		public int score;
		public int total;
	}

	[System.Serializable]
	public class UserInfo
	{
		public int user_id;	
		public string name;
		public int avatar_type;
		public int gender;
		public int country;
		public int rank;
		public string rank_title;
	}

	[System.Serializable]
	public class UserDetails
	{
		public int user_id;
		public string name;
		public string email_id;
		public string facebook_id;
		public int country;
		public int gender;
		public int avatar_type;
		public int age;
		public string google_id;
		public List<int> category_preference;
		public List<Score_Statistics> score_statistics;
		public int total_win;
		public int total_lost;
		public int total_draw;
		public List<UserBadges> user_badge;
	}

	[System.Serializable]
	public class Score_Statistics
	{
		public int category_id;
		public string category_title;
		public List<Score> score;
	}

	[System.Serializable]
	public class UserBadges
	{
		public int badge_id;
		public string title;
		public string image;
		public int notified_to_user;
		public string description;
	}

	[System.Serializable]
	public class Score
	{
		public int score;
		public int type;
	}

	[System.Serializable]
	public class FollowSearchUserInfo
	{
		public int user_id;
		public string name;
		public string email_id;
		public string facebook_id;
		public int country;
		public int gender;
		public int avatar_type;
		public int age;
		public int total_win;
		public int total_lost;
		public int total_draw;
	}

    [System.Serializable]
    public class OpponentDetails
    {
        public OpponentInfo user_info;
    }

    [System.Serializable]
    public class OpponentInfo
    {
        public int user_id;
        public string name;
        public string email_id;
		public string facebook_id;
        public int country;
        public int gender;
        public int avatar_type;
        public int age;
		public string google_id;
    }

    [System.Serializable]
	public class LastStatus
	{
		public int last_status_id;
		public int status_count;
		public List<Status> status;
	}

	[System.Serializable]
	public class Status
	{
		public int status_id;
		public int user_quiz_id;
		public int user_id;
		public int type;
		public object data;
		public string created_at;
		public int status;
		//public StatusData data;
	}

	[System.Serializable]
	public class StatusData
	{
		public int count;
		public int question_id;
		public int answer_id;
		public int score;
		#if NEW_RESULT_LOGIC
		public int quizComplete;
		#endif
	}

	[System.Serializable]
	public class StatusDataChallenge
	{
		public int user_quiz_id;
		public int user_id;
		public string message;
	}

	[System.Serializable]
	public class FollowerDetails
	{
		public int user_id;
		public string name;
		public string facebook_id;
		public string google_id;
		public int avatar_type;
	}

	[System.Serializable]
	public class FollowingDetails
	{
		public int user_id;
		public string name;
		public string facebook_id;
		public string google_id;
		public int avatar_type;
	}

    [System.Serializable]
    public class Notification
    {
        public List<NotificationDetails> content = new List<NotificationDetails>();
        public int last_notification_id;
    }

    [System.Serializable]
    public class NotificationDetails
    {
        public int notification_id;
        public int notification_type;
        public NotificationData data;
		public string message;
		public int avatar_type;
    }

    [System.Serializable]
    public class NotificationData
    {
		public int user_id;
        public int quiz_type;
		public int user_quiz_id;
		public int category_id;
		public string category_title;

		// Badge
		public int user_badge_id;
		public int badge_id;
		public string title;
		public string image;
		public string description;
    }

	[System.Serializable]
	public class GetChallengeList
	{
		public int user_quiz_id;
		public int user_id;
		public int challenge_user_id;
		public int quiz_id;
		public int user_score;
		public int challenge_user_score;
	}

	[System.Serializable]
	public class UserRankDetails
	{
		public List<UserRanksInfo> rank_title;
	}

	[System.Serializable]
	public class UserRanksInfo
	{
		public int category_id;
		public string category_title;
		public string image;
		public int rank;
		public int country;
		public string score_title;
	}

	[System.Serializable]
	public class QuizResult
	{
		public QuizResultDetails user;
		public QuizResultDetails opponent;
		public string after_taste;
	}

	[System.Serializable]
	public class QuizResultDetails
	{
		public int user_id;
		public string name;
		public int avatar_type;
		public int gender;
		public int country;
		public int rank;
		public string rank_title;
		public int score;
	}

	[System.Serializable]
	public class FrequentlyPlayedPlayerInfo
	{
		public int user_id;
		public string name;
		public string facebook_id;
		public string google_id;
		public int avatar_type;
	}
}