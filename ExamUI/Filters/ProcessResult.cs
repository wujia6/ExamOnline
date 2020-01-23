namespace ExamUI.Filters
{
    /// <summary>
    /// 自定义Action返回类
    /// </summary>
    public class ProcessResult
    {
        //结果
        public bool Success { get; set; }
        //信息
        public string Message { get; set; }
        //跳转路径
        public string Path { get; set; }
    }
}