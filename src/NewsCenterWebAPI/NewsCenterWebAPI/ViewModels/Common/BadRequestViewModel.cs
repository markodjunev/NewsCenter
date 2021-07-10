namespace NewsCenterWebAPI.ViewModels.Common
{
    using Microsoft.AspNetCore.Mvc;

    public class BadRequestViewModel : ProblemDetails
    {
        public string Message { get; set; }
    }
}
