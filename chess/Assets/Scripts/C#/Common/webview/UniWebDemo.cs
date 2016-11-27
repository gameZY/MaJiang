//
//	UniWebDemo.cs
//  Created by Wang Wei(@onevcat) on 2013-10-20.
//
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This is a demo script to show how to use UniWebView.
/// You can follow the step 1 to 10 and get started with the basic use of UniWebView.
/// </summary>
public class UniWebDemo : MonoBehaviour {

//Just let it compile on platforms beside of iOS and Android
    //If you are just targeting for iOS and Android, you can ignore this
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_EDITOR

    //1. First of all, we need a reference to hold an instance of UniWebView
	private UniWebView _webView;
	private string _errorMessage;

	void Start() {
        OpenWebView();
	}

	void Update() {

	}

    void OpenWebView()
    {
        _webView = GetComponent<UniWebView>();
        if (_webView == null)
        {
            _webView = gameObject.AddComponent<UniWebView>();
            _webView.OnReceivedMessage += OnReceivedMessage;
            _webView.OnLoadComplete += OnLoadComplete;
            _webView.OnWebViewShouldClose += OnWebViewShouldClose;
            _webView.OnEvalJavaScriptFinished += OnEvalJavaScriptFinished;
            _webView.InsetsForScreenOreitation += InsetsForScreenOreitation;
        }

        //3. You can set the insets of this webview by assigning an insets value simply
        //   like this:
        /*
                int bottomInset = (int)(UniWebViewHelper.screenHeight * 0.5f);
                _webView.insets = new UniWebViewEdgeInsets(5,5,bottomInset,5);
        */

        // Or you can also use the `InsetsForScreenOreitation` delegate to specify different
        // insets for portrait or landscape screen. If your webpage should resize on both portrait
        // and landscape, please use the delegate way. See the `InsetsForScreenOreitation` method
        // in this file for more.

        _webView.HideToolBar(true);

        // Now, set the url you want to load.
        _webView.url = "http://192.168.0.77:8082/lobby/manage/notifyWeb";

        // You can set the spinner visibility and text of the webview.
        // This line can change the text of spinner to "Wait..." (default is  "Loading...")
        _webView.SetSpinnerLabelText("Wait...");
        // This line will tell UniWebView to not show the spinner as well as the text when loading.
        _webView.SetShowSpinnerWhenLoading(true);

        //4.Now, you can load the webview and waiting for OnLoadComplete event now.
        _webView.Load();

        _errorMessage = null;

        //You can also load some HTML string instead from a url or local file.
        //When loading from the HTML string, the _webView.url will take no effect.
        //_webView.LoadHTMLString("<body>I am a html string</body>",null);

        //If you want the webview show immediately, instead of the OnLoadComplete event, call Show()
        //A blank webview will appear first, then load the web page content in it
        _webView.Show();
    }

    void GoBack()
    {
        _webView.GoBack();
    }

	//5. When the webView complete loading the url sucessfully, you can show it.
	//   You can also set the autoShowWhenLoadComplete of UniWebView to show it automatically when it loads finished.
	void OnLoadComplete(UniWebView webView, bool success, string errorMessage) {
		if (success) {
			webView.Show();
		} else {
			Debug.Log("Something wrong in webview loading: " + errorMessage);
			_errorMessage = errorMessage;
		}
	}

	//6. The webview can talk to Unity by a url with scheme of "uniwebview". See the webpage for more
	//   Every time a url with this scheme clicked, OnReceivedMessage of webview event get raised.
	void OnReceivedMessage(UniWebView webView, UniWebViewMessage message) {
        Debug.Log("Received a message from native");
		Debug.Log(message.rawMessage);
		//7. You can get the information out from the url path and query in the UniWebViewMessage
		//For example, a url of "uniwebview://move?direction=up&distance=1" in the web page will 
		//be parsed to a UniWebViewMessage object with:
		//				message.scheme => "uniwebview"
		//              message.path => "move"
		//              message.args["direction"] => "up"
		//              message.args["distance"] => "1"
		// "uniwebview" scheme is sending message to Unity by default.
		// If you want to use your customized url schemes and make them sending message to UniWebView,
		// use webView.AddUrlScheme("your_scheme") and webView.RemoveUrlScheme("your_scheme")
	    if (string.Equals(message.path, "close")) 
        {
			//8. When you done your work with the webview, 
			//you can hide it, destory it and do some clean work.
			webView.Hide();
			Destroy(webView);
			webView.OnReceivedMessage -= OnReceivedMessage;
			webView.OnLoadComplete -= OnLoadComplete;
			webView.OnWebViewShouldClose -= OnWebViewShouldClose;
			webView.OnEvalJavaScriptFinished -= OnEvalJavaScriptFinished;
			webView.InsetsForScreenOreitation -= InsetsForScreenOreitation;
			_webView = null;
		}
	}

	//In this demo, we set the text to the return value from js.
	void OnEvalJavaScriptFinished(UniWebView webView, string result) {
		Debug.Log("js result: " + result);
	}

	//10. If the user close the webview by tap back button (Android) or toolbar Done button (iOS), 
	//    we should set your reference to null to release it. 
	//    Then we can return true here to tell the webview to dismiss.
	bool OnWebViewShouldClose(UniWebView webView) {
		if (webView == _webView) {
			_webView = null;
			return true;
		}
		return false;
	}

	// This method will be called when the screen orientation changed. Here we returned UniWebViewEdgeInsets(5,5,bottomInset,5)
	// for both situation. Although they seem to be the same, screenHeight was changed, leading a difference between the result.
	// eg. on iPhone 5, bottomInset is 284 (568 * 0.5) in portrait mode while it is 160 (320 * 0.5) in landscape.
	UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation) {
		int bottomInset = (int)(UniWebViewHelper.screenHeight * 0.5f);

		if (orientation == UniWebViewOrientation.Portrait) {
			return new UniWebViewEdgeInsets(5,5,bottomInset,5);
		} else {
			return new UniWebViewEdgeInsets(5,5,bottomInset,5);
		}
    }
#else //End of #if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
	void Start() {
		Debug.LogWarning("UniWebView only works on iOS/Android/WP8. Please switch to these platforms in Build Settings.");
	}
#endif
}
