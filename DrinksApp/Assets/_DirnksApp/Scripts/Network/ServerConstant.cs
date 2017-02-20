using UnityEngine;
using System.Collections;

public class ServerConstant
{
	public static string EDITOR_DEVICEID = "abc123def456";
	//http://www.jongwings.com/chivita/app/login.php

	public static string APPURL = "ttp://www.jongwings.com/chivita/app/login.php?";
	#if CLIENT_BUILD
	public static string BASEURL = "https://www.sportsqwizz.com/SPORTS-QUIZ/API/rest.php?methodName=";
	#else
	public static string BASEURL = "http://juegostudio.in/SPORTS-QUIZ/TEST/rest.php?methodName=";
	#endif

	#if UNITY_ANDROID
	public static string APPLICATION_KEY_NO = "and-1";
	#elif UNITY_IOS || UNITY_IPHONE
	public static string APPLICATION_KEY_NO = "ios-1";
	#endif

	public static string APPLICATION_KEY = "applicationKey";
	public const string CONFIG_GET = "config.get";

	//SERVER METHODS
	public const string USER_LOGIN = "user.login";
	public const string USER_REGISTER = "user.register";
	public const string USER_GET = "user.get";
	public const string USER_UPDATE = "user.update";
	public const string GET_QUESTION = "question.get";
	public const string GET_CATEGORY = "category.get";
	public const string GET_SPONSERED_CATEGORY = "sponseredQuiz.get";
	public const string GET_RANDOM_TOPICS = "topic.getRandom";
	public const string SAVE_ANSWER = "answer.save";
	public const string USER_EMAIL_SIGNUP = "email_id";
	public const string USER_PASSWORD = "password";
    public const string GET_LEISURE = "quiz.getLeisure";
    public const string GET_DUEL = "quiz.getDuel";
    public const string GET_IMFLUCKY = "quiz.getRandom";
    public const string GET_CHALLENGE = "quiz.getChallenge";
	public const string GET_STATUS = "status.get";
	public const string UPDATE_STATUS = "status.update";
	public const string GET_FOLLOWER_LIST = "follow.getFollowersList";
	public const string GET_FOLLOWING_LIST = "follow.getFollowingList";
	public const string SEARCH_FOLLOW = "follow.search";
	public const string FOLLOW_USER = "follow.user";
	public const string USER_CATEGORY_PREFERENCE = "user.categoryPreference";
	public const string GET_NOTIFICATION = "notification.get";
	public const string CLEAR_NOTIFICATION = "notification.clear";
	public const string GET_CHALLENGE_LIST = "challenge.getList";
	public const string CHALLENGE_REJECT = "challenge.reject";
	public const string CHALLENGE_CANCEL = "challenge.cancel";
	public const string USER_RANK_TITLE = "user.rankTitle";
	public const string OPPONENT_RESULT = "quiz.getOpponentResult";
	public const string USER_FREQUENT_PLAYER = "user.frequentPlayer";
	public const string QUIZ_RESULT = "quiz.getResult";
	public const string UNFOLLOW_USER = "follow.unfollowUser";
	public const string PASSWORD_RESET = "user.passwordReset";
	public const string SAVE_BADGE = "badge.save";
	public const string FEEDBACK_SAVE = "feedback.save";


    //LOGIN
    public const string LOGIN_TYPE = "type";
	public const string LOGIN_NAME = "name";
	public const string FACEBOOK_TOKEN = "facebook_access_token";
	public const string DEVICE_ID = "device_id";
	public const string GOOGLE_ID = "google_id";
	public const string iOS_PUSH_Notification = "ios_push_token";
	public const string ANDROID_PUSH_Notification = "android_push_token";
	public const string USER_EMAIL_LOGIN = "emailId";

	//INPUT PARAMETER AND RESPONSE KEY
	public const string RESPONSE_CODE = "responseCode";
	public const string RESPONSE_MSG = "responseMsg";
	public const string RESPONSE_INFO = "responseInfo";
	public const string USER_ID = "user_id";
	public const string USER_ID_CATEGORY = "userId";
	public const string ACCESS_TOKEN = "access_token";
	public const string ACCESS_TOKEN_QUESTION = "accessToken";
	public const string PARENT_CATEGORY_ID = "parent_category_id";
	public const string CATEGORY_ID = "category_id";
	public const string OTHER_USER_ID = "other_user_id";
	public const string PREVIOUS_USER_ID = "previous_user_quiz_id";
	public const string OTHER_USER_TYPE = "other_user_type";
	public const string EXCLUDE_QUIZ_ID = "exclude_quiz_id";
	public const string USER_QUIZ_ID = "user_quiz_id";
	public const string ANSWER	= "answer";
	public const string SUBMIT_SCORE	= "score";
	public const string RANDOM_TOPICS_LIMIT = "limit";
	public const string LAST_STATUS_ID = "last_status_id";
	public const string UPDATE_TYPE = "type";
	public const string FOLLOW_USER_ID = "follow_user_id";
	public const string LAST_NOTIFICATION = "last_notification_id";
    public const string NOTIFICATION_ID = "notification_id";
    public const string NOTIFICATION_LIMIT = "limit";
	public const string OPPONENT_ID = "user_detail_id";
    public const string STATUS_DATA = "data";
	public const string UNFOLLOW_USER_ID = "unfollow_user_id";
	public const string BADGE_ID = "badge_id";
	public const string BADGE_NOTIFIED_USER = "notified_to_user";
	public const string FEEDBACK_MESSAGE = "message";

    //SERVER ERROR MESSAGE
	public const int WORKING_FINE = 1;
    public const int EMAIL_DOESNT_EXIT = 230;
	public const int IN_CORRECT_PASSWORD = 231;
	public const int ALL_USER_OFFLINE = 234;
	public const int ALREADY_ANSWERED = 235;
	public const int USER_DONOT_EXISTS = 236;
	public const int USER_ALREADY_REGISTERED = 229;
	//230
	//emailId  does not exists in database

	//User Info
	public const string USER_COUNTRY = "country";  
	public const string USER_GENDER = "gender";
	public const string USER_AVATAR_TYPE = "avatar_type";
	public const string USER_AGE = "age";
}
