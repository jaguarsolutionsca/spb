using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Ajustement_EssenceUnite] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Ajustement_EssenceUnite {

		Params.spS_Ajustement_EssenceUnite Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Ajustement_EssenceUnite class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Ajustement_EssenceUnite(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement_EssenceUnite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Ajustement_EssenceUnite", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Ajustement_EssenceUnite(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Ajustement_EssenceUnite class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Ajustement_EssenceUnite(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement_EssenceUnite'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Ajustement_EssenceUnite", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Ajustement_EssenceUnite(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Ajustement_EssenceUnite class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Ajustement_EssenceUnite(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement_EssenceUnite'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Ajustement_EssenceUnite", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Ajustement_EssenceUnite(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_AjustementID;
		/// <summary>
		/// Returns the value of the AjustementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;AjustementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_AjustementID {

			get {

				return (this.col_AjustementID);
			}
		}

		private System.Data.SqlTypes.SqlString col_EssenceID;
		/// <summary>
		/// Returns the value of the EssenceID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_EssenceID {

			get {

				return (this.col_EssenceID);
			}
		}

		private System.Data.SqlTypes.SqlString col_UniteID;
		/// <summary>
		/// Returns the value of the UniteID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UniteID {

			get {

				return (this.col_UniteID);
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

		private System.Data.SqlTypes.SqlSingle col_Taux_usine;
		/// <summary>
		/// Returns the value of the Taux_usine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_usine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Taux_usine {

			get {

				return (this.col_Taux_usine);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Taux_producteur;
		/// <summary>
		/// Returns the value of the Taux_producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Taux_producteur {

			get {

				return (this.col_Taux_producteur);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Date_Modification;
		/// <summary>
		/// Returns the value of the Date_Modification column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Date_Modification&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Date_Modification {

			get {

				return (this.col_Date_Modification);
			}
		}

		private System.Data.SqlTypes.SqlString col_Code;
		/// <summary>
		/// Returns the value of the Code column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Code&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Code {

			get {

				return (this.col_Code);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_Taux_usine = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Ajustement_EssenceUnite] table.
		/// </summary>
		/// <param name="col_AjustementID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;AjustementID&quot; column.</param>
		/// <param name="col_EssenceID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceID&quot; column.</param>
		/// <param name="col_UniteID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteID&quot; column.</param>
		/// <param name="col_Code">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Code&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_AjustementID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_Code) {

			bool Status;
			Reset();

			if (col_AjustementID.IsNull) {

				throw new ArgumentNullException("col_AjustementID" , "The primary key 'col_AjustementID' can not have a Null value!");
			}

			if (col_EssenceID.IsNull) {

				throw new ArgumentNullException("col_EssenceID" , "The primary key 'col_EssenceID' can not have a Null value!");
			}

			if (col_UniteID.IsNull) {

				throw new ArgumentNullException("col_UniteID" , "The primary key 'col_UniteID' can not have a Null value!");
			}

			if (col_Code.IsNull) {

				throw new ArgumentNullException("col_Code" , "The primary key 'col_Code' can not have a Null value!");
			}


			this.col_AjustementID = col_AjustementID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteID = col_UniteID;
			this.col_Code = col_Code;

			this.Param.Reset();

			this.Param.Param_AjustementID = this.col_AjustementID;
			this.Param.Param_EssenceID = this.col_EssenceID;
			this.Param.Param_UniteID = this.col_UniteID;
			this.Param.Param_Code = this.col_Code;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Ajustement_EssenceUnite SP = new SPs.spS_Ajustement_EssenceUnite(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_usine.ColumnIndex)) {

						this.col_Taux_usine = DR.GetSqlSingle(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_usine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_producteur.ColumnIndex)) {

						this.col_Taux_producteur = DR.GetSqlSingle(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Date_Modification.ColumnIndex)) {

						this.col_Date_Modification = DR.GetSqlDateTime(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Date_Modification.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Ajustement_EssenceUnite", "Refresh");
			}
		}
	}
}
