using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [IndexationCalcule_Producteur] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_IndexationCalcule_Producteur {

		Params.spS_IndexationCalcule_Producteur Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_IndexationCalcule_Producteur class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_IndexationCalcule_Producteur(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'IndexationCalcule_Producteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "IndexationCalcule_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_IndexationCalcule_Producteur(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_IndexationCalcule_Producteur class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_IndexationCalcule_Producteur(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'IndexationCalcule_Producteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "IndexationCalcule_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_IndexationCalcule_Producteur(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_IndexationCalcule_Producteur class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_IndexationCalcule_Producteur(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'IndexationCalcule_Producteur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "IndexationCalcule_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_IndexationCalcule_Producteur(true);
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

		private System.Data.SqlTypes.SqlDateTime col_DateCalcul;
		/// <summary>
		/// Returns the value of the DateCalcul column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateCalcul&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateCalcul {

			get {

				return (this.col_DateCalcul);
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

		private System.Data.SqlTypes.SqlInt32 col_IndexationID;
		/// <summary>
		/// Returns the value of the IndexationID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IndexationID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_IndexationID {

			get {

				return (this.col_IndexationID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_IndexationDetailID;
		/// <summary>
		/// Returns the value of the IndexationDetailID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IndexationDetailID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_IndexationDetailID {

			get {

				return (this.col_IndexationDetailID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonID;
		/// <summary>
		/// Returns the value of the LivraisonID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LivraisonID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {

			get {

				return (this.col_LivraisonID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonDetailID;
		/// <summary>
		/// Returns the value of the LivraisonDetailID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LivraisonDetailID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonDetailID {

			get {

				return (this.col_LivraisonDetailID);
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

		private System.Data.SqlTypes.SqlDouble col_Volume;
		/// <summary>
		/// Returns the value of the Volume column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Volume&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Volume {

			get {

				return (this.col_Volume);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_MontantDejaPaye;
		/// <summary>
		/// Returns the value of the MontantDejaPaye column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MontantDejaPaye&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_MontantDejaPaye {

			get {

				return (this.col_MontantDejaPaye);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_PourcentageDuMontant;
		/// <summary>
		/// Returns the value of the PourcentageDuMontant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PourcentageDuMontant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_PourcentageDuMontant {

			get {

				return (this.col_PourcentageDuMontant);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux;
		/// <summary>
		/// Returns the value of the Taux column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux {

			get {

				return (this.col_Taux);
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

		private System.Data.SqlTypes.SqlBoolean col_ErreurCalcul;
		/// <summary>
		/// Returns the value of the ErreurCalcul column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ErreurCalcul&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_ErreurCalcul {

			get {

				return (this.col_ErreurCalcul);
			}
		}

		private System.Data.SqlTypes.SqlString col_ErreurDescription;
		/// <summary>
		/// Returns the value of the ErreurDescription column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ErreurDescription&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ErreurDescription {

			get {

				return (this.col_ErreurDescription);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
			this.col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_IndexationDetailID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.col_Volume = System.Data.SqlTypes.SqlDouble.Null;
			this.col_MontantDejaPaye = System.Data.SqlTypes.SqlDouble.Null;
			this.col_PourcentageDuMontant = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [IndexationCalcule_Producteur] table.
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
			SPs.spS_IndexationCalcule_Producteur SP = new SPs.spS_IndexationCalcule_Producteur(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = DR.GetSqlDateTime(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_TypeIndexation.ColumnIndex)) {

						this.col_TypeIndexation = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_TypeIndexation.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationID.ColumnIndex)) {

						this.col_IndexationID = DR.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationDetailID.ColumnIndex)) {

						this.col_IndexationDetailID = DR.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationDetailID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonID.ColumnIndex)) {

						this.col_LivraisonID = DR.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonDetailID.ColumnIndex)) {

						this.col_LivraisonDetailID = DR.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonDetailID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_UniteID.ColumnIndex)) {

						this.col_UniteID = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_UniteID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Volume.ColumnIndex)) {

						this.col_Volume = DR.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Volume.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_MontantDejaPaye.ColumnIndex)) {

						this.col_MontantDejaPaye = DR.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_MontantDejaPaye.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex)) {

						this.col_PourcentageDuMontant = DR.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Taux.ColumnIndex)) {

						this.col_Taux = DR.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Taux.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = DR.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Montant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = DR.GetSqlBoolean(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Facture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_FactureID.ColumnIndex)) {

						this.col_FactureID = DR.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_FactureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex)) {

						this.col_ErreurCalcul = DR.GetSqlBoolean(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurDescription.ColumnIndex)) {

						this.col_ErreurDescription = DR.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurDescription.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_IndexationCalcule_Producteur", "Refresh");
			}
		}
	}
}
