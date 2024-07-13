using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

[Preserve]//特性，防止在打包的时候这个脚本 没有被打包进程序
public class SkipUnityLogo
{
    //在启动画面显示之前执行这个方法
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void Run()
    {
        Task.Run(() =>
        {
            SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
        });
    }
}
