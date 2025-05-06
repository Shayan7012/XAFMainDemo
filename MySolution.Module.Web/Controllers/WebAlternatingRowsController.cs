using DevExpress.ExpressApp;
using System;
using System.Drawing;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace MySolution.Module.Web.Controllers
{
    public partial class WebAlternatingRowsController : ViewController
    {
        public WebAlternatingRowsController()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
        private void WebAlternatingRowsController_ViewControlsCreated(object sender, EventArgs e)
        {
            ASPxGridListEditor listEditor = ((ListView)View).Editor as ASPxGridListEditor;
            if (listEditor != null) listEditor.Grid.Styles.AlternatingRow.BackColor = Color.FromArgb(244, 244, 244);
        }
    }
}