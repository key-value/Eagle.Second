
using System;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Core.Model;

namespace Eagle.Server
{
    public class ApplicationServices : DisposableObject
    {
        /// <summary>
        /// 初始化 <see cref="T:System.Object"/> 类的新实例。
        /// </summary>
        protected ApplicationServices()
        {
            Flag = false;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public bool Flag { get; set; }

        protected int _pageCount;

        public int PageCount { get { return _pageCount; } set { _pageCount = value; } }

        public const int PageSize = 15;

        public virtual Cells GetResult()
        {
            return new Cells(Flag, Message, Code);
        }

        protected override void Dispose(bool disposing)
        {
        }

        public DateTime ReceiveTime { get; set; }

        public bool Async { get; set; }
    }
}