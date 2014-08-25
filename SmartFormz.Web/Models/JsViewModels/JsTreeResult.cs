namespace SmartFormz.Web.Models.JsViewModels
{
    public class JsTreeResult
    {
        public string id { get; set; }
        public string text { get; set; }
        public bool children { get; set; }
        public JsTreeState state { get; set; }
        public string type { get; set; }
        public JsTreeLiAttr li_attr { get; set; }
        public JsTreeAAttr a_attr { get; set; }

    }

    public class JsTreeState
    {

        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }

    public class JsTreeLiAttr
    {
        public string @class { get; set; }
    }

    public class JsTreeAAttr
    {
        public string @class { get; set; }
    }
}