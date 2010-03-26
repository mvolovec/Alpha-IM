using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace MyService1
{
    public class urlService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                case "plus":
                    {
                        int a, b;
                        if (int.TryParse(context.Request["a"], out a) && int.TryParse(context.Request["b"], out b))
                        {
                            context.Response.Write("Vysledek= " + (a + b));
                        }
                        else
                        {
                            context.Response.Write("Spatna syntaxe pozadavku.");
                        }
                    } break;
                case "minus":
                    {
                        int a, b;
                        if (int.TryParse(context.Request["a"], out a) && int.TryParse(context.Request["b"], out b))
                        {
                            context.Response.Write("Vysledek= " + (a - b));
                        }
                        else
                        {
                            context.Response.Write("Spatna syntaxe pozadavku.");
                        }
                    } break;
                case "nasobit":
                    {
                        int a, b;
                        if (int.TryParse(context.Request["a"], out a) && int.TryParse(context.Request["b"], out b))
                        {
                            context.Response.Write("Vysledek= " + (a * b));
                        }
                        else
                        {
                            context.Response.Write("Spatna syntaxe pozadavku.");
                        }
                    } break;
                default:
                    {
                        context.Response.Write("Nebyl zadan zadny pozadavek, nebo je zadani chybne.");
                    }
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

