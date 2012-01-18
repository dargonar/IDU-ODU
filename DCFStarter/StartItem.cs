using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCFStarter
{
  public class StartItem
  {
    public StartItem() { }
    public StartItem(string argSemiColonSeparatedValue) 
    {
      string[] data = argSemiColonSeparatedValue.Split(';');
      foreach (string name_value in data)
      {
        string[] item = name_value.Split('=');
        switch (item[0].Trim())
        { 
          case StartItem.NAME:
            this.Name = item[1].Trim();
            break;
          case StartItem.PATH:
            this.Path = item[1].Trim();
            break;
          case StartItem.TYPE:
            this.Type = item[1].Trim();
            break;

        }
      }
    }

    private const string APPLICATION  = "application";
    private const string SERVICE      = "service";
    private const string NAME = "name";
    private const string PATH = "path";
    private const string TYPE = "type";

    //type=application;name=OPCDAServer.exe;path=C:\Archivos de programa\Siemens\S7-200 PC Access\Bin\OPCDAServer.exe
    private string mType= string.Empty;   //application service
    private string mName= string.Empty;   //OPCDAServer.exe
    private string mPath = string.Empty;  //C:\Archivos de programa\Siemens\S7-200 PC Access\Bin\OPCDAServer.exe

    public string Type {

      get { return mType; }
      set { mType = value; }
    }
    public string Name 
    {
      get { return mName; }
      set { mName= value;}
    }
    public string Path 
    {
      get { return mPath; }
      set { mPath= value;}
    }

    public bool IsService() 
    {
      if (string.IsNullOrEmpty(this.mType))
        return false;
      return this.mType.Trim().Equals(StartItem.SERVICE);
    }
    public bool IsApplication() 
    {
      if (string.IsNullOrEmpty(this.mType))
        return false;
      return this.mType.Trim().Equals(StartItem.APPLICATION);
    }
  }
}
