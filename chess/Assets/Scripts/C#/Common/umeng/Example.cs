using UnityEngine;
using Umeng;


public class Example : MonoBehaviour {



	void Start () {

				//请到 http://www.umeng.com/analytics 获取app key
				GA.StartWithAppKeyAndChannelId ("app key" , "App Store");

				//调试时开启日志 发布时设置为false
				GA.SetLogEnabled (true);
		

				
		}


	void OnGUI() {


        if (GUI.Button(new Rect(150, 100, 500, 100), "StartLevel"))
        {
        	//触发统计事件 开始关卡
			GA.StartLevel ("your level name");


        }

        if (GUI.Button(new Rect(150, 300, 500, 100), "FinishLevel"))
        {
        	//结束关卡
			GA.FinishLevel ("your level name");


        }

    }





}


