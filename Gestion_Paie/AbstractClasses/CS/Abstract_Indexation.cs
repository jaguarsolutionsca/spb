using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Indexation] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Indexation {

		Params.spS_Indexation Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Indexation class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Indexation(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Indexation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Indexation(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Indexation class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Indexation(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Indexation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Indexation(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Indexation class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Indexation(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Indexation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Indexation(true);
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

		private System.Data.SqlTypes.SqlDateTime col_DateIndexation;
		/// <summary>
		/// Returns the value of the DateIndexation column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateIndexation&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateIndexation {

			get {

				return (this.col_DateIndexation);
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

		private System.Data.SqlTypes.SqlString col_TypeIndexation;
		/// <summary>
		/// Returns the value of the TypeIndexation column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TypeIndexation&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TypeIndexation {

			get {

				return (this.col_TypeIndexation);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_PourcentageDuMontant;
		/// <summary>
		/// Returns the value of the PourcentageDuMontant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PourcentageDuMontant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_PourcentageDuMontant {

			get {

				return (this.col_PourcentageDuMontant);
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

		private System.Data.SqlTypes.SqlBoolean col_IndexationTransporteur;
		/// <summary>
		/// Returns the value of the IndexationTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IndexationTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IndexationTransporteur {

			get {

				return (this.col_IndexationTransporteur);
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

		private System.Data.SqlTypes.SqlBoolean col_IndexationManuelle;
		/// <summary>
		/// Returns the value of the IndexationManuelle column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IndexationManuelle&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IndexationManuelle {

			get {

				return (this.col_IndexationManuelle);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DateIndexation = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;
			this.col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
			this.col_PourcentageDuMontant = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Indexation] table.
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
			SPs.spS_Indexation SP = new SPs.spS_Indexation(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_DateIndexation.ColumnIndex)) {

						this.col_DateIndexation = DR.GetSqlDateTime(SPs.spS_Indexation.Resultset1.Fields.Column_DateIndexation.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_Indexation.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Debut.ColumnIndex)) {

						this.col_Periode_Debut = DR.GetSqlInt32(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Debut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Fin.ColumnIndex)) {

						this.col_Periode_Fin = DR.GetSqlInt32(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Fin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_TypeIndexation.ColumnIndex)) {

						this.col_TypeIndexation = DR.GetSqlString(SPs.spS_Indexation.Resultset1.Fields.Column_TypeIndexation.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex)) {

						this.col_PourcentageDuMontant = DR.GetSqlSingle(SPs.spS_Indexation.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = DR.GetSqlBoolean(SPs.spS_Indexation.Resultset1.Fields.Column_Facture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationTransporteur.ColumnIndex)) {

						this.col_IndexationTransporteur = DR.GetSqlBoolean(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Debut.ColumnIndex)) {

						this.col_Date_Debut = DR.GetSqlDateTime(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Debut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Fin.ColumnIndex)) {

						this.col_Date_Fin = DR.GetSqlDateTime(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Fin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationManuelle.ColumnIndex)) {

						this.col_IndexationManuelle = DR.GetSqlBoolean(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationManuelle.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Indexation", "Refresh");
			}
		}
	}
}
