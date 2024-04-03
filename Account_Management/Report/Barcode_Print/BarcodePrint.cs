using MBDataLib;
using System;
using System.Collections;

namespace Account_Management.Report.Barcode_Print
{

    public class BarcodePrint
    {
        public class Pkt
        {
            public string KapanNo = string.Empty;
            public string SrNo = "0";
            public string Date = string.Empty;
            public Int64 LotId = 0;
            public bool RBar = false;
            public int pcs = 0;
            public decimal carat = 0;

            public Pkt(string pStrKapan, string pIntSrNo, string pStrDate, int pIntLotId, int pIntPc, decimal pDecCarat, bool pBoolRBar)
            {
                this.KapanNo = pStrKapan;
                this.SrNo = pIntSrNo;
                this.Date = pStrDate;
                this.LotId = pIntLotId;
                this.RBar = pBoolRBar;
                this.pcs = pIntPc;
                this.carat = pDecCarat;
            }
        }
        public class Stock_Pkt
        {
            public string Item_Name = string.Empty;
            public string Color_Name = string.Empty;
            public string Size_Name = string.Empty;
            public string SrNo = "0";
            public string Date = string.Empty;
            public Int64 Stock_ID = 0;
            public bool RBar = false;
            public Int64 Balance_Pcs = 0;

            public Stock_Pkt(string pStrItem, string pIntColor, string pStrSize, Int64 pIntStockId, Int64 pBalancePcs, bool pBoolRBar)
            {
                this.Item_Name = pStrItem;
                this.Color_Name = pIntColor;
                this.Size_Name = pStrSize;
                this.Stock_ID = pIntStockId;
                this.RBar = pBoolRBar;
                this.Balance_Pcs = pBalancePcs;
            }
        }

        public class GalaxyPkt
        {
            public string ProcessName = string.Empty;
            public string KapanNumber = "0";
            public string StoneNumber = string.Empty;
            public Int64 Tops = 0;
            public decimal RoughCarat = 0;
            public decimal Carat = 0;
            public decimal PolishCarat = 0;
            public string pClarity = "0";
            public bool RBar = false;


            public GalaxyPkt(string processName, string kapanNo, string stone_no, int tops, decimal pRoughCarat, decimal carat, decimal polCarat, string pClarity, bool pBoolRBar)
            {
                this.ProcessName = processName;
                this.KapanNumber = kapanNo;
                this.StoneNumber = stone_no;
                this.Tops = tops;
                this.RoughCarat = pRoughCarat;
                this.Carat = carat;
                this.PolishCarat = polCarat;
                this.pClarity = pClarity;
                this.RBar = pBoolRBar;
            }
        }

        // Comment By Praful On 06042021

        //private string _mStrBarPos = "O0215";

        //private string _StrPrnLast = "";

        //private string _StrPrnFirst = "";

        //private string _StrBarCode = "";
        //private int IntIndex = 0;

        // End By Praful On 06042021

        private ArrayList _Pkt = new ArrayList();
        public void AddPkt(string pStrKapan, string pIntSrNo, string pStrDate, int pIntLotId, int pIntPc, decimal pDecCarat, bool pBoolRBar)
        {
            this._Pkt.Add(new BarcodePrint.Pkt(pStrKapan, pIntSrNo, pStrDate, pIntLotId, pIntPc, pDecCarat, pBoolRBar));
        }
        private ArrayList _GalaxyPkt = new ArrayList();
        public void AddPktGalaxy(string processName, string kapanNo, string stone_no, int tops, decimal pRoughCarat, decimal carat, decimal polCarat, string pClarity, bool pBoolRBar)
        {
            this._GalaxyPkt.Add(new BarcodePrint.GalaxyPkt(processName, kapanNo, stone_no, tops, pRoughCarat, carat, polCarat, pClarity, pBoolRBar));
        }

        public void Stock_AddPkt(string pStrItem, string pIntColor, string pStrSize, Int64 pIntStockId, Int64 pBalancePcs, bool pBoolRBar)
        {
            this._Pkt.Add(new BarcodePrint.Stock_Pkt(pStrItem, pIntColor, pStrSize, pIntStockId, pBalancePcs, pBoolRBar));
        }

        public void Stock_PrintTSC()
        {
            string pStrFileName = System.Windows.Forms.Application.StartupPath + @"\Output2.txt";//Global.gStrVersion + "\\Output2.txt";
            Printing.FileOpen(pStrFileName);
            BarcodePrint.Stock_Pkt[] array = new BarcodePrint.Stock_Pkt[this._Pkt.Count];
            for (int i = 0; i < this._Pkt.Count; i++)
            {
                array[i] = (BarcodePrint.Stock_Pkt)this._Pkt[i];
            }
            BarcodePrint.Stock_Pkt[] array2 = array;
            for (int j = 0; j < array2.Length; j++)
            {
                BarcodePrint.Stock_Pkt pkt = array2[j];

                Printing.PrintLine("<xpml><page quantity='0' pitch='15.0 mm'></xpml>I8,A");
                Printing.PrintLine("ZN");
                Printing.PrintLine("q304");
                Printing.PrintLine("O");
                Printing.PrintLine("JF");
                Printing.PrintLine("KIZZQ0");
                Printing.PrintLine("KI9+0.0");
                Printing.PrintLine("ZT");
                Printing.PrintLine("Q120,25");
                Printing.PrintLine("Arglabel 150 31");
                Printing.PrintLine("exit");
                Printing.PrintLine("KI80");
                Printing.PrintLine("<xpml></page></xpml><xpml><page quantity='1' pitch='15.0 mm'></xpml>N");
                Printing.PrintLine("B275,106,2,1,2,4,45,N,\"" + pkt.Stock_ID + "\"");
                Printing.PrintLine("A275,55,2,3,1,1,N,\"" + pkt.Stock_ID + "\"");
                Printing.PrintLine("A275,29,2,2,1,1,N,\"" + pkt.Date + "\"");
                Printing.PrintLine("A93,104,2,1,1,1,N,\"" + pkt.Item_Name + "\"");

                // Change By Praful 07122022
                Printing.PrintLine("A93,56,2,3,1,1,N,\"" + pkt.Balance_Pcs + "\"");
                Printing.PrintLine("A125,29,2,3,1,1,N,\"" + pkt.SrNo + "\"");

                // End

                Printing.PrintLine("P1");
                Printing.PrintLine("<xpml></page></xpml><xpml><end/></xpml>");
            }
            Printing.FileClose();

            if ((BLL.GlobalDec.gEmployeeProperty.user_name == "VISHAL") && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_3rdFloor.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "RAJU") && BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "DC" || BLL.GlobalDec.gEmployeeProperty.user_name == "LALITA4P" || BLL.GlobalDec.gEmployeeProperty.user_name == "LALITAM")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_LALITA.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "KARAN" || BLL.GlobalDec.gEmployeeProperty.user_name == "KHODIDAS") && BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM_KARAN.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "VINOD" && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_DW_VINOD.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "RAVI")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_BHAVNAGAR_RAVI.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "KAILASH" || BLL.GlobalDec.gEmployeeProperty.user_name == "GAURAVG"
                || BLL.GlobalDec.gEmployeeProperty.user_name == "NIMISHA"
                || BLL.GlobalDec.gEmployeeProperty.user_name == "HARDIK")
                && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            {
                Printing.PrintBarcode(pStrFileName, "PRINTFIB_1_Makable.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "SAHIL" && BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
            {
                Printing.PrintBarcode(pStrFileName, "PRINTFIB_SAWANI.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "CHIRAGD" && BLL.GlobalDec.gEmployeeProperty.branch_id == 9) || BLL.GlobalDec.gEmployeeProperty.user_name == "YASHY" || BLL.GlobalDec.gEmployeeProperty.user_name == "RAJAT" || BLL.GlobalDec.gEmployeeProperty.user_name == "ABHIJEET"
                || BLL.GlobalDec.gEmployeeProperty.user_name == "RAJNI" || BLL.GlobalDec.gEmployeeProperty.user_name == "PREETI")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_3rdFloor.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "TUSHARG" || BLL.GlobalDec.gEmployeeProperty.user_name == "VISHALV" || BLL.GlobalDec.gEmployeeProperty.user_name == "MAMTAG")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_2ndFloor.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "PRIYANKA" || BLL.GlobalDec.gEmployeeProperty.user_name == "VAISHALIV" || BLL.GlobalDec.gEmployeeProperty.user_name == "RITA" || BLL.GlobalDec.gEmployeeProperty.user_name == "NISHAS" || BLL.GlobalDec.gEmployeeProperty.user_name == "URVASHI" || BLL.GlobalDec.gEmployeeProperty.user_name == "SUBHAM")
            {
                Printing.PrintBarcode(pStrFileName, "PRINTFIB_2_Makable.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "HARSHIL" || BLL.GlobalDec.gEmployeeProperty.user_name == "PURVI" || BLL.GlobalDec.gEmployeeProperty.user_name == "JINAL" || BLL.GlobalDec.gEmployeeProperty.user_name == "PRAGNESH" || BLL.GlobalDec.gEmployeeProperty.user_name == "POUL" || BLL.GlobalDec.gEmployeeProperty.user_name == "PANKAJ" || BLL.GlobalDec.gEmployeeProperty.user_name == "SANJAYS" || BLL.GlobalDec.gEmployeeProperty.user_name == "SUNIL")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_DW_4FLOOR.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "TARUN" || BLL.GlobalDec.gEmployeeProperty.user_name == "BHATT" || BLL.GlobalDec.gEmployeeProperty.user_name == "DEVANGI" || BLL.GlobalDec.gEmployeeProperty.user_name == "RAHUL")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_ASSORTMENT.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "RAJESH")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_HAREKRISHNA.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "KMDM")
            {
                Printing.PrintBarcode(pStrFileName, "PRINTGIB.bat");
            }
            else
            {
                if ((BLL.GlobalDec.gEmployeeProperty.user_name == "PRIYAM" || BLL.GlobalDec.gEmployeeProperty.user_name == "KOMAL") && (BLL.GlobalDec.gEmployeeProperty.branch_id == 1))
                    Printing.PrintBarcode(pStrFileName, "PRINTFIB.bat");
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
                    Printing.PrintBarcode(pStrFileName, "PRINTSIB.bat");
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
                {
                    Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
                }
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 1 && BLL.GlobalDec.gEmployeeProperty.user_name == "KJG")
                {
                    Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
                }
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
                {
                    Printing.PrintBarcode(pStrFileName, "PRINTGIB.bat");
                }
            }
        }
        public void PrintTSC()
        {
            string pStrFileName = System.Windows.Forms.Application.StartupPath + @"\Output2.txt";//Global.gStrVersion + "\\Output2.txt";
            Printing.FileOpen(pStrFileName);
            BarcodePrint.Pkt[] array = new BarcodePrint.Pkt[this._Pkt.Count];
            for (int i = 0; i < this._Pkt.Count; i++)
            {
                array[i] = (BarcodePrint.Pkt)this._Pkt[i];
            }
            BarcodePrint.Pkt[] array2 = array;
            for (int j = 0; j < array2.Length; j++)
            {
                BarcodePrint.Pkt pkt = array2[j];

                string carat = pkt.carat.ToString("#.000");

                Printing.PrintLine("<xpml><page quantity='0' pitch='15.0 mm'></xpml>I8,A");
                Printing.PrintLine("ZN");
                Printing.PrintLine("q304");
                Printing.PrintLine("O");
                Printing.PrintLine("JF");
                Printing.PrintLine("KIZZQ0");
                Printing.PrintLine("KI9+0.0");
                Printing.PrintLine("ZT");
                Printing.PrintLine("Q120,25");
                Printing.PrintLine("Arglabel 150 31");
                Printing.PrintLine("exit");
                Printing.PrintLine("KI80");
                Printing.PrintLine("<xpml></page></xpml><xpml><page quantity='1' pitch='15.0 mm'></xpml>N");
                Printing.PrintLine("B275,106,2,1,2,4,45,N,\"" + pkt.LotId + "\"");
                Printing.PrintLine("A275,55,2,3,1,1,N,\"" + pkt.LotId + "\"");
                Printing.PrintLine("A275,29,2,2,1,1,N,\"" + pkt.Date + "\"");
                Printing.PrintLine("A93,104,2,1,1,1,N,\"" + pkt.KapanNo + "\"");

                // Change By Praful 07122022
                Printing.PrintLine("A93,85,2,3,1,1,N,\"" + carat + "\"");
                Printing.PrintLine("A93,56,2,3,1,1,N,\"" + pkt.pcs + "\"");
                Printing.PrintLine("A125,29,2,3,1,1,N,\"" + pkt.SrNo + "\"");

                // End

                Printing.PrintLine("P1");
                Printing.PrintLine("<xpml></page></xpml><xpml><end/></xpml>");
            }
            Printing.FileClose();

            if ((BLL.GlobalDec.gEmployeeProperty.user_name == "VISHAL") && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_3rdFloor.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "RAJU") && BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "DC" || BLL.GlobalDec.gEmployeeProperty.user_name == "LALITA4P" || BLL.GlobalDec.gEmployeeProperty.user_name == "LALITAM")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_LALITA.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "KARAN" || BLL.GlobalDec.gEmployeeProperty.user_name == "KHODIDAS") && BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM_KARAN.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "VINOD" && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_DW_VINOD.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "RAVI")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_BHAVNAGAR_RAVI.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "KAILASH" || BLL.GlobalDec.gEmployeeProperty.user_name == "GAURAVG"
                || BLL.GlobalDec.gEmployeeProperty.user_name == "NIMISHA"
                || BLL.GlobalDec.gEmployeeProperty.user_name == "HARDIK")
                && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            {
                Printing.PrintBarcode(pStrFileName, "PRINTFIB_1_Makable.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "SAHIL" && BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
            {
                Printing.PrintBarcode(pStrFileName, "PRINTFIB_SAWANI.bat");
            }
            else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "CHIRAGD" && BLL.GlobalDec.gEmployeeProperty.branch_id == 9) || BLL.GlobalDec.gEmployeeProperty.user_name == "YASHY" || BLL.GlobalDec.gEmployeeProperty.user_name == "RAJAT" || BLL.GlobalDec.gEmployeeProperty.user_name == "ABHIJEET"
                || BLL.GlobalDec.gEmployeeProperty.user_name == "RAJNI" || BLL.GlobalDec.gEmployeeProperty.user_name == "PREETI")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_3rdFloor.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "TUSHARG" || BLL.GlobalDec.gEmployeeProperty.user_name == "VISHALV" || BLL.GlobalDec.gEmployeeProperty.user_name == "MAMTAG")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_2ndFloor.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "PRIYANKA" || BLL.GlobalDec.gEmployeeProperty.user_name == "VAISHALIV" || BLL.GlobalDec.gEmployeeProperty.user_name == "RITA" || BLL.GlobalDec.gEmployeeProperty.user_name == "NISHAS" || BLL.GlobalDec.gEmployeeProperty.user_name == "URVASHI" || BLL.GlobalDec.gEmployeeProperty.user_name == "SUBHAM")
            {
                Printing.PrintBarcode(pStrFileName, "PRINTFIB_2_Makable.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "HARSHIL" || BLL.GlobalDec.gEmployeeProperty.user_name == "PURVI" || BLL.GlobalDec.gEmployeeProperty.user_name == "JINAL" || BLL.GlobalDec.gEmployeeProperty.user_name == "PRAGNESH" || BLL.GlobalDec.gEmployeeProperty.user_name == "POUL" || BLL.GlobalDec.gEmployeeProperty.user_name == "PANKAJ" || BLL.GlobalDec.gEmployeeProperty.user_name == "SANJAYS" || BLL.GlobalDec.gEmployeeProperty.user_name == "SUNIL")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_DW_4FLOOR.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "TARUN" || BLL.GlobalDec.gEmployeeProperty.user_name == "BHATT" || BLL.GlobalDec.gEmployeeProperty.user_name == "DEVANGI" || BLL.GlobalDec.gEmployeeProperty.user_name == "RAHUL")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_ASSORTMENT.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "RAJESH")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_HAREKRISHNA.bat");
            }
            else if (BLL.GlobalDec.gEmployeeProperty.user_name == "KMDM")
            {
                Printing.PrintBarcode(pStrFileName, "PRINTGIB.bat");
            }
            else
            {
                if ((BLL.GlobalDec.gEmployeeProperty.user_name == "PRIYAM" || BLL.GlobalDec.gEmployeeProperty.user_name == "KOMAL") && (BLL.GlobalDec.gEmployeeProperty.branch_id == 1))
                    Printing.PrintBarcode(pStrFileName, "PRINTFIB.bat");
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
                    Printing.PrintBarcode(pStrFileName, "PRINTSIB.bat");
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
                {
                    Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
                }
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 1 && BLL.GlobalDec.gEmployeeProperty.user_name == "KJG")
                {
                    Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
                }
                else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
                {
                    Printing.PrintBarcode(pStrFileName, "PRINTGIB.bat");
                }
            }
        }
        public void GalaxyPrintTSC()
        {
            string pStrFileName = System.Windows.Forms.Application.StartupPath + @"\Output2.txt";//Global.gStrVersion + "\\Output2.txt";
            Printing.FileOpen(pStrFileName);
            BarcodePrint.GalaxyPkt[] array = new BarcodePrint.GalaxyPkt[this._GalaxyPkt.Count];
            for (int i = 0; i < this._GalaxyPkt.Count; i++)
            {
                array[i] = (BarcodePrint.GalaxyPkt)this._GalaxyPkt[i];
            }
            BarcodePrint.GalaxyPkt[] array2 = array;
            for (int j = 0; j < array2.Length; j++)
            {
                BarcodePrint.GalaxyPkt pkt = array2[j];

                //string roughcarat = pkt.RoughCarat.ToString("#.000");

                Printing.PrintLine("<xpml><page quantity='0' pitch='15.0 mm'></xpml>I8,A");
                Printing.PrintLine("ZN");
                Printing.PrintLine("q304");
                Printing.PrintLine("O");
                Printing.PrintLine("JF");
                Printing.PrintLine("KIZZQ0");
                Printing.PrintLine("KI9+0.0");
                Printing.PrintLine("ZT");
                Printing.PrintLine("Q120,25");
                Printing.PrintLine("Arglabel 150 31");
                Printing.PrintLine("exit");
                Printing.PrintLine("KI80");
                Printing.PrintLine("<xpml></page></xpml><xpml><page quantity='1' pitch='15.0 mm'></xpml>N");
                //Printing.PrintLine("B290,106,2,1,2,4,45,N,\"" + pkt.KapanNumber + ","+ pkt.ProcessName + ","+ pkt.StoneNumber + ","+ pkt.Tops + ","+ pkt.PolishCarat + "\"");
                //livePrinting.PrintLine("B280,106,2,1,1,4,45,N,\"" + pkt.KapanNumber + "," + pkt.ProcessName + "," + pkt.StoneNumber + "," + pkt.Tops + "," + pkt.PolishCarat + "\"");
                Printing.PrintLine("B280,106,2,1,2,4,45,N,\"" + pkt.ProcessName + "," + pkt.StoneNumber + "\"");
                //Printing.PrintLine("B290,106,2,1,1,4,45,N,\"" + pkt.KapanNumber + "\"");
                Printing.PrintLine("A275,55,2,3,1,1,N,\"" + pkt.KapanNumber + "\"");
                Printing.PrintLine("A275,29,2,2,1,1,N,\"" + pkt.ProcessName + "\"");
                //Printing.PrintLine("A93,104,2,1,1,1,N,\"" + pkt.StoneNumber + "\"");


                // Change By Praful 07122022
                //Printing.PrintLine("A93,85,2,3,1,1,N,\"" + pkt.RoughCarat + "\"");
                Printing.PrintLine("A150,56,2,3,1,1,N,\"" + pkt.StoneNumber + "\"");
                Printing.PrintLine("A125,56,2,3,1,1,N,\"" + pkt.pClarity + "\"");
                Printing.PrintLine("A93,29,2,3,1,1,N,\"" + pkt.RoughCarat + "\"");


                Printing.PrintLine("P1");
                Printing.PrintLine("<xpml></page></xpml><xpml><end/></xpml>");

            }
            Printing.FileClose();
            if (BLL.GlobalDec.gEmployeeProperty.user_name == "G")
            {
                Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_BARCODE.bat");
            }
            //if ((BLL.GlobalDec.gEmployeeProperty.user_name == "TARUN" || BLL.GlobalDec.gEmployeeProperty.user_name == "GAURAVG") && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            //{
            //    Printing.PrintBarcode(pStrFileName, "PRINT_MAKABLE_AMBIKA_1stFloor.bat");
            //}
            //else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "VISHAL") && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            //{
            //    Printing.PrintBarcode(pStrFileName, "PRINT_GALAXY_AMBIKA_3rdFloor.bat");
            //}
            //else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "RAJU") && BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
            //{
            //    Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
            //}
            //else if ((BLL.GlobalDec.gEmployeeProperty.user_name == "KARAN" || BLL.GlobalDec.gEmployeeProperty.user_name == "KHODIDAS") && BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
            //{
            //    Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM_KARAN.bat");
            //}
            //else if (BLL.GlobalDec.gEmployeeProperty.user_name == "VINOD" && BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            //{
            //    Printing.PrintBarcode(pStrFileName, "PRINT_DW_VINOD.bat");
            //}
            //else
            //{
            //    if (BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
            //        Printing.PrintBarcode(pStrFileName, "PRINTFIB.bat");
            //    else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
            //        Printing.PrintBarcode(pStrFileName, "PRINTSIB.bat");
            //    else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
            //    {
            //        Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
            //    }
            //    else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
            //    {
            //        Printing.PrintBarcode(pStrFileName, "PRINTGIB.bat");
            //    }
            //}
        }
        public void PrintTSC1(string pStrFileName)
        {
            if (BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
                Printing.PrintBarcode(pStrFileName, "PRINTFIB.bat");
            else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
                Printing.PrintBarcode(pStrFileName, "PRINTSIB.bat");
            else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 14)
                Printing.PrintBarcode(pStrFileName, "PRINT_KATARGAM.bat");
            else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 38)
            {
                Printing.PrintBarcode(pStrFileName, "PRINTGIB.bat");
                //  Global.Message(pStrFileName);
            }
        }
    }
}
