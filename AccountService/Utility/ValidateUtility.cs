using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Utility
{
    public class CheckValidCustomerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                    if (!string.IsNullOrEmpty(context.HttpContext.Request.Form["CustomerId"]))
                    {
                        context.Result = new NotFoundObjectResult("Invalid customer");
                    }
               
            }
            catch (Exception)
            {

                        context.Result = new NotFoundObjectResult("Invalid request");
            }
           
        }
    }
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
    public class ValidationError
    {
      
    }

    public class ValidationResultModel
    {

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = "Success";

        public int Code { get; set; } = 0;

        public bool Data { get; set; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            this.Data = false;
            this.IsSuccess = false;
            this.Code = 2;
            //  Response.ReturnMessage = modelState.Keys.Select(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)));
            //  Message = "Validation Failed";
            var Errors = modelState.Keys
                     .SelectMany(key => modelState[key].Errors)
                     .ToList();
            string message = "";
            foreach (var error in Errors)
            {
                message = message + error.ErrorMessage + ",";
            }
            this.Message = message;

        }
    }
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
