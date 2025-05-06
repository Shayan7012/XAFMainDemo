using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Utils;
using MySolution.Module.BusinessObjects;
using System;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Editors;
using System.Collections;

namespace MySolution.Module.Controllers
{
    public partial class TaskActionsController : ViewController
    {
        private ChoiceActionItem setPriorityItem;
        private ChoiceActionItem setStatusItem;
        public TaskActionsController()
        {
            InitializeComponent();
            SetTaskAction.Items.Clear();
            setPriorityItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Priority"), null);
            SetTaskAction.Items.Add(setPriorityItem);
            FillItemWithEnumValues(setPriorityItem, typeof(Priority));
            setStatusItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Status"), null);
            SetTaskAction.Items.Add(setStatusItem);
            FillItemWithEnumValues(setStatusItem, typeof(TaskStatus));
        }
        private void FillItemWithEnumValues(ChoiceActionItem parentItem, Type enumType)
        {
            foreach (object current in Enum.GetValues(enumType))
            {
                EnumDescriptor ed = new EnumDescriptor(enumType);
                ChoiceActionItem item = new ChoiceActionItem(ed.GetCaption(current), current);
                item.ImageName = ImageLoader.Instance.GetEnumValueImageName(current);
                parentItem.Items.Add(item);
            }
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
        private void SetTaskAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = View is ListView ? Application.CreateObjectSpace(typeof(DemoTask)) : View.ObjectSpace;
            ArrayList objectsToProcess = new ArrayList(e.SelectedObjects);
            if (e.SelectedChoiceActionItem.ParentItem == setPriorityItem) foreach (Object obj in objectsToProcess)
            {
                DemoTask objInNewObjectSpace = (DemoTask)objectSpace.GetObject(obj);
                objInNewObjectSpace.Priority = (Priority)e.SelectedChoiceActionItem.Data;
            }
            else if (e.SelectedChoiceActionItem.ParentItem == setStatusItem) foreach (Object obj in objectsToProcess)
            {
                DemoTask objInNewObjectSpace = (DemoTask)objectSpace.GetObject(obj);
                objInNewObjectSpace.Status = (TaskStatus)e.SelectedChoiceActionItem.Data;
            }
            if (View is DetailView && ((DetailView)View).ViewEditMode == ViewEditMode.View) objectSpace.CommitChanges();
            if (View is ListView)
            {
                objectSpace.CommitChanges();
                View.ObjectSpace.Refresh();
            }
        }
    }
}