using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonDataWEB.Models
{
    public class ActionResponse<TResult> : ActionResponse
    {
        public ActionResponse() { }
        public ActionResponse(ActionResponse response) : this()
        {
            Messages = response.Messages;
            ActionSucceeded = response.ActionSucceeded;
        }
        public ActionResponse(ActionResponse response, TResult result) : this(response) { Result = result; }
        public ActionResponse(bool actionSucceeded) : base(actionSucceeded) { }
        public ActionResponse(bool actionSucceeded, string message) : base(actionSucceeded, message) { }
        public ActionResponse(bool actionSucceeded, List<string> messages) : base(actionSucceeded, messages) { }
        public ActionResponse(TResult result, bool actionSucceeded) : base(actionSucceeded) { Result = result; }
        public ActionResponse(TResult result, bool actionSucceeded, string message) : base(actionSucceeded, message) { Result = result; }
        public ActionResponse(TResult result, bool actionSucceeded, List<string> messages) : base(actionSucceeded, messages) { Result = result; }
        public TResult Result { get; set; }
    }

    public class ActionResponse
    {
        public ActionResponse()
        {
            Messages = new List<string>();
        }
        public ActionResponse(bool actionSucceeded)
        {
            ActionSucceeded = actionSucceeded;
            Messages = new List<string>();
        }
        public ActionResponse(bool actionSucceeded, string message)
        {
            ActionSucceeded = actionSucceeded;
            Messages = new List<string> { message };
        }
        public ActionResponse(bool actionSucceeded, List<string> messages)
        {
            ActionSucceeded = actionSucceeded;
            Messages = messages;
        }
        public bool ActionSucceeded { get; set; }
        public List<string> Messages { get; set; }
    }
}