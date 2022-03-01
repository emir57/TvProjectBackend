using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool isSuccess,string message,int totalPage = 0):base(isSuccess,message)
        {
            Data = data;
            TotalPage = totalPage;
        }
        public DataResult(T data,bool isSuccess,int totalPage=0):base(isSuccess)
        {
            Data = data;
            TotalPage = totalPage;
        }
        public T Data { get; }

        public int TotalPage { get; }
    }
}
