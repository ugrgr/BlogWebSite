using System.Text.Json.Serialization;

namespace BlogWebSite.Core
{
    public class CustomResponse<T>
    {

        public T Data { get; set; }

        public List<String> Errors { get; set; }

        [JsonIgnore]
        public int Status { get; set; }


        //Static Factory Method

        public static CustomResponse<T> Success(T Data, int status)
        {

            return new CustomResponse<T>() { Data = Data, Status = status };
        }


        public static CustomResponse<T> Fail(List<string> errors, int status)
        {
            return new CustomResponse<T>() { Errors = errors, Status = status };
        }

        public static CustomResponse<T> Fail(List<string> errors)
        {
            return new CustomResponse<T>() { Errors = errors };
        }

        public static CustomResponse<T> Fail(string error, int status)
        {
            return new CustomResponse<T>() { Errors = new List<string> { error }, Status = status };
        }


    }
}
