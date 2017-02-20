using UnityEngine;
using System.Collections;

public class TagConstant
{
	public const string APP_NAME = "Sports Qwizz";

	public class ServerMessage
	{
		public const string CHALLENGE_ACCEPT = "Challenge Accept";
		public const string CHALLENGE_REJECT = "Challenge Reject";
	}

	public class AppStoreLink
	{
//		public const string APP_STORE_LINK_ANDROID = "market://details?id=YOUR_ID";
		public const string APP_STORE_LINK_ANDROID = "https://play.google.com/store/apps/details?id=com.sportswizz.sportsqwizz";
		public const string APP_STORE_LINK_iOS = "https://itunes.apple.com/us/app/sports-qwizz/id1141449749?ls=1&mt=8";
		public const string SPONSORED_QUIZ_LINK = "http://cricwizz.com";
	}

	public class SocialShare
	{
		public const string DISPLAY_TEXT = "SPORTS QWIZZ !";
		public const string DEEP_LINK_ID = "https://play.google.com/store/apps/details?id=com.sportswizz.sportsqwizz";
		public const string DEEP_LINK_TITLE = "Come on up and prove!";
		public const string DEEP_LINK_DESC = "Hey! Got the courage to take up some Sporty Qwizz?! Come on up and prove!!!";
		public const string DEEP_LINK_ICON = "https://fbcdn-photos-a-a.akamaihd.net/hphotos-ak-xft1/t39.2081-0/p128x128/13672019_1574840206150503_304294222_n.png";
	}

	public class PrefsName
	{
		public const string PLAYER_INFORMATION = "playerInfo";
		public const string LOGIN_PREFS = "logindetails";
		public const string LAST_NOTIFICATION = "lastnotificationnewimp";
		public const string iOS_DEVICE_TOKEN = "iOSDeviceToken";
		public const string ANDROID_DEVICE_TOKEN = "AndroidDeviceToken";
		public const string LOCAL_NOTIFICATION_MSG = "lastnotificationmessage";
		public const string LAST_iOS_NOTIFICATION = "lastiosnotification";
		public const string RATE_THE_APP	= "ratetheapps";
	}

	public class PopUpMessages
	{
		//"<color=red> DDDDDD </color>\n\n AAAAAAA";
		public const string Feeling_Lucy_Mode_Info = "<color=red>I'm Feeling Lucky!</color>\n\nPlay against a random quizzer to\na random quiz! Do you have the courage?";
		public const string Leisure_Mode_Info = "<color=red>Leisure</color>\n\nPlay solo, and set a high score.";
		public const string Duel_Mode_Info = "<color=red>Dual</color>\n\nInvite your friends to a challenge\nand see who's more awesome!";
		public const string Tournament_Mode_Info = "<color=red>Tournament!</color>\n\nPlay Tournament!";
		public const string Locked_Info = "! Locked !\n\nLog-In using your account\nto gain access.";
		public const string SURRENDER_INFO = "You will lose the match if\nyou forfeit. Continue?";

		public const string NO_INTERNET_CONNECTION = "Check your internet connection!!!";
		public const string FB_LOGIN_SUCCESS = "Facebook Login successful!";
		public const string GPLUS_LOGIN_SUCCESS = "G+ login successful!";
		public const string GUEST_LOGIN_SUCCESS = "Login As Guest User!";
		public const string EMAIL_SIGNUP_SUCCESS = "Email sign up successful!";
		public const string EMAIL_LOGIN_SUCCESS = "Email login successful!";
		public const string CHALLENGE_REJECTED = "Challenge Rejected!!!";
		public const string NO_RANDOM_OPPONENT = "Aw! Snap!\nOther players are not available now.\nTry playing solo in our LEISURE MODE";//"Oops! No opponent found!";//"Oops! No opponent found. Play our \"Leisure Mode\" and win exciting badges.";
		public const string LOOKING_FOR_OPPONENT = "Looking for an opponent";
		public const string REQUEST_SEND_OPPONENT = "Request sent to opponent";
		public const string REQUEST_REJECT_OPPONENT = "Request rejected by opponent";
		public const string LOOKING_NEW_OPPONENT = "Looking for new opponent";
		public const string FRIEND_IS_BUSY = "Hey! Looks like your friend is busy. Till the time, Play our \"Leisure Mode\" and win exciting badges.";
		public const string FRIEND_NOT_AVAILABLE = "Aw! Snap!\nYour friend is not available now.\nWould you like to try another ?";
		public const string PLEASE_RATE_APP = "Please rate the app.";

		public const string WAITING_RESULT = "Result awaiting...";
		public const string YOU_WIN = "<color=#FFC94AFF>You Win!</color>";
		public const string YOU_LOSE = "<color=#BB2423FF>You Lose!</color>";
		public const string MATCH_TIE = "<color=#FFC94AFF>Match Tied!</color>";

		public const string TRY_PANEL_INFO = "<color=red>Try is Limited!!!</color>\n\nProceed with Try to take\na demo of the game";
		public const string NO_QUIZZERS = "All sports persons at net practice at the moment!";
		public const string NO_FOLLOWERS = "Play more quizzes to have other quizzer follow you!";//"No followers yet!";
		public const string NO_FOLLOWING = "Search for quizzer to challenge in quizzes";//  "You are not following anybody yet!";

		//PANEL DESCRIPTION
		public const string INVITE_FRIEND_FOR_CHALLENGE = "Cool Now invite a\nfriend for challenge!";

		public const string NOBODY_FOLLOWING = "Play more quizzes to have other quizzer follow you!"; //"Nobody is Following You! ";
		public const string NO_FRIEND_LIST_FB = "No Friends In "+ TagConstant.APP_NAME +". \n Invite Friends to play.";
		public const string NO_FRIEND_LIST_GP = "No Friends In " + TagConstant.APP_NAME +". \n Invite Friends to play.";

		//VALIDATION
		public const string AGE_FIELD_EMPTY = "Age field cannot be empty.";
		public const string AGE_INVALID = "Invalid age\n Age should be 12 or greater than 12.";
		public const string USERNAME_FIELD_EMPTY = "Name field cannot be empty.";
		public const string INVALID_GENDER = "Please select your gender.";

		public const string SELECT_ANY_TOPIC = "Lucky Topic";//"Choose any topic";
		public const string SELECT_TOPIC = "Pick a topic";
		public const string SELECT_CATEGORY = "Pick a category";

		public const string FEEDBACK_HEADER = "FEEDBACK";
		public const string FEEDBACK_EMPTY = "You cannot send empty feedback.";
		public const string FEEDBACK_SEND = "Thanks for your valuable feedback";
		public const string FEEDBACK_NOT_SEND = "Feedback not send";

		public const string REPORT_HEADER = "REPORT A MISTAKE";
		public const string REPORT_EMPTY = "You cannot send empty feedback.";
		public const string REPORT_SEND = "Thanks for your valuable report";
		public const string REPORT_NOT_SEND = "Report not send";
	}

	public static class ColorHexCode
	{
		public const string AQUA	=	"#00FFFF";//	RGB(0, 255, 255)
		public const string BLACK	=	"#000000";//	RGB(0, 0, 0)
		public const string BLUE	=	"#0000FF";//	RGB(0, 0, 255)
		public const string FUCHSIA	=	"#FF00FF";//	RGB(255, 0, 255))
		public const string GRAY	=	"#808080";//	RGB(128, 128, 128)
		public const string GREEN	=	"#008000";//	RGB(0, 128, 0)
		public const string GOLD	=	"#FFD700";
		public const string LIME	=	"#00FF00";//	RGB(0, 255, 0)
		public const string MAROON	=	"#800000";//	RGB(128, 0, 0)
		public const string NAVY	=	"#000080";//	RGB(0, 0, 128)
		public const string OLIVE	=	"#808000";//	RGB(128, 128, 0)
		public const string PURPLE	=	"#800080";//	RGB(128, 0, 128))
		public const string RED		=	"#FF0000";//	RGB(255, 0, 0)
		public const string SILVER	=	"#C0C0C0";//	RGB(192, 192, 192)
		public const string TEAL	=	"#008080";//	RGB(0, 128, 128)
		public const string WHITE	=	"#FFFFFF";//	RGB(255, 255, 255)
		public const string YELLOW	=	"#FFC94AFF";//	RGB(255, 255, 0)
		public const string DARK_YELLOW_1 = "#FFCC00FF";
		public const string DARK_YELLOW = "#FFBD26FF";
		public const string RED_DARK = "#EA3320FF";
		public const string RED_SCORE =	"#AD3535FF";//	RGB(255, 255, 0)
		public const string LEISURE_MODE = "#0BA8A8FF";
		public const string LUCKY_MODE = "#A3B74EFF";
		public const string DUAL_MODE = "#ED5135FF";
		public const string BG_DEFAULT_COLOR = "#32BAADFF";
	}

	public class Audio
	{
		public const string AUDIO_PATH = "Audio";
	}
}
