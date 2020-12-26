using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Contingentement_Producteur] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Contingentement_Producteur {

		Params.spS_Contingentement_Producteur Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement_Producteur class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Contingentement_Producteur(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Producteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Contingentement_Producteur(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement_Producteur class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Contingentement_Producteur(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Producteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contingentement_Producteur(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contingentement_Producteur class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Contingentement_Producteur(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Producteur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contingentement_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contingentement_Producteur(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_ContingentementID;
		/// <summary>
		/// Returns the value of the ContingentementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {

			get {

				return (this.col_ContingentementID);
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

		private System.Data.SqlTypes.SqlSingle col_Superficie_Contingentee;
		/// <summary>
		/// Returns the value of the Superficie_Contingentee column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Superficie_Contingentee&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Superficie_Contingentee {

			get {

				return (this.col_Superficie_Contingentee);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_Demande;
		/// <summary>
		/// Returns the value of the Volume_Demande column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Demande&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Demande {

			get {

				return (this.col_Volume_Demande);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_Facteur;
		/// <summary>
		/// Returns the value of the Volume_Facteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Facteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Facteur {

			get {

				return (this.col_Volume_Facteur);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_Fixe;
		/// <summary>
		/// Returns the value of the Volume_Fixe column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Fixe&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Fixe {

			get {

				return (this.col_Volume_Fixe);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_Supplementaire;
		/// <summary>
		/// Returns the value of the Volume_Supplementaire column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Supplementaire&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Supplementaire {

			get {

				return (this.col_Volume_Supplementaire);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Volume_Accorde;
		/// <summary>
		/// Returns the value of the Volume_Accorde column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Accorde&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Accorde {

			get {

				return (this.col_Volume_Accorde);
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

		private System.Data.SqlTypes.SqlSingle col_Volume_Inventaire;
		/// <summary>
		/// Returns the value of the Volume_Inventaire column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume_Inventaire&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Volume_Inventaire {

			get {

				return (this.col_Volume_Inventaire);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_LastLivraison;
		/// <summary>
		/// Returns the value of the LastLivraison column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LastLivraison&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_LastLivraison {

			get {

				return (this.col_LastLivraison);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_VolumeMaximum;
		/// <summary>
		/// Returns the value of the VolumeMaximum column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeMaximum&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_VolumeMaximum {

			get {

				return (this.col_VolumeMaximum);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Imprime;
		/// <summary>
		/// Returns the value of the Imprime column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Imprime&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Imprime {

			get {

				return (this.col_Imprime);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_Superficie_Contingentee = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Demande = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Facteur = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Supplementaire = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Volume_Accorde = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Volume_Inventaire = System.Data.SqlTypes.SqlSingle.Null;
			this.col_LastLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_VolumeMaximum = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Imprime = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Contingentement_Producteur] table.
		/// </summary>
		/// <param name="col_ContingentementID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentementID&quot; column.</param>
		/// <param name="col_ProducteurID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProducteurID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlString col_ProducteurID) {

			bool Status;
			Reset();

			if (col_ContingentementID.IsNull) {

				throw new ArgumentNullException("col_ContingentementID" , "The primary key 'col_ContingentementID' can not have a Null value!");
			}

			if (col_ProducteurID.IsNull) {

				throw new ArgumentNullException("col_ProducteurID" , "The primary key 'col_ProducteurID' can not have a Null value!");
			}


			this.col_ContingentementID = col_ContingentementID;
			this.col_ProducteurID = col_ProducteurID;

			this.Param.Reset();

			this.Param.Param_ContingentementID = this.col_ContingentementID;
			this.Param.Param_ProducteurID = this.col_ProducteurID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Contingentement_Producteur SP = new SPs.spS_Contingentement_Producteur(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Superficie_Contingentee.ColumnIndex)) {

						this.col_Superficie_Contingentee = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Superficie_Contingentee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Demande.ColumnIndex)) {

						this.col_Volume_Demande = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Demande.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Facteur.ColumnIndex)) {

						this.col_Volume_Facteur = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Facteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex)) {

						this.col_Volume_Fixe = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Supplementaire.ColumnIndex)) {

						this.col_Volume_Supplementaire = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Supplementaire.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Accorde.ColumnIndex)) {

						this.col_Volume_Accorde = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Accorde.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Date_Modification.ColumnIndex)) {

						this.col_Date_Modification = DR.GetSqlDateTime(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Date_Modification.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Inventaire.ColumnIndex)) {

						this.col_Volume_Inventaire = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Inventaire.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_LastLivraison.ColumnIndex)) {

						this.col_LastLivraison = DR.GetSqlDateTime(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_LastLivraison.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_VolumeMaximum.ColumnIndex)) {

						this.col_VolumeMaximum = DR.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_VolumeMaximum.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Imprime.ColumnIndex)) {

						this.col_Imprime = DR.GetSqlBoolean(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Imprime.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Contingentement_Producteur", "Refresh");
			}
		}
	}
}
