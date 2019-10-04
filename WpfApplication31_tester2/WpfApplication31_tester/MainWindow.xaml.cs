using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


using System.Data;

//using System.Data.SQLite;
using System.IO;
using System.Drawing.Printing;
using System.Security.Permissions;
using System.Windows.Controls.Primitives;
using System.Collections.Specialized;


namespace WpfApplication31_tester2
{

    public partial class MainWindow : Window
    {

        //********************************************************
        //databse sqlite operations
        //********************************************************
        //private SQLiteConnection sql_con;
        //private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private int i = 0;

        //private SQLiteDataAdapter DBswitch;
        private DataSet DSswitch = new DataSet();
        private DataTable DTswitch = new DataTable();

        //private SQLiteDataAdapter DBinfo;
        private DataSet DSinfo = new DataSet();
        private DataTable DTinfo = new DataTable();

        //private SQLiteDataAdapter DBconnessioni;
        private DataSet DSconnessioni = new DataSet();
        private DataTable DTconnessioni = new DataTable();

        //private void LoadData()
        //{
        //    update();
        //}
        private void SetConnection()
        {
            String s;
            s = WpfApplication31_tester2.Properties.Settings.Default.DBFileName;
            //sql_con = new SQLiteConnection("Data Source=data.sqlite;Version=3;New=False;Compress=True;");
        }
        bool DBbuilding = false;
        void buildDB()
        {
            DBbuilding = true;
            Console.WriteLine("please wait about 5 seconds while build data.sqlite ...");
            // da usare se non esiste la tabella di base   dati.sqlite

            string s1 = @" 

drop table if exists led;
  CREATE TABLE  [led] (   
  [id] INTEGER, 
  [n0] INTEGER,
  [n1] INTEGER,
  [n2] INTEGER,
  [n3] INTEGER,
  [n4] INTEGER,
  [n5] INTEGER,
  [n6] INTEGER,
  [n7] INTEGER,
  [n8] INTEGER,
  [n9] INTEGER  );
insert into  led   values (0,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (1,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (2,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (3,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (4,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (5,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (6,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (7,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (8,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (9,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (10,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (11,0,0,0,0,0,0,0,0,0,0);
insert into  led   values (12,0,0,0,0,0,0,0,0,0,0);

DROP TABLE if exists switch;
CREATE TABLE [switch] (
  [id] INTEGER, 
  [n0] INTEGER,
  [n1] INTEGER, 
  [n2] INTEGER,
  [n3] INTEGER,
  [n4] INTEGER,
  [n5] INTEGER,
  [n6] INTEGER,
  [n7] INTEGER,
  [n8] INTEGER, 
  [n9] INTEGER );

insert into  switch   values (0,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (1,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (2,0,0,0,0,0,0,0,0,0,0);
insert into  switch  values (3,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (4,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (5,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (6,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (7,0,0,0,0,0,0,0,0,0,0);
insert into switch   values (8,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (9,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (10,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (11,0,0,0,0,0,0,0,0,0,0);
insert into  switch   values (12,0,0,0,0,0,0,0,0,0,0);



DROP TABLE if exists connessioni;
CREATE TABLE [connessioni] (
  [id] INTEGER, 
  [n0] INTEGER,
  [n1] INTEGER, 
  [n2] INTEGER,
  [n3] INTEGER,
  [n4] INTEGER,
  [n5] INTEGER,
  [n6] INTEGER,
  [n7] INTEGER,
  [n8] INTEGER, 
  [n9] INTEGER );

insert into  connessioni   values (0,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (1,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (2,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni  values (3,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (4,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (5,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (6,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (7,0,0,0,0,0,0,0,0,0,0);
insert into connessioni   values (8,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (9,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (10,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (11,0,0,0,0,0,0,0,0,0,0);
insert into  connessioni   values (12,0,0,0,0,0,0,0,0,0,0);


drop table if exists informazioni;
CREATE TABLE [informazioni] (
  [tipo] TEXT(16), 
  [codice] TEXT(16), 
  [data] TEXT(16), 
  [varie] TEXT(64));
insert  into informazioni values(""x"",""x"",""x"",""x""); 

  ";

            //ExecuteQuery(s1);

            //DBbuilding = false;
            Console.WriteLine("ok, done.");

        }
        //private void ExecuteQuery(string txtQuery)
        //{
        //    SetConnection();
        //    sql_con.Open();

        //    sql_cmd = sql_con.CreateCommand();
        //    sql_cmd.CommandText = txtQuery;

        //    try
        //    {
        //        sql_cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception s)
        //    {
        //        Console.WriteLine("sql query error: " + s);
        //    }
        //    sql_con.Close();
        //}
        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                i = Convert.ToInt32(DT.Rows[Grid.SelectedIndex]["id"]);

                String i1 = (DT.Rows[Grid.SelectedIndex]["n2"]).ToString();

                //Object 02 = new Object ("cippo");
                // DT.Rows[Grid.SelectedIndex]["n2"] = "cippo";

                Object o1 = DT.Rows[Grid.SelectedIndex]["n2"];
                String i2 = o1.ToString();

                Console.WriteLine("id:" + i);
                Console.WriteLine("col:" + i1);
                Console.WriteLine("obj:" + i2);
            }
            catch
            {
                return;
            };

            Console.WriteLine(i);
        }
        //void dbset(String tipo, int i, int state)
        //{
        //    //            string txtSQLQuery = "update  mains set  name =\"" + txtDesc.Text + "\" where id =" + i;
        //    string txtSQLQuery = ""; // "update  led set  n5 = \"" + txtDesc.Text + "\"    where id =" + 4;

        //    var watch = Stopwatch.StartNew();

        //    SetConnection();
        //    sql_con.Open();

        //    sql_cmd = sql_con.CreateCommand();

        //    String s1 = "swicth";
        //    if (tipo == "B") s1 = "switch";
        //    if (tipo == "L") s1 = "led";

        //    int r, c;

        //    r = i / 10;
        //    c = i % 10;

        //    txtSQLQuery = "update " + s1 + " set  n" + c + "=" + state + " where id =" + r;
        //    Console.WriteLine(txtSQLQuery);

        //    sql_cmd.CommandText = txtSQLQuery;

        //    try
        //    {
        //        sql_cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception s)
        //    {
        //        Console.WriteLine("sql query error: " + s);
        //    }

        //    sql_con.Close();

        //    watch.Stop();

        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine("ms: " + elapsedMs);

        //}
        //private void Edit()
        //{
        //    //            string txtSQLQuery = "update  mains set  name =\"" + txtDesc.Text + "\" where id =" + i;
        //    string txtSQLQuery = ""; // "update  led set  n5 = \"" + txtDesc.Text + "\"    where id =" + 4;

        //    var watch = Stopwatch.StartNew();

        //    SetConnection();
        //    sql_con.Open();

        //    sql_cmd = sql_con.CreateCommand();


        //    // the code that you want to measure comes here
        //    int r, c;
        //    for (r = 0; r <= 5; r++)
        //    {
        //        for (c = 1; c < 11; c++)
        //        {
        //            //ExecuteQuery(txtSQLQuery);

        //            txtSQLQuery = "update  led set  n" + c + "= \"" + (r * 20 + c) + "\"    where id =" + r;
        //            Console.WriteLine(txtSQLQuery);

        //            sql_cmd.CommandText = txtSQLQuery;

        //            try
        //            {
        //                sql_cmd.ExecuteNonQuery();
        //            }
        //            catch (Exception s)
        //            {
        //                Console.WriteLine("sql query error: " + s);
        //            }

        //            //ExecuteQuery(txtSQLQuery);
        //        }
        //    }

        //    sql_con.Close();

        //    watch.Stop();

        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine("ms: " + elapsedMs);
        //}
        private void Grid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Console.WriteLine("--qui01--");
            //int index = Grid.SelectedCells[3].Column.DisplayIndex;
            //index = Grid.CurrentColumn.DisplayIndex;

            //Console.WriteLine("col:" + index);

            var currentRowIndex = Grid.Items.IndexOf(Grid.CurrentItem);
            Console.WriteLine("row:" + currentRowIndex);

            //System.Data.DataRowView item = new System.Data.DataRowView();
            //var item = Grid.Items[currentRowIndex];

            //item = Grid.CurrentItem;
            //var rowObject = item as DataRowView;
            //var array = rowObject.Row.ItemArray;
            //foreach (object s in array)
            //{
            //    Console.WriteLine("row item:" + s + " " + s.GetType());
            //}
        }
        private void Grid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            Console.WriteLine("--qui02--");
            //int col = Convert.ToInt32(Grid.Current
            //String item = Convert.ToString(Grid.CurrentItem);
            //String cell = Convert.ToString(Grid.CurrentCell);
            //Console.WriteLine("col:"+col+ "item:"+item+" cell:" + cell);
            //Grid.Columns[3].Width = 200;

            //Console.WriteLine("pos:" + i1);
            int index = Grid.SelectedCells[3].Column.DisplayIndex;
            index = Grid.CurrentColumn.DisplayIndex;

            Console.WriteLine("col:" + index);

            var currentRowIndex = Grid.Items.IndexOf(Grid.CurrentItem);
            Console.WriteLine("row:" + currentRowIndex);

            //System.Data.DataRowView item = new System.Data.DataRowView();
            var item = Grid.Items[0]; //currentRowIndex];

            item = Grid.CurrentItem;
            var rowObject = item as DataRowView;
            var array = rowObject.Row.ItemArray;
            foreach (object s in array)
            {
                Console.WriteLine("row item:" + s); //+ " " + s.GetType());
            }
            //foreach (DataGridViewRow row in Grid.SelectedRows)
            //{
            //    var rowObject = row.DataBoundItem as DataRowView;
            //    var array = rowObject.Row.ItemArray;
            //}


            //DB.Update(DS);
        }
        private void buttPrint(object sender, RoutedEventArgs e)
        {

            Color c1, c2;
            c1 = Color.FromRgb(50, 50, 50);
            c2 = Color.FromRgb(200, 200, 200);
            LinearGradientBrush gradientBrush0 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            c1 = Color.FromRgb(0, 200, 0);
            c2 = Color.FromRgb(0, 250, 0);
            LinearGradientBrush gradientBrush1 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            c1 = Color.FromRgb(150, 0, 0);
            c2 = Color.FromRgb(200, 0, 0);
            LinearGradientBrush gradientBrush2 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            int rn = 0;
            int cn = 0;

            int[] av = new int[20];

            for (rn = 0; rn < 13; rn++)
            {
                var item = gridSwitch.Items[rn]; //currentRowIndex];
                var rowObject = item as DataRowView;
                var array = rowObject.Row.ItemArray;
                int value;
                cn = 0;
                String ssb;
                int bn;

                for (cn = 0; cn < 10; cn++)
                {

                    object s = array[cn + 1];

                    Console.WriteLine("row: " + rn + " col:" + cn + " :" + s); //+ " " + s.GetType());


                    value = 0;
                    try
                    {
                        Int64 v = Convert.ToInt64(s);
                        value = (int)v;
                    }
                    catch
                    {
                        //value = 0;
                    }

                    //****************** grid to keyboard
                    bn = rn * 10 + cn;
                    ssb = String.Format("B{0:d03}", bn);
                    var bt = (Button)this.FindName(ssb);
                    if (bt != null)
                    {
                        switch (value)
                        {
                            case 0: bt.Background = gradientBrush0; break;
                            case 1: bt.Background = gradientBrush1; break;
                            case 2: bt.Background = gradientBrush2; break;

                        }
                    }
                    //*****************************


                }

            }

        }
        private void buttUpdate(object sender, RoutedEventArgs e)
        {
            //update();
        }
        //private void update()
        //{

        //    if (File.Exists("data.sqlite") == false)
        //    {
        //        buildDB();
        //    }


        //    SetConnection();
        //    sql_con.Open();

        //    sql_cmd = sql_con.CreateCommand();
        //    string CommandText = "select id,n0,n1,n2,n3,n4,n5,n6,n7,n8,n9 from  switch";
        //    DBswitch = new SQLiteDataAdapter(CommandText, sql_con);
        //    DSswitch.Reset();

        //    DBswitch.Fill(DSswitch);
        //    DTswitch = DSswitch.Tables[0];

        //    int nc = DTswitch.Columns.Count;
        //    int nr = DTswitch.Rows.Count;
        //    Console.WriteLine("DTswitch nc:" + nc + " nr:" + nr);

        //    //IEnumerable<DataRow> query =   from product DTswitch.AsEnumerable()   select product;



        //    gridSwitch.ItemsSource = DTswitch.DefaultView;

        //    CommandText = "select id,n0,n1,n2,n3,n4,n5,n6,n7,n8,n9 from  led";
        //    DB = new SQLiteDataAdapter(CommandText, sql_con);
        //    DS.Reset();
        //    DB.Fill(DS);
        //    DT = DS.Tables[0];
        //    Grid.ItemsSource = DT.DefaultView;

        //    CommandText = "select id,n0,n1,n2,n3,n4,n5,n6,n7,n8,n9 from  connessioni";
        //    DBconnessioni = new SQLiteDataAdapter(CommandText, sql_con);
        //    DSconnessioni.Reset();
        //    DBconnessioni.Fill(DSconnessioni);
        //    DTconnessioni = DSconnessioni.Tables[0];
        //    gridConnessioni.ItemsSource = DTconnessioni.DefaultView;

        //    CommandText = "select tipo,codice,data,varie from  informazioni";
        //    DBinfo = new SQLiteDataAdapter(CommandText, sql_con);
        //    DSinfo.Reset();
        //    DBinfo.Fill(DSinfo);
        //    DTinfo = DSinfo.Tables[0];
        //    gridInfo.ItemsSource = DTinfo.DefaultView;


        //    var item = gridInfo.Items[0]; //currentRowIndex];
        //    var rowObject = item as DataRowView;
        //    var array = rowObject.Row.ItemArray;
        //    txtTipo.Text = (String)array[0];
        //    txtCodice.Text = (String)array[1];
        //    txtData.Text = (String)array[2];
        //    txtVarie.Text = (String)array[3];



        //    sql_con.Close();


        //}
        private void buttNew_Click(object sender, RoutedEventArgs e)
        {
            buildDB();
        }

        private void buttLoad(object sender, RoutedEventArgs e)
        {

            String fn = "";

            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Title = "Select database sqlite";
            fileDialog.InitialDirectory = "";
            fileDialog.Filter = "(*.sqlite)|*.sqlite";
            //fileDialog.Filter = @"(*.sqlite)|*.sqlite";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            var result = fileDialog.ShowDialog();

            if (result == false)
            {
                return;
            }


            fn = fileDialog.FileName;
            String curDir = System.IO.Path.GetDirectoryName(fn);
            Console.WriteLine(fn + "\r\n" + curDir);

            File.Delete(@"data.sqlite");
            File.Copy(fn, @"data.sqlite");
            lblFileName.Content = fn;
            DBFileName = fn;

            string newDir = @"D:\temp";
            string curFile = System.IO.Path.GetFileName(fn);
            string newPathToFile = System.IO.Path.Combine(newDir, curFile);
            // Console.WriteLine(newPathToFile);
            //update();
        }
        private void butSave(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //dlg.FileName = "database"; // Default file name
            dlg.DefaultExt = ".sqlite"; // Default file extension
            dlg.Filter = " (.sqlite)|*.sqlite"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filenameSave = dlg.FileName;
                Console.WriteLine(filenameSave);

                lblFileName.Content = filenameSave;
                DBFileName = filenameSave;
                String s1 = filenameSave + ".bak";
                try
                {

                    if (File.Exists(filenameSave))
                    {
                        //----- bakup
                        if (File.Exists(s1))
                        {
                            File.Delete(s1);
                        }
                        File.Copy(filenameSave, s1);
                        //--------
                        File.Delete(filenameSave);
                    }
                    File.Copy(@"data.sqlite", filenameSave);
                }
                catch (Exception sx)
                {
                    //Console.WriteLine(sx);
                    String xx;
                    xx = sx.Message;
                    MessageBox.Show(xx);
                }

            }

        }
        //********************************************************
        //*****************************************************


        string[] bands = { "ACDC", "Queen", "Aerosmith", "Iron Maiden", "Megadeth", "Metallica", "Cream", "Oasis", "Abba", "Blur", "Chic", "Eurythmics", "Genesis", "INXS", "Midnight Oil", "Kent", "Madness", "Manic Street Preachers", "Noir Desir", "The Offspring", "Pink Floyd", "Rammstein", "Red Hot Chili Peppers", "Tears for Fears", "Deep Purple", "KISS" };


        [DllImport("kernel32")]
        static extern bool AllocConsole();
        [DllImport("kernel32")]
        static extern bool FreeConsole();

        System.IO.Ports.SerialPort SerialPort1;


        static uint tcount1 = 0;
        private Thread trd1;
        private Thread trd2;
        private Thread trd3;
        private Thread trd4;
        private Thread trd5;
        private Thread trd6;
        private Thread trd7;

        private int xtrd1;
        private int xtrd2;
        private int xtrd3;
        private int xtrd4;
        private int xtrd5;
        private int xtrd6;
        private int xtrd7;

        //UDPListener CLudp1 = new UDPListener();

        TcpServer ObjTcpServer = new TcpServer();


        private Mutex mut = new Mutex();

        public static string udpRx = "{\"check\":\"2\"}";

        public MainWindow()
        {
            InitializeComponent();

            //Label l1 = new Label();
            //led.label[0] = l1;
            //Rectangle r1 = new Rectangle();
            //r1.Width = 9;
            //led.r1[0] = r1;
            //double w;
            //w = led.r1[0].Width;

            for (int i = 0; i < 1000; i++)
            {
                led.r1[i] = new Rectangle();
                led.label[i] = new Label();
            }

            int idx;
            for (int j = 0; j < 16; j++)
            {
                cv2.Children.Add(led.label[j]);
                for (int i = 0; i < 8; i++)
                {
                    idx = j * 8 + i;
                    cv2.Children.Add(led.r1[idx]);
                }
            }
            for (int j = 0; j < 16; j++)
            {
                idx = 256 + j;
                cv2.Children.Add(led.label[idx]);
                for (int i = 0; i < 8; i++)
                {
                    idx = 256 + j * 8 + i;
                    cv2.Children.Add(led.r1[idx]);
                }
            }

            Uri iconUri = new Uri(".\\image1.ico", UriKind.RelativeOrAbsolute);

            this.Icon = BitmapFrame.Create(iconUri);

            AllocConsole();

            Console.WriteLine(this.Width);
            Console.WriteLine(this.Height);

            SerialPort1 = new System.IO.Ports.SerialPort();
            listCom();



            trd1 = new Thread(ThreadReadSerial);
            trd1.Start();

            trd2 = new Thread(ThreadElabora);
            trd2.Start();

            trd3 = new Thread(ThreadSendSerial);
            trd3.Start();

            trd4 = new Thread(ThreadTimer);
            trd4.Start();

            //trd5 = new Thread(ThreadUdp);
            //trd5.Start();

            trd6 = new Thread(ThreadUdpServer);
            trd6.Start();


            //trd7 = new Thread(TcpServer);
            //trd7.Start();




            //CLudp1.StartListener(600);


            // 4 timers: 0: 1 secondo , 1:send cmnd,  2:aggiorna visualizzazione,   3: swing frequency

            dispatcherTimer0.Tick += new EventHandler(dispatcherTimer0_Tick);
            dispatcherTimer0.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer0.Start();

            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 0, 0, 10); // 100msec 200000);
            dispatcherTimer1.Start();


        }


        #region Timers
        int timer0 = 0;
        DispatcherTimer dispatcherTimer0 = new DispatcherTimer();
        private void dispatcherTimer0_Tick(object sender, EventArgs e)
        {
            timer0++;
            lbl0.Content = timer0 + " " + timer1;
            timer1 = 0;

            //***************************************
            int v;
            v = 0;
            try
            {
                v = Convert.ToInt32(tbSwTime.Text);
            }
            catch
            {
                v = 0;
            }
            TimeSpan ts1 = new TimeSpan();
            TimeSpan ts2 = new TimeSpan();
            TimeSpan time1 = TimeSpan.FromSeconds(v);
            ts1 = sw.Elapsed;
            ts2 = ts1.Add(time1);
            DateTime dt1 = new DateTime();
            dt1 = Convert.ToDateTime(ts2.ToString());
            //***************************************

            //dt1.ToString("HH:mm:ss")

            lblSw.Content = dt1.ToString("HH:mm:ss");
            lblDateTime.Content = DateTime.Now.ToString();
            lblSwTest.Content = "sw ok: " + dati.numSw + " su " + dati.totSw;

            swOkPrec = swOk;
            swOk = (dati.numSw == dati.totSw);
            if ((swOk != swOkPrec) && (swOk == true))
            {
                //tbSwitch.Text = "OK";
                CbTasti.IsChecked = true;
            }
            if ((swOk != swOkPrec) && (swOk == false))
            {
                //tbSwitch.Text = "---";
                CbTasti.IsChecked = false;
            }
        }


        bool swOk, swOkPrec;



        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);



        //int lblNewCnt = 0;
        //String lblNewString = "-\\|/";
        int timer1 = 0;
        int timer1_lbserial = 0;
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
            timer1++;


            if(timer1_lbserial>0){
                timer1_lbserial--;
                if (timer1_lbserial == 0)
                {
                    //LB_serial.SelectedIndex = LB_serial.Items.Count - 1;

                    //LB_serial.UpdateLayout();

                    //LB_serial.ScrollIntoView(LB_serial.SelectedItem);
                    
                    //LB_serial.Items.MoveCurrentToLast();
                    //LB_serial.ScrollIntoView(LB_serial.Items.CurrentItem);
                    //LB_serial.Items.Refresh();
                }
            }


            //if (DBbuilding == true)
            //{
            //    lblNewCnt = ((lblNewCnt+1)&3);
            //    lblNew.Content=lblNewString.Substring (lblNewCnt,1);
            //}else{
            //    lblNew.Content="";
            //}




            Point p = Mouse.GetPosition(cv2); //canvas1);
            //bool b = E001.IsMouseDirectlyOver;
            bool b = B001.IsMouseOver;



            //VK_LBUTTON = 0x01
            //short v1 =  GetAsyncKeyState(1);  //it work for all screen

            double x = Canvas.GetLeft(E001);
            double y = Canvas.GetTop(E001);
            //bool b1 = IsWithinCircle((int)x, (int)y, (int)p.X, (int)p.Y, 10);


            bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed; // work for this window


            lbl1.Content = p + "," + b + "," + x + "," + y + "," + "," + mouseIsDown;


            chk1();
            drawByteSet();

            dati.plcOut[0] += 1;

        }
        #endregion


        // these are the name-number of each button (there are 63 button)
        int[] Kbn = new int[] { 
            1, 2, 3, 4,5,6,7,8,9,
            10,11, 12, 13, 14,15,16,17,18,19,
            20,21, 22, 23, 24,25,26,27,28,29, 
            30,31, 32, 33, 34,35,36,37,38,39, 
            40,41,     43, 44,45,46,47,48,49, 
            101, 102, 103, 104,105,106,107,108,109,110,111,112,113,114,115,
 
            120,121,122,123,124,125,

            130,131,132,133,134

            };

        bool[] Bprev = new bool[228];
        bool[] Bcurr = new bool[228];
        bool[] Bklik = new bool[228];
        int[] Bstate = new int[228];

        bool[] Lprev = new bool[228];
        bool[] Lcurr = new bool[228];
        bool[] Lklik = new bool[228];
        int[] Lstate = new int[228];

        bool[] Eprev = new bool[228];
        bool[] Ecurr = new bool[228];
        bool[] Eklik = new bool[228];
        int[] Estate = new int[228];


        int defBKlik(int i, bool b)
        {
            string ls;
            Bprev[i] = Bcurr[i];
            Bcurr[i] = b;
            Bklik[i] = b & (Bcurr[i] ^ Bprev[i]);
            if (Bklik[i])
            {
                //if (buttRkliTest)
                if (Bstate[i] == 3)
                {
                    buttRkliTest = false;
                    dati.switchInTest = 0;
                    Console.WriteLine("test button " + i + " off");


                    //ls = string.Format(",0,{0:d},7,.", i);
                    //ls = padStringCrc(ls);
                    //dati.qe.Enqueue(ls);
                }
                Bstate[i]++;
                if (Bstate[i] >= 3) Bstate[i] = 0;
            }
            return Bstate[i];
        }

        //**************** tasto destro mouse, per richiesta test tasto tasiera 
        bool lastButtRklik;
        bool currButtRklik;
        bool buttRkliTest = false;
        void defBKlikR(int i, bool b)
        {
            string ls, s;

            lastButtRklik = currButtRklik;
            currButtRklik = b;
            bool press;
            press = (lastButtRklik != currButtRklik) && (currButtRklik);


            if (press)
            {
                //if (Bklik[i]){

                //Bprev[i] = Bcurr[i];
                //Bcurr[i] = b;
                //Bklik[i] = b & (Bcurr[i] ^ Bprev[i]);


                //if (!buttRkliTest)
                if (Bstate[i] != 3)
                {
                    Bklik[i] = true;
                    Bstate[i] = 3; // test mode
                    buttRkliTest = true;
                    //dati.switchInTest = i;
                    Console.WriteLine("test button " + i + " on");


                    //ls = string.Format(",1,{0:d},7,.", i);
                    //ls = padStringCrc(ls);
                    //dati.qe.Enqueue(ls);
                }
                //else
                //{
                //    Bklik[i] = true;
                //    Bstate[i] = 0; // test mode off
                //    buttRkliTest = false;
                //    //dati.switchInTest = 0;
                //    Console.WriteLine("test button " + i+ " off");
                //    ls = string.Format("(|,0,{0:d},7,. ,0,{0:d},12,.)S", i);
                //    dati.qe.Enqueue(ls);
                //}
            }
        }
        //******************************************

        int defLKlik(int i, bool b)
        {
            Lprev[i] = Lcurr[i];
            Lcurr[i] = b;
            Lklik[i] = b & (Lcurr[i] ^ Lprev[i]);
            if (Lklik[i])
            {
                Lstate[i]++;
                if (Lstate[i] >= 3) Lstate[i] = 0;
            }
            return Lstate[i];
        }
        int defEKlik(int i, bool b)
        {
            Eprev[i] = Ecurr[i];
            Ecurr[i] = b;
            Eklik[i] = b & (Ecurr[i] ^ Eprev[i]);
            if (Eklik[i])
            {
                Estate[i]++;
                if (Estate[i] >= 2) Estate[i] = 0;
            }
            return Estate[i];
        }


        // implement button, ellipse(led), label  click
        // 2 array on boolean : previous actual, clik  for each type.
        // common klik action for each type
        // label toogle test ok fail skip
        // led toggle totest fail ok
        // button toggle state:  toTest  tested
        //-------
        // for each element save current state and load current state - set klik flag

        bool lastSerialState = false;

        void chk1()
        {


            if (lastSerialState != SerialPort1.IsOpen)
            {
                lastSerialState = SerialPort1.IsOpen;

                if (SerialPort1.IsOpen == true)
                {
                    lblCOM.Foreground = new SolidColorBrush(Colors.Green);
                    lblCOM.Content = serialName + " connected";
                }
                else
                {
                    lblCOM.Foreground = new SolidColorBrush(Colors.Red);
                    lblCOM.Content = serialName + " disconnected";
                }
            }





            Color c1, c2;
            c1 = Color.FromRgb(50, 50, 50);
            c2 = Color.FromRgb(200, 200, 200);
            LinearGradientBrush gradientBrush0 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            c1 = Color.FromRgb(0, 200, 0);
            c2 = Color.FromRgb(0, 250, 0);
            LinearGradientBrush gradientBrush1 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            c1 = Color.FromRgb(150, 0, 0);
            c2 = Color.FromRgb(200, 0, 0);
            LinearGradientBrush gradientBrush2 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            //tipo cyan
            c1 = Color.FromRgb(0, 100, 100);
            c2 = Color.FromRgb(0, 200, 200);
            LinearGradientBrush gradientBrush3 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            //gradientBrush2.StartPoint = new Point(0, 0);
            //gradientBrush2.EndPoint = new Point(1, 1);
            //// http://www.c-sharpcorner.com/uploadfile/mahesh/wpf-lineargradientbrush/
            //GradientStop orangeGS = new GradientStop();
            //orangeGS.Color = Colors.Orange;
            //orangeGS.Offset = 0.25;
            //gradientBrush2.GradientStops.Add(orangeGS);
            //GradientStop yellowGS = new GradientStop();
            //yellowGS.Color = Colors.Yellow;
            //yellowGS.Offset = 0.50;
            //gradientBrush2.GradientStops.Add(yellowGS);
            //*********************

            string s, ls;
            int state;
            bool forceState = false;

            int percentualeSwOk;
            int numSw;
            int totSw;


            totSw = 0;
            numSw = 0;

            foreach (int i in Kbn)
            {
                //****** button
                s = String.Format("B{0:d03}", i);
                var bt = (Button)this.FindName(s);
                if (bt != null)
                {
                    bool b1 = bt.IsMouseOver;
                    bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed; // work for this window
                    bool mouseIsDownRight = System.Windows.Input.Mouse.RightButton == MouseButtonState.Pressed; // work for this window


                    totSw++;
                    if (Bstate[i] == 1)
                    {
                        numSw++;
                    }



                    forceState = false;
                    state = 0;
                    if (Bstate[i] == 3)
                    {
                        //state = 3;
                        if (dati.switchPremuto == i)
                        {
                            dati.switchPremuto = 0;
                            Bstate[i] = 1;
                            state = 1;
                            forceState = true;
                            Bklik[i] = true;
                            b1 = true;


                            //ls = string.Format(",0,{0:d},7,.", i);
                            //ls = padStringCrc(ls);
                            //dati.qe.Enqueue(ls);
                        }
                    }



                    if (b1 == true)
                    {

                        if (forceState == false)
                        {
                            state = defBKlik(i, mouseIsDown);   // questo
                            defBKlikR(i, mouseIsDownRight);         // e questo devono stare in questo ordine
                        }


                        if (Bklik[i])
                        {
                            Console.WriteLine("B" + i + ":" + state);




                            //dbset("B", i, state);

                            switch (Bstate[i])
                            {
                                case 0: bt.Background = gradientBrush0; break;
                                case 1: bt.Background = gradientBrush1; break;
                                case 2: bt.Background = gradientBrush2; break;
                                case 3: bt.Background = gradientBrush3; break; // test mode - cyan

                            }
                        }






                    }
                }

                //******* label
                s = String.Format("L{0:d03}", i);
                var lt = (Label)this.FindName(s);
                if (lt != null)
                {
                    bool b1 = lt.IsMouseOver;
                    bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed; // work for this window
                    if (b1 == true)
                    {
                        state = defLKlik(i, mouseIsDown);

                        if (Lklik[i])
                        {
                            Console.WriteLine("L" + i + ":" + state);
                            //dbset("L", i, state);
                            switch (Lstate[i])
                            {
                                case 0: lt.Background = new SolidColorBrush(Colors.Yellow); lt.Content = "TEST"; break;
                                case 1: lt.Background = new SolidColorBrush(Colors.LightGreen); lt.Content = "PASS"; break;
                                case 2: lt.Background = new SolidColorBrush(Colors.Red); lt.Content = "FAIL"; break;
                                case 3: lt.Background = new SolidColorBrush(Colors.Cyan); lt.Content = "SKIP"; break;

                            }
                        }

                    }
                }
                //******* ellipse
                s = String.Format("E{0:d03}", i);
                var et = (Ellipse)this.FindName(s);
                if (et != null)
                {


                    ////******************** visualizza led
                    //int index;
                    //bool lon;
                    //index = i;
                    //if(index > 101) index = (index-101)+50;
                    //index &= 0x3f;
                    //lon = (dati.ledArray[index >>3] & (1<<(index & 7)))!=0;
                    //if(lon==true){
                    //    et.Visibility=Visibility.Visible;
                    //}else{
                    //    et.Visibility=Visibility.Hidden;
                    //}
                    ////*******************************







                    bool b1 = et.IsMouseOver;
                    bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed; // work for this window
                    if (b1 == true)
                    {
                        state = defEKlik(i, mouseIsDown);

                        if (Eklik[i])
                        {
                            Console.WriteLine("E" + i + ":" + state);

                            ls = string.Format("(|,2,{0},7,.)S", i);
                            dati.qe.Enqueue(ls);

                            if (modeFanuc == 1)
                            {
                                switch (i)
                                {
                                    case 120:
                                        ls = string.Format("(|,2,21,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 121:
                                        ls = string.Format("(|,2,27,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 122:
                                        ls = string.Format("(|,2,26,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 123:
                                        ls = string.Format("(|,2,28,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 124:
                                        ls = string.Format("(|,2,49,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 125:
                                        ls = string.Format("(|,2,16,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                }
                            }
                            else
                            {

                                switch (i)
                                {
                                    case 120:
                                        ls = string.Format("(|,2,21,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 121:
                                        ls = string.Format("(|,2,27,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 122:
                                        ls = string.Format("(|,2,26,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 123:
                                        ls = string.Format("(|,2,28,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 124:
                                        ls = string.Format("(|,2,49,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                    case 125:
                                        ls = string.Format("(|,2,16,7,.)S", i);
                                        dati.qe.Enqueue(ls);
                                        break;
                                }

                            }
                        }

                    }
                }
                //*****************

            }

            dati.switchPremuto = 0;
            dati.totSw = totSw;
            dati.numSw = numSw;

        }


        //bool IsWithinCircle(int centerX, int centerY, int mouseX, int mouseY, double radius)
        //{
        //    int diffX = centerX+(int)(radius/2) - mouseX;
        //    int diffY = centerY+(int)(radius/2) - mouseY;
        //    return (diffX * diffX + diffY * diffY) <= radius * radius;
        //}


        static string serialName;

        public void listCom()
        {
            string s = null;
            ComboBox1.Items.Clear();

            Console.WriteLine("------");
            foreach (string sp in Microsoft.Win32.Registry.LocalMachine.GetSubKeyNames())
            {
                Console.WriteLine(sp);
            }
            Console.WriteLine("------");

            Microsoft.Win32.RegistryKey x = default(Microsoft.Win32.RegistryKey);
            x = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Hardware\\devicemap\\serialcomm", false);
            try
            {
                foreach (string sp in x.GetValueNames())
                {
                    object s1 = null;
                    string s2 = null;
                    string s3 = null;
                    s1 = x.GetValue(sp);
                    s2 = s1.ToString();
                    s3 = (s2 + "     :" + sp);
                    // lasciare i 5 blank, mi serve per dopo
                    Console.WriteLine(s3);
                    ComboBox1.Items.Add(s3);
                }
            }
            catch (Exception ex1)
            {
                Console.WriteLine("no serial comm");
            }

            Console.WriteLine("------");


            //For Each sp As String In My.Computer.Ports.SerialPortNames
            //    ComboBox1.Items.Add(sp)
            //    Console.WriteLine(sp)
            //Next

            int i = 0;
            //n = ComboBox1.Items.Count - 1

            i = WpfApplication31_tester2.Properties.Settings.Default.comIndex;
            //indiceCom = i;
            //ricarica indice com

            //If i <= n Then
            //ComboBox1.SelectedIndex = i
            //s = ComboBox1.SelectedItem

            s = "COM" + i.ToString();
            serialName = s;
            Console.WriteLine(serialName);

            dati.serialError = 0;



            if (dati.serialRequestClose == 0)
            {
                try
                {
                    SerialPort1.Close();
                    SerialPort1.PortName = serialName;
                    SerialPort1.BaudRate = 460800;
                    SerialPort1.ReadTimeout = 10;

                    SerialPort1.Open();
                }
                catch
                {
                    //dati.serialError = 1
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listCom();
        }

        String DBFileName;


        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillTheThread()
        {
            trd6.Abort();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            ObjTcpServer.Stop();

            //this.CLudp1.NewMessageReceived -= OnNewMessageReceived;
            //CLudp1.StopListener();
            //this.Application.DoEvents(); 

            newsock.Close();
            //KillTheThread();


            udp.Close();

            xtrd1 = 1;
            xtrd2 = 1;
            xtrd3 = 1;
            xtrd4 = 1;
            xtrd5 = 1;
            xtrd6 = 1;

            Console.WriteLine("wait stop threads");
            //while ((xtrd1 != 2) || (xtrd2 != 2) || (xtrd3 != 2) || (xtrd4 != 2) || (xtrd6 != 2))
            while ((xtrd1 != 2))
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine("ok threads stopped");

            ////***************** stop threads (wait max 100 msec) 
            //tstop = 1;
            //int cnt = 10;
            //while (cnt > 0)
            //{
            //    cnt--;
            //    if ((ts1 == 2) && (ts2 == 2) & (ts3 == 2)) break;
            //    Thread.Sleep(5);
            //}
            //if (ts1 != 2) trd1.Abort();
            //if (ts2 != 2) trd2.Abort();
            //if (ts3 != 2) trd3.Abort();
            ////*****************************

            WindowState = WindowState.Normal;

            WpfApplication31_tester2.Properties.Settings.Default.DBFileName = DBFileName;

            WpfApplication31_tester2.Properties.Settings.Default.Top = this.Top;
            WpfApplication31_tester2.Properties.Settings.Default.Left = this.Left;
            WpfApplication31_tester2.Properties.Settings.Default.Width = this.Width;
            WpfApplication31_tester2.Properties.Settings.Default.Heigth = this.Height;
            WpfApplication31_tester2.Properties.Settings.Default.modeFanuc = modeFanuc;

            WpfApplication31_tester2.Properties.Settings.Default.IncNum = IncNum;

            WpfApplication31_tester2.Properties.Settings.Default.Save();


            Thread.Sleep(1001);

            //Properties.Settings.Default.comIndex = indiceCom; 
            FreeConsole();

        }


        //TimeSpan span1 = new TimeSpan();
        Stopwatch sw = Stopwatch.StartNew();



        //void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        //{
        //    if (LB_serial.ItemContainerGenerator.Status ==   GeneratorStatus.ContainersGenerated)
        //    {
        //        var info = LB_serial.Items[LB_serial.Items.Count - 1] as FileInfo;
        //        if (info == null)
        //            return;

        //        LB_serial.ScrollIntoView(info);
        //    }
        //}


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //LB_serial.ItemContainerGenerator.StatusChanged += new ItemContainerGenerator_StatusChanged;


            CLelabora.f1 = F1;
            CLelabora.f1a = F1a;
            CLelabora.f3a = F3a;

            dati.f1 = F1;
            dati.f2 = F2;

            ObjTcpServer.Start();

            //==============================
            //Create endpoint
            udp_ep = new IPEndPoint(IPAddress.Any, 2281);

            //Initialize UdpClient
            udp = new UdpClient(udp_ep);

            //==============================



            Console.WriteLine(sw.Elapsed);

            this.Title = "Key Test sw20100 fw" + dati.fwvers;

            WpfApplication31_tester2.Properties.Settings.Default.Reload();


            IncNum = WpfApplication31_tester2.Properties.Settings.Default.IncNum;
            string ls = string.Format("{0:d05}", IncNum);
            tbCodice.Text = DateTime.Now.ToString("yyMM") + ls;
            ls = string.Format("{0:d}", IncNum);
            tbNum.Text = ls;

            int v1;
            try
            {
                v1 = int.Parse(tbNum.Text);
            }
            catch (Exception e1) { v1 = 0; };



            this.Top = WpfApplication31_tester2.Properties.Settings.Default.Top;
            this.Left = WpfApplication31_tester2.Properties.Settings.Default.Left;
            this.Width = WpfApplication31_tester2.Properties.Settings.Default.Width;
            this.Height = WpfApplication31_tester2.Properties.Settings.Default.Heigth;
            modeFanuc = WpfApplication31_tester2.Properties.Settings.Default.modeFanuc;

            if (modeFanuc != 0)
            {
                rbuttFanuc.IsChecked = true;
                rbuttFanuc_Click(sender, e);
            }
            else
            {
                rbuttMitsu.IsChecked = true;
                rbuttMitsu_Click(sender, e);
            }


            DBFileName = WpfApplication31_tester2.Properties.Settings.Default.DBFileName;
            lblFileName.Content = DBFileName;

            // buildDB();

            //LoadData();
            //update();

            TextRange range = new TextRange(rtb1.Document.ContentStart, rtb1.Document.ContentEnd);

            range.Text = "hello";
            range.Text += "\r\nworld!";

            butt3.Visibility = Visibility.Hidden;
            buttComesel.Visibility = Visibility.Hidden;
            buttSet1.Visibility = Visibility.Hidden;
            buttClr.Visibility = Visibility.Hidden;
            buttTest2.Visibility = Visibility.Hidden;
            cv2.Visibility = Visibility.Hidden;
            //border_b1.Visibility = Visibility.Hidden;
            //grid_a1.Visibility = Visibility.Hidden;
            lbl0.Visibility = Visibility.Hidden;
            lbl1.Visibility = Visibility.Hidden;
            tabItem2.Visibility = Visibility.Hidden;
            tabItem3.Visibility = Visibility.Hidden;

            //buttTestAll.Visibility = Visibility.Hidden;
            tbMode.Visibility = Visibility.Hidden;

            slid3.Visibility = Visibility.Hidden;
            slid4.Visibility = Visibility.Hidden;



        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = 0;
            string s = null;
            string[] sa = new string[20];
            try
            {
                n = ComboBox1.SelectedIndex;
                Console.WriteLine(n);
                //My.Settings.comIndex = n
                s = ComboBox1.SelectedItem.ToString();


                s = s.Substring(3, 10); //String.Mid(s, 4, 10);
                sa = s.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                //s = sa[0].Substring(3, 10); ;
                n = Convert.ToInt32(sa[0]);
                WpfApplication31_tester2.Properties.Settings.Default.comIndex = n;
                serialName = "COM" + n;

                dati.serialError = 0;
                try
                {
                    SerialPort1.Close();
                    SerialPort1.PortName = serialName;
                    SerialPort1.BaudRate = 460800;
                    SerialPort1.Open();
                    n = 1;
                }
                catch
                {
                    //dati.serialError = 1
                }

            }
            catch
            {
            }
        }

        bool grid2Flag = true;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("test");
            grid2Flag = !grid2Flag;
            if (!grid2Flag)
            {
                grid2.Visibility = Visibility.Hidden;
            }
            else
            {
                grid2.Visibility = Visibility.Visible;
            }

            string s;
            int v = 4;
            s = String.Format("E{0:d03}", v);
            Console.WriteLine(s);

            //Console.WriteLine(Kbn.Length);
            //foreach (int i in Kbn)
            //{
            //    s = String.Format("B{0:d03}", i);
            //    Console.WriteLine(s);
            //    var b = (Button)this.FindName(s);
            //    bool b1 = b.IsMouseOver;
            //    bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed; // work for this window
            //    //                if (b1 == true)
            //    //                {
            //    if (mouseIsDown == true)
            //    {
            //        b.Background = new SolidColorBrush(Colors.Blue);
            //    }
            //    //                }
            //}


        }

        private const int DMAX = 5100;
        static byte[] datiSer = new byte[DMAX + 1];
        static int rp;
        static int wp;
        static byte tstop = 0;
        static byte ts1 = 0;
        static byte ts2 = 0;
        static byte ts3 = 0;
        static byte ts4 = 0;
        static byte ts5 = 0;
        static byte ts6 = 0;
        CLelabora el = new CLelabora();

        private void ThreadReadSerial()
        {
            byte[] buffer = new byte[5201];
            int i = 0;
            int n = 0;
            int xxx = 0;
            string s = null;

            do
            {

                if (xtrd1 == 1) break;


                Array.Clear(buffer, buffer.GetLowerBound(0), buffer.Length);
                try
                {
                    n = SerialPort1.BytesToRead;
                }
                catch
                {
                    n = 0;
                }

                if ((n > 0))
                {
                    try
                    {
                        n = SerialPort1.Read(buffer, 0, 5100);
                    }
                    catch
                    {
                        n = 0;
                    }
                }
                else
                {
                    dati.noData += 1;
                }


                if ((n > 0))
                {
                    s = System.Text.Encoding.UTF8.GetString(buffer);
                    for (i = 0; i <= n - 1; i++)
                    {
                        int x = 0;
                        x = wp;
                        x = x + 1;
                        if (x >= DMAX)
                            x = 0;
                        datiSer[x] = buffer[i];
                        wp = x;
                    }
                    //dati.freeBuffer = DMAX - ((wp - rp) Mod DMAX)

                }
                else
                {
                    xxx = 1;
                }



                Thread.Sleep(5);
                ts1 = tstop;
                if (ts1 != 0)
                {
                    ts1 = 2;
                    break; // TODO: might not be correct. Was : Exit Do
                }
            } while (true);

            xtrd1 = 2;

        }


        private void ThreadElabora()
        {
            //Dim buffer(200) As Byte
            byte c = 0;
            //Dim i, n As Integer
            String s;
            do
            {

                if (xtrd2 == 1) break;

                while (rp != wp)
                {
                    rp = rp + 1;
                    if (rp >= DMAX)
                        rp = 0;
                    c = datiSer[rp];
                    //Console.Write(Chr(c))
                    el.keepbinh(c);
                    //s = s + c.ToString();
                    //Dispatcher.Invoke(new Action(() => { LB_serial.Items.Add(s); }));
                }
                Thread.Sleep(5);
                ts2 = tstop;
                if (ts2 != 0)
                {
                    ts2 = 2;
                    break; // TODO: might not be correct. Was : Exit Do
                }
            } while (true);
            xtrd2 = 2;
        }


        int timerAck;


        private void ThreadTimer()
        {
            do
            {

                if (xtrd3 == 1) break;

                if (timerAck > 0)
                {
                    timerAck--;
                    if (timerAck == 0)
                    {
                        if (Ack != 0)
                        {
                            Console.WriteLine("\r\n-----\r\n--- timer Ack overrun ERROR --\r\n-------\r\n");
                            Ack = 0;
                        }
                    }
                }
                Thread.Sleep(100);
            } while (true);
            xtrd3 = 2;
        }

        private void ThreadSendSerial()
        {
            string s; //= "(|,1,.)S";

            bool ok = false;

            do
            {

                if (xtrd4 == 1) break;
                if (Ack == 3)
                {
                    if (el.Ack == 1)
                    {
                        Ack = 0;
                        el.Ack = 0;
                    }
                    continue;
                }

                tcount1 += 1;
                //If dati.stopm <> 1 Then
                ok = dati.qe.TryDequeue(out s);
                if (ok == true)
                {
                    try
                    {
                        SerialPort1.Write(s);
                        Console.WriteLine("send:" + s);
                        if (Ack == 2)
                        {
                            timerAck = 20; // wait 2 seconds
                            Ack = 3;
                        }
                    }
                    catch
                    {
                        dati.serialError = 1;
                    }
                }
                //Else
                //    Dim xxx As Integer
                //    xxx = 1
                //End If
                //Console.WriteLine("")
                //Console.WriteLine(s)
                Thread.Sleep(20);
                ts3 = tstop;
                if (ts3 != 0)
                {
                    ts3 = 2;
                    break; // TODO: might not be correct. Was : Exit Do
                }
            } while (true);
            xtrd4 = 2;
        }


        //=================================
        static UdpClient udp1;
        static IPEndPoint udp_ep1;
        static string sResponse1;
        static byte udp1OK = 0;

        void UDP_IncomingData1(IAsyncResult ar)
        {
            //  ----   http://pcrelated.net/index.php/csharp-send-and-receive-data-using-udpclient/

            //Get the data from the response
            byte[] bResp = new byte[] { 1, 2, 3 };
            try
            {
                try
                {
                    bResp = udp1.EndReceive(ar, ref udp_ep1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //Convert the data to a string
                string sResponse1 = Encoding.UTF8.GetString(bResp);
                //Close the UDP connection
                udp1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }



            udp1OK = 1;
        }


        private void ThreadUdp()
        {

            byte[] bSend;
            short cnt;
            string s;
            ulong count = 0;


            do
            {

                if (xtrd5 == 1) break;

                udp1OK = 0;

                try
                {
                    ////Create endpoint
                    udp_ep1 = new IPEndPoint(IPAddress.Any, 2283);

                    ////Initialize UdpClient

                    udp1 = new UdpClient(udp_ep1);

                    s = "x" + count.ToString();
                    count++;

                    bSend = Encoding.ASCII.GetBytes(s);

                    udp1.Send(bSend, bSend.Length, "192.168.137.28", 12345);

                    udp1.BeginReceive(new AsyncCallback(UDP_IncomingData1), udp_ep1);

                    cnt = 0;
                    while ((udp1OK == 0) && (cnt < 200))
                    {
                        Thread.Sleep(5);
                        cnt++;
                    }
                    Console.WriteLine(sResponse1);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    udp1.Close();
                }

                Thread.Sleep(1000);

                ts5 = tstop;
                if (ts5 != 0)
                {
                    ts5 = 2;
                    break; // TODO: might not be correct. Was : Exit Do
                }

            } while (true);
            xtrd5 = 2;
        }
        //=================================


        //=================================
        static IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
        static UdpClient newsock = new UdpClient(ipep);


        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            byte[] data = new byte[1024];
            string welcome = "server port";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.Send(data, data.Length, "192.168.137.28", 12347);
        }

        private void ThreadUdpServer()
        {

            //Thread.Sleep(3000);
            byte[] data = new byte[1024];
            byte[] data1 = new byte[] { 1, 2, 3, 4 };
            //IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            // UdpClient newsock = new UdpClient(ipep);

            //Console.WriteLine("Waiting for a client...");

            //            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            //data = newsock.Receive(ref sender);

            //Console.WriteLine("Message received from {0}:", sender.ToString());
            //Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string welcome = "Welcome to my UDP test server";
            Console.WriteLine(welcome);
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.Send(data, data.Length, "192.168.137.28", 12347);

            //udp.Send(bSend, bSend.Length, "192.168.137.28", 12345);

            newsock.Client.ReceiveTimeout = 100;


            while (true)
            {
                if (xtrd6 == 1) break;

                //Console.WriteLine("Waiting for a client...");

                try
                {
                    data = newsock.Receive(ref sender);
                }
                catch (Exception ex1)
                {
                    continue;
                }

                //dati.mutex1.WaitOne();

                //Console.WriteLine();
                //Console.WriteLine("------ udp rx server data received ------");
                Console.WriteLine("udp serv:"+Encoding.ASCII.GetString(data, 0, data.Length));
                //Console.WriteLine("-----------------------------------------");

                udpRx = Encoding.ASCII.GetString(data, 0, data.Length);

                string as1;
                as1 = Encoding.ASCII.GetString(data, 0, data.Length);

                string[] words = as1.Split(',');

                long al = words.Length;
                //Console.WriteLine(al);
                long i;
                foreach (string s in words)
                {
                    //Console.WriteLine(s);
                }


                //dati.mutex1.ReleaseMutex();

                //Console.WriteLine("------ udp rx server end   ------\r\n");

                //newsock.Send(data, data.Length, sender);
                //newsock.Send(data1, 2, sender);

                Thread.Sleep(5);

                ts6 = tstop;
                if (ts6 != 0)
                {
                    ts6 = 2;
                    break; // TODO: might not be correct. Was : Exit Do
                }
            }

            xtrd6 = 2;

        }
        //=================================



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string ls = null;
            ls = TextBox8.Text;

            //ls = string.Format("(|" + ls + ")S");

            int i = getStringCrc(ls);
            string ls1, ls2;

          //  while (dati.qe.IsEmpty == false) ;


            ls1 = string.Format("(" + ls + "){0:X4}s\r\n", i);

            ls2 = padStringCrc(ls);

            Ack = 2;
            dati.qe.Enqueue(ls2);

        }

        int Ack = 0;

        #region NTP server
        public static DateTime GetNetworkTime()
        {

            DateTime d = new DateTime();
            //return d;

            //default Windows time server
            const string ntpServer = "time.windows.com";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);

            //Stops code hang if NTP is blocked
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("\r\n" + GetNetworkTime());
        }
        #endregion


        #region view hide console

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        bool viewToggle = true;
        private void butt4_Click(object sender, RoutedEventArgs e)
        {
            var handle = GetConsoleWindow();

            viewToggle = !viewToggle;
            if (!viewToggle)
            {
                // Hide
                ShowWindow(handle, SW_HIDE);
            }
            else
            {
                // Show
                ShowWindow(handle, SW_SHOW);
            }
        }
        #endregion

        //        private void Image_IsStylusCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    Console.WriteLine("qui1");
        //}

        //private void Image_IsStylusDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    Console.WriteLine("qui2");
        //}

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   Console.WriteLine("--qui04--");
            //update();
        }

        //private void Image_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Console.WriteLine("qui3");
        //}


        SolidColorBrush ledCol;
        bool B100f = false;
        int T100 = 0;
        private void B001_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("B001");
            //B100f = !B100f;
            //if (B100f == true) ledCol = new SolidColorBrush(Colors.LightGreen); else ledCol = new SolidColorBrush(Colors.Red);
            //E001.Fill = ledCol;
            //T100 = ((T100 + 1) & 3);
            //switch (T100)
            //{
            //    default:
            //    case 0: L001.Background = new SolidColorBrush(Colors.Yellow); L001.Content = "TEST"; break;
            //    case 1: L001.Background = new SolidColorBrush(Colors.LightGreen); L001.Content = "PASS"; break;
            //    case 2: L001.Background = new SolidColorBrush(Colors.Red); L001.Content = "FAIL"; break;
            //    case 3: L001.Background = new SolidColorBrush(Colors.Cyan); L001.Content = "SKIP"; break;
            //}
            ////B100.Foreground = new SolidColorBrush(Colors.Yellow);
        }
        private void B004_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("B004");

            //try
            //{
            //    //                object resource = Application.Current.FindResource("UnfindableResource");
            //    //object resource = Application.Current.FindResource("bs1");
            //    string s = "L007";
            //    var myLabel = (Label)this.FindName(s);
            //    myLabel.Content = "ciao";

            //    s = "E001";
            //    var El = (Ellipse)this.FindName(s);
            //    El.Fill = new SolidColorBrush(Colors.Blue);

            //    Color c1, c2;
            //    c1 = Color.FromRgb(250, 250, 0);
            //    c2 = Color.FromRgb(0, 250, 0);
            //    LinearGradientBrush gradientBrush =
            //        new LinearGradientBrush(
            //            c1,
            //            c2,
            //            new Point(0.5, 0.2),
            //            new Point(0.5, 0.8)
            //            );

            //    s = "B003";
            //    var Bt = (Button)this.FindName(s);
            //    Bt.Background = gradientBrush;


            //}
            //catch (ResourceReferenceKeyNotFoundException ex)
            //{
            //    MessageBox.Show("Resource not found.");
            //}
        }


        void test(int n)
        {

        }


        //void sb1()
        //{
        //    IEnumerable<int> lengths = bands.Select(b => b.Length);
        //    foreach (int l in lengths)
        //    {
        //        Console.WriteLine(l);
        //    }
        //}
        //void sb2()
        //{
        //    var customObjects = bands.Select(b => new { Name = b, Length = b.Length });
        //    foreach (var item in customObjects)
        //    {
        //        Console.WriteLine("Band name: {0}, length: {1}", item.Name, item.Length);
        //    }
        //}
        //public class Band
        //{
        //    public string Name { get; set; }
        //    public int NameLength { get; set; }
        //    public string AllCapitals { get; set; }
        //    public int BandIndex { get; set; }
        //}
        //void sb3()
        //{
        //    IEnumerable<Band> bandList = bands.Select(b => new Band() { AllCapitals = b.ToUpper(), Name = b, NameLength = b.Length });
        //    foreach (Band band in bandList)
        //    {
        //        Console.WriteLine(string.Concat(band.Name, ", ", band.NameLength, ", ", band.AllCapitals));
        //    }

        //    IEnumerable<Band> bandList1 = bands.Select((b, i) => new Band() { AllCapitals = b.ToUpper(), BandIndex = i + 1, Name = b, NameLength = b.Length });
        //    foreach (Band band in bandList1)
        //    {
        //        Console.WriteLine(string.Concat(band.BandIndex, ": ", band.Name, ", ", band.NameLength, ", ", band.AllCapitals));
        //    }
        //}
        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //sb1();
        //sb2();
        //sb3();
        //}


        IEnumerable<int> firstRange = Enumerable.Range(10, 10);
        IEnumerable<int> secondRange = Enumerable.Range(5, 20);

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<int> concatenated = firstRange.Concat(secondRange).ToList();
            concatenated.ForEach(i => Console.WriteLine(i));
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        //**************** plc drawing - use canvas coordinate

        //static byte[] plcOut = new byte[16];
        //static byte[] plcInp = new byte[16];

        void drawByteSet()
        {
            byte v;
            int idx;
            Point p = Mouse.GetPosition(cv2);
            double x, y, d;

            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            dati.plcOut[1] = 0x52; // test

            for (int j = 0; j < 16; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    idx = j * 8 + i;
                    led.r1[idx].Width = 9;
                    led.r1[idx].Height = 9;
                    led.r1[idx].Stroke = Brushes.Blue;
                    led.r1[idx].Fill = Brushes.Gray;
                    v = dati.plcOut[j];
                    if ((v & (1 << i)) != 0)
                    {
                        led.r1[idx].Fill = Brushes.Red;
                    }
                    x = 10 + (7 - i) * 10;
                    y = 5 + j * 15;
                    d = Math.Sqrt(Math.Pow(((x + 4.5) - p.X), 2) + Math.Pow(((y + 4.5) - p.Y), 2));
                    if (d < 4)
                    {
                        if (dati.cv2m == 0)
                        {
                            led.r1[idx].Stroke = Brushes.Cyan;
                        }
                        if (dati.cv2ml == 1)
                        {
                            led.r1[idx].Fill = Brushes.Red;
                            dati.plcOut[j] = (byte)(dati.plcOut[j] | (1 << i));
                        }
                        if (dati.cv2mr == 1)
                        {
                            led.r1[idx].Fill = Brushes.Gray;
                            dati.plcOut[j] = (byte)(dati.plcOut[j] & ~(1 << i));
                        }
                    }
                    Canvas.SetLeft(led.r1[idx], x); //10 + (7 - i) * 10);
                    Canvas.SetTop(led.r1[idx], y); //5 + j * 15);
                }
            }
            ////********************
            dati.plcInp[4] = 0x36;//test
            dati.plcInp[0] = 0x82;//test
            for (int j = 0; j < 16; j++)
            {
                idx = 256 + j;
                for (int i = 0; i < 8; i++)
                {
                    idx = 256 + j * 8 + i;
                    led.r1[idx].Width = 9;
                    led.r1[idx].Height = 9;
                    led.r1[idx].Stroke = Brushes.Blue;
                    led.r1[idx].Fill = Brushes.Gray;
                    v = dati.plcInp[j];
                    if ((v & (1 << i)) != 0)
                    {
                        led.r1[idx].Fill = Brushes.Orange;
                    }
                    x = 10 + 90 + (7 - i) * 10;
                    y = 5 + j * 15;
                    //d = Math.Sqrt(Math.Pow(((x + 4.5) - p.X), 2) + Math.Pow(((y + 4.5) - p.Y), 2));
                    //if (d < 4)
                    //{
                    //        led.r1[idx].Fill = Brushes.Cyan;
                    //}
                    Canvas.SetLeft(led.r1[idx], x); //10 + 90 + (7 - i) * 10);
                    Canvas.SetTop(led.r1[idx], y); //5 + j * 15);
                }
            }

            // Stop timing
            stopwatch.Stop();
            dati.et1 = stopwatch.Elapsed.TotalMilliseconds;
            //Console.WriteLine("Time elapsed (ms): {0}", stopwatch.Elapsed.TotalMilliseconds);
        }

        void drawPlcSet()
        {

        }
        //*****************************

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            drawByteSet();

            // led.label[0].Content = "qwe";


        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            cv2.Children.Clear();
            int idx;
            for (int j = 0; j < 16; j++)
            {
                cv2.Children.Add(led.label[j]);
                led.label[j].Content = j & 7;
                led.label[j].FontSize = 8;
                Canvas.SetLeft(led.label[j], 0);
                Canvas.SetTop(led.label[j], 0 + j * 15);

                for (int i = 0; i < 8; i++)
                {
                    idx = j * 8 + i;
                    cv2.Children.Add(led.r1[idx]);
                }
            }
            for (int j = 0; j < 16; j++)
            {
                idx = 256 + j;
                cv2.Children.Add(led.label[idx]);
                led.label[idx].Content = j & 7;
                led.label[idx].FontSize = 8;
                Canvas.SetLeft(led.label[idx], 90);
                Canvas.SetTop(led.label[idx], 0 + j * 15);
                for (int i = 0; i < 8; i++)
                {
                    idx = 256 + j * 8 + i;
                    cv2.Children.Add(led.r1[idx]);
                }
            }
        }

        private void cv2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dati.cv2m = 1;
            Console.WriteLine("mouse down");
        }

        private void cv2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dati.cv2m = 0;
            Console.WriteLine("mouse up");
        }

        private void cv2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dati.cv2ml = 1;
            Console.WriteLine("mouse left down");
        }

        private void cv2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dati.cv2ml = 0;
            Console.WriteLine("mouse left up");
        }

        private void cv2_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            dati.cv2mr = 1;
            Console.WriteLine("mouse right down");

        }

        private void cv2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            dati.cv2mr = 0;
            Console.WriteLine("mouse right up");
        }

        private void TextBox8_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTipo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void nonQuery(String s1)
        {
            //sql_cmd = sql_con.CreateCommand();
            //sql_cmd.CommandText = s1;
            //try
            //{
            //    sql_cmd.ExecuteNonQuery();
            //}
            //catch (Exception sx)
            //{
            //    Console.WriteLine("sql query error: " + sx);
            //}
        }

        private void buttSet_Click(object sender, RoutedEventArgs e)
        {
            String s1;
            var watch = Stopwatch.StartNew();

            //SetConnection();
            //sql_con.Open();

            s1 = "update informazioni  set  tipo = \"" + txtTipo.Text + "\"";
            nonQuery(s1);
            s1 = "update informazioni  set  codice = \"" + txtCodice.Text + "\"";
            nonQuery(s1);
            s1 = "update informazioni  set  data = \"" + txtData.Text + "\"";
            nonQuery(s1);
            s1 = "update informazioni  set  varie= \"" + txtVarie.Text + "\"";
            nonQuery(s1);

            //sql_con.Close();

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("ms: " + elapsedMs);







        }

        private void TabItem_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("--qui03--");
        }




        private void buttPrint_Click(object sender, RoutedEventArgs e)
        {

            buttReport_Click(sender, e);

            PrintDialog pd = new PrintDialog();

            //pd.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape; 

            RichTextBox rb = new RichTextBox();

            rb = rtb2;

            if (pd.ShowDialog() == true)
            {
                // suggerimento da:
                // https://social.msdn.microsoft.com/Forums/vstudio/en-US/7dff2089-29a3-43c5-bf5b-d07f3057732c/flowdocument-text-disappears-after-printing?forum=wpf

                MemoryStream stream = new MemoryStream();
                TextRange sourceDocument = new TextRange(rb.Document.ContentStart, rb.Document.ContentEnd);
                sourceDocument.Save(stream, DataFormats.Xaml);

                FlowDocument flowDocumentCopy = new FlowDocument();



                TextRange copyDocumentRange = new TextRange(flowDocumentCopy.ContentStart, flowDocumentCopy.ContentEnd);
                copyDocumentRange.Load(stream, DataFormats.Xaml);

                string ls;

                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(100, 100, 100, 100);
                //Margins margins = new Margins(10, 10, 10, 10);
                //pd.DefaultPageSettings.Margins = margins;

                pd.PrintDocument(
                  ((IDocumentPaginatorSource)flowDocumentCopy).DocumentPaginator,
                  nomeReport);
                //"Printing Richtextbox Content");

                // facendo solo così  dopo il print non visualizza più il rich text Box
                //pd.PrintVisual(rtb2, "My First Print Job");
                //pd.PrintDocument((((IDocumentPaginatorSource) rb.Document).DocumentPaginator), "printing as paginator");
                //-------------

                IncNum++;
                Button_Click_6(sender, e);

            }



        }

        private void buttDisconnect_Click(object sender, RoutedEventArgs e)
        {
            //dati.serialRequestClose = true;
            SerialPort1.Close();

        }

        string nomeReport = "report";
        private void buttReport_Click(object sender, RoutedEventArgs e)
        {

            TimeSpan ts = new TimeSpan();
            ts = sw.Elapsed;
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(ts.Seconds);


            rtb2.Document.Blocks.Clear();



            /*
                    Ciao Nel software prevedi anche una stampa a richiesta molto compatte con:
                    Codice tastiera in Collaudo richiesto all’inizio Se è una Fanuc è tipicamente E102-00016
                    Se è una Mitsubishi è E102-00013
                    Data e ora del test e durata
                    Test Tasti = OK
                    TEST Led = OK
                    Test Potenziometro= OK
                    Test Cablaggi = OK
                    N. di riferimento = ggmmaa.ora.min.sec
            */


            var paragraph = new Paragraph();
            //paragraph.Inlines.Add(new Run(string.Format("Paragraph Sample {0}", Environment.TickCount)));
            //paragraph.Inlines.Add(new Run(string.Format("Paragraph Sample {0}", Environment.TickCount)));


            paragraph.FontFamily = new FontFamily("Arial");
            paragraph.FontSize = 12;
            paragraph.FontWeight = FontWeights.Bold;


            string ls;

            ls = "";
            ls += lblTipo.Content + "";
            paragraph.Inlines.Add(new Run(string.Format("" + ls + "\r\n")));


            ls += tbCodice.Text;
            nomeReport = ls;




            ls = DateTime.Now.ToString("dd/MM/yyyy");
            paragraph.Inlines.Add(new Run(string.Format(ls + "\r\n")));
            ls = DateTime.Now.ToString("HH:MM:ss");
            paragraph.Inlines.Add(new Run(string.Format(ls + "\r\n")));
            ls = tbTipo.Text;
            paragraph.Inlines.Add(new Run(string.Format(ls + "\r\n")));
            paragraph.Inlines.Add(new Run("TEST  s/n:\r\n" + tbCodice.Text + "\r\n"));
            // rtb2.Document.Blocks.Add(paragraph);

            //var p1 = new Paragraph();
            //p1.FontFamily = new FontFamily("Arial");
            //p1.FontSize = 10;
            //p1.FontWeight = FontWeights.Bold;

            if (CbTasti.IsChecked == true) ls = "OK"; else ls = "---";
            paragraph.Inlines.Add(new Run("Tasti: \t" + ls + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);

            if (CbLed.IsChecked == true) ls = "OK"; else ls = "---";
            paragraph.Inlines.Add(new Run("Led: \t" + ls + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);

            if (CbDisp.IsChecked == true) ls = "OK"; else ls = "---";
            paragraph.Inlines.Add(new Run("Disp: \t" + ls + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);

            if (CbPot.IsChecked == true) ls = "OK"; else ls = "---";
            paragraph.Inlines.Add(new Run("Pot: \t" + ls + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);

            if (CbBuz.IsChecked == true) ls = "OK"; else ls = "---";
            paragraph.Inlines.Add(new Run("Buz: \t" + ls + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);

            if (CbConn.IsChecked == true) ls = "OK"; else ls = "---";
            paragraph.Inlines.Add(new Run("Conn: \t" + ls + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);



            //DateTime dt = new DateTime();
            //dt =  Convert.ToDateTime(ts.ToString());
            //            p1.Inlines.Add(new Run("\r\ndurata test: " + ts.ToString("HH:mm") + "\r\n"));
            //            p1.Inlines.Add(new Run("\r\ndurata test: " + dt.ToString("HH:mm:ss") + "\r\n"));
            //p1.Inlines.Add(new Run("\r\ndurata test: " + lblSw.Content  + "\r\n"));

            paragraph.Inlines.Add(new Run("" + tbVarie.Text));

            rtb2.Document.Blocks.Add(paragraph);
            //p1.Inlines.Add(new Run("\r\n==========\r\n"));
            //rtb2.Document.Blocks.Add(p1);


        }

        private void buttReport_Click_old(object sender, RoutedEventArgs e)
        {

            TimeSpan ts = new TimeSpan();
            ts = sw.Elapsed;
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(ts.Seconds);


            rtb2.Document.Blocks.Clear();

            /*
                    Ciao Nel software prevedi anche una stampa a richiesta molto compatte con:
                    Codice tastiera in Collaudo richiesto all’inizio Se è una Fanuc è tipicamente E102-00016
                    Se è una Mitsubishi è E102-00013
                    Data e ora del test e durata
                    Test Tasti = OK
                    TEST Led = OK
                    Test Potenziometro= OK
                    Test Cablaggi = OK
                    N. di riferimento = ggmmaa.ora.min.sec
            */


            var paragraph = new Paragraph();
            //paragraph.Inlines.Add(new Run(string.Format("Paragraph Sample {0}", Environment.TickCount)));
            //paragraph.Inlines.Add(new Run(string.Format("Paragraph Sample {0}", Environment.TickCount)));

            string ls;

            ls = "TASTIERA-";
            ls += lblTipo.Content + "-";
            ls += tbTipo.Text + "-";
            ls += tbCodice.Text;
            nomeReport = ls;

            paragraph.FontFamily = new FontFamily("Tahoma");
            paragraph.FontSize = 10;
            paragraph.FontWeight = FontWeights.Bold;
            paragraph.Inlines.Add(new Run(string.Format("REPORT " + ls + "\r\n")));

            ls = DateTime.Now.ToString("yyMMddHHmm");
            ls = DateTime.Now.ToString();

            paragraph.Inlines.Add(new Run(string.Format(ls + "\r\n")));
            paragraph.Inlines.Add(new Run("tipo    \t: " + tbTipo.Text + "\r\n"));
            paragraph.Inlines.Add(new Run("codice \t: " + tbCodice.Text + "\r\n"));
            rtb2.Document.Blocks.Add(paragraph);

            var p1 = new Paragraph();

            //p1.Inlines.Add(new Run("switch:           \t" + tbSwitch.Text + "\r\n"));
            //rtb2.Document.Blocks.Add(p1);
            //p1.Inlines.Add(new Run("led:                \t" + tbLed.Text + "\r\n"));
            //rtb2.Document.Blocks.Add(p1);
            //p1.Inlines.Add(new Run("potenziometri: \t" + tbPot.Text + "\r\n"));
            //rtb2.Document.Blocks.Add(p1);
            //p1.Inlines.Add(new Run("connessioni:    \t" + tbConn.Text + "\r\n"));
            //rtb2.Document.Blocks.Add(p1);


            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(ts.ToString());
            //            p1.Inlines.Add(new Run("\r\ndurata test: " + ts.ToString("HH:mm") + "\r\n"));
            //            p1.Inlines.Add(new Run("\r\ndurata test: " + dt.ToString("HH:mm:ss") + "\r\n"));
            p1.Inlines.Add(new Run("\r\ndurata test: " + lblSw.Content + "\r\n"));

            p1.Inlines.Add(new Run("\r\n=== varie ===\r\n" + tbVarie.Text));
            rtb2.Document.Blocks.Add(p1);
            p1.Inlines.Add(new Run("\r\n==========\r\n"));
            rtb2.Document.Blocks.Add(p1);


        }


        void ledMitsuFanuc(int modo)
        {
            if (modo == 0) //mitsu
            {
                E101.Fill = new SolidColorBrush(Colors.Yellow);
                E102.Fill = new SolidColorBrush(Colors.Yellow);
                E103.Fill = new SolidColorBrush(Colors.Yellow);
                E104.Fill = new SolidColorBrush(Colors.Yellow);
                E105.Fill = new SolidColorBrush(Colors.Yellow);
                E106.Fill = new SolidColorBrush(Colors.Yellow);
                E107.Fill = new SolidColorBrush(Colors.Yellow);
                E108.Fill = new SolidColorBrush(Colors.Yellow);
                E109.Fill = new SolidColorBrush(Colors.Yellow);
                E110.Fill = new SolidColorBrush(Colors.Yellow);
                E111.Fill = new SolidColorBrush(Colors.Yellow);
                E112.Fill = new SolidColorBrush(Colors.Yellow);
                E113.Fill = new SolidColorBrush(Colors.Yellow);
                E114.Fill = new SolidColorBrush(Colors.Yellow);
                E115.Fill = new SolidColorBrush(Colors.Yellow);

                E101.Visibility = Visibility.Visible;
                E102.Visibility = Visibility.Visible;
                E103.Visibility = Visibility.Visible;
                E104.Visibility = Visibility.Visible;
                E105.Visibility = Visibility.Visible;
                E106.Visibility = Visibility.Visible;
                E107.Visibility = Visibility.Visible;
                E108.Visibility = Visibility.Visible;
                E109.Visibility = Visibility.Visible;
                E110.Visibility = Visibility.Visible;
                E111.Visibility = Visibility.Visible;
                E112.Visibility = Visibility.Visible;
                E113.Visibility = Visibility.Visible;
                E114.Visibility = Visibility.Visible;
                E115.Visibility = Visibility.Visible;

            }
            else
            {// 1= fanuc mode

                Color c = (Color)ColorConverter.ConvertFromString("#FFE6510B");

                E101.Fill = new SolidColorBrush(c);
                E102.Fill = new SolidColorBrush(c);
                E103.Fill = new SolidColorBrush(c);
                E104.Fill = new SolidColorBrush(c);
                E105.Fill = new SolidColorBrush(c);
                E106.Fill = new SolidColorBrush(c);
                E107.Fill = new SolidColorBrush(c);
                E108.Fill = new SolidColorBrush(c);
                E109.Fill = new SolidColorBrush(c);
                E110.Fill = new SolidColorBrush(c);
                E111.Fill = new SolidColorBrush(c);
                E112.Fill = new SolidColorBrush(c);
                E113.Fill = new SolidColorBrush(c);
                E114.Fill = new SolidColorBrush(c);
                E115.Fill = new SolidColorBrush(c);


                E101.Visibility = Visibility.Hidden;
                E102.Visibility = Visibility.Visible;
                E103.Visibility = Visibility.Hidden;
                E104.Visibility = Visibility.Hidden;
                E105.Visibility = Visibility.Visible;
                E106.Visibility = Visibility.Hidden;
                E107.Visibility = Visibility.Hidden;
                E108.Visibility = Visibility.Visible;
                E109.Visibility = Visibility.Hidden;
                E110.Visibility = Visibility.Hidden;
                E111.Visibility = Visibility.Visible;
                E112.Visibility = Visibility.Hidden;
                E113.Visibility = Visibility.Hidden;
                E114.Visibility = Visibility.Visible;
                E115.Visibility = Visibility.Hidden;

            }

            //string s;
            //SolidColorBrush c1 = new SolidColorBrush();
            //c1 = (SolidColorBrush)E101.Fill;
            //Color c0 = c1.Color;
            //c0 = Color.FromArgb(c0.A, (byte)(c0.R * 0.8), (byte)(c0.G * 0.8), (byte)(c0.B * 0.8));
            ////int r = c0.R;
            ////int g = c0.G;
            ////int b = c0.B;
            ////r /= 3;
            ////g /= 3;
            ////b /= 3;
            ////c0.R = (byte)r;
            ////c0.G = (byte)g;
            ////c0.B = (byte)b;
            //s = c1.ToString();
            //Console.WriteLine(c1);
            //Console.WriteLine(c0);
            //Console.WriteLine(s);
        }
        private void rbuttFanuc_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("change1");
            //            tbTipo.Text = "Fanuc: E102-00016";
            //tbTipo.Text = "E102-00016";
            tbTipo.Text = "E102-00016";
            lblTipo.Content = "FANUC";
            ledMitsuFanuc(1);
        }

        private void rbuttMitsu_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("change2");
            //            tbTipo.Text = "Mitsu: E102-00013";
            //tbTipo.Text = "E102-00013";
            tbTipo.Text = "E102-00013";
            lblTipo.Content = "MITSU";
            ledMitsuFanuc(0);
        }

        private void buttClearReport_Click(object sender, RoutedEventArgs e)
        {
            rtb2.Document.Blocks.Clear();
        }

        private void buttTestAll_Click(object sender, RoutedEventArgs e)
        {
            string ls;
            while (dati.qe.IsEmpty == false) ;
            Ack = 2;
            ls = string.Format(",0,*FF,10,.\r\n");
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void buttTestAllOff_Click(object sender, RoutedEventArgs e)
        {
            string ls;
            while (dati.qe.IsEmpty == false) ;
            Ack = 2;
            ls = string.Format(",0,0,10,.\r\n");
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }





        private void testAllButt(int mode)
        {
            Color c1, c2;

            c1 = Color.FromRgb(50, 50, 50);
            c2 = Color.FromRgb(200, 200, 200);
            LinearGradientBrush gradientBrush0 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));

            //tipo cyan
            c1 = Color.FromRgb(0, 100, 100);
            c2 = Color.FromRgb(0, 200, 200);
            LinearGradientBrush gradientBrush3 = new LinearGradientBrush(c1, c2, new Point(0.5, 0.2), new Point(0.5, 0.8));


            int i;
            int v;
            string ls, s;

            v = mode;

            for (i = 0; i < 127; i++)
            {
                //while (dati.qe.IsEmpty == false) ;
                //Ack = 2;
                //ls = string.Format(",{1},{0},7,.\r\n", i, v);
                //ls = padStringCrc(ls);
                //dati.qe.Enqueue(ls);

                if (v != 0) Bstate[i] = 3; else Bstate[i] = 0;
                s = String.Format("B{0:d03}", i);
                var bt = (Button)this.FindName(s);
                if (bt != null)
                {

                    if (v != 0) bt.Background = gradientBrush3;
                    if (v == 0) bt.Background = gradientBrush0;
                }
            }
        }











        private void buttTest3_Click(object sender, RoutedEventArgs e)
        {
            int i;
            i = getStringCrc(TextBox8.Text);
            string ls;
            ls = string.Format("{0:X4}", i);
            Console.Write(ls);
            Console.WriteLine("\r\nonline check:  http://www.lammertbies.nl/comm/info/crc-calculation.html");

        }

        int getStringCrc(string ls)
        {
            //http://www.lammertbies.nl/comm/info/crc-calculation.html
            //is CRC-16
            int i, bi, cCrc, len;
            //string ls;
            cCrc = 0;

            //ls = TextBox8.Text;
            len = ls.Length;
            for (i = 0; i < len; i++)
            {
                bi = ls[i];
                cCrc = el.getCrc16(bi, cCrc);
            }
            return cCrc;
        }

        string padStringCrc(string ls)
        {
            string ls1;
            int i = getStringCrc(ls);
            ls1 = string.Format("(" + ls + "){0:X4}s\r\n", i);
            return ls1;
        }

        private void TextBox8_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            if (e.Key == Key.Enter)
            {

                Button_Click_2(sender, e);

            }
        }

        private void buttAllSw1_Click(object sender, RoutedEventArgs e)
        {
            testAllButt(1);
        }

        private void buttAllSw0_Click(object sender, RoutedEventArgs e)
        {
            testAllButt(0);
        }

        int modeFanuc = 0;

        private void rbuttFanuc_Checked(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",1,80,. ,81,.", i);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
            modeFanuc = 1;
            //tbTipo.Text = "E102-00016";
            //lblTipo.Content = "Fanuc";
        }

        private void rbuttMitsu_Checked(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",0,80,. ,81,.", i);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
            modeFanuc = 0;
            //tbTipo.Text = "E102-00013";
            //lblTipo.Content  = "Mitsubishi";
        }

        private void buttBuzz1_Click(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",1,120,. ", i);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void buttBuzz0_Click(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",0,120,. ", i);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        int toggleCnt = 0;
        private void buttCnt_Click(object sender, RoutedEventArgs e)
        {
            //toggleCnt = ((toggleCnt ^ 1) & 1);
            toggleCnt++;
            if (toggleCnt >= 4) toggleCnt = 0;
            buttCnt.Content = "cnt mode: " + toggleCnt;
            string ls;
            ls = string.Format(",{0:D},110,. ", toggleCnt);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void buttClr1_Click(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",111,. ", i);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void buttClrTestTime_Click(object sender, RoutedEventArgs e)
        {
            //int v;
            //TimeSpan ts;
            //DateTime dt;
            //v = 0;
            //try
            //{
            //    v = Convert.ToInt32(tbSwTime.Text);
            //}
            //catch
            //{
            //    v = 0;
            //}
            //ts = v;
            //dt = ts;
            sw = Stopwatch.StartNew();

        }

        private void rbuttFanuc_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void rbuttMitsu_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private int IncNum = 1;
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string ls;
            //int ore, minuti, dminX2;
            //ls = DateTime.Now.ToString("yyMMdd");
            //ore = DateTime.Now.Hour;
            //minuti = DateTime.Now.Minute;
            //dminX2 = (ore * 60 + minuti)/2;
            //tbCodice.Text = DateTime.Now.ToString("yyMMdd")+dminX2.ToString();


            ls = string.Format("{0:d05}", IncNum);
            // IncNum++;
            tbCodice.Text = DateTime.Now.ToString("yyMM") + ls;

            ls = string.Format("{0:d}", IncNum);
            tbNum.Text = ls;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void tbNum_KeyDown(object sender, KeyEventArgs e)
        {
            //IncNum = WpfApplication31_tester2.Properties.Settings.Default.IncNum;
            //tbNum.Text = ls;

            int v1 = 0;

            if (e.Key == Key.Enter)
            {
                try
                {
                    v1 = int.Parse(tbNum.Text);
                }
                catch (Exception e1) { v1 = 0; };
            }
            IncNum = v1;
            string ls = string.Format("{0:d05}", IncNum);
            tbCodice.Text = DateTime.Now.ToString("yyMM") + ls;

        }

        //***************** gestione lampadine *********
        int togHOLD, togCYCLE, togSQUARE;

        private void buttHOLD_Click(object sender, RoutedEventArgs e)
        {
            togHOLD = ((togHOLD ^ 1) & 1);
            string ls;
            ls = string.Format(",{0:d},121,. ", togHOLD);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void buttCYCLE_Click(object sender, RoutedEventArgs e)
        {
            togCYCLE = ((togCYCLE ^ 1) & 1);
            string ls;
            ls = string.Format(",{0:d},122,. ", togCYCLE);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void buttSQUARE_Click(object sender, RoutedEventArgs e)
        {
            togSQUARE = ((togSQUARE ^ 1) & 1);
            string ls;
            ls = string.Format(",{0:d},123,. ", togSQUARE);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        //==========================================================================







        static UdpClient udp;
        static IPEndPoint udp_ep;

        static void inviaUDP()  //string[] args)
        {
            //  ----   http://pcrelated.net/index.php/csharp-send-and-receive-data-using-udpclient/

            //Create byte[] of data to send
            byte[] bSend = new byte[] { 0x41, 0x42, 0x43 };
            bSend = Encoding.ASCII.GetBytes("X");



            bSend = Encoding.ASCII.GetBytes(dati.stringa);
            if (dati.stringa.Length == 0)
            {

                bSend = new byte[] { 0 };
            }

            ////Create endpoint
            //udp_ep = new IPEndPoint(IPAddress.Any, 2282);

            ////Initialize UdpClient
            //udp = new UdpClient(udp_ep);

            //Send the data
            //udp.Send(bSend, bSend.Length, "1.2.3.4", 12345);

            udp.Send(bSend, bSend.Length, "192.168.137.28", 12345);





            //Begin waiting for a response asynchronously
            //udp.BeginReceive(new AsyncCallback(UDP_IncomingData), udp_ep);

            //Prevent the console from closing automatically
            //Console.ReadKey();
        }

        //static void UDP_IncomingData(IAsyncResult ar)
        //{
        //    //  ----   http://pcrelated.net/index.php/csharp-send-and-receive-data-using-udpclient/

        //    //Get the data from the response
        //    byte[] bResp = udp.EndReceive(ar, ref udp_ep);

        //    //Convert the data to a string
        //    string sResponse = Encoding.UTF8.GetString(bResp);

        //    //Display the string
        //    Console.WriteLine(sResponse);

        //    //Close the UDP connection
        //    //udp.Close();
        //}


        //static void SendUdp(int srcPort, string dstIp, int dstPort, byte[] data)
        //{
        //    // ----   http://stackoverflow.com/questions/2637697/sending-udp-packet-in-c-sharp

        //    using (UdpClient c = new UdpClient(srcPort))
        //    {
        //        c.Send(data, data.Length, dstIp, dstPort);
        //        c.Close();
        //    }
        //}

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("hello 1!");
            //SendUdp(11000, "192.168.137.28", 11000, Encoding.ASCII.GetBytes("Hello!"));
            dati.stringa = TB_generic.Text;
            inviaUDP();
            //Console.WriteLine("hello 2!");
            //int port = 0x2223;
            //UdpClient udp = new UdpClient();
            ////udp.EnableBroadcast = true;  //This was suggested in a now deleted answer
            //IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, port);
            //string str4 = "I want to receive this!";
            //byte[] sendBytes4 = Encoding.ASCII.GetBytes(str4);
            //udp.Send(sendBytes4, sendBytes4.Length, groupEP);
            //string str5 = "";
            //str5 = Encoding.UTF8.GetString(sendBytes4);
            //Console.WriteLine(str5);
            //udp.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Console.Clear();
        }




        private void buttIp_Click(object sender, RoutedEventArgs e)
        {
            string s;
            s = txtIp.Text;
            lblIp.Content = s;

            int intAddress = BitConverter.ToInt32(IPAddress.Parse(s).GetAddressBytes(), 0);
            string ipAddress = new IPAddress(BitConverter.GetBytes(intAddress)).ToString();
            Console.WriteLine(intAddress);
            Console.WriteLine(ipAddress);
            string hexValue = intAddress.ToString("X");
            Console.WriteLine(hexValue);
            // Convert the hex string back to the number
            int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(intAgain);

            string ls;
            ls = string.Format(",{0:D},604,. ", intAddress);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);



        }

        private void Butt_GetIp(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",605,. ");
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        void F1()
        {
            string s = "ciao";
            s = dati.sf1;
            //lblIp.Content = "cippo";
            Console.WriteLine(s);

            // e da qui :  http://www.albertobarbazza.it/Programming/Delegati_it.aspx
            // tratto da qui: http://the--semicolon.blogspot.it/p/change-wpf-window-label-content-from.html
            Dispatcher.Invoke(new Action(() => { lblIp.Content = s; }));
            //---------------

        }

        void F1a(string s)
        {
            //string s = "ciao";
            //s = dati.sf1;
            //lblIp.Content = "cippo";
            Console.WriteLine(s);

            // e da qui :  http://www.albertobarbazza.it/Programming/Delegati_it.aspx
            // tratto da qui: http://the--semicolon.blogspot.it/p/change-wpf-window-label-content-from.html
            Dispatcher.Invoke(new Action(() => { lblIp.Content = s; }));
            //---------------

        }

        void F2()
        {
            string s = "ciao";
            s = dati.Mac1.ToString("X");
            s = s + dati.Mac2.ToString("X");


            string s1;
            s1 = s.Substring(0, 2) +
                 "-" + s.Substring(2, 2) +
                 "-" + s.Substring(4, 2) +
                 "-" + s.Substring(6, 2) +
                 "-" + s.Substring(8, 2) +
                 "-" + s.Substring(10, 2);

            //lblIp.Content = "cippo";
            Console.WriteLine(s1);

            // e da qui :  http://www.albertobarbazza.it/Programming/Delegati_it.aspx
            // tratto da qui: http://the--semicolon.blogspot.it/p/change-wpf-window-label-content-from.html
            Dispatcher.Invoke(new Action(() => { lblMac.Content = s1; }));
            //---------------

        }

        void F3a(string s)
        {
            //string s = "ciao";
            //s = dati.sf1;
            //lblIp.Content = "cippo";
            Console.WriteLine(s);

            // e da qui :  http://www.albertobarbazza.it/Programming/Delegati_it.aspx
            // tratto da qui: http://the--semicolon.blogspot.it/p/change-wpf-window-label-content-from.html
            Dispatcher.Invoke(
                new Action(() => { 
                    LB_serial.Items.Add(s);
                    LB_serial.SelectedIndex = LB_serial.Items.Count - 1;
                    //LB_serial.SelectedIndex = - 1;
                    //LB_serial.Items.Refresh();
                    //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    LB_serial.ScrollIntoView(LB_serial.SelectedItem);
                    
                    //timer1_lbserial = 2;
                })
            );

            //---------------

        }

        //private void OnCollectionChanged(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        //{
        //    throw new NotImplementedException();
        //}

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            // solo per test
            dati.f1();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            string s;
            s = txtMac.Text;
            typeMac(s);

            string ls;
            ls = string.Format(",{0:D},{1:D},606,. ", dati.Mac1, dati.Mac2);
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void typeMac(string s)
        {
            ulong ulv;
            byte[] lblMac = new byte[6];
            string s1, ls;
            int v1, i;
            byte v0;
            s = s + "00.00.00.00.00.00";
            i = 0;
            ulv = 0;
            for (i = 0; i < 6; i++)
            {
                s1 = s.Substring(i * 3, 2);
                try
                {
                    v1 = int.Parse(s1, System.Globalization.NumberStyles.HexNumber);
                }
                catch (Exception ex1)
                {
                    v1 = 0;
                }

                v1 = v1 & 0xFF;
                v0 = (byte)v1;
                ulv = ulv * 256 + v0;
                ls = string.Format("{0:X02}:", v1);
                Console.Write(ls);
            }
            Console.WriteLine();
            ls = string.Format("{0:X}", ulv);
            Console.WriteLine(ls);

            uint a, b;
            a = (uint)ulv;
            b = (uint)(ulv >> 32);
            ls = string.Format("{0:X}", a);
            Console.WriteLine(ls);
            ls = string.Format("{0:X}", b);
            Console.WriteLine(ls);
            dati.Mac1 = b;
            dati.Mac2 = a;


        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",607,. ");
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }

        private void Butt_GetIpMac(object sender, RoutedEventArgs e)
        {
            string ls;
            uint ip, mac1, mac2;
            ip = dati.localIp;
            mac1 = dati.Mac1;
            mac2 = dati.Mac2;

            ls = string.Format("{0:X} {1:X} {2:X}", ip, mac1, mac2);
            Console.WriteLine(ls);

        }



        private void CB_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            dati.showAll = (CB_ShowAll.IsChecked == true);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            LB_serial.Items.Clear();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {

           // LB_serial.SelectedItem = observableCollection.Last();


           // LB_serial.ScrollIntoView(LB_serial.SelectedItem);

           // LB_serial.EnsureVisible(LB_serial.Items.Count - 1);

            //LB_serial.Items.Refresh();
            
            //LB_serial.SelectedIndex = LB_serial.Items.Count - 1;
            //LB_serial.ScrollIntoView(LB_serial.SelectedItem);

            LB_serial.SelectedIndex = LB_serial.Items.Count - 1;
            LB_serial.ScrollIntoView(LB_serial.SelectedItem);
            //LB_serial.Items.Add("hello");
            
            //LB_serial.LayoutUpdated += ListBox_LayoutUpdated;
            //LB_serial.UpdateLayout();

            //LB_serial.Items.MoveCurrentToLast();
            //LB_serial.ScrollIntoView(LB_serial.Items.CurrentItem);
            //LB_serial.Items.Refresh();


            //this.LB_serial.ScrollIntoView(this.LB_serial.Items.Count - 1);

            //int visibleItems = LB_serial.ClientSize.Height / LB_serial.ItemHeight;
            //LB_serial.TopIndex = Math.Max(LB_serial.Items.Count - visibleItems + 1, 0);

            

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            string ls;
            ls = string.Format(",623,. ");
            ls = padStringCrc(ls);
            dati.qe.Enqueue(ls);
        }



        //************************************
    }



    //===============================================
    // http://stackoverflow.com/questions/17572854/c-sharp-net-receiving-udp-packets-in-separater-thread-and-application-exit
    //===============================================

    public class MyMessageArgs : EventArgs
    {
        public byte[] data { get; set; }

        public MyMessageArgs(byte[] newData)
        {
            data = newData;
        }
    }


    class UDPListener
    {
        private int m_portToListen = 2280; //12345; //2003;
        private volatile bool listening;
        Thread m_ListeningThread;
        public event EventHandler<MyMessageArgs> NewMessageReceived;

        //        UdpClient listener = null;


        //constructor
        public UDPListener()
        {
            this.listening = false;
        }

        public void StartListener(int exceptedMessageLength)
        {
            if (!this.listening)
            {
                m_ListeningThread = new Thread(ListenForUDPPackages);
                this.listening = true;
                m_ListeningThread.Start();
            }
        }

        public void StopListener()
        {
            this.listening = false;
            //listener.Close();   // forcibly end communication 
        }

        public void ListenForUDPPackages()
        {
            UdpClient listener = null;
            try
            {
                listener = new UdpClient(m_portToListen);
            }
            catch (SocketException)
            {
                //do nothing
            }

            if (listener != null)
            {
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, m_portToListen);

                try
                {
                    while (this.listening)
                    {
                        Console.WriteLine("Waiting for UDP broadcast to port " + m_portToListen);
                        byte[] bytes = listener.Receive(ref groupEP);

                        string sResponse = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(sResponse);

                        //raise event                        
                        //NewMessageReceived(this, new MyMessageArgs(bytes));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    listener.Close();
                    Console.WriteLine("Done listening for UDP broadcast");
                }
            }
        }
    }

    //=============================================================================










    public class MarginConverter : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness(0, System.Convert.ToDouble(value), 0, 0);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class MultiMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness(System.Convert.ToDouble(values[0]),
                                 System.Convert.ToDouble(values[1]),
                                 System.Convert.ToDouble(values[2]),
                                 System.Convert.ToDouble(values[3])
                                 );
        }

        public object[] ConvertBack(object value, System.Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }




    //============================================================================
    public class TcpServer
    {
        private Thread m_thread;
        private volatile bool m_stop;

        public TcpServer() { }

        public void Start()
        {
            m_thread = new Thread(Listen);
            m_thread.Start();
            m_stop = false;
        }

        private void Listen()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 4000);
            listener.Start();
            try
            {
                while (!m_stop)
                {
                    if (listener.Pending())
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Thread clientThread = new Thread(new ParameterizedThreadStart(ClientConnection));
                        clientThread.Start(client);
                    }
                    else
                        Thread.Sleep(10);
                }
            }
            finally { listener.Stop(); }
        }

        //NetworkStream clientStream = new NetworkStream(); // aggiungo io perchè non c'era ????
        int cnt000 = 0;
        private void ClientConnection(object client)
        {
            using (TcpClient tcpClient = (TcpClient)client)
            using (NetworkStream netStream = tcpClient.GetStream())
            {
                //if (DataAvailable(clientStream, 5000)) // sul sito era così, ma non và
                if (DataAvailable(netStream, 5000)) // questo l'ho cambiato io.
                {
                    byte[] buffer = new byte[4096]; // Read don't block because DataAvailable is true 
                    int readCount = netStream.Read(buffer, 0, buffer.Length);
                    if (readCount > 0)
                    { // read data
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string text = encoder.GetString(buffer, 0, readCount); // answer
                        //                        byte[] answer = encoder.GetBytes("Server received: " + text + "CIPPOLO");
                        //Console.WriteLine(text);

                        //text= @"HTTP/1.1 200 OK
                        //Server:Apache/2.4.10 (Win32) PHP/5.4.31
                        //E-tag:""1-53e2d4e817c17""
                        //Accept-Ranges: bytes
                        //Content-Length:1
                        //Keep-Alive:timeout=5, max=100
                        //Connection:Keep-Alive
                        //Content-Type: text/html
                        //
                        //A";
                        //text = "HTTP/1.1 200 OK\r\nblabla:blublbl\r\n\r\nA\r\nB\r\n";

                        text = "ab1bvc cnt:" + cnt000.ToString(); cnt000++;
                        text = MainWindow.udpRx;
                        







                        //text = "HTTP/1.1 200 OK\r\ncontent-type: text/plain\r\n\r\nciao\r\n";
                        byte[] answer = encoder.GetBytes(text);// + "{\"id\":\"1\",\"content\":\"Hello, World!\"}\r\n\r\n");
                        netStream.Write(answer, 0, answer.Length);


                        string sResponse = Encoding.UTF8.GetString(answer);
                        if (sResponse != "nodata")
                        {
                            Console.WriteLine("tcp serv " + cnt000 + ":" + sResponse);
                        }
                        //Thread.Sleep(1000);

                        netStream.Flush();


                        //Console.WriteLine("=======");

                        MainWindow.udpRx = "nodata"; // "{\"check\":\"2\"}";
                    }
                }
            }
        }

        public bool DataAvailable(NetworkStream netStream, int timeout)
        {
            int start = Environment.TickCount;
            while (!netStream.DataAvailable)
            {
                if ((Environment.TickCount - start > timeout) || m_stop) return false;
                Thread.Sleep(1);
            }
            return true;
        }

        public void Stop()
        {
            m_stop = true;
            if (!m_thread.Join(1000))
                throw new Exception("Stop server failed");
        }
    }
    //============================ end of class tcpserver =============


}

sealed class led
{
    static public Rectangle[] r1 = new Rectangle[1000];
    static public Label[] label = new Label[1000];
    //led(){
    //    for (int i = 0; i < 1000; i++)
    //    {
    //        r1[i] = new Rectangle();
    //        r1[i].Width = 9;
    //        label[i] = new Label();
    //    }
    //}
}

sealed class dati
{
    //public static Mutex mutex1 = new Mutex();

    public static string stringa;

    public static uint localIp;
    public static uint Mac1;
    public static uint Mac2;

    //------------------------------------- prova per settare una label nel thread principale
    public delegate void MyFunc();

    public static MyFunc f1; // ip in label
    public static string sf1 = "ola pippo";

    public static MyFunc f2; // scrive Mac in label
    //-------------------------------------




    // public string fwVersion = "10100";

    public static int totSw;
    public static int numSw;

    public static int switchPremuto;
    public static int switchInTest;


    public static int cv2m;
    public static int cv2ml;
    public static int cv2mr;

    public static double et1;

    public static byte[] ledArray = new byte[32];

    public static byte[] plcOut = new byte[16];
    public static byte[] plcInp = new byte[16];


    //public static led[] leds = new led[1000];


    public static int freqMaxv1;

    public static int freqMaxv2;

    public static int fwvers = 10100;
    public static int timerAlarmlabel27;
    public static ulong noData;

    public static ulong freeBuffer;
    public static int serialRequestOpen;

    public static int serialRequestClose;
    public static double freqAppresa;
    public static double freqAppresa2;
    public static int stopm;
    public static int show;
    public static int serialError = 0;
    public static ConcurrentQueue<string> qe = new ConcurrentQueue<string>();
    public static bool showAll = false;
    public static bool aggiorna;
    //
    public static int freqMin1;
    public static int freqMax1;
    public static int inpMin1;
    public static int inpMax1;
    public static int pwrMin1;
    public static int pwrMax1;
    //
    public static int freqMin2;
    public static int freqMax2;
    public static int inpMin2;
    public static int inpMax2;
    public static int pwrMin2;
    public static int pwrMax2;
    //
    public static int rpmHertz;
    public static double hrratio;
    public static int rpmHertz2;
    public static double hrratio2;
    public static double freqHyst;
    public static int alarmEn1;
    public static int alarmEn2;
    public static int PercMin;
    public static int PercMax;
    public static int alarmStatus;
    public static int timerAlarm;
    public static int alarm1;
    public static int alarm2;
    //
    public static int delayAlarmFreq;
    public static int delayAlarmINP;
    public static int delayAlarmPWR;
    public static int ledMode;
    //

    public static int timerStart;
    public static int al1;

    public static int al2;
    //

}

public class CLelabora
{


    public delegate void MyFuncf1a(string s);
    public static MyFuncf1a f1a; // ip in label


    public delegate void MyFunc();
    public static MyFunc f1; // ip in label


    public delegate void MyFuncf3a(string s);
    public static MyFuncf3a f3a; // ip in label


    //
    static int sCrc;
    static int rCrc;
    static int cCrc;
    static int inpIdx;
    static int Fnib;
    static int rIdx;
    static int hv;
    static int BPayloadLen;
    int v1;
    int v2;
    int v3;
    int v4;
    int v5;
    int v6;
    int v7;
    int v8;
    int v9;
    int v0;
    int v11;
    const int KFreqM = 10;
    public int Ack;
    public int timerAck;
    static byte[] Ba1 = new byte[601];

    static int ii = 0;
    string s = "";


    // 
    public int getCrc16(int b, int wv)
    {
        ushort[] table = {
			0x0,
			0xc0c1,
			0xc181,
			0x140,
			0xc301,
			0x3c0,
			0x280,
			0xc241,
			0xc601,
			0x6c0,
			0x780,
			0xc741,
			0x500,
			0xc5c1,
			0xc481,
			0x440,
			0xcc01,
			0xcc0,
			0xd80,
			0xcd41,
			0xf00,
			0xcfc1,
			0xce81,
			0xe40,
			0xa00,
			0xcac1,
			0xcb81,
			0xb40,
			0xc901,
			0x9c0,
			0x880,
			0xc841,
			0xd801,
			0x18c0,
			0x1980,
			0xd941,
			0x1b00,
			0xdbc1,
			0xda81,
			0x1a40,
			0x1e00,
			0xdec1,
			0xdf81,
			0x1f40,
			0xdd01,
			0x1dc0,
			0x1c80,
			0xdc41,
			0x1400,
			0xd4c1,
			0xd581,
			0x1540,
			0xd701,
			0x17c0,
			0x1680,
			0xd641,
			0xd201,
			0x12c0,
			0x1380,
			0xd341,
			0x1100,
			0xd1c1,
			0xd081,
			0x1040,
			0xf001,
			0x30c0,
			0x3180,
			0xf141,
			0x3300,
			0xf3c1,
			0xf281,
			0x3240,
			0x3600,
			0xf6c1,
			0xf781,
			0x3740,
			0xf501,
			0x35c0,
			0x3480,
			0xf441,
			0x3c00,
			0xfcc1,
			0xfd81,
			0x3d40,
			0xff01,
			0x3fc0,
			0x3e80,
			0xfe41,
			0xfa01,
			0x3ac0,
			0x3b80,
			0xfb41,
			0x3900,
			0xf9c1,
			0xf881,
			0x3840,
			0x2800,
			0xe8c1,
			0xe981,
			0x2940,
			0xeb01,
			0x2bc0,
			0x2a80,
			0xea41,
			0xee01,
			0x2ec0,
			0x2f80,
			0xef41,
			0x2d00,
			0xedc1,
			0xec81,
			0x2c40,
			0xe401,
			0x24c0,
			0x2580,
			0xe541,
			0x2700,
			0xe7c1,
			0xe681,
			0x2640,
			0x2200,
			0xe2c1,
			0xe381,
			0x2340,
			0xe101,
			0x21c0,
			0x2080,
			0xe041,
			0xa001,
			0x60c0,
			0x6180,
			0xa141,
			0x6300,
			0xa3c1,
			0xa281,
			0x6240,
			0x6600,
			0xa6c1,
			0xa781,
			0x6740,
			0xa501,
			0x65c0,
			0x6480,
			0xa441,
			0x6c00,
			0xacc1,
			0xad81,
			0x6d40,
			0xaf01,
			0x6fc0,
			0x6e80,
			0xae41,
			0xaa01,
			0x6ac0,
			0x6b80,
			0xab41,
			0x6900,
			0xa9c1,
			0xa881,
			0x6840,
			0x7800,
			0xb8c1,
			0xb981,
			0x7940,
			0xbb01,
			0x7bc0,
			0x7a80,
			0xba41,
			0xbe01,
			0x7ec0,
			0x7f80,
			0xbf41,
			0x7d00,
			0xbdc1,
			0xbc81,
			0x7c40,
			0xb401,
			0x74c0,
			0x7580,
			0xb541,
			0x7700,
			0xb7c1,
			0xb681,
			0x7640,
			0x7200,
			0xb2c1,
			0xb381,
			0x7340,
			0xb101,
			0x71c0,
			0x7080,
			0xb041,
			0x5000,
			0x90c1,
			0x9181,
			0x5140,
			0x9301,
			0x53c0,
			0x5280,
			0x9241,
			0x9601,
			0x56c0,
			0x5780,
			0x9741,
			0x5500,
			0x95c1,
			0x9481,
			0x5440,
			0x9c01,
			0x5cc0,
			0x5d80,
			0x9d41,
			0x5f00,
			0x9fc1,
			0x9e81,
			0x5e40,
			0x5a00,
			0x9ac1,
			0x9b81,
			0x5b40,
			0x9901,
			0x59c0,
			0x5880,
			0x9841,
			0x8801,
			0x48c0,
			0x4980,
			0x8941,
			0x4b00,
			0x8bc1,
			0x8a81,
			0x4a40,
			0x4e00,
			0x8ec1,
			0x8f81,
			0x4f40,
			0x8d01,
			0x4dc0,
			0x4c80,
			0x8c41,
			0x4400,
			0x84c1,
			0x8581,
			0x4540,
			0x8701,
			0x47c0,
			0x4680,
			0x8641,
			0x8201,
			0x42c0,
			0x4380,
			0x8341,
			0x4100,
			0x81c1,
			0x8081,
			0x4040
		};
        int crc = 0;
        b = b & 0xff;
        wv = wv & 0xffff;
        crc = wv;
        crc = (crc >> 8) ^ table[(crc ^ b) & 0xff] & 0xffff;
        return crc;
    }

    public uint getReverseULongAt(int idx)
    {
        uint v = 0;
        uint v1 = 0;
        uint v2 = 0;
        uint v3 = 0;
        uint v4 = 0;

        v1 = (uint)(Ba1[idx + 3] & 0xff);
        v2 = (uint)(Ba1[idx + 2] & 0xff);
        v3 = (uint)(Ba1[idx + 1] & 0xff);
        v4 = (uint)(Ba1[idx + 0] & 0xff);
        v = 0;
        v = v | v4;
        v = v << 8;
        v = v | v3;
        v = v << 8;
        v = v | v2;
        v = v << 8;
        v = v | v1;
        return v;
    }

    public int getReverseWordAt(int idx)
    {
        int v = 0;
        int v1 = 0;
        int v2 = 0;
        v1 = Ba1[idx + 1] & 0xff;
        v2 = Ba1[idx + 0] & 0xff;
        v = 0;
        v = v | v2;
        v = v << 8;
        v = v | v1;
        return v;
    }

    public int getByteAt(int idx)
    {
        int v = 0;
        int v1 = 0;
        v1 = Ba1[idx + 0] & 0xff;
        v = 0;
        v = v | v1;
        return v;
    }



    public void keepB1()
    {
        if ((Ba1[0] != 1))
        {
            return;
            //// not this tipe
        }
        Console.WriteLine("\r\nacknowledged");
        Ack = 1;
        if ((timerAck > 0))
            timerAck = 0;
    }


    public void keepB38()
    {
        string ls1 = "";

        if ((Ba1[0] != 38))
        {
            return;
            //// not this tipe
        }

        int index = 0;
        index = getByteAt(1);

        switch ((index))
        {
            case 0:
                dati.freqMin1 = getReverseWordAt(2);
                dati.freqMax1 = getReverseWordAt(4);
                dati.inpMin1 = getReverseWordAt(6);
                dati.inpMax1 = getReverseWordAt(8);
                dati.pwrMin1 = getReverseWordAt(10);
                dati.pwrMax1 = getReverseWordAt(12);
                dati.rpmHertz = getReverseWordAt(14);
                dati.rpmHertz2 = getReverseWordAt(16);
                dati.hrratio = Convert.ToDouble(dati.rpmHertz) / 10;
                dati.hrratio2 = Convert.ToDouble(dati.rpmHertz2) / 10;

                break;
            case 1:
                dati.freqMin2 = getReverseWordAt(2);
                dati.freqMax2 = getReverseWordAt(4);
                dati.inpMin2 = getReverseWordAt(6);
                dati.inpMax2 = getReverseWordAt(8);
                dati.pwrMin2 = getReverseWordAt(10);
                dati.pwrMax2 = getReverseWordAt(12);
                dati.freqHyst = getReverseWordAt(14);

                break;
            case 2:
                dati.alarmEn1 = getReverseWordAt(2);
                dati.alarmEn2 = getReverseWordAt(4);
                dati.PercMin = getReverseWordAt(6);
                dati.PercMax = getReverseWordAt(8);
                dati.alarmStatus = getReverseWordAt(10);
                dati.timerAlarm = getReverseWordAt(12);
                dati.alarm1 = getReverseWordAt(14);
                dati.alarm2 = getReverseWordAt(16);
                //Dati.freqP.drawPanel();
                dati.ledMode = getByteAt(18);

                break;
            case 3:
                dati.delayAlarmFreq = getReverseWordAt(2);
                dati.delayAlarmINP = getReverseWordAt(4);
                dati.delayAlarmPWR = getReverseWordAt(6);
                dati.aggiorna = true;
                break;
        }


    }


    public void keepB100()
    {
        v1 = getByteAt(1);
        dati.switchPremuto = v1;
        Console.WriteLine("switch premuto: " + v1);
        if (dati.switchPremuto == dati.switchInTest)
        {
            Console.WriteLine("switch in test ok");
            //Bstate[v1] = 1; // stato ok
            //Bklik[v1] = true;
        }
    }




    public void keepB101()
    {
        int i, j, v, index;
        string s;
        for (i = 0; i < 8; i++)
        {
            v = getByteAt(1 + i);
            dati.ledArray[i] = (byte)v;

        }
        v = getReverseWordAt(9);
        dati.fwvers = v;

    }



    public void keepB102()
    {
        uint v1;
        v1 = getReverseULongAt(1);
        Console.WriteLine("test 102: " + v1);
        string hexValue = v1.ToString("X");
        Console.WriteLine(hexValue);
        // Convert the hex string back to the number
        int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        Console.WriteLine(intAgain);

        string ipAddress = new IPAddress(BitConverter.GetBytes(intAgain)).ToString();
        Console.WriteLine(ipAddress);


        dati.localIp = v1;

        //dati.sf1 = ipAddress;
        //dati.f1();

        //f1();
        f1a(ipAddress);


    }

    public void keepB103()
    {
        uint v1, v2;
        v1 = getReverseULongAt(1);
        v2 = getReverseULongAt(5);
        Console.Write("test 103: ");

        string hexv1 = v1.ToString("X");
        Console.Write(hexv1 + " ");
        string hexv2 = v2.ToString("X");
        Console.Write(hexv2 + "\r\n");

        dati.Mac1 = v1;
        dati.Mac2 = v2;
        //dati.sf1 = ipAddress;
        dati.f2();


    }




    public void keepB37()
    {
        v1 = getReverseWordAt(3);
        dati.fwvers = v1;

        ////--------------------------------- freq letta
        v1 = getReverseWordAt(5);
        double fc = 0;
        //; //, min, max, p, f;
        fc = v1 / KFreqM;
        dati.freqAppresa = fc;
        Console.WriteLine("\r\nfreq:" + fc + "\r\n");
        //sprintf(ls1 , "\r\n%7.1f Hz\r\n", fc);

        //printf(ls1);
        ////Dati.freqP.jLabel18.setText(ls1);
        ////Dati.freqP.Lfreq.ss(ls1);
        ////---------------------------------
        //Console.WriteLine("freq: " & dati.freqAppresa & " " & ii)
        dati.al1 = getByteAt(17);
        dati.al2 = getByteAt(18);

        v1 = getReverseWordAt(20);
        fc = v1 / KFreqM;
        dati.freqAppresa2 = fc;


        ii += 1;
    }

    public void keepCMD()
    {
        switch ((Ba1[0] & 0xff))
        {
            case 1:
                keepB1();
                //// the acknowledge
                break;
            case 37:
                keepB37();
                break;
            case 38:
                keepB38();
                break;
            case 100:
                keepB100();
                break;
            case 101:
                keepB101();
                break;
            case 102:
                keepB102();
                break;
            case 103:
                keepB103();
                break;
        }
    }

    public int h2n(int h)
    {
        int v = 0;
        v = h;
        if ((h >= 0x30) & (h <= 0x39))
        {
            v = (h & 0xf);
        }
        if ((h >= 0x41) & (h <= 0x46))
        {
            v = ((h - 0x41 + 0xa) & 0xf);
        }
        return (v & 0xf);
    }
    //readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_keepbinh_showF_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();


    bool showF = false;

    public void keepbinh(int bi)
    {
        Console.Write((char)bi);
        //dati.mutex1.WaitOne();

        //--------------------------

        if (bi == 10)
        {
            return;
        }
        
        
        if (bi == (int)'>')
        {

            int a = 1;
        }

        if (bi == (int)'<')
        {
            showF = true;
            s = "";
        }

        if (showF && dati.showAll == false)
        {
            if (bi != 13)
            {
                s = s + (char)bi;
            }
        }




        if (showF || dati.showAll)
        {
            if (bi == (int)'>')
            {

                if (showF && dati.showAll && (char)bi=='>')
                {
                    s = s + (char)bi;
                }

                f3a(s);
                s = "";
               
            }
        }

        if (bi == (int)'>')
        {
            showF = false;
        }


        //-----------------------


        //
        //        Dim bi As Char
        //        bi = bin.ToString

        if (bi == (int)'.')
        {
            sCrc = cCrc;
        }
        //
        cCrc = getCrc16(bi, cCrc);
        //Console.WriteLine("  cCrc:" & Format(cCrc, "X4") & " sCrc:" & Format(sCrc, "X4") & " rCrc:" & Format(rCrc, "X4"))
        //
        if (bi == (int)'(')
        {
            int xxx = 0;
            xxx = 1;
        }


        if (bi == 10)
        {
            int xxx = 0;
            xxx = 1;
        }

        if (bi == 13)
        {
            int xxx = 0;
            xxx = 1;
            if (dati.showAll == true)
            {
                //Console.WriteLine();
                f3a(s);
                s = "";
            }
        }


        if (bi == (int)'(' | bi == (int)'#' | bi == (int)'!' | bi == (int)'=')
        {
            //Console.WriteLine();
            if (dati.showAll == true)
            {
                //Console.WriteLine();
                s = "";
            }

            inpIdx = 0;
            Fnib = 0;
            rIdx = 0;
            //clr rIdx index
            cCrc = 0;
            rCrc = 0;
        }
        //
        if (dati.showAll == true)
        {
            //Console.Write((char)(bi));
            if((char)bi!='>') s = s + (char)bi;
        }
        //
        if (bi == (int)'x' | bi == (int)'y' | bi == (int)'z' | bi == (int)'o')
        {
            if (dati.showAll == true)
            {
                //Console.WriteLine();
                f3a(s);
                s = "";
            }

            if (rCrc == sCrc)
            {
                BPayloadLen = rIdx;
                //sprintf(ls, "crc ok\r\n")
                //printf(ls)
                //Console.WriteLine("crc ok")
                //Console.WriteLine("crc ok   : " & Format(rCrc, "X4") & " " & Format(sCrc, "X4") & " " & Format(cCrc, "X4"))
                keepCMD();
            }
            else
            {
                //Console.WriteLine("crc error: " & Format(rCrc, "X4") & " " & Format(sCrc, "X4") & " " & Format(cCrc, "X4"))
                //sprintf(ls, "\r\nerror: crc_PC  r%04X c%04X\r\n", rCrc, sCrc)
                //printf(ls)
            }
        }
        //
        if ((bi >= (int)'0' & bi <= (int)'9') | (bi >= (int)'A' & bi <= (int)'F'))
        {
            hv = ((hv << 4) | h2n(bi)) & 0xff;
            Fnib = ((Fnib + 1) & 1);
            if (((Fnib & 1) == 0))
            {
                Fnib = 0;
                Ba1[rIdx] = (byte)(hv & 0xff);
                rCrc = ((rCrc << 8) | hv) & 0xffff;
                if ((rIdx < 510))
                {
                    rIdx += 1;
                }
            }
        }
        //


        //dati.mutex1.ReleaseMutex();
    }


}

