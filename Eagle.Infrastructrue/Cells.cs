namespace Eagle.ViewModel
{
    public class Cells
    {
        /// <summary>
        /// 初始化 <see cref="T:System.Object"/> 类的新实例。
        /// </summary>
        public Cells(bool flag, string message, int code)
        {
            Flag = flag;
            Message = message;
            Code = code;
        }

        public bool Flag { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }

        public string Body { get; set; }
    }
}