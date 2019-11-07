using System;
using System.Reflection;
using System.Runtime.Loader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Infrastructure.Utils
{
    public class Common
    {
        private static readonly Common comm;

        private Common() { }

        public static Common Instance => comm ?? new Common();

        /// <summary>
        /// 获取指定程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns></returns>
        public Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }

        /// <summary>
        /// 产生图片验证码
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public byte[] Builder(string code)
        {
            Bitmap image = new Bitmap(70, 22);
            Graphics gdi = Graphics.FromImage(image);
            try
            {
                //生成随机生成器  
                Random random = new Random();
                //清空图片背景色  
                gdi.Clear(Color.White);
                // 画图片的背景噪音线  
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    gdi.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new Font("Arial", 12, (FontStyle.Bold));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, true);
                gdi.DrawString(code, font, brush, 2, 2);
                //画图片的前景噪音点  
                gdi.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
            finally
            {
                gdi.Dispose();
                image.Dispose();
            }
        }

        /// <summary>  
        /// 产生随机字符串  
        /// </summary>  
        /// <param name="num">随机出几个字符</param>  
        /// <returns>随机出的字符串</returns>  
        public string GenCode(int num)
        {
            string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] chastr = str.ToCharArray();
            string code = string.Empty;
            Random rd = new Random();
            for (int i = 0; i < num; i++)
            {
                code += str.Substring(rd.Next(0, str.Length), 1);
            }
            return code;
        }
    }
}
