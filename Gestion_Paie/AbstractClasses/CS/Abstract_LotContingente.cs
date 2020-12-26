using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [LotContingente] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_LotContingente {

		Params.spS_LotContingente Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_LotContingente class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_LotContingente(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'LotContingente'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "LotContingente", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_LotContingente(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_LotContingente class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_LotContingente(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'LotContingente'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "LotContingente", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_LotContingente(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_LotContingente class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_LotContingente(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'LotContingente'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "LotContingente", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_LotContingente(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_LotID;
		/// <summary>
		/// Returns the value of the LotID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LotID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_LotID {

			get {

				return (this.col_LotID);
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

		private System.Data.SqlTypes.SqlSingle col_SuperficieContingentee;
		/// <summary>
		/// Returns the value of the SuperficieContingentee column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;SuperficieContingentee&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_SuperficieContingentee {

			get {

				return (this.col_SuperficieContingentee);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Override;
		/// <summary>
		/// Returns the value of the Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Override {

			get {

				return (this.col_Override);
			}
		}

		private System.Data.SqlTypes.SqlString col_FournisseurID;
		/// <summary>
		/// Returns the value of the FournisseurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FournisseurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_FournisseurID {

			get {

				return (this.col_FournisseurID);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_SuperficieContingentee = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [LotContingente] table.
		/// </summary>
		/// <param name="col_LotID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LotID&quot; column.</param>
		/// <param name="col_Annee">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Annee&quot; column.</param>
		/// <param name="col_FournisseurID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;FournisseurID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_LotID, System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlString col_FournisseurID) {

			bool Status;
			Reset();

			if (col_LotID.IsNull) {

				throw new ArgumentNullException("col_LotID" , "The primary key 'col_LotID' can not have a Null value!");
			}

			if (col_Annee.IsNull) {

				throw new ArgumentNullException("col_Annee" , "The primary key 'col_Annee' can not have a Null value!");
			}

			if (col_FournisseurID.IsNull) {

				throw new ArgumentNullException("col_FournisseurID" , "The primary key 'col_FournisseurID' can not have a Null value!");
			}


			this.col_LotID = col_LotID;
			this.col_Annee = col_Annee;
			this.col_FournisseurID = col_FournisseurID;

			this.Param.Reset();

			this.Param.Param_LotID = this.col_LotID;
			this.Param.Param_Annee = this.col_Annee;
			this.Param.Param_FournisseurID = this.col_FournisseurID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_LotContingente SP = new SPs.spS_LotContingente(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_LotContingente.Resultset1.Fields.Column_SuperficieContingentee.ColumnIndex)) {

						this.col_SuperficieContingentee = DR.GetSqlSingle(SPs.spS_LotContingente.Resultset1.Fields.Column_SuperficieContingentee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_LotContingente.Resultset1.Fields.Column_Override.ColumnIndex)) {

						this.col_Override = DR.GetSqlBoolean(SPs.spS_LotContingente.Resultset1.Fields.Column_Override.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_LotContingente", "Refresh");
			}
		}
	}
}
