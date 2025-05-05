using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.BaseImpl;
using MySolution.Module.BusinessObjects;
using System;

namespace MySolution.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PopupNotesController : ViewController
    {
        public PopupNotesController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ShowNotesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs args)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Note));
            args.View = Application.CreateListView(objectSpace, typeof(Note), true);
        }

        private void ShowNotesAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs args)
        {
            DemoTask task = (DemoTask)View.CurrentObject;
            foreach (Note note in args.PopupWindowViewSelectedObjects)
            {
                if (!string.IsNullOrEmpty(task.Description)) task.Description += Environment.NewLine;
                task.Description += note.Text;
            }
            if (((DetailView)View).ViewEditMode == ViewEditMode.View) View.ObjectSpace.CommitChanges();
        }
    }
}
