using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace StockAlert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string _AlertPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nallware\\StockSoft\\");
        private string _AlertFile = "stockalerts.dat";
        public int level1 = 0, level2 = 0, level3 = 0, level4 = 0;
        public int t1;


        private void Form1_Load(object sender, EventArgs e)
        {   
            if (!Directory.Exists(_AlertPath))
            {
                Directory.CreateDirectory(_AlertPath);
            }
            if (!File.Exists(_AlertPath+_AlertFile))
            {
                using (FileStream fs = File.Create(_AlertPath + _AlertFile))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("spaceholder");
                    fs.Write(info, 0, info.Length);
                }
                //create "blank" alerts.dat
                using (StreamWriter file = new StreamWriter(_AlertPath + _AlertFile))
                {
                    file.WriteLine("GOOGL,1,765.43");
                    file.Close();
                }
            }
            else
            {
                if (new FileInfo(_AlertPath + _AlertFile).Length > 0)
                {                    
                    CheckStocks();
                }
            }

            dgvOrders.RowTemplate.Height = 20;
            dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            timer1.Enabled = true;
                   
        }

        public void CheckStocks()
        {
            dgvOrders.Rows.Clear();
            AlertGroup ag = new AlertGroup();
            ag = AllAlerts();
            foreach (Alert lert in ag)
            {
                string ticker = lert.Ticker;
                decimal current = lert.CurrentSharePrice;
                int shares = lert.Shares;
                decimal cost = lert.PerShareCost;
                decimal tCost = (shares * cost);
                decimal buy = (shares * current);
                decimal one = ((1.0m / shares) + cost);
                decimal twofifty = ((2.5m / shares) + cost);
                decimal five = ((5.0m / shares) + cost);
                decimal ten = ((10.0m / shares) + cost);


                dgvOrders.Rows.Add(ticker, shares, cost, current, one, twofifty, five, ten);
            }
            dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        


        public AlertGroup AllAlerts()
        {
            AlertGroup ag = new AlertGroup();
            var allLines = File.ReadAllLines(_AlertPath+_AlertFile);
            //string[] allLines = allCsv.Split('#');
            foreach (string line in allLines)
            {
                string[] stockdata = line.Split(',');
                Alert lert = new Alert(stockdata[0], CurrentPrice(stockdata[0]), stockdata[1], stockdata[2]);
                ag.Add(lert);
            }
            return ag;
        }

        public decimal CurrentPrice(string tick)
        {
            #region test_tradeking

            //public Manager(string consumerKey,
            //           string consumerSecret,
            //           string token,
            //           string tokenSecret) : this()


            //Manager man = new Manager("Q49jNvQH7gipFo0ItTWn7FWbH8OxrkCFTnXxyuUnniU6", "phSUF8FokqrmWcS6W1TcP2dd7AlN0ull89OyX72CGYs5", "vpcqlZcvmvNbzWdNO9PDHYq6Zf5O4dbe4m4hwrJ59V83", "C3oBVmoKAWZBRzB8UTUpFZQ7ZzjSxnInnSal7g4mXII1");


            //man.NewRequest();
            ////var authzHeader = man.GetAuthorizationHeader(uri, method);

            //var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            //request.Headers.Add("Authorization", authzHeader);
            //request.Method = method;

            //using (var response = (System.Net.HttpWebResponse)request.GetResponse())
            //{
            //    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            //    {
            //        var r = new OAuthResponse(reader.ReadToEnd());
            //        this["token"] = r["oauth_token"];

            //        // Sometimes the request_token URL gives us an access token,
            //        // with no user interaction required. Eg, when prior approval
            //        // has already been granted.
            //        try
            //        {
            //            if (r["oauth_token_secret"] != null)
            //                this["token_secret"] = r["oauth_token_secret"];
            //        }
            //        catch { }
            //    }
            //}

            //https://api.tradeking.com/v1/ac  

            //Q49jNvQH7gipFo0ItTWn7FWbH8OxrkCFTnXxyuUnniU6  //consumer key
            //phSUF8FokqrmWcS6W1TcP2dd7AlN0ull89OyX72CGYs5  //consumer secret
            //vpcqlZcvmvNbzWdNO9PDHYq6Zf5O4dbe4m4hwrJ59V83  //oauth token
            //C3oBVmoKAWZBRzB8UTUpFZQ7ZzjSxnInnSal7g4mXII1  //oauth secret
            #endregion


            string url = "http://finance.yahoo.com/d/quotes.csv?s=STOX&f=l1";
            url = url.Replace("STOX", tick);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return Convert.ToDecimal(results);


           

        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            foreach (DataGridViewRow MyRow in dgvOrders.Rows)
            {
                if (Convert.ToDecimal(MyRow.Cells[3].Value) > 0)
                {
                    if (Convert.ToDecimal(MyRow.Cells[4].Value) <= Convert.ToDecimal(MyRow.Cells[3].Value))
                    {
                        MyRow.Cells[4].Style.BackColor = Color.FromArgb(255, 153, 51);
                        level1++;
                    }
                    if (Convert.ToDecimal(MyRow.Cells[5].Value) <= Convert.ToDecimal(MyRow.Cells[3].Value))
                    {
                        MyRow.Cells[5].Style.BackColor = Color.FromArgb(255, 102, 0);
                        level2++;
                    }
                    if (Convert.ToDecimal(MyRow.Cells[6].Value) <= Convert.ToDecimal(MyRow.Cells[3].Value))
                    {
                        MyRow.Cells[6].Style.BackColor = Color.FromArgb(255, 51, 0);
                        level3++;
                    }
                    if (Convert.ToDecimal(MyRow.Cells[7].Value) <= Convert.ToDecimal(MyRow.Cells[3].Value))
                    {
                        MyRow.Cells[7].Style.BackColor = Color.FromArgb(255, 0, 0);
                        level4++;
                    }
                    if (Convert.ToDecimal(MyRow.Cells[3].Value) >= Convert.ToDecimal(MyRow.Cells[2].Value))
                    {
                        MyRow.Cells[3].Style.ForeColor = Color.FromArgb(255, 0, 0);                        
                    }

                }

                dgvOrders.Columns[2].DefaultCellStyle.Format = "N4";
                dgvOrders.Columns[3].DefaultCellStyle.Format = "N4";
                dgvOrders.Columns[4].DefaultCellStyle.Format = "N4";
                dgvOrders.Columns[5].DefaultCellStyle.Format = "N4";
                dgvOrders.Columns[6].DefaultCellStyle.Format = "N4";
                dgvOrders.Columns[7].DefaultCellStyle.Format = "N4";
                dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        public class Alert : IEnumerable
        {
            private string _ticker;
            private decimal _current_share_price;
            private int _shares;
            private decimal _per_share_cost;

            public string Ticker
            {
                get { return _ticker; }
                set { _ticker = value; }
            }

            public decimal CurrentSharePrice
            {
                get { return _current_share_price; }
                set { _current_share_price = value; }
            }

            public int Shares
            {
                get { return _shares; }
                set { _shares = value; }
            }

            public decimal PerShareCost
            {
                get { return _per_share_cost; }
                set { _per_share_cost = value; }
            }

            public Alert(string ticker, decimal current, int shares, decimal sharePrice)
            {
                Ticker = ticker;
                CurrentSharePrice = current;
                Shares = shares;
                PerShareCost = sharePrice;
            }

            public Alert(object ticker, object current, object shares, object sharePrice)
            {
                Ticker = Convert.ToString(ticker);
                CurrentSharePrice = Convert.ToDecimal(current);
                Shares = Convert.ToInt32(shares);
                PerShareCost = Convert.ToDecimal(sharePrice);
            }

            public Alert(string ticker, string current, string shares, string sharePrice)
            {
                Ticker = ticker;
                CurrentSharePrice = Convert.ToDecimal(current);
                Shares = Convert.ToInt32(shares);
                PerShareCost = Convert.ToDecimal(sharePrice);
            }
            bool IsString(object value)
            {
                return value is string;
            }

            public IEnumerator GetEnumerator()
            {
                //is this correct?
                return this.GetEnumerator();
            }
        }

        [Serializable]
        public class AlertGroup : IEnumerable<Alert>
        {
            private List<Alert> alerts = new List<Alert>();

            public void Add(Alert lert)
            {
                alerts.Add(lert);
            }

            public void Remove(Alert lert)
            {
                alerts.Remove(lert);
            }

            public IEnumerator<Alert> GetEnumerator()
            {
                return alerts.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return alerts.GetEnumerator();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckStocks();
            ShowMessages();
        }

        MessageForm _MF = new MessageForm();
        public void ShowMessages()
        {
            string _msg = "";
            tbMessages.Text = "";
            char _icon = ' ';

            if (level4 > 0)
            {
                if (ckbxHigh.Checked)
                {
                    _msg = "You have some stocks in $10 profit range!!";//level4
                    _icon = 'e';
                    timer1.Interval = 30000;//30 sec=30000
                    _MF.InfoMessage = _msg;
                    _MF.IconForMessage = _icon;
                    _MF.refToForm1 = this;
                    this.Visible = false;
                    _MF.Show();
                }
                else
                {
                    tbMessages.Text = "You have some stocks in $10 profit range!!";
                    timer1.Interval = 60000;
                }


            }
            else if (level3 > 0)
            {
                if (ckbxHigh.Checked)
                {
                    _msg = "You have some stocks in $5 profit range!";//level3
                    _icon = 'i';
                    timer1.Interval = 60000;//1 min=60000
                    _MF.InfoMessage = _msg;
                    _MF.IconForMessage = _icon;
                    _MF.refToForm1 = this;
                    this.Visible = false;
                    _MF.Show();
                }
                else
                {
                    tbMessages.Text = "You have some stocks in $5 profit range!";
                    timer1.Interval = 180000;
                }
            }
            else if (level2 > 0)
            {
                if (ckbxHigh.Checked)
                {
                    _msg = "You have some stocks in $2.50 profit range.";//level2
                    _icon = 'p';
                    timer1.Interval = 180000;//3 mins=180000
                    _MF.InfoMessage = _msg;
                    _MF.IconForMessage = _icon;
                    _MF.refToForm1 = this;
                    this.Visible = false;
                    _MF.Show();
                }
                else
                {
                    tbMessages.Text = "You have some stocks in $2.50 profit range.";
                    timer1.Interval = 300000;
                }
            }
            else if (level1 > 0)
            {
                if (ckbxHigh.Checked)
                {
                    _msg = "You have some stocks in $1 profit range.";//level1
                    _icon = 'h';
                    timer1.Interval = 300000; //5 mins=300000
                    _MF.InfoMessage = _msg;
                    _MF.IconForMessage = _icon;
                    _MF.refToForm1 = this;
                    this.Visible = false;
                    _MF.Show();
                }
                else
                {
                    tbMessages.Text = "You have some stocks in $1 profit range.";
                    timer1.Interval = 600000;
                }
            }
            level1 = 0;
            level2 = 0;
            level3 = 0;
            level4 = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //delete old files
            string dir = _AlertPath;
            var files = new DirectoryInfo(dir).GetFiles("*.bak");
            foreach (var file in files)
            {
                if (DateTime.UtcNow - file.CreationTimeUtc > TimeSpan.FromDays(5))
                {
                    File.Delete(file.FullName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAlertData();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        public void SaveAlertData()
        {
            StreamWriter file = new StreamWriter(_AlertPath+_AlertFile);
            
            foreach(DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length > 0)
                {
                    file.WriteLine(row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() +
                        "," + row.Cells[2].Value.ToString());
                }
            }
            file.Close();
            MessageBox.Show("Your alerts have been saved to settings.");
            File.Copy(_AlertPath+_AlertFile, _AlertPath+BackupFile(), true);

        }

        public string BackupFile()
        {
            //Guid gd = new Guid();
            return "alert" + Guid.NewGuid().ToString() + ".bak";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {            
            CheckStocks();
            ShowMessages();
            timer1.Enabled = true;
        }
    }
    
}

