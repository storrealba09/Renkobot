using BitMEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitMexSampleBot
{
    public partial class Form1 : Form
    {

        // IMPORTANT - Enter your API Key information below

        //TEST NET
        private static string TestbitmexKey = "YOURHEREKEYHERE";
        private static string TestbitmexSecret = "YOURSECRETHERE";
        private static string TestbitmexDomain = "https://testnet.bitmex.com";

        //REAL NET
        private static string bitmexKey = "YOURHEREKEYHERE";
        private static string bitmexSecret = "YOURSECRETHERE";
        private static string bitmexDomain = "https://www.bitmex.com";




        BitMEXApi bitmex;
        List<OrderBook> CurrentBook = new List<OrderBook>();
        List<Instrument> ActiveInstruments = new List<Instrument>();
        Instrument ActiveInstrument = new Instrument();
        List<Candle> Candles = new List<Candle>();

        bool Running = false;
        double? Stop = 0;
        double? BasePrice = 0;
        double Target = 0;

        //string Mode = "Wait";
        List<Position> OpenPositions = new List<Position>();
        List<Order> OpenOrders = new List<Order>();

        public Form1()
        {
            InitializeComponent();
            InitializeDropdowns();
            InitializeAPI();
            InitializeCandleArea();

        }
        private void InitializeDropdowns()
        {
            ddlNetwork.SelectedIndex = 0;
        }

        private void InitializeCandleArea()
        {
            tmrUpdater.Start();
        }

        private void InitializeAPI()
        {
            switch(ddlNetwork.SelectedItem.ToString())
            {
                case "TestNet":
                    bitmex = new BitMEXApi(TestbitmexKey, TestbitmexSecret, TestbitmexDomain);
                    break;
                case "RealNet":
                    bitmex = new BitMEXApi(bitmexKey, bitmexSecret, bitmexDomain);
                    break;
            }

            // We must do this in case symbols are different on test and real net
            InitializeSymbolInformation();
        }

        private void InitializeSymbolInformation()
        {
            ActiveInstruments = bitmex.GetActiveInstruments().OrderByDescending(a => a.Volume24H).ToList();
            ddlSymbol.DataSource = ActiveInstruments;
            ddlSymbol.DisplayMember = "Symbol";
            ddlSymbol.SelectedIndex = 0;
            ActiveInstrument = ActiveInstruments[0];
        }

        private double CalculateMakerOrderPrice(string Side)
        {
            CurrentBook = bitmex.GetOrderBook(ActiveInstrument.Symbol, 1);

            double SellPrice = CurrentBook.Where(a => a.Side == "Sell").FirstOrDefault().Price;
            double BuyPrice = CurrentBook.Where(a => a.Side == "Buy").FirstOrDefault().Price;

            double OrderPrice = 0;

            switch (Side)
            {
                case "Buy":
                    OrderPrice = BuyPrice;

                    if (BuyPrice + ActiveInstrument.TickSize >= SellPrice)
                    {
                        OrderPrice = BuyPrice;
                    }
                    else if (BuyPrice + ActiveInstrument.TickSize < SellPrice)
                    {
                        OrderPrice = BuyPrice + ActiveInstrument.TickSize;
                    }
                    break;
                case "Sell":
                    OrderPrice = SellPrice;

                    if (SellPrice - ActiveInstrument.TickSize <= BuyPrice)
                    {
                        OrderPrice = SellPrice;
                    }
                    else if (SellPrice - ActiveInstrument.TickSize > BuyPrice)
                    {
                        OrderPrice = SellPrice - ActiveInstrument.TickSize;
                    }
                    break;
            }
            return OrderPrice;
        }

        private void MakeOrder(string Side, int Qty, double Price)
        {
          
                    var MakerBuy = bitmex.PostOrderPostOnly(ActiveInstrument.Symbol, Side, Price, Qty);
     
        }

       



        private void ddlNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeAPI();
        }

        private void ddlSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveInstrument = bitmex.GetInstrument(((Instrument)ddlSymbol.SelectedItem).Symbol)[0];
        }

        private void Updates()
        {
            OpenPositions = bitmex.GetOpenPositions(ActiveInstrument.Symbol);
            OpenOrders = bitmex.GetOpenOrders(ActiveInstrument.Symbol);
            
            int? Qty = OpenPositions[0].CurrentQty;

            if (Qty>0 && Stop==0)
            {
                Stop = BasePrice - (Target * 2);
            }
            if (Qty<0 && Stop==0)
            {
                Stop = BasePrice + (Target * 2);
            }

            CurrentBook = bitmex.GetOrderBook(ActiveInstrument.Symbol, 1);

            double SellPrice = CurrentBook.Where(a => a.Side == "Sell").FirstOrDefault().Price;
            double BuyPrice = CurrentBook.Where(a => a.Side == "Buy").FirstOrDefault().Price;

            if (Qty>0 && SellPrice > (BasePrice+Target))
            {
                BasePrice += Target;
                Stop += Target;
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
               
            }

            if (Qty < 0 && BuyPrice < (BasePrice - Target))
            {
                BasePrice -= Target;
                Stop -= Target;
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
            }

            if (Qty>0 && SellPrice<(Stop+5))
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                int Qtyy = Convert.ToInt32(Qty);
                MakeOrder("Sell", (Qtyy * 2), SellPrice);
                System.Threading.Thread.Sleep(3000);
                BasePrice = SellPrice;
                Stop = 0;
                
            }

            if (Qty < 0 && BuyPrice > (Stop - 5))
            {
                bitmex.CancelAllOpenOrders(ActiveInstrument.Symbol);
                int Qtyy = Convert.ToInt32(Qty);
                MakeOrder("Buy", (Qtyy * 2), BuyPrice);
                System.Threading.Thread.Sleep(3000);
                BasePrice = BuyPrice;
                Stop = 0;
            }

        }

        private void tmrUpdater_Tick(object sender, EventArgs e)
        {
           
                Updates();
            
            
        }

        

    

        private void btnAutomatedTrading_Click(object sender, EventArgs e)
        {
            if(btnAutomatedTrading.Text == "Start")
            {
                CurrentBook = bitmex.GetOrderBook(ActiveInstrument.Symbol, 1);
                btnAutomatedTrading.Text = "Stop";
                btnAutomatedTrading.BackColor = Color.Red;
                Running = true;
                txtQty.Enabled = false;
                nudBoxSize.Enabled = false;
                MakeOrder("Buy", Convert.ToInt32(txtQty.Text), CurrentBook.Where(a => a.Side == "Buy").FirstOrDefault().Price);
                BasePrice = OpenPositions[0].AvgEntryPrice;
                Target = Convert.ToInt32(nudBoxSize.Value);
            }
            else
            {
                //tmrAutoTradeExecution.Stop();
                btnAutomatedTrading.Text = "Start";
                btnAutomatedTrading.BackColor = Color.LightGreen;
                Running = false;
                BasePrice = 0;
                Target = 0;
            }
            
        }

      

     

     
    }
}
