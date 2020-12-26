using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [FactureUsine] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_FactureUsine {

		Params.spS_FactureUsine Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_FactureUsine class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_FactureUsine(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureUsine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_FactureUsine(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureUsine class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_FactureUsine(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureUsine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureUsine(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FactureUsine class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_FactureUsine(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FactureUsine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FactureUsine(true);
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

		private System.Data.SqlTypes.SqlDateTime col_DatePermis;
		/// <summary>
		/// Returns the value of the DatePermis column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DatePermis&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DatePermis {

			get {

				return (this.col_DatePermis);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateLivraison;
		/// <summary>
		/// Returns the value of the DateLivraison column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateLivraison&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateLivraison {

			get {

				return (this.col_DateLivraison);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DatePaye;
		/// <summary>
		/// Returns the value of the DatePaye column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DatePaye&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DatePaye {

			get {

				return (this.col_DatePaye);
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

		private System.Data.SqlTypes.SqlInt32 col_Periode;
		/// <summary>
		/// Returns the value of the Periode column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Periode&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Periode {

			get {

				return (this.col_Periode);
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

		private System.Data.SqlTypes.SqlBoolean col_Sciage;
		/// <summary>
		/// Returns the value of the Sciage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Sciage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Sciage {

			get {

				return (this.col_Sciage);
			}
		}

		private System.Data.SqlTypes.SqlString col_EssenceSciage;
		/// <summary>
		/// Returns the value of the EssenceSciage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceSciage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_EssenceSciage {

			get {

				return (this.col_EssenceSciage);
			}
		}

		private System.Data.SqlTypes.SqlString col_NumeroFactureUsine;
		/// <summary>
		/// Returns the value of the NumeroFactureUsine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NumeroFactureUsine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_NumeroFactureUsine {

			get {

				return (this.col_NumeroFactureUsine);
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

		private System.Data.SqlTypes.SqlBoolean col_Livraison;
		/// <summary>
		/// Returns the value of the Livraison column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Livraison&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Livraison {

			get {

				return (this.col_Livraison);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DatePermis = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_EssenceSciage = System.Data.SqlTypes.SqlString.Null;
			this.col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_Livraison = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [FactureUsine] table.
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
			SPs.spS_FactureUsine SP = new SPs.spS_FactureUsine(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePermis.ColumnIndex)) {

						this.col_DatePermis = DR.GetSqlDateTime(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePermis.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = DR.GetSqlDateTime(SPs.spS_FactureUsine.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePaye.ColumnIndex)) {

						this.col_DatePaye = DR.GetSqlDateTime(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePaye.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = DR.GetSqlInt32(SPs.spS_FactureUsine.Resultset1.Fields.Column_Annee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = DR.GetSqlInt32(SPs.spS_FactureUsine.Resultset1.Fields.Column_Periode.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Sciage.ColumnIndex)) {

						this.col_Sciage = DR.GetSqlBoolean(SPs.spS_FactureUsine.Resultset1.Fields.Column_Sciage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_EssenceSciage.ColumnIndex)) {

						this.col_EssenceSciage = DR.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_EssenceSciage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex)) {

						this.col_NumeroFactureUsine = DR.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = DR.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Livraison.ColumnIndex)) {

						this.col_Livraison = DR.GetSqlBoolean(SPs.spS_FactureUsine.Resultset1.Fields.Column_Livraison.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_FactureUsine", "Refresh");
			}
		}
	}
}
