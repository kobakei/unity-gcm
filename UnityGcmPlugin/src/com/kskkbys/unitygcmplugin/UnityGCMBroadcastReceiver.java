package com.kskkbys.unitygcmplugin;

import android.content.Context;

import com.google.android.gcm.GCMBroadcastReceiver;

/**
 * Overrides GCMBroadcastReceiver to fix the class name of GCMIntentService
 * @author Keisuke Kobayashi
 *
 */
public class UnityGCMBroadcastReceiver extends GCMBroadcastReceiver {

	private static final String SERVICE_NAME = "com.kskkbys.unitygcmplugin.UnityGCMIntentService";
	
	/**
	 * Get the fixed name of subclass of GCMBaseIntentService
	 */
	@Override
	protected String getGCMIntentServiceClassName(Context context) {
		return SERVICE_NAME;
	}
}
