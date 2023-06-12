using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Localization;


namespace CustomControls
{
    public partial class GridControl : DevExpress.XtraGrid.GridControl
    {
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;

        protected override BaseView CreateDefaultView()
        {
            return CreateView("MyGridView");
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomControls.GridViewInfoRegistrator());
        }

        private void InitializeComponent()
        {
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)this.GridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            this.SuspendLayout();
            //
            //GridView1
            //
            this.GridView1.GridControl = this;
            this.GridView1.Name = "GridView1";
            //
            //MyGridControl
            //
            this.MainView = this.GridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.GridView1 });
            ((System.ComponentModel.ISupportInitialize)this.GridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            this.ResumeLayout(false);

        }
    }

    public partial class GridViewInfoRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {

        public override string ViewName
        {
            get
            {
                return "MyGridView";
            }
        }

        public override BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            return new CustomControls.GridView(grid as DevExpress.XtraGrid.GridControl);
        }
    }

    public partial class GridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        public GridView()
            : this(null)
        {

        }

        public GridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid)
        {
            PopupMenuShowing += GridPopupMenuShowing;
            this.OptionsMenu.EnableFooterMenu = false;
            this.OptionsNavigation.EnterMoveNextColumn = false;
            this.OptionsNavigation.UseTabKey = false;
            this.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.OptionsView.ShowGroupPanel = false;
        }

        protected override string ViewName
        {
            get { return "MyGridView"; }
        }

        protected new void GridPopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DXMenuItem miColumnChooser = GetItemByStringId(e.Menu, GridStringId.MenuColumnColumnCustomization);
                if (miColumnChooser != null)
                {
                    miColumnChooser.Visible = false;
                }

                DXMenuItem miRemoveColumn = GetItemByStringId(e.Menu, GridStringId.MenuColumnRemoveColumn);
                if (miRemoveColumn != null)
                {
                    miRemoveColumn.Visible = false;
                }

                DXMenuItem miShowColumn = GetItemByStringId(e.Menu, GridStringId.MenuColumnShowColumn);
                if (miShowColumn != null)
                {
                    miShowColumn.Visible = true;
                }
            }
            else if (e.MenuType == GridMenuType.Summary)
            {
                //MessageBox.Show("")
            }
        }

        private DXMenuItem GetItemByStringId(DXPopupMenu menu, GridStringId id)
        {
            foreach (DXMenuItem item in menu.Items)
            {
                if (item.Caption == GridLocalizer.Active.GetLocalizedString(id))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
