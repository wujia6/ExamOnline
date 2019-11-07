using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Infrastructure.Utils
{
    public class VerifyCode
    {
        private static readonly VerifyCode verifyCode;

        private VerifyCode() { }

        public static VerifyCode GetInstance => verifyCode ?? new VerifyCode();

        
    }
}
