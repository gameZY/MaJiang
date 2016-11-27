using UnityEngine;

//检测网络状态类
public class NetworkReach
{
    public static NetworkReach self = new NetworkReach();

    //获取网络状态,0代表无网络,1代表流量,2代表wifi,3代表不明网络
    public int getNetState()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return 0;
        }
        else
        {
            //2G,3G,4G流量
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                return 1;
            }
            //wifi
            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}

