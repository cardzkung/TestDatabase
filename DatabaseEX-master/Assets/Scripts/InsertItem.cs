using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System.Data;
using System;
using UnityEngine.UI;

public class InsertItem : MonoBehaviour {

	public InputField nameInput;
	public InputField passwordInput;
	public InputField ageInput;
	public Text Show;

	public void Insert(){
		string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(connectionString);

		dbconn.Open(); //Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand();

		string sqlQuery = "insert into Account (userName,password, age) values ('"+ nameInput.text +"','"+ passwordInput.text +"','"+ ageInput.text +"')";
		dbcmd.CommandText = sqlQuery;

		IDataReader reader = dbcmd.ExecuteReader();

		reader.Close();reader = null;
		dbcmd.Dispose();dbcmd = null;
		dbconn.Close();dbconn = null;
	}

	public void SelectFromUI(){
		string connectionString = "URI=file:" + Application.dataPath + "/myDatabase.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(connectionString);
		
		dbconn.Open(); //Open connection to the database.

		Show.text = "";

		IDbCommand dbcmd = dbconn.CreateCommand();
		
		string sqlQuery = "SELECT * FROM Account";
		dbcmd.CommandText = sqlQuery;
		
		IDataReader reader = dbcmd.ExecuteReader();
		
		while(reader.Read()) 
		{
			string Username = reader.GetString(1);
			string Password = reader.GetString(2);
			int Ages = reader.GetInt32(3);
			Show.text += Username+ " - " +Password+ " - " +Ages+ "\n";
			Debug.Log( 1);
		}
		reader.Close();reader = null;
		dbcmd.Dispose();dbcmd = null;
		dbconn.Close();dbconn = null;
	}

}
