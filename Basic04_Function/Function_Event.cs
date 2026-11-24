using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic04_Function
{
    class Downloader
    {
        //为什么有了委托还要有事件
        /*
         * 假设你写了一个下载器类 Downloader，下载完后你需要通知外部（比如让 UI 弹窗）。你用委托实现了：
         */
        #region 为什么要有事件
        public Action OnFinished; // 这是一个委托字段

        public void Start()
        {
            // 模拟下载...
            OnFinished?.Invoke(); // 下载完成后通知
        }
        #endregion
    }
    internal class Function_Event
    {
        public Function_Event()
        {
            //外部调用委托
            Downloader downloader = new Downloader();
            downloader.OnFinished = () => Console.WriteLine("下载完成");
            downloader.Start();
            /*
             * 》》乍一看没问题，但是如果
             *      downloader.OnFinished = null; （原来的委托订阅全废了，被清空了）
             * 》》再其次，因为这个Action是public，外部可以直接触发不需要 Strat()
             *      downloader.OnFinished(); （明明还没下载完，外部居然可以强制触发，破坏了类的封装）
             * 》》再比如，外部重新写了新方法
             *      downloader.OnFinished = 新方法;  （之前订阅的方法被覆盖了）
             */

            // 外部调用事件
            Downloader_Event downloaderEvent = new Downloader_Event();
            downloaderEvent.ProgressChanged += (sender, e) =>   //订阅事件，事件触发后回调此函数
            {
                Console.WriteLine($"事件发布者（发布对象）：{sender.ToString()}");
                Console.WriteLine($"接收到文件 {e.FileName} 的进度：{e.Progress}%");
            };
            downloaderEvent.OnDownloadFinshed();    // 触发下载结束，内部触发事件，回调上面的函数
            /*
             * 外部只能通过 += 和 -+ 来订阅或取消订阅
             * 外部不能通过 = 直接赋值，防止被清空或者覆盖
             * 外部也不能直接 Invok()调用 （防止强行触发）
             * 》》这就是 发布——订阅 模式，Downloader_Event是发布者，外部代码是订阅者
             */
        }

    }
    //  event 关键字：给委托加把锁
    class DownloaderEvent
    {
        // 加上 event 关键字，本质上就是被限制了的委托
        public event Action OnFinished;
        public void Start()
        {
            // 模拟下载...
            OnFinished?.Invoke(); // 只有类内部（发布者）才能触发 Invoke
        }
    }

    #region 事件的标准写法
    /*
     * 触发事件名用动词，通常是 On... 或 ...ing。
     * 发布者参数用 object sender（谁触发的事件）。
     * 传递的数据必须继承自 EventArgs 类。
     */
    // 1. 定义包含事件数据的类
    public class DownloadEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public int Progress { get; set; }
    }

    class Downloader_Event
    {
        // 2. 定义事件（使用标准的 EventHandler 泛型委托）
        public event EventHandler<DownloadEventArgs> ProgressChanged;

        public void OnDownloadFinshed()
        {
            // 3. 触发事件，传入 this（发布者）和数据
            ProgressChanged?.Invoke(this, new DownloadEventArgs { FileName = "a.mp4", Progress = 50 });
        }
    }
    #endregion
}
