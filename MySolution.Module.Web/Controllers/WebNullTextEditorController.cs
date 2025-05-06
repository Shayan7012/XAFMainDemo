using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using System;
using DevExpress.Web;
using DevExpress.ExpressApp.Web.Editors;

namespace MySolution.Module.Web.Controllers
{
    public partial class WebNullTextEditorController : ViewController
    {
        public WebNullTextEditorController()
        {
            InitializeComponent();
            RegisterActions(components);
        }
        private void InitNullText(WebPropertyEditor propertyEditor)
        {
            if (propertyEditor.ViewEditMode == ViewEditMode.Edit) ((ASPxDateEdit)propertyEditor.Editor).NullText = CaptionHelper.NullValueText;
        }
        private void propertyEditor_ControlCreated(object sender, EventArgs e)
        {
            InitNullText((WebPropertyEditor)sender);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            WebPropertyEditor propertyEditor = ((DetailView)View).FindItem("Anniversary") as WebPropertyEditor;
            if (propertyEditor != null)
            {
                if (propertyEditor.Control != null) InitNullText(propertyEditor);
                else propertyEditor.ControlCreated += new EventHandler<EventArgs>(propertyEditor_ControlCreated);
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ViewItem propertyEditor = ((DetailView)View).FindItem("Anniversary");
            if (propertyEditor != null) propertyEditor.ControlCreated -= new EventHandler<EventArgs>(propertyEditor_ControlCreated);
        }
    }
}