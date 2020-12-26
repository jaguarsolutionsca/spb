using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Ajustement] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Ajustement {

		Params.spS_Ajustement Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Ajustement class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Ajustement(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Ajustement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Ajustement(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Ajustement class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Ajustement(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Ajustement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Ajustement(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Ajustement class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Ajustement(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Ajustement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Ajustement(true);
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

		private System.Data.SqlTypes.SqlString col_ContratID;
		/// <summary>
		/// Returns the value of the ContratID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContratID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ContratID {

			get {

				return (this.col_ContratID);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateAjustement;
		/// <summary>
		/// Returns the value of the DateAjustement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateAjustement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateAjustement {

			get {

				return (this.col_DateAjustement);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Periode_Debut;
		/// <summary>
		/// Returns the value of the Periode_Debut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Periode_Debut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Periode_Debut {

			get {

				return (this.col_Periode_Debut);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Periode_Fin;
		/// <summary>
		/// Returns the value of the Periode_Fin column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Periode_Fin&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Periode_Fin {

			get {

				return (this.col_Periode_Fin);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Facture;
		/// <summary>
		/// Returns the value of the Facture column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Facture&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Facture {

			get {

				return (this.col_Facture);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_UsePeriodes;
		/// <summary>
		/// Returns the value of the UsePeriodes column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UsePeriodes&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_UsePeriodes {

			get {

				return (this.col_UsePeriodes);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Date_Debut;
		/// <summary>
		/// Returns the value of the Date_Debut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Date_Debut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Date_Debut {

			get {

				return (this.col_Date_Debut);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Date_Fin;
		/// <summary>
		/// Returns the value of the Date_Fin column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Date_Fin&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Date_Fin {

			get {

				return (this.col_Date_Fin);
			}
		}

		private System.Data.SqlTypes.SqlString col_ProducteurID;
		/// <summary>
		/// Returns the value of the ProducteurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProducteurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ProducteurID {

			get {

				return (this.col_ProducteurID);
			}
		}

		private System.Data.SqlTypes.SqlString col_TransporteurID;
		/// <summary>
		/// Returns the value of the TransporteurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TransporteurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TransporteurID {

			get {

				return (this.col_TransporteurID);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsRistourne;
		/// <summary>
		/// Returns the value of the IsRistourne column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsRistourne&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsRistourne {

			get {

				return (this.col_IsRistourne);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_DateAjustement = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_UsePeriodes = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_IsRistourne = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Ajustement] table.
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
			SPs.spS_Ajustement SP = new SPs.spS_Ajustement(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_Ajustement.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_DateAjustement.ColumnIndex)) {

						this.col_DateAjustement = DR.GetSqlDateTime(SPs.spS_Ajustement.Resultset1.Fields.Column_DateAjustement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Debut.ColumnIndex)) {

						this.col_Periode_Debut = DR.GetSqlInt32(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Debut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Fin.ColumnIndex)) {

						this.col_Periode_Fin = DR.GetSqlInt32(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Fin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = DR.GetSqlBoolean(SPs.spS_Ajustement.Resultset1.Fields.Column_Facture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_UsePeriodes.ColumnIndex)) {

						this.col_UsePeriodes = DR.GetSqlBoolean(SPs.spS_Ajustement.Resultset1.Fields.Column_UsePeriodes.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Debut.ColumnIndex)) {

						this.col_Date_Debut = DR.GetSqlDateTime(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Debut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Fin.ColumnIndex)) {

						this.col_Date_Fin = DR.GetSqlDateTime(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Fin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = DR.GetSqlString(SPs.spS_Ajustement.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = DR.GetSqlString(SPs.spS_Ajustement.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_IsRistourne.ColumnIndex)) {

						this.col_IsRistourne = DR.GetSqlBoolean(SPs.spS_Ajustement.Resultset1.Fields.Column_IsRistourne.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Ajustement", "Refresh");
			}
		}
	}
}
