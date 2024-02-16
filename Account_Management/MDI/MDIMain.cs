using Account_Management.Class;
using Account_Management.Search;
using BLL;
using BLL.FunctionClasses.Utility;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Account_Management.MDI
{
    public partial class MDIMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable DTForm = new DataTable();
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        UserAuthentication objUser = new UserAuthentication();
        Boolean ISMessageDisplay = true;
        string mStrPassword = string.Empty;
        FillCombo ObjFillCombo = new FillCombo();
        bool isManual = false;
        public static string FormTypeStr { get; set; }
        public MDIMain()
        {
            InitializeComponent();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = false;
            objBOFormEvents.FormClosing = false;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        public void ShowForm()
        {
            try
            {
                AttachFormEvents();
                //this.Text = "Kakdiya Diamond [ Since 1905 ]   ";
                this.Text = this.Text + " [ User : " + GlobalDec.gEmployeeProperty.user_name + " ]";
                this.Text = this.Text + " [ Version : " + Global.gStrVersion + " ]";
                try
                {
                    DTForm = objUser.Get_MENU_FormDetail(Val.ToInt(GlobalDec.gEmployeeProperty.role_id));
                    GeneratePage();
                }
                catch (Exception et) { MessageBox.Show(et.Message.ToString()); }
            }
            catch
            { }
        }
        void gallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            try
            {
                Int32 Res = objUser.SaveThemes(e.Item.Tag.ToString());

                if (Res != 0)
                {
                }
            }
            catch (Exception Ex)
            { MessageBox.Show(Ex.ToString()); }
        }
        private void GeneratePage()
        {
            try
            {
                //DataTable dtPage = DTForm.Select("1 = 1").CopyToDataTable().AsDataView().ToTable(true, "Menu_Head");

                if (DTForm.Select("form_group_name ='" + FormTypeStr + "'").Length > 0)
                {
                    DataTable dtPage = DTForm.Select("form_group_name ='" + FormTypeStr + "'").CopyToDataTable().AsDataView().ToTable(true, "Menu_Head");
                    DataTable dtMenuNames = dtPage.Clone();
                    var rows = from row in dtPage.AsEnumerable()
                                   //where row.Field<string>("main_menu") != null
                               where row.Field<string>("Menu_Head") != null
                               select row;
                    foreach (DataRow dr in rows)
                    {
                        dtMenuNames.ImportRow(dr);
                    }

                    RibbonPage[] ribbonPage2 = new RibbonPage[dtMenuNames.Rows.Count];
                    for (int i = 0; i < dtMenuNames.Rows.Count; i++)
                    {
                        ribbonPage2[i] = new RibbonPage();
                        //ribbonPage2[i].Text = Val.ToString(dtMenuNames.Rows[i]["main_menu"]);
                        ribbonPage2[i].Text = Val.ToString(dtMenuNames.Rows[i]["Menu_Head"]);
                        ribbonPage2[i].Name = "Pg" + (i + 1).ToString();
                        //GenerateGroup(ribbonPage2[i], Val.ToString(dtMenuNames.Rows[i]["main_menu"]));
                        GenerateGroup(ribbonPage2[i], Val.ToString(dtMenuNames.Rows[i]["Menu_Head"]));
                    }
                    ribbonControl1.Pages.AddRange(ribbonPage2);
                }
                else
                {
                    MessageBox.Show(FormTypeStr + " : Data Not Set..Please Contact to Administrator");
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private void GenerateGroup(RibbonPage pg_, string Menu_)
        {
            try
            {
                DataTable dtPage = new DataTable();
                //if (DTForm.Select("Menu_Head='" + Menu_ + "' ").Length > 0)
                //{
                if (DTForm.Select("form_group_name ='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' ").Length > 0)
                {
                    //dtPage = DTForm.Select("Menu_Head='" + Menu_ + "'").CopyToDataTable().AsDataView().ToTable(true, "sub_menu");
                    dtPage = DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "'").CopyToDataTable().AsDataView().ToTable(true, "sub_menu");
                    RibbonPageGroup[] pgrp = new RibbonPageGroup[dtPage.Rows.Count];
                    for (int j = 0; j < dtPage.Rows.Count; j++)
                    {
                        pgrp[j] = new RibbonPageGroup();
                        pgrp[j].Text = Val.ToString(dtPage.Rows[j]["sub_menu"]);
                        pgrp[j].Name = "Grp" + (j + 1).ToString();
                        pgrp[j].ShowCaptionButton = false;
                        GenerateBtn(pgrp[j], Menu_, Val.ToString(dtPage.Rows[j]["sub_menu"]));
                        GenerateCombo(pgrp[j], Menu_, Val.ToString(dtPage.Rows[j]["sub_menu"]));
                    }
                    pg_.Groups.AddRange(pgrp);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void GenerateBtn(RibbonPageGroup pgrp_, string Menu_, string SubMenu_)
        {
            try
            {
                DataTable dtPage = new DataTable();
                //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name IS NULL").Length > 0)
                //{
                if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name IS NULL").Length > 0)
                {
                    //dtPage = DTForm.Select("sub_menu='" + SubMenu_ + "' AND parent_btn_name IS NULL").CopyToDataTable();
                    dtPage = DTForm.Select("form_group_name='" + FormTypeStr + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name IS NULL").CopyToDataTable();
                    BarButtonItem[] barbtn = new BarButtonItem[dtPage.Rows.Count];
                    for (int t = 0; t < dtPage.Rows.Count; t++)
                    {
                        barbtn[t] = new BarButtonItem(ribbonControl1.Manager, Val.ToString(dtPage.Rows[t]["caption"]));
                        barbtn[t].Name = "Btn" + (t + 1).ToString();
                        barbtn[t].Caption = Val.ToString(dtPage.Rows[t]["caption"]);
                        barbtn[t].Tag = Val.ToString(dtPage.Rows[t]["form_name"]);
                        barbtn[t].Description = Val.ToString(dtPage.Rows[t]["form_id"]);
                        if (Val.ToString(dtPage.Rows[t]["icon"]) != "")
                        {
                            barbtn[t].RibbonStyle = RibbonItemStyles.All;
                            barbtn[t].LargeWidth = 75;
                            barbtn[t].ImageIndex = Val.ToInt(dtPage.Rows[t]["icon"]);
                            barbtn[t].LargeImageIndex = Val.ToInt(dtPage.Rows[t]["icon"]);
                        }
                        barbtn[t].ItemClick += new ItemClickEventHandler(MDIMain_ItemClick);
                    }
                    pgrp_.ItemLinks.AddRange(barbtn);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                return;
            }
        }

        private void GenerateCombo(RibbonPageGroup pgrp_, string Menu_, string SubMenu_)
        {
            try
            {
                DataTable dtPage = new DataTable();
                //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name IS NOT NULL").Length > 0)
                //{
                if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name IS NOT NULL").Length > 0)
                {
                    //dtPage = DTForm.Select("sub_menu='" + SubMenu_ + "' AND  parent_btn_name IS  NOT  NULL").CopyToDataTable().AsDataView().ToTable(true, "parent_btn_name");
                    dtPage = DTForm.Select("form_group_name='" + FormTypeStr + "' AND sub_menu='" + SubMenu_ + "' AND  parent_btn_name IS  NOT  NULL").CopyToDataTable().AsDataView().ToTable(true, "parent_btn_name");
                    BarSubItem[] barbtn = new BarSubItem[dtPage.Rows.Count];
                    for (int t = 0; t < dtPage.Rows.Count; t++)
                    {
                        DataTable dtBtns = new DataTable();
                        //if (DTForm.Select("Menu_Head='" + Menu_ + "'  AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'").Length > 0)
                        //{
                        //   dtBtns = DTForm.Select("Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'").CopyToDataTable();
                        //}
                        if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "'  AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'").Length > 0)
                        {
                            dtBtns = DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'").CopyToDataTable();
                        }

                        barbtn[t] = new BarSubItem(ribbonControl1.Manager, Val.ToString(dtPage.Rows[t]["parent_btn_name"]));
                        barbtn[t].Id = Ribbon.Manager.GetNewItemId();  // (t + 1);
                        barbtn[t].Name = "Combo" + (t + 1).ToString();
                        barbtn[t].Caption = Val.ToString(dtPage.Rows[t]["parent_btn_name"]);
                        barbtn[t].RibbonStyle = RibbonItemStyles.All;
                        barbtn[t].LargeWidth = 99;
                        if (Val.ToString(dtBtns.Rows[0]["icon"]) != "")
                        {
                            barbtn[t].ImageIndex = Val.ToInt(dtBtns.Rows[0]["icon"]);
                            barbtn[t].LargeImageIndex = Val.ToInt(dtBtns.Rows[0]["icon"]);
                        }
                        if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "' AND level1 IS NOT NULL").Length > 0)
                        {
                            GetLevel1(barbtn[t], Menu_, SubMenu_, Val.ToString(dtPage.Rows[t]["parent_btn_name"]));
                        }
                        //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "' AND level1 IS NOT NULL").Length > 0)
                        //{
                        //    GetLevel1(barbtn[t], Menu_, SubMenu_, Val.ToString(dtPage.Rows[t]["parent_btn_name"]));
                        //}
                        //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'  AND level1 IS NULL").Length > 0)
                        //{
                        if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'  AND level1 IS NULL").Length > 0)
                        {
                            dtBtns = new DataTable();
                            //dtBtns = DTForm.Select("Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'  AND level1 IS NULL").CopyToDataTable();
                            dtBtns = DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Val.ToString(dtPage.Rows[t]["parent_btn_name"]) + "'  AND level1 IS NULL").CopyToDataTable();
                            BarButtonItem[] Cmbbtn = new BarButtonItem[dtBtns.Rows.Count];
                            for (int z = 0; z < dtBtns.Rows.Count; z++)
                            {
                                Cmbbtn[z] = new BarButtonItem(ribbonControl1.Manager, Val.ToString(dtBtns.Rows[z]["caption"]));
                                Cmbbtn[z].Id = Ribbon.Manager.GetNewItemId(); //  (z + 1);
                                Cmbbtn[z].Name = "CBtn" + (z + 1).ToString();
                                Cmbbtn[z].Caption = Val.ToString(dtBtns.Rows[z]["caption"]);
                                Cmbbtn[z].Description = Val.ToString(dtBtns.Rows[z]["form_id"]);
                                Cmbbtn[z].Tag = Val.ToString(dtBtns.Rows[z]["form_name"]);
                                Cmbbtn[z].ItemClick += new ItemClickEventHandler(MDIMain_ItemClick);
                            }
                            barbtn[t].AddItems(Cmbbtn);
                        }
                    }
                    pgrp_.ItemLinks.AddRange(barbtn);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                return;
            }
        }

        void GetLevel1(BarSubItem barbtn_, string Menu_, string SubMenu_, string Parent_)
        {
            try
            {
                DataTable dtPage = new DataTable();
                //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL").Length > 0)
                //{
                if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL").Length > 0)
                {
                    //dtPage = DTForm.Select("sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL").CopyToDataTable().AsDataView().ToTable(true, "level1");
                    dtPage = DTForm.Select("form_group_name='" + FormTypeStr + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL").CopyToDataTable().AsDataView().ToTable(true, "level1");
                    BarSubItem[] barbtn = new BarSubItem[dtPage.Rows.Count];
                    for (int t = 0; t < dtPage.Rows.Count; t++)
                    {
                        DataTable dtBtns = new DataTable();
                        //dtBtns = DTForm.AsEnumerable().Where(m => m.Field<string>("sub_menu") == SubMenu_ && m.Field<string>("parent_btn_name") == Parent_ && m.Field<string>("level1") == Val.ToString(dtPage.Rows[t]["level1"])).CopyToDataTable();
                        dtBtns = DTForm.AsEnumerable().Where(m => m.Field<string>("form_group_name") == FormTypeStr && m.Field<string>("sub_menu") == SubMenu_ && m.Field<string>("parent_btn_name") == Parent_ && m.Field<string>("level1") == Val.ToString(dtPage.Rows[t]["level1"])).CopyToDataTable();

                        barbtn[t] = new BarSubItem(ribbonControl1.Manager, Val.ToString(dtPage.Rows[t]["level1"]));
                        barbtn[t].Id = Ribbon.Manager.GetNewItemId();  // (t + 1);
                        barbtn[t].Name = "L1Combo" + (t + 1).ToString();
                        barbtn[t].Caption = Val.ToString(dtPage.Rows[t]["level1"]);
                        barbtn[t].RibbonStyle = RibbonItemStyles.All;
                        barbtn[t].LargeWidth = 99;
                        if (Val.ToString(dtBtns.Rows[0]["icon"]) != "")
                        {
                            barbtn[t].ImageIndex = Val.ToInt(dtBtns.Rows[0]["icon"]);
                            barbtn[t].LargeImageIndex = Val.ToInt(dtBtns.Rows[0]["icon"]);
                        }
                        //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL AND level2 IS NOT NULL").Length > 0)
                        //{
                        //    GetLevel2(barbtn[t], Menu_, SubMenu_, Parent_, Val.ToString(dtPage.Rows[t]["level1"]));
                        //}
                        if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL AND level2 IS NOT NULL").Length > 0)
                        {
                            GetLevel2(barbtn[t], Menu_, SubMenu_, Parent_, Val.ToString(dtPage.Rows[t]["level1"]));
                        }

                        //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL AND level2 IS NULL").Length > 0)
                        //{
                        if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "' AND level1 IS NOT NULL AND level2 IS NULL").Length > 0)
                        {
                            dtBtns = new DataTable();
                            //dtBtns = DTForm.AsEnumerable().Where(m => m.Field<string>("sub_menu") == SubMenu_ && m.Field<string>("parent_btn_name") == Parent_ && m.Field<string>("level1") == Val.ToString(dtPage.Rows[t]["level1"]) && m.Field<string>("level2") == null).CopyToDataTable();
                            dtBtns = DTForm.AsEnumerable().Where(m => m.Field<string>("form_group_name") == FormTypeStr && m.Field<string>("sub_menu") == SubMenu_ && m.Field<string>("parent_btn_name") == Parent_ && m.Field<string>("level1") == Val.ToString(dtPage.Rows[t]["level1"]) && m.Field<string>("level2") == null).CopyToDataTable();
                            BarButtonItem[] Cmbbtn = new BarButtonItem[dtBtns.Rows.Count];
                            for (int z = 0; z < dtBtns.Rows.Count; z++)
                            {
                                Cmbbtn[z] = new BarButtonItem(ribbonControl1.Manager, Val.ToString(dtBtns.Rows[z]["caption"]));
                                Cmbbtn[z].Id = Ribbon.Manager.GetNewItemId();
                                Cmbbtn[z].Name = "CBtn" + (z + 1).ToString();
                                Cmbbtn[z].Caption = Val.ToString(dtBtns.Rows[z]["caption"]);
                                Cmbbtn[z].Description = Val.ToString(dtBtns.Rows[z]["form_id"]);
                                Cmbbtn[z].Tag = Val.ToString(dtBtns.Rows[z]["form_name"]);
                                Cmbbtn[z].ItemClick += new ItemClickEventHandler(MDIMain_ItemClick);
                            }
                            barbtn[t].AddItems(Cmbbtn);
                        }
                    }
                    barbtn_.AddItems(barbtn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        void GetLevel2(BarSubItem barbtn_, string Menu_, string SubMenu_, string Parent_, string Level1_)
        {
            try
            {
                DataTable dtPage = new DataTable();
                //if (DTForm.Select("Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "'  AND  level1='" + Level1_ + "' AND level2 IS NOT NULL").Length > 0)
                //{
                if (DTForm.Select("form_group_name='" + FormTypeStr + "' AND Menu_Head='" + Menu_ + "' AND  sub_menu='" + SubMenu_ + "' AND parent_btn_name='" + Parent_ + "'  AND  level1='" + Level1_ + "' AND level2 IS NOT NULL").Length > 0)
                {
                    //dtPage = DTForm.Select("sub_menu='" + SubMenu_ + "' AND  parent_btn_name='" + Parent_ + "'  AND level1='" + Level1_ + "'  AND level2 IS NOT NULL").CopyToDataTable().AsDataView().ToTable(true, "level2");
                    dtPage = DTForm.Select("form_group_name='" + FormTypeStr + "' AND sub_menu='" + SubMenu_ + "' AND  parent_btn_name='" + Parent_ + "'  AND level1='" + Level1_ + "'  AND level2 IS NOT NULL").CopyToDataTable().AsDataView().ToTable(true, "level2");
                    BarSubItem[] barbtn = new BarSubItem[dtPage.Rows.Count];
                    for (int t = 0; t < dtPage.Rows.Count; t++)
                    {
                        DataTable dtBtns = new DataTable();
                        //dtBtns = DTForm.AsEnumerable().Where(m => m.Field<string>("sub_menu") == SubMenu_ && m.Field<string>("parent_btn_name") == Parent_ && m.Field<string>("level1") == Level1_ && m.Field<string>("level2") == Val.ToString(dtPage.Rows[t]["level2"])).CopyToDataTable();
                        dtBtns = DTForm.AsEnumerable().Where(m => m.Field<string>("form_group_name") == FormTypeStr && m.Field<string>("sub_menu") == SubMenu_ && m.Field<string>("parent_btn_name") == Parent_ && m.Field<string>("level1") == Level1_ && m.Field<string>("level2") == Val.ToString(dtPage.Rows[t]["level2"])).CopyToDataTable();

                        barbtn[t] = new BarSubItem(ribbonControl1.Manager, Val.ToString(dtPage.Rows[t]["level2"]));
                        barbtn[t].Id = Ribbon.Manager.GetNewItemId();  // (t + 1);
                        barbtn[t].Name = "L2Combo" + (t + 1).ToString();
                        barbtn[t].Caption = Val.ToString(dtPage.Rows[t]["level2"]);
                        barbtn[t].RibbonStyle = RibbonItemStyles.All;
                        barbtn[t].LargeWidth = 99;
                        if (Val.ToString(dtBtns.Rows[0]["icon"]) != "")
                        {
                            barbtn[t].ImageIndex = Val.ToInt(dtBtns.Rows[0]["icon"]);
                            barbtn[t].LargeImageIndex = Val.ToInt(dtBtns.Rows[0]["icon"]);
                        }
                        BarButtonItem[] Cmbbtn = new BarButtonItem[dtBtns.Rows.Count];
                        for (int z = 0; z < dtBtns.Rows.Count; z++)
                        {
                            Cmbbtn[z] = new BarButtonItem(ribbonControl1.Manager, Val.ToString(dtBtns.Rows[z]["caption"]));
                            Cmbbtn[z].Id = Ribbon.Manager.GetNewItemId();
                            Cmbbtn[z].Name = "CBtn" + (z + 1).ToString();
                            Cmbbtn[z].Caption = Val.ToString(dtBtns.Rows[z]["caption"]);
                            Cmbbtn[z].Description = Val.ToString(dtBtns.Rows[z]["form_id"]);
                            Cmbbtn[z].Tag = Val.ToString(dtBtns.Rows[z]["form_name"]);
                            Cmbbtn[z].ItemClick += new ItemClickEventHandler(MDIMain_ItemClick);
                        }
                        barbtn[t].AddItems(Cmbbtn);
                    }
                    barbtn_.AddItems(barbtn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        void MDIMain_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem btn = e.Item as BarButtonItem;

            Boolean Flag = false;

            try
            {
                string ref_form_name = "";
                if (btn.Description.ToString().Length > 0)
                {
                    DataRow[] _drs = DTForm.Select("form_id = " + btn.Description.ToString());
                    //ref_form_name = _drs[0]["REF_FORM_NAME"].ToString();
                }
                Form k = Application.OpenForms[btn.Tag.ToString().ToUpper()];

                if (k == null)
                {
                    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
                    foreach (Type type in frmAssembly.GetTypes())
                    {
                        if (Flag)
                        {
                            break;
                        }

                        if (type.BaseType == typeof(DevExpress.XtraEditors.XtraForm))
                        {
                            if (type.Name.ToString().ToUpper() == btn.Tag.ToString().ToUpper())
                            {
                                XtraForm frmShow = (XtraForm)frmAssembly.CreateInstance(type.ToString());
                                frmShow.MdiParent = this;
                                if (ref_form_name.Length > 0)
                                    frmShow.Name = ref_form_name.ToUpper();
                                if (DTForm.AsEnumerable().Where(m => m.Field<string>("form_name") == btn.Tag.ToString() && m.Field<string>("caption") == btn.Caption.ToString()).CopyToDataTable().Rows[0]["param"].ToString().Length > 0)
                                {
                                    string param = DTForm.AsEnumerable().Where(m => m.Field<string>("form_name") == btn.Tag.ToString() && m.Field<string>("caption") == btn.Caption.ToString()).CopyToDataTable().Rows[0]["param"].ToString();
                                    object[] obj1 = param.Split(',');
                                    frmShow.GetType().GetMethod("ShowForm").Invoke(frmShow, obj1);
                                    Flag = true;
                                }
                                else
                                {
                                    frmShow.GetType().GetMethod("ShowForm").Invoke(frmShow, null);
                                    Flag = true;
                                }
                            }
                        }
                        else if (type.BaseType == typeof(Form))
                        {
                            if (type.Name.ToString().ToUpper() == btn.Tag.ToString().ToUpper())
                            {
                                Form frmShow = (Form)frmAssembly.CreateInstance(type.ToString());
                                frmShow.MdiParent = this;
                                if (ref_form_name.Length > 0)
                                    frmShow.Name = ref_form_name.ToUpper();
                                if (DTForm.Select("form_name='" + btn.Tag.ToString() + "' AND caption = '" + btn.Caption.ToString() + "'").CopyToDataTable().Rows[0]["param"].ToString().Length > 0)
                                {
                                    string param = DTForm.Select("form_name='" + btn.Tag.ToString() + "' AND caption = '" + btn.Caption.ToString() + "'").CopyToDataTable().Rows[0]["param"].ToString();
                                    object[] obj1 = param.Split(',');
                                    frmShow.GetType().GetMethod("ShowForm").Invoke(frmShow, obj1);
                                    Flag = true;
                                }
                                else
                                {
                                    frmShow.GetType().GetMethod("ShowForm").Invoke(frmShow, null);
                                    Flag = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    k.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Cursor = Cursors.Default;
        }
        private void MDIMain_Shown(object sender, EventArgs e)
        {
            try
            {
                ShowForm();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private void BarBtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private void MDIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Global.gBoolForceFullyClose == true)
                {
                    this.Close();
                }
                else if (ISMessageDisplay == true && !isManual)
                {
                    if (Global.Confirm("Are You Sure You Want To Close ? ", "Account_Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                XtraTabbedMdiManager pg = sender as XtraTabbedMdiManager;
                if (pg.SelectedPage != null)
                {
                    XtraForm frm = pg.SelectedPage.MdiChild as XtraForm;
                    if (pg.SelectedPage.Text.ToUpper().Contains("Live Stock  [Template : ".ToUpper()))
                    {
                        Ribbon.Minimized = false;
                        ribbonPageCategory2.Visible = true;
                    }
                    else
                    {
                        Ribbon.Minimized = false;
                        ribbonPageCategory2.Visible = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void MDIMain_Load(object sender, EventArgs e)
        {
            try
            {
                Global.gMainFormRef = this;
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.XtraBars.Ribbon.GalleryDropDown skins = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
                skins.Ribbon = ribbonControl1;
                DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
                barBtnTheme.DropDownControl = skins;
                FormTypeStr = "SALES";
                skins.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(gallery_GalleryItemClick);

                Global.Gwidth = this.Width;
                Global.Gheight = this.Height;

                Global.Gwidth = this.Width;
                Global.Gheight = this.Height;

                Ribbon.AllowMinimizeRibbon = true;

                DataTable DTabThemes = objUser.Get_Theme_Master();

                //Global.LOOKUPCompanyRep(repositoryItemLookUpEdit2);
                //Global.LOOKUPBranchRep(repositoryItemLookUpEdit3);
                //Global.LOOKUPLocationRep(repositoryItemLookUpEdit4);
                //Global.LOOKUPDepartmentRep(repositoryItemLookUpEdit5);

                if (DTabThemes.Rows.Count > 0)
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Val.ToString(DTabThemes.Rows[0]["Theme_Name"]);
                }
                else
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel";
                }

                barComp.Caption = "Company : " + BLL.GlobalDec.gEmployeeProperty.company_name;
                barBranch.Caption = "Branch : " + BLL.GlobalDec.gEmployeeProperty.branch_name;
                BarLocation.Caption = "Location : " + BLL.GlobalDec.gEmployeeProperty.location_name;
                BarDepartment.Caption = "Department : " + BLL.GlobalDec.gEmployeeProperty.department_name;
                //BarChangeMode.Caption = "Role : " + BLL.GlobalDec.gEmployeeProperty.role_name;
                //barStaticItemLogin.Caption = "Mode : SALES";
                //barFinYear.Caption = "Fin. Year : " + BLL.GlobalDec.gEmployeeProperty.gFinancialYear;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }

        private void repositoryItemLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                Global.LOOKUPCompanyRep(repositoryItemLookUpEdit2);
            }
        }

        private void barBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            ObjFillCombo.user_id = GlobalDec.gEmployeeProperty.user_id;
            DataTable tdt = ObjFillCombo.FillCmb(FillCombo.TABLE.Branch_Master);
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["branch_id"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["Branch_Name"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["state_id"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["cgst_per"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["sgst_per"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["igst_per"].Visible = false;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.branch_id = Val.ToInt32(Val.ToString(FrmDevExpPopupGrid.DRow["branch_id"]));
                GlobalDec.gEmployeeProperty.state_id = Val.ToInt32(Val.ToString(FrmDevExpPopupGrid.DRow["state_id"]));
                GlobalDec.gEmployeeProperty.cgst_per = Val.ToDecimal(Val.ToString(FrmDevExpPopupGrid.DRow["cgst_per"]));
                GlobalDec.gEmployeeProperty.sgst_per = Val.ToDecimal(Val.ToString(FrmDevExpPopupGrid.DRow["sgst_per"]));
                GlobalDec.gEmployeeProperty.igst_per = Val.ToDecimal(Val.ToString(FrmDevExpPopupGrid.DRow["igst_per"]));
                barBranch.Caption = "Branch : " + Val.ToString(FrmDevExpPopupGrid.DRow["branch_name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void barComp_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            ObjFillCombo.user_id = GlobalDec.gEmployeeProperty.user_id;

            DataTable tdt = ObjFillCombo.FillCmb(FillCombo.TABLE.Company_Master);
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["company_id"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["Company_Name"].Visible = true;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.company_id = Val.ToInt32(Val.ToString(FrmDevExpPopupGrid.DRow["Company_id"]));
                barComp.Caption = "Company : " + Val.ToString(FrmDevExpPopupGrid.DRow["Company_Name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void BarDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            ObjFillCombo.user_id = GlobalDec.gEmployeeProperty.user_id;
            DataTable tdt = ObjFillCombo.FillCmb(FillCombo.TABLE.Department_Master);
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["department_id"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["Department_Name"].Visible = true;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.department_id = Val.ToInt32(Val.ToString(FrmDevExpPopupGrid.DRow["department_id"]));
                BarDepartment.Caption = "Department : " + Val.ToString(FrmDevExpPopupGrid.DRow["department_name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void BarLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            ObjFillCombo.user_id = GlobalDec.gEmployeeProperty.user_id;
            DataTable tdt = ObjFillCombo.FillCmb(FillCombo.TABLE.Location_Master);
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["location_id"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["Location_Name"].Visible = true;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.location_id = Val.ToInt32(Val.ToString(FrmDevExpPopupGrid.DRow["location_id"]));
                BarLocation.Caption = "Location : " + Val.ToString(FrmDevExpPopupGrid.DRow["location_name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void barFinYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FinancialYearMaster ObjFinancial = new FinancialYearMaster();
            //FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            //DataTable tdt = ObjFinancial.GetData();
            //FrmDevExpPopupGrid.DTab = tdt;
            //FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            //FrmDevExpPopupGrid.MainGridDetail.Refresh();
            //FrmDevExpPopupGrid.Size = new Size(500, 300);
            //FrmDevExpPopupGrid.GrdDet.Columns["financial_year"].Visible = true;
            //FrmDevExpPopupGrid.GrdDet.Columns["active"].Visible = true;
            //FrmDevExpPopupGrid.GrdDet.Columns["fin_year_code"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["start_date"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["end_date"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["short_name"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["start_yearmonth"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["end_yearmonth"].Visible = false;

            //FrmDevExpPopupGrid.ShowDialog();

            //if (FrmDevExpPopupGrid.DRow != null)
            //{
            //    foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
            //    {
            //        Frm.Focus();
            //        Frm.Hide();
            //        Frm.Close();
            //        Frm.Dispose();
            //    }
            //    GlobalDec.gEmployeeProperty.gFinancialYear_Code = Val.ToInt64(Val.ToString(FrmDevExpPopupGrid.DRow["fin_year_code"]));
            //    barFinYear.Caption = "Fin. Year : " + Val.ToString(FrmDevExpPopupGrid.DRow["financial_year"]);
            //    GlobalDec.gEmployeeProperty.gFinancialYear = Val.ToString(FrmDevExpPopupGrid.DRow["financial_year"]);
            //}
            //FrmDevExpPopupGrid.Hide();
            //FrmDevExpPopupGrid.Dispose();
            //FrmDevExpPopupGrid = null;
        }

        private void barBtnRefreshPref_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                MDIMain MainForm = new MDIMain();
                BLL.FormPer ObjPer = new BLL.FormPer();
                Global.gMainFormRef = MainForm;
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                isManual = true;
                this.Hide();

                this.Close();
                this.Dispose();
                MainForm.ShowDialog();
                isManual = true;
            }
            catch
            { }
        }

        private void barStaticItemLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //if (GlobalDec.gEmployeeProperty.Allow_Change_Login == 0)
                //{
                //    Global.Message("Sorry......You Are Not Authorised To Change The Login");
                //    return;
                //}

                FrmLogin FrmLogin = new FrmLogin();
                isManual = true;
                this.Hide();

                this.Close();
                this.Dispose();
                this.Cursor = Cursors.WaitCursor;
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    if (Frm.Name.ToUpper() != "FrmMainHome".ToUpper())
                    {
                        Frm.Focus();
                        Frm.Hide();
                        Frm.Close();
                        Frm.Dispose();
                    }
                }
                FrmLogin.ShowDialog();
                isManual = true;
                this.Cursor = Cursors.Default;
            }
            catch
            { }
        }
    }
}

