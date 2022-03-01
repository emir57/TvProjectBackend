using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,string message, int totalPage = 0) :base(data,false,message, totalPage)
        {

        }
        public ErrorDataResult(T data,int totalPage = 0):base(data,false, totalPage)
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
