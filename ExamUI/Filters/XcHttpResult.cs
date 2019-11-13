namespace ExamUI.Filters
{
    /// <summary>
    /// 自定义Action返回类
    /// </summary>
    public class XcHttpResult
    {
        //结果
        public bool result { get; set; }
        //信息
        public string message { get; set; }
        //跳转路径
        public string path { get; set; }
    }
}