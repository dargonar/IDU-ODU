using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace DCFStarter
{
  public partial class frmDBRestorer : Form
  {
    public frmDBRestorer()
    {
      InitializeComponent();
    }

    public frmDBRestorer(int i)
    {
      InitializeComponent();

      this.Text += " - " + i.ToString();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {

    }

    private void btnSelectBkpFile_Click(object sender, EventArgs e)
    {
      string mDirectory = Starter.getBinFullDirectory();

      openFileDialog1.InitialDirectory = mDirectory;

      DirectoryInfo oDirInfo = new DirectoryInfo(mDirectory);
      FileInfo[] mSqlFiles = oDirInfo.GetFiles("*.sql");
      if (mSqlFiles != null && mSqlFiles.Length > 0)
        openFileDialog1.FileName = mSqlFiles[0].FullName;
      else
        openFileDialog1.FileName = "";

      mSqlFiles = null;
      oDirInfo = null;

      openFileDialog1.ShowDialog();

      if (!string.IsNullOrEmpty(openFileDialog1.FileName))
        this.txtBkpFile.Text = openFileDialog1.FileName;


    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
      txtLog.Text += string.Format("{0} Iniciando Actualización.", Environment.NewLine);
      TextReader tr = new StreamReader(txtBkpFile.Text);
      StringBuilder strb = new StringBuilder(tr.ReadToEnd());
      
      // close the stream
      tr.Close();

      try
      {
        execute(strb.ToString());
      }
      catch (Exception ex)
      {
        txtLog.Text += string.Format("{3}ERROR:  updateDB():: MSG:'{0}'; STACK:'{1}'; SOURCE:'{2}';"
                                       , ex.Message
                                       , ex.StackTrace
                                       , ex.Source
                                       , Environment.NewLine);
        return;
      }
      txtLog.Text += "" + Environment.NewLine;
    }

    private MySqlConnection Connection(string connection)
    {
      MySqlConnection _sqlconnection = null;
      try
      {
        if (_sqlconnection == null)
          _sqlconnection = new MySqlConnection(connection);
        if (_sqlconnection.State != System.Data.ConnectionState.Open)
          _sqlconnection.Open();
        return _sqlconnection;
      }
      catch (Exception ex)
      {
        this.txtLog.Text += string.Format("{0}No se pudo establecer la conexión. {0}ERROR:{1} {0}Stack:{2}{0}", Environment.NewLine, ex.Message, ex.StackTrace);
        throw new Exception(ex.Message, ex);
      }
    }

    private void execute(string sqlCommand)
    {
      MySqlConnection _sqlConn;
      MySqlCommand _sqlComm = new MySqlCommand();
      MySqlTransaction _sqlTrans;
      bool bRet = false;
      //server=localhost;uid=root;pwd=248;database=idu_odu_min;pooling=false;
      _sqlConn = this.Connection(this.txtConnString.Text);

      _sqlTrans = _sqlConn.BeginTransaction();
      _sqlComm.Connection = _sqlConn;
      _sqlComm.CommandTimeout = 32000;
      _sqlComm.Transaction = _sqlTrans;
      try
      {
        
        _sqlComm.CommandText = sqlCommand;
        _sqlComm.ExecuteNonQuery();
        _sqlTrans.Commit();
        bRet = true;
      }
      catch (Exception ex)
      {
        _sqlTrans.Rollback();

        this.txtLog.Text += string.Format("{0}{1} Transaction no pudo ser ejecutada. {0} ERROR:'{2}' {0} STACK:'{3}' {0}", Environment.NewLine, DateTime.Now.ToString(), ex.Message, ex.StackTrace);
        return;

      }
      finally
      {
        _sqlConn.Close();
      }

      if (bRet)
        this.txtLog.Text += string.Format("{0}Transaction ejecutada correctamente!!! {0}", Environment.NewLine);

    }

    private void btnRestoreBat_Click(object sender, EventArgs e)
    {
      string data = "";
        string result = "Finalizado con exito";
      string path = string.Format("{0}\\{1}", Starter.getBinFullDirectory(), "restore.bat");
      List<string> args = new List<string>();
      args.Add( txtUser.Text);
      args.Add( txtPwd.Text);
      args.Add( txtDBChoice.Text);
      args.Add( txtBkpFile.Text);
      args.Add( txtServer.Text);
      args.Add( txtMysqlBinPath.Text);
      try
      {
          RestoreBatExecuter.ExecuteBatchFile(path, args.ToArray(), out data);
      }
        catch(Exception ex)
      {
          result = "Se produjo un error. In tentelo mas tarde o comuniquese con personal de sistemas.";
        }
        
        txtLog.Text += Environment.NewLine;
        txtLog.Text += data;
        txtLog.Text += Environment.NewLine;
        txtLog.Text += result;
    }

    private void btnMysqlBinPath_Click(object sender, EventArgs e)
    {
        folderBrowserDialog1.RootFolder = Environment.SpecialFolder.ProgramFiles ;
        folderBrowserDialog1.ShowDialog();
        this.txtMysqlBinPath.Text = folderBrowserDialog1.SelectedPath; 
    }

    private void frmDBRestorer_Load(object sender, EventArgs e)
    {
        string path = Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles);

        this.txtMysqlBinPath.Text = path + @"\MySQL\MySQL Server 5.0\bin";
        if (!Directory.Exists(this.txtMysqlBinPath.Text))
            this.txtMysqlBinPath.Text = "-- Seleccione el directorio Bin de MySQL server --";

    }
  }
}
