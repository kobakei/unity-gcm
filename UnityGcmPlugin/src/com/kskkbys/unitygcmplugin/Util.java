package com.kskkbys.unitygcmplugin;

import android.text.TextUtils;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;

public class Util {
	
	// GameObject name of the receiver object
	private static final String RECEIVER_NAME = "GCMReceiver";
	
	/**
	 * Send message to GameObject of Unity
	 * @param method
	 * @param message
	 */
	public static void sendMessage(final String method, final String message) {
		if (TextUtils.isEmpty(message)) {
			UnityPlayer.UnitySendMessage(RECEIVER_NAME, method, "");
		} else {
			UnityPlayer.UnitySendMessage(RECEIVER_NAME, method, message);
		}
	}
	
	/**
	 * Show toast message (for debugging)
	 * @param message
	 */
	public static void showToast(final String message) {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				Toast.makeText(UnityPlayer.currentActivity, message, Toast.LENGTH_SHORT).show();
			}
		});
	}

}
