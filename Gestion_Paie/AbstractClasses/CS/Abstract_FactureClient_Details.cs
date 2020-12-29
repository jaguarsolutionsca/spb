﻿using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [FactureClient_Details] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_FactureClient_Details {

		Params.spS_FactureClient_Details Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_FactureClient_Details class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_FactureClient_Details(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient_Details'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureClient_Details", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_FactureClient_Details(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureClient_Details class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_FactureClient_Details(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlConnection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlConnection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient_Details'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureClient_Details", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureClient_Details(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureClient_Details class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_FactureClient_Details(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlTransaction.Connection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlTransaction.Connection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlTransaction.Connection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient_Details'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureClient_Details", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureClient_Details(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_FactureID;
		/// <summary>
		/// Returns the value of the FactureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FactureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_FactureID {

			get {

				return (this.col_FactureID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Ligne;
		/// <summary>
		/// Returns the value of the Ligne column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Ligne&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Ligne {

			get {

				return (this.col_Ligne);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte;
		/// <summary>
		/// Returns the value of the Compte column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte {

			get {

				return (this.col_Compte);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant;
		/// <summary>
		/// Returns the value of the Montant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant {

			get {

				return (this.col_Montant);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_RefID;
		/// <summary>
		/// Returns the value of the RefID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;RefID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_RefID {

			get {

				return (this.col_RefID);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Ligne = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;
			this.col_RefID = System.Data.SqlTypes.SqlInt32.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [FactureClient_Details] table.
		/// </summary>
		/// <param name="col_FactureID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FactureID&quot; column.</param>
		/// <param name="col_Ligne">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Ligne&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_FactureID, System.Data.SqlTypes.SqlInt32 col_Ligne) {

			bool Status;
			Reset();

			if (col_FactureID.IsNull) {

				throw new ArgumentNullException("col_FactureID" , "The primary key 'col_FactureID' can not have a Null value!");
			}

			if (col_Ligne.IsNull) {

				throw new ArgumentNullException("col_Ligne" , "The primary key 'col_Ligne' can not have a Null value!");
			}


			this.col_FactureID = col_FactureID;
			this.col_Ligne = col_Ligne;

			this.Param.Reset();

			this.Param.Param_FactureID = this.col_FactureID;
			this.Param.Param_Ligne = this.col_Ligne;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_FactureClient_Details SP = new SPs.spS_FactureClient_Details(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_FactureClient_Details.Resultset1.Fields.Column_Compte.ColumnIndex)) {

						this.col_Compte = DR.GetSqlInt32(SPs.spS_FactureClient_Details.Resultset1.Fields.Column_Compte.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient_Details.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = DR.GetSqlDouble(SPs.spS_FactureClient_Details.Resultset1.Fields.Column_Montant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient_Details.Resultset1.Fields.Column_RefID.ColumnIndex)) {

						this.col_RefID = DR.GetSqlInt32(SPs.spS_FactureClient_Details.Resultset1.Fields.Column_RefID.ColumnIndex);
					}

					Status = true;
				}

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				return(Status);
			}

			else {

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_FactureClient_Details", "Refresh");
			}
		}
	}
}