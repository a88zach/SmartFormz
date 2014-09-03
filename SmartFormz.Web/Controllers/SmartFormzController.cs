using System.Web.Mvc;
using MediatR;

namespace SmartFormz.Web.Controllers
{
    public abstract class SmartFormzController : Controller
    {
        public IMediator Mediator { get; set; }
    }
}