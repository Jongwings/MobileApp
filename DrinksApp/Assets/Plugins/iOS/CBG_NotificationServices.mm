#import <UIKit/UIKit.h>

extern "C" {
    void CBG_RegisterForRemoteNotifications(int types) {
        UIUserNotificationSettings *settings = [UIUserNotificationSettings settingsForTypes:types categories:Nil];
        [[UIApplication sharedApplication] registerUserNotificationSettings:settings];
        
        [[UIApplication sharedApplication] registerForRemoteNotifications];
    }
}