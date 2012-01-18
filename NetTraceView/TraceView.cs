/************************************************************************
 *       (c) Copyright by Ing. Walter Ljutek                 2006       *
 ************************************************************************
 *                                                                      *
 *  PROJECT   : Trace View                                              *
 *  PROGRAM   : ANY														*
 *  FILE      : uSendDebugMsg.cs										*
 *  LANGUAGE  : Microsoft Visual C# .NET								*
 *  VERSION   : 1.00                                                    *
 *  DATE      : 22.06.06                                                *
 ************************************************************************
 *                                                                      *
 *  HISTORY                                                             *
 *      22.06.2006	Walter Ljutek		Rev 1.00                       	*
 ************************************************************************
 *                                                                      *
 *  DESCRIPTION                                                         *
 *                                                                      *
 *      Message Packer for Trace View.                                  *
 *                                                                      *
 ************************************************************************/

using System;
using System.Diagnostics;

public class TraceView
{
	private const string MSG_HDR	= "[TV]";		// HEADER: Trace View 
	private const string MSG_PID	= "[PID]";		// Process ID 
	private const string MSG_EXE	= "[EXE]";		// Executable Name (Process name)
	private const string MSG_TYPE	= "[TYPE]";		// Message type
	private const string MSG_UNIT	= "[UNIT]";		// Unit name
	private const string MSG_PROC	= "[PROC]";		// Procedure / Function name
	private const string MSG_DESC	= "[DESC]";		// Message description

	public enum TMsgType {MsgDebug, MsgInformation, MsgWarning, MsgError, MsgSQL, MsgPLC, MsgEXCEPTION, MsgUnknown};

	//****************************************************************************************************************
	// static private string PackDebugMessage (TMsgType MsgType, string UnitName, string ProcName, string Description)
	//****************************************************************************************************************
	static private string PackDebugMessage (TMsgType MsgType, string UnitName, string ProcName, string Description)
	{
		return (MSG_HDR		+ (char)32 + 
				MSG_TYPE	+ (char)32 + Convert.ToInt32(MsgType) + (char)32 + 
				MSG_UNIT	+ (char)32 + UnitName + (char)32 +
				MSG_PROC	+ (char)32 + ProcName + (char)32 +
				MSG_DESC	+ (char)32 + Description + (char)32);
	}

	//****************************************************************************************************************
	// static public void SendDebugMessage (TMsgType MsgType, string UnitName, string ProcName, string Description)
	//****************************************************************************************************************
	static public void SendDebugMessage (TMsgType MsgType, string UnitName, string ProcName, string Description)
	{
		Trace.WriteLine (PackDebugMessage(MsgType, UnitName, ProcName, Description));
	}
}
