﻿using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.ConditionalAppearance;
using System;

namespace MySolution.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    [Appearance("FontColorRed", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView", Criteria = "Status!='Completed'", FontColor = "Red")]
    public class DemoTask : Task
    {
        public DemoTask(Session session) : base(session) { }
        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts
        {
            get { return GetCollection<Contact>("Contacts"); }
        }
        private Priority priority;
        [Appearance("PriorityBackColorPink", AppearanceItemType = "ViewItem", Context = "Any", Criteria = "Priority=2", BackColor = "255, 240, 240")]
        public Priority Priority
        {
            get { return priority; }
            set { SetPropertyValue("Priority", ref priority, value); }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }
        [Action(ToolTip = "Postpone the task to the next day")]
        public void Postpone()
        {
            if (DueDate == DateTime.MinValue) DueDate = DateTime.Now;
            DueDate = DueDate + TimeSpan.FromDays(1);
        }
    }
    public enum Priority
    {
        [ImageName("State_Priority_Low")]
        Low = 0,
        [ImageName("State_Priority_Normal")]
        Normal = 1,
        [ImageName("State_Priority_High")]
        High = 2
    }
}