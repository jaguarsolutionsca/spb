using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [FeuilletDomtar] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_FeuilletDomtar {

		Params.spS_FeuilletDomtar Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_FeuilletDomtar class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_FeuilletDomtar(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FeuilletDomtar'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FeuilletDomtar", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_FeuilletDomtar(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FeuilletDomtar class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_FeuilletDomtar(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FeuilletDomtar'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FeuilletDomtar", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FeuilletDomtar(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_FeuilletDomtar class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_FeuilletDomtar(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FeuilletDomtar'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "FeuilletDomtar", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_FeuilletDomtar(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_Transaction;
		/// <summary>
		/// Returns the value of the Transaction column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Transaction&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Transaction {

			get {

				return (this.col_Transaction);
			}
		}

		private System.Data.SqlTypes.SqlString col_TransactionType;
		/// <summary>
		/// Returns the value of the TransactionType column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TransactionType&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_TransactionType {

			get {

				return (this.col_TransactionType);
			}
		}

		private System.Data.SqlTypes.SqlString col_Fournisseur;
		/// <summary>
		/// Returns the value of the Fournisseur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Fournisseur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Fournisseur {

			get {

				return (this.col_Fournisseur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Contrat;
		/// <summary>
		/// Returns the value of the Contrat column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Contrat&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Contrat {

			get {

				return (this.col_Contrat);
			}
		}

		private System.Data.SqlTypes.SqlString col_Produit;
		/// <summary>
		/// Returns the value of the Produit column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Produit&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Produit {

			get {

				return (this.col_Produit);
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

		private System.Data.SqlTypes.SqlString col_Carte;
		/// <summary>
		/// Returns the value of the Carte column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Carte&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Carte {

			get {

				return (this.col_Carte);
			}
		}

		private System.Data.SqlTypes.SqlString col_License;
		/// <summary>
		/// Returns the value of the License column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;License&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_License {

			get {

				return (this.col_License);
			}
		}

		private System.Data.SqlTypes.SqlString col_Transporteur_Camion;
		/// <summary>
		/// Returns the value of the Transporteur_Camion column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Transporteur_Camion&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Transporteur_Camion {

			get {

				return (this.col_Transporteur_Camion);
			}
		}

		private System.Data.SqlTypes.SqlString col_Producteur;
		/// <summary>
		/// Returns the value of the Producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Producteur {

			get {

				return (this.col_Producteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Municipalite;
		/// <summary>
		/// Returns the value of the Municipalite column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Municipalite&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Municipalite {

			get {

				return (this.col_Municipalite);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Brut;
		/// <summary>
		/// Returns the value of the Brut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Brut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Brut {

			get {

				return (this.col_Brut);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Tare;
		/// <summary>
		/// Returns the value of the Tare column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Tare&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Tare {

			get {

				return (this.col_Tare);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Net;
		/// <summary>
		/// Returns the value of the Net column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Net&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Net {

			get {

				return (this.col_Net);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Rejets;
		/// <summary>
		/// Returns the value of the Rejets column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rejets&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Rejets {

			get {

				return (this.col_Rejets);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_KgVert_Paye;
		/// <summary>
		/// Returns the value of the KgVert_Paye column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;KgVert_Paye&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Paye {

			get {

				return (this.col_KgVert_Paye);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Pourcent_Sec;
		/// <summary>
		/// Returns the value of the Pourcent_Sec column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourcent_Sec&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourcent_Sec {

			get {

				return (this.col_Pourcent_Sec);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_KgSec_Paye;
		/// <summary>
		/// Returns the value of the KgSec_Paye column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;KgSec_Paye&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_KgSec_Paye {

			get {

				return (this.col_KgSec_Paye);
			}
		}

		private System.Data.SqlTypes.SqlString col_Validation;
		/// <summary>
		/// Returns the value of the Validation column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Validation&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Validation {

			get {

				return (this.col_Validation);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Transfert;
		/// <summary>
		/// Returns the value of the Transfert column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Transfert&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Transfert {

			get {

				return (this.col_Transfert);
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

		private System.Data.SqlTypes.SqlString col_BonCommande;
		/// <summary>
		/// Returns the value of the BonCommande column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;BonCommande&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_BonCommande {

			get {

				return (this.col_BonCommande);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_Transaction = System.Data.SqlTypes.SqlString.Null;
			this.col_TransactionType = System.Data.SqlTypes.SqlString.Null;
			this.col_Fournisseur = System.Data.SqlTypes.SqlString.Null;
			this.col_Contrat = System.Data.SqlTypes.SqlString.Null;
			this.col_Produit = System.Data.SqlTypes.SqlString.Null;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Carte = System.Data.SqlTypes.SqlString.Null;
			this.col_License = System.Data.SqlTypes.SqlString.Null;
			this.col_Transporteur_Camion = System.Data.SqlTypes.SqlString.Null;
			this.col_Producteur = System.Data.SqlTypes.SqlString.Null;
			this.col_Municipalite = System.Data.SqlTypes.SqlString.Null;
			this.col_Brut = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Tare = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Net = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Rejets = System.Data.SqlTypes.SqlInt32.Null;
			this.col_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Pourcent_Sec = System.Data.SqlTypes.SqlDouble.Null;
			this.col_KgSec_Paye = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Validation = System.Data.SqlTypes.SqlString.Null;
			this.col_Transfert = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_BonCommande = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [FeuilletDomtar] table.
		/// </summary>
		/// <param name="col_Transaction">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Transaction&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_Transaction) {

			bool Status;
			Reset();

			if (col_Transaction.IsNull) {

				throw new ArgumentNullException("col_Transaction" , "The primary key 'col_Transaction' can not have a Null value!");
			}


			this.col_Transaction = col_Transaction;

			this.Param.Reset();

			this.Param.Param_Transaction = this.col_Transaction;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_FeuilletDomtar SP = new SPs.spS_FeuilletDomtar(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransactionType.ColumnIndex)) {

						this.col_TransactionType = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransactionType.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Fournisseur.ColumnIndex)) {

						this.col_Fournisseur = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Fournisseur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Contrat.ColumnIndex)) {

						this.col_Contrat = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Contrat.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Produit.ColumnIndex)) {

						this.col_Produit = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Produit.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = DR.GetSqlDateTime(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Carte.ColumnIndex)) {

						this.col_Carte = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Carte.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_License.ColumnIndex)) {

						this.col_License = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_License.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transporteur_Camion.ColumnIndex)) {

						this.col_Transporteur_Camion = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transporteur_Camion.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Producteur.ColumnIndex)) {

						this.col_Producteur = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Municipalite.ColumnIndex)) {

						this.col_Municipalite = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Municipalite.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Brut.ColumnIndex)) {

						this.col_Brut = DR.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Brut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Tare.ColumnIndex)) {

						this.col_Tare = DR.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Tare.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Net.ColumnIndex)) {

						this.col_Net = DR.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Net.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Rejets.ColumnIndex)) {

						this.col_Rejets = DR.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Rejets.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex)) {

						this.col_KgVert_Paye = DR.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Pourcent_Sec.ColumnIndex)) {

						this.col_Pourcent_Sec = DR.GetSqlDouble(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Pourcent_Sec.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgSec_Paye.ColumnIndex)) {

						this.col_KgSec_Paye = DR.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgSec_Paye.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Validation.ColumnIndex)) {

						this.col_Validation = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Validation.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transfert.ColumnIndex)) {

						this.col_Transfert = DR.GetSqlBoolean(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transfert.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_UniteID.ColumnIndex)) {

						this.col_UniteID = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_UniteID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_BonCommande.ColumnIndex)) {

						this.col_BonCommande = DR.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_BonCommande.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_FeuilletDomtar", "Refresh");
			}
		}
	}
}
