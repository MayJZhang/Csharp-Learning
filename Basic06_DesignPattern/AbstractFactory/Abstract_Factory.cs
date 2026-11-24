using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basic06_DesignPattern
{
    /*
     * 抽象工厂 设计模式
     * 一、抽象产品和具体产品：抽象产品是定义产品的接口或抽象类，具体产品实现抽象产品
     * 二、抽象工厂：可以理解为品牌家族划分的通用接口
     * 三、具体工厂：比如小米、华为，实现了抽象工厂。
     * 四、客户端只负责实例化具体工厂。通过具体工厂来生产具体产品。只依赖抽象工厂接口，不接触实体
     *      AbstractFactory factory = new XiaoMiFactory();
     *      Computer c = factory.makeComputer();
     *      MobilePhone m = factory.makeMobilePhone();
     *      c.setOperationSystem();
     *      m.setOperationSystem();
     */

    //1、抽象产品————通用相机抽象类
    public abstract class Camera
    {
        protected Camera(string id)
        {
            Id = id;
        }

        public abstract string BandName { get; }
        /// <summary>
        /// 相机Id号
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// 开启相机
        /// </summary>
        public abstract void OpenCamera();
        /// <summary>
        /// 关闭相机
        /// </summary>
        public abstract void CloseCamera();
        /// <summary>
        /// 采集图像
        /// </summary>
        public abstract void CaptureImg();
        /// <summary>
        /// 显示图像
        /// </summary>
        public virtual void ShowImg()
        {

            Console.WriteLine("显示图像");
        }

    }

    //2、具体产品类————实现抽象产品
    public class NikonCamera : Camera
    {
        public NikonCamera(string id) : base(id)
        {
        }

        public override string BandName => "尼康";

        public override void CaptureImg()
        {
            Console.WriteLine($"{BandName}相机正在采集图像");
        }

        public override void CloseCamera()
        {
            Console.WriteLine($"{BandName}相机已关闭");
        }

        public override void OpenCamera()
        {
            Console.WriteLine($"{BandName}相机已打开");
        }
        public override void ShowImg()
        {
            Console.WriteLine($"{BandName}相机编号{Id}");
        }
    }
    public class FujiFilmCamera : Camera
    {
        public FujiFilmCamera(string id) : base(id)
        {
        }

        public override string BandName => "富士";

        public override void CaptureImg()
        {
            Console.WriteLine($"{BandName}相机正在采集图像");
        }

        public override void CloseCamera()
        {
            Console.WriteLine($"{BandName}相机已关闭");
        }

        public override void OpenCamera()
        {
            Console.WriteLine($"{BandName}相机已打开");
        }
        public override void ShowImg()
        {
            Console.WriteLine($"{BandName}相机编号{Id}");
        }
    }

    //3、抽象相机工厂类————生产相机的工厂的通用类
    public interface ICameraFactory
    {
        /// <summary>
        /// 工厂生产相机的方法
        /// </summary>
        /// <returns>相机产品实体</returns>
        Camera MakeCamera();
    }
    //4、实体工厂类————实现了抽象工厂接口的实体工厂
    public class NikonFactory : ICameraFactory
    {
        static int Id = 0;
        public Camera MakeCamera()
        {
            return new NikonCamera(Id++.ToString());
        }
    }
    public class FujiFilmFactory : ICameraFactory
    {
        static int Id = 0;
        public Camera MakeCamera()
        {
            return new FujiFilmCamera(Id++.ToString());
        }
    }
    internal class Abstract_Factory
    {
        // 客户端调用，选择生产对应品牌
        protected ICameraFactory cameraFactory;
        public Abstract_Factory()
        {
            Console.WriteLine("请选择尼康或者富士品牌");
            string factory = Console.ReadLine();
            if (factory.Equals("尼康"))
            {
                cameraFactory = new NikonFactory();
            }
            else if (factory.Equals("富士"))
            {
                cameraFactory = new FujiFilmFactory();
            }
            else
            {
                Console.WriteLine("不支持的相机品牌");
                return;
            }
            Camera camera = cameraFactory.MakeCamera();
            Thread.Sleep(3000); // 模拟开机延迟
            camera.OpenCamera();
            Thread.Sleep(1000); // 模拟采集时间
            camera.CaptureImg();
            camera.ShowImg();
            camera.CloseCamera();
        }
    }
}
