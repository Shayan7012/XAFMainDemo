using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using MySolution.Module.BusinessObjects;

namespace MySolution.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ClearContactTasksController : ViewController
    {
        public ClearContactTasksController()
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

        private void ClearTasksAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            while (((Contact)View.CurrentObject).Tasks.Count > 0) ((Contact)View.CurrentObject).Tasks.Remove(((Contact)View.CurrentObject).Tasks[0]);
            ObjectSpace.SetModified(View.CurrentObject);
        }
    }
}
