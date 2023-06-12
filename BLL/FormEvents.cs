using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BLL
{
    public class FormEvents
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        Validation Val = new Validation();
        private Form _mForm;
        private System.Collections.ArrayList _mArrList = new System.Collections.ArrayList();

        public System.Collections.ArrayList ObjToDispose
        {
            get
            {
                return _mArrList;
            }
            set
            {
                _mArrList.Add(value);
            }
        }

        public Form CurForm
        {
            get
            {
                return _mForm;
            }
            set
            {
                _mForm = value;
            }
        }

        public bool FormKeyDown
        {
            set
            {
                if (value == true)
                {
                    CurForm.KeyDown += new KeyEventHandler(Form_KeyDown);
                }
                if (value == false)
                {
                }
            }
        }

        public bool FormKeyPress
        {
            set
            {
                if (value == true)
                {
                    CurForm.KeyPress += new KeyPressEventHandler(Form_KeyPress);
                }
                if (value == false)
                {
                    CurForm.KeyPress -= new KeyPressEventHandler(Form_KeyPress);
                }
            }
        }

        public bool FormKeyPressAsItIs
        {
            set
            {
                if (value == true)
                {
                    CurForm.KeyPress += new KeyPressEventHandler(Form_KeyPressAsItIs);
                }
            }
        }

        public bool FormResize
        {
            set
            {
                if (value == true)
                {
                    CurForm.Resize += new EventHandler(Form_Resize);
                }
                if (value == false)
                {
                    CurForm.Resize -= new EventHandler(Form_Resize);
                }
            }
        }

        public bool FormClosing
        {
            set
            {
                if (value == true)
                {
                    CurForm.FormClosing += new FormClosingEventHandler(Form_Closing);
                }
                if (value == false)
                {
                    CurForm.FormClosing -= new FormClosingEventHandler(Form_Closing);
                }
            }
        }


        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            Val.FormKeyDownEvent(sender, e);
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form_KeyPressAsItIs(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            Val.frmResize(CurForm);
        }

        public void iDispose(Control C)
        {
            if (C.HasChildren == true)
            {
                foreach (Control Cntl in C.Controls)
                {
                    if (Cntl.HasChildren == true)
                    {
                        iDispose(Cntl);
                    }
                    else
                    {
                        Cntl.Dispose();
                    }
                }
            }
            else
            {
                C.Dispose();
            }
        }

        public void iDispose()
        {
            foreach (Control Cntl in CurForm.Controls)
            {
                if (Cntl.HasChildren == true)
                {
                    iDispose(Cntl);
                }
                else
                {
                    Cntl.Dispose();
                }
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CurForm.Dispose();

                for (Int16 inti = 0; inti <= ObjToDispose.Count - 1; inti++)
                {
                    ObjToDispose[inti] = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (
                    Environment.OSVersion.Platform == PlatformID.Win32NT ||
                    Environment.OSVersion.Platform == PlatformID.Win32S ||
                    Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                    Environment.OSVersion.Platform == PlatformID.WinCE
                    )
                {
                    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
            }
            catch
            {

            }
        }
    }
}
