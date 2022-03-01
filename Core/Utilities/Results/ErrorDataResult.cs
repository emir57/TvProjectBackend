﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,string message, int page=0) :base(data,false,message,page)
        {

        }
        public ErrorDataResult(T data,int page=0):base(data,false,page)
        {

        }
        public ErrorDataResult(string message):base(default,false,message)
        {

        }
        public ErrorDataResult():base(default,false)
        {

        }
    }
}
