﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool isSuccess,string message,int page=0):base(isSuccess,message)
        {
            Data = data;
            TotalPage = page;
        }
        public DataResult(T data,bool isSuccess,int page=0):base(isSuccess)
        {
            Data = data;
            TotalPage = page;
        }
        public T Data { get; }

        public int TotalPage { get; }
    }
}
