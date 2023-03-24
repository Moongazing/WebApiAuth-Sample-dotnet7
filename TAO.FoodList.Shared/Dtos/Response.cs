using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TAO.FoodList.Shared.Dtos
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public ErrorDto Error { get; set; }
        public static Response<T> Success(T data, int statusCode )
        {
            return new Response<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T>
            {
                Data = default,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }
        public static Response<T> Fail(int statusCode, ErrorDto errorDto)
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                Error = errorDto,
                IsSuccessful = false

            };
        }
        public static Response<T> Fail(int statusCode, string errorMessage, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
