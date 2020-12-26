using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [FactureClient] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_FactureClient {

		Params.spS_FactureClient Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_FactureClient class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_FactureClient(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureClient", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_FactureClient(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureClient class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_FactureClient(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureClient", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureClient(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureClient class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_FactureClient(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureClient", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureClient(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_ID;
		/// <summary>
		/// Returns the value of the ID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_ID {

			get {

				return (this.col_ID);
			}
		}

		private System.Data.SqlTypes.SqlString col_NoFacture;
		/// <summary>
		/// Returns the value of the NoFacture column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NoFacture&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_NoFacture {

			get {

				return (this.col_NoFacture);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateFacture;
		/// <summary>
		/// Returns the value of the DateFacture column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateFacture&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateFacture {

			get {

				return (this.col_DateFacture);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Annee;
		/// <summary>
		/// Returns the value of the Annee column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Annee&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Annee {

			get {

				return (this.col_Annee);
			}
		}

		private System.Data.SqlTypes.SqlString col_TypeFacture;
		/// <summary>
		/// Returns the value of the TypeFacture column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TypeFacture&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TypeFacture {

			get {

				return (this.col_TypeFacture);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_TypeInvoiceClientAcomba;
		/// <summary>
		/// Returns the value of the TypeInvoiceClientAcomba column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TypeInvoiceClientAcomba&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_TypeInvoiceClientAcomba {

			get {

				return (this.col_TypeInvoiceClientAcomba);
			}
		}

		private System.Data.SqlTypes.SqlString col_ClientID;
		/// <summary>
		/// Returns the value of the ClientID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ClientID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ClientID {

			get {

				return (this.col_ClientID);
			}
		}

		private System.Data.SqlTypes.SqlString col_PayerAID;
		/// <summary>
		/// Returns the value of the PayerAID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PayerAID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_PayerAID {

			get {

				return (this.col_PayerAID);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Total;
		/// <summary>
		/// Returns the value of the Montant_Total column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Total&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Total {

			get {

				return (this.col_Montant_Total);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_TPS;
		/// <summary>
		/// Returns the value of the Montant_TPS column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_TPS&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_TPS {

			get {

				return (this.col_Montant_TPS);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_TVQ;
		/// <summary>
		/// Returns the value of the Montant_TVQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_TVQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_TVQ {

			get {

				return (this.col_Montant_TVQ);
			}
		}

		private System.Data.SqlTypes.SqlString col_Description;
		/// <summary>
		/// Returns the value of the Description column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Description&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Description {

			get {

				return (this.col_Description);
			}
		}

		private System.Data.SqlTypes.SqlString col_Status;
		/// <summary>
		/// Returns the value of the Status column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Status&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Status {

			get {

				return (this.col_Status);
			}
		}

		private System.Data.SqlTypes.SqlString col_StatusDescription;
		/// <summary>
		/// Returns the value of the StatusDescription column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;StatusDescription&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_StatusDescription {

			get {

				return (this.col_StatusDescription);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateFactureAcomba;
		/// <summary>
		/// Returns the value of the DateFactureAcomba column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateFactureAcomba&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateFactureAcomba {

			get {

				return (this.col_DateFactureAcomba);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_NoFacture = System.Data.SqlTypes.SqlString.Null;
			this.col_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_TypeFacture = System.Data.SqlTypes.SqlString.Null;
			this.col_TypeInvoiceClientAcomba = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ClientID = System.Data.SqlTypes.SqlString.Null;
			this.col_PayerAID = System.Data.SqlTypes.SqlString.Null;
			this.col_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;
			this.col_Status = System.Data.SqlTypes.SqlString.Null;
			this.col_StatusDescription = System.Data.SqlTypes.SqlString.Null;
			this.col_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [FactureClient] table.
		/// </summary>
		/// <param name="col_ID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_ID) {

			bool Status;
			Reset();

			if (col_ID.IsNull) {

				throw new ArgumentNullException("col_ID" , "The primary key 'col_ID' can not have a Null value!");
			}


			this.col_ID = col_ID;

			this.Param.Reset();

			this.Param.Param_ID = this.col_ID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_FactureClient SP = new SPs.spS_FactureClient(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_NoFacture.ColumnIndex)) {

						this.col_NoFacture = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_NoFacture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFacture.ColumnIndex)) {

						this.col_DateFacture = DR.GetSqlDateTime(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFacture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = DR.GetSqlInt32(SPs.spS_FactureClient.Resultset1.Fields.Column_Annee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeFacture.ColumnIndex)) {

						this.col_TypeFacture = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeFacture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeInvoiceClientAcomba.ColumnIndex)) {

						this.col_TypeInvoiceClientAcomba = DR.GetSqlInt32(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeInvoiceClientAcomba.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_ClientID.ColumnIndex)) {

						this.col_ClientID = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_ClientID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_PayerAID.ColumnIndex)) {

						this.col_PayerAID = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_PayerAID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_Total.ColumnIndex)) {

						this.col_Montant_Total = DR.GetSqlDouble(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_Total.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TPS.ColumnIndex)) {

						this.col_Montant_TPS = DR.GetSqlDouble(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TPS.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TVQ.ColumnIndex)) {

						this.col_Montant_TVQ = DR.GetSqlDouble(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TVQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_Description.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Status.ColumnIndex)) {

						this.col_Status = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_Status.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_StatusDescription.ColumnIndex)) {

						this.col_StatusDescription = DR.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_StatusDescription.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFactureAcomba.ColumnIndex)) {

						this.col_DateFactureAcomba = DR.GetSqlDateTime(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFactureAcomba.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_FactureClient", "Refresh");
			}
		}
	}
}
