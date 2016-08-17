using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Example
    {
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        public Result Get()
        {
            return new Result() { Name = "name", No = "no1" };
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Result Post()
        {
            return new Result() { Name = "name", No = "no1" };
        }

        [OperationContract]
        [WebInvoke(Method = "*", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Result All()
        {
            return new Result() { Name = "name", No = "no1" };
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Parm?name={name}&no={no}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Result Parm(string name,string no)
        {
            return new Result() { Name = name, No = no };
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "RestFul/{name}/no", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Result RestFul(string name, string no)
        {
            return new Result() { Name = name, No = no };
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "RestFul/{name}/no", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Result CrossDomain (string name, string no)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            return new Result() { Name = name, No = no };
        }

        [OperationContract]
        public Result Xml()
        {
            return new Result() { Name = "name", No = "no1" };
        }
    }

    public class Result
    {
        public string Name { get; set; }
        public string No { get; set; }
    }
}
