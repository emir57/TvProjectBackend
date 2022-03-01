using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message,int totalPage = 0):base(data,true,message, totalPage)
        {

        }
        public SuccessDataResult(T data,int totalPage = 0):base(data,true, totalPage)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
