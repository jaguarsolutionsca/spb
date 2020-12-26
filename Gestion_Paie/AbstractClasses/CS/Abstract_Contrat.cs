using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Contrat] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Contrat {

		Params.spS_Contrat Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Contrat class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Contrat(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contrat", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Contrat(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contrat class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Contrat(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contrat", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contrat(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Contrat class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Contrat(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Contrat", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Contrat(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_ID;
		/// <summary>
		/// Returns the value of the ID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ID {

			get {

				return (this.col_ID);
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

		private System.Data.SqlTypes.SqlString col_UsineID;
		/// <summary>
		/// Returns the value of the UsineID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UsineID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UsineID {

			get {

				return (this.col_UsineID);
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

		private System.Data.SqlTypes.SqlDateTime col_Date_debut;
		/// <summary>
		/// Returns the value of the Date_debut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Date_debut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Date_debut {

			get {

				return (this.col_Date_debut);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_Date_fin;
		/// <summary>
		/// Returns the value of the Date_fin column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Date_fin&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_Date_fin {

			get {

				return (this.col_Date_fin);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Actif;
		/// <summary>
		/// Returns the value of the Actif column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Actif&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Actif {

			get {

				return (this.col_Actif);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_PaieTransporteur;
		/// <summary>
		/// Returns the value of the PaieTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PaieTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PaieTransporteur {

			get {

				return (this.col_PaieTransporteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Surcharge;
		/// <summary>
		/// Returns the value of the Taux_Surcharge column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Surcharge&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Surcharge {

			get {

				return (this.col_Taux_Surcharge);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_SurchargeManuel;
		/// <summary>
		/// Returns the value of the SurchargeManuel column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;SurchargeManuel&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_SurchargeManuel {

			get {

				return (this.col_SurchargeManuel);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_TxTransSameProd;
		/// <summary>
		/// Returns the value of the TxTransSameProd column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TxTransSameProd&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_TxTransSameProd {

			get {

				return (this.col_TxTransSameProd);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlString.Null;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;
			this.col_UsineID = System.Data.SqlTypes.SqlString.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Date_debut = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Date_fin = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Taux_Surcharge = System.Data.SqlTypes.SqlDouble.Null;
			this.col_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_TxTransSameProd = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Contrat] table.
		/// </summary>
		/// <param name="col_ID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_ID) {

			bool Status;
			Reset();

			if (col_ID.IsNull) {

				throw new ArgumentNullException("col_ID" , "The primary key 'col_ID' can not have a Null value!");
			}


			this.col_ID = col_ID;

			this.Param.Reset();

			this.Param.Param_ID = this.col_ID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Contrat SP = new SPs.spS_Contrat(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = DR.GetSqlString(SPs.spS_Contrat.Resultset1.Fields.Column_Description.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_UsineID.ColumnIndex)) {

						this.col_UsineID = DR.GetSqlString(SPs.spS_Contrat.Resultset1.Fields.Column_UsineID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = DR.GetSqlInt32(SPs.spS_Contrat.Resultset1.Fields.Column_Annee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Date_debut.ColumnIndex)) {

						this.col_Date_debut = DR.GetSqlDateTime(SPs.spS_Contrat.Resultset1.Fields.Column_Date_debut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Date_fin.ColumnIndex)) {

						this.col_Date_fin = DR.GetSqlDateTime(SPs.spS_Contrat.Resultset1.Fields.Column_Date_fin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_Actif.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex)) {

						this.col_PaieTransporteur = DR.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Taux_Surcharge.ColumnIndex)) {

						this.col_Taux_Surcharge = DR.GetSqlDouble(SPs.spS_Contrat.Resultset1.Fields.Column_Taux_Surcharge.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex)) {

						this.col_SurchargeManuel = DR.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_TxTransSameProd.ColumnIndex)) {

						this.col_TxTransSameProd = DR.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_TxTransSameProd.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Contrat", "Refresh");
			}
		}
	}
}
