using System;
using System.Windows.Forms;

namespace Krishna_Textiles.UserControls
{

    public partial class UCHTMLEditor : UserControl
    {
        public UCHTMLEditor()
        {
            InitializeComponent();
        }

        private void TsBold_Click(object sender, System.EventArgs e)
        {
            HtmlEditor1.Document.execCommand("bold", false, null);
        }

        private void TsItalic_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("Italic", false, null);
        }

        private void TsUnderline_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("Underline", false, null);
        }

        private void TsFont_Click(object sender, System.EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult dr = fd.ShowDialog();
            if ((dr == DialogResult.OK))
            {
                this.HtmlEditor1.SelectionFont = fd.Font;
                if (((fd.Font.Bold == false)
                            && ((fd.Font.Italic == false)
                            && (fd.Font.Underline == false))))
                {
                    this.TsBold.Checked = false;
                    this.TsItalic.Checked = false;
                    this.TsUnderline.Checked = false;
                }
                else if (((fd.Font.Bold == true)
                            && (fd.Font.Italic == true)))
                {
                    this.TsBold.Checked = true;
                    this.TsItalic.Checked = true;
                    this.TsUnderline.Checked = false;
                    TsBold_Click(new object(), EventArgs.Empty);
                    TsItalic_Click(new object(), EventArgs.Empty);
                }
                else if ((fd.Font.Bold == true))
                {
                    this.TsBold.Checked = true;
                    this.TsItalic.Checked = false;
                    this.TsUnderline.Checked = false;
                    TsBold_Click(new object(), EventArgs.Empty);
                }
                else if ((fd.Font.Italic == true))
                {
                    this.TsItalic.Checked = true;
                    this.TsUnderline.Checked = false;
                    this.TsBold.Checked = false;
                    TsItalic_Click(new object(), EventArgs.Empty);
                }
                else if ((fd.Font.Underline == true))
                {
                    this.TsUnderline.Checked = true;
                    this.TsItalic.Checked = false;
                    this.TsBold.Checked = false;
                    TsUnderline_Click(new object(), EventArgs.Empty);
                }
            }
            this.TsFont.Checked = false;
        }

        private void TsColor_Click(object sender, System.EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult dr = cd.ShowDialog();
            if ((dr == DialogResult.OK))
            {
                this.HtmlEditor1.SelectionForeColor = cd.Color;
            }
        }

        private void TsLeft_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("JustifyLeft", false, null);
        }

        private void TsCenter_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("JustifyCenter", false, null);
        }

        private void TsRight_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("JustifyRight", false, null);
        }

        private void TsList_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("InsertOrderedList", false, null);
        }

        private void TsUndo_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("Undo", false, null);
        }

        private void TsRedo_Click(object sender, System.EventArgs e)
        {
            this.HtmlEditor1.Document.execCommand("Redo", false, null);
        }

        public string getHtml()
        {

            mshtml.IHTMLElement element = this.HtmlEditor1.Document.body;
            string header = "<html><body>";
            string pie = "</body></html>";

            string StrRes = header + "<p>" + element.innerHTML + "</p></br>" + pie;

            return StrRes;
        }

        public void setHtml(string html)
        {
            this.HtmlEditor1.LoadDocument(html);
        }
    }
}
