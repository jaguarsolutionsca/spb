using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Usine] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Usine {

		Params.spS_Usine Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Usine class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Usine(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Usine'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Usine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Usine(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Usine class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Usine(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Usine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Usine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Usine(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Usine class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Usine(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Usine'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Usine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Usine(true);
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

		private System.Data.SqlTypes.SqlInt32 col_UtilisationID;
		/// <summary>
		/// Returns the value of the UtilisationID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UtilisationID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_UtilisationID {

			get {

				return (this.col_UtilisationID);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Paye_producteur;
		/// <summary>
		/// Returns the value of the Paye_producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Paye_producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Paye_producteur {

			get {

				return (this.col_Paye_producteur);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Paye_transporteur;
		/// <summary>
		/// Returns the value of the Paye_transporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Paye_transporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Paye_transporteur {

			get {

				return (this.col_Paye_transporteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Specification;
		/// <summary>
		/// Returns the value of the Specification column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Specification&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Specification {

			get {

				return (this.col_Specification);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_a_recevoir;
		/// <summary>
		/// Returns the value of the Compte_a_recevoir column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_a_recevoir&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_a_recevoir {

			get {

				return (this.col_Compte_a_recevoir);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_ajustement;
		/// <summary>
		/// Returns the value of the Compte_ajustement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_ajustement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_ajustement {

			get {

				return (this.col_Compte_ajustement);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_transporteur;
		/// <summary>
		/// Returns the value of the Compte_transporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_transporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_transporteur {

			get {

				return (this.col_Compte_transporteur);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_producteur;
		/// <summary>
		/// Returns the value of the Compte_producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_producteur {

			get {

				return (this.col_Compte_producteur);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_plan_conjoint;
		/// <summary>
		/// Returns the value of the Compte_preleve_plan_conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_preleve_plan_conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_plan_conjoint {

			get {

				return (this.col_Compte_preleve_plan_conjoint);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_roulement;
		/// <summary>
		/// Returns the value of the Compte_preleve_fond_roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_preleve_fond_roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_fond_roulement {

			get {

				return (this.col_Compte_preleve_fond_roulement);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_forestier;
		/// <summary>
		/// Returns the value of the Compte_preleve_fond_forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_preleve_fond_forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_fond_forestier {

			get {

				return (this.col_Compte_preleve_fond_forestier);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_divers;
		/// <summary>
		/// Returns the value of the Compte_preleve_divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_preleve_divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_divers {

			get {

				return (this.col_Compte_preleve_divers);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_mise_en_commun;
		/// <summary>
		/// Returns the value of the Compte_mise_en_commun column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_mise_en_commun&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_mise_en_commun {

			get {

				return (this.col_Compte_mise_en_commun);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_surcharge;
		/// <summary>
		/// Returns the value of the Compte_surcharge column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_surcharge&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_surcharge {

			get {

				return (this.col_Compte_surcharge);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_indexation_carburant;
		/// <summary>
		/// Returns the value of the Compte_indexation_carburant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_indexation_carburant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_indexation_carburant {

			get {

				return (this.col_Compte_indexation_carburant);
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

		private System.Data.SqlTypes.SqlBoolean col_NePaiePasTPS;
		/// <summary>
		/// Returns the value of the NePaiePasTPS column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NePaiePasTPS&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_NePaiePasTPS {

			get {

				return (this.col_NePaiePasTPS);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_NePaiePasTVQ;
		/// <summary>
		/// Returns the value of the NePaiePasTVQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NePaiePasTVQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_NePaiePasTVQ {

			get {

				return (this.col_NePaiePasTVQ);
			}
		}

		private System.Data.SqlTypes.SqlString col_NoTPS;
		/// <summary>
		/// Returns the value of the NoTPS column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NoTPS&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_NoTPS {

			get {

				return (this.col_NoTPS);
			}
		}

		private System.Data.SqlTypes.SqlString col_NoTVQ;
		/// <summary>
		/// Returns the value of the NoTVQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NoTVQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_NoTVQ {

			get {

				return (this.col_NoTVQ);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_chargeur;
		/// <summary>
		/// Returns the value of the Compte_chargeur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Compte_chargeur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Compte_chargeur {

			get {

				return (this.col_Compte_chargeur);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_UsineGestionVolume;
		/// <summary>
		/// Returns the value of the UsineGestionVolume column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UsineGestionVolume&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_UsineGestionVolume {

			get {

				return (this.col_UsineGestionVolume);
			}
		}

		private System.Data.SqlTypes.SqlString col_AuSoinsDe;
		/// <summary>
		/// Returns the value of the AuSoinsDe column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;AuSoinsDe&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_AuSoinsDe {

			get {

				return (this.col_AuSoinsDe);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rue;
		/// <summary>
		/// Returns the value of the Rue column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rue&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rue {

			get {

				return (this.col_Rue);
			}
		}

		private System.Data.SqlTypes.SqlString col_Ville;
		/// <summary>
		/// Returns the value of the Ville column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Ville&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Ville {

			get {

				return (this.col_Ville);
			}
		}

		private System.Data.SqlTypes.SqlString col_PaysID;
		/// <summary>
		/// Returns the value of the PaysID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PaysID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_PaysID {

			get {

				return (this.col_PaysID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Code_postal;
		/// <summary>
		/// Returns the value of the Code_postal column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Code_postal&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Code_postal {

			get {

				return (this.col_Code_postal);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone;
		/// <summary>
		/// Returns the value of the Telephone column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone {

			get {

				return (this.col_Telephone);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone_Poste;
		/// <summary>
		/// Returns the value of the Telephone_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone_Poste {

			get {

				return (this.col_Telephone_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telecopieur;
		/// <summary>
		/// Returns the value of the Telecopieur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telecopieur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telecopieur {

			get {

				return (this.col_Telecopieur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone2;
		/// <summary>
		/// Returns the value of the Telephone2 column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone2&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone2 {

			get {

				return (this.col_Telephone2);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone2_Desc;
		/// <summary>
		/// Returns the value of the Telephone2_Desc column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone2_Desc&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone2_Desc {

			get {

				return (this.col_Telephone2_Desc);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone2_Poste;
		/// <summary>
		/// Returns the value of the Telephone2_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone2_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone2_Poste {

			get {

				return (this.col_Telephone2_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone3;
		/// <summary>
		/// Returns the value of the Telephone3 column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone3&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone3 {

			get {

				return (this.col_Telephone3);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone3_Desc;
		/// <summary>
		/// Returns the value of the Telephone3_Desc column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone3_Desc&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone3_Desc {

			get {

				return (this.col_Telephone3_Desc);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone3_Poste;
		/// <summary>
		/// Returns the value of the Telephone3_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone3_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone3_Poste {

			get {

				return (this.col_Telephone3_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Email;
		/// <summary>
		/// Returns the value of the Email column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Email&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Email {

			get {

				return (this.col_Email);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlString.Null;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;
			this.col_UtilisationID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Paye_producteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Paye_transporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Specification = System.Data.SqlTypes.SqlString.Null;
			this.col_Compte_a_recevoir = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_ajustement = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_transporteur = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_producteur = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_preleve_plan_conjoint = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_preleve_fond_roulement = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_preleve_fond_forestier = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_preleve_divers = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_mise_en_commun = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_surcharge = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Compte_indexation_carburant = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_NePaiePasTPS = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_NePaiePasTVQ = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_NoTPS = System.Data.SqlTypes.SqlString.Null;
			this.col_NoTVQ = System.Data.SqlTypes.SqlString.Null;
			this.col_Compte_chargeur = System.Data.SqlTypes.SqlInt32.Null;
			this.col_UsineGestionVolume = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
			this.col_Rue = System.Data.SqlTypes.SqlString.Null;
			this.col_Ville = System.Data.SqlTypes.SqlString.Null;
			this.col_PaysID = System.Data.SqlTypes.SqlString.Null;
			this.col_Code_postal = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Telecopieur = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone2 = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone3 = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Email = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Usine] table.
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
			SPs.spS_Usine SP = new SPs.spS_Usine(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Description.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_UtilisationID.ColumnIndex)) {

						this.col_UtilisationID = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_UtilisationID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Paye_producteur.ColumnIndex)) {

						this.col_Paye_producteur = DR.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_Paye_producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Paye_transporteur.ColumnIndex)) {

						this.col_Paye_transporteur = DR.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_Paye_transporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Specification.ColumnIndex)) {

						this.col_Specification = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Specification.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_a_recevoir.ColumnIndex)) {

						this.col_Compte_a_recevoir = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_a_recevoir.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_ajustement.ColumnIndex)) {

						this.col_Compte_ajustement = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_ajustement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_transporteur.ColumnIndex)) {

						this.col_Compte_transporteur = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_transporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_producteur.ColumnIndex)) {

						this.col_Compte_producteur = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_plan_conjoint.ColumnIndex)) {

						this.col_Compte_preleve_plan_conjoint = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_plan_conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_roulement.ColumnIndex)) {

						this.col_Compte_preleve_fond_roulement = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_forestier.ColumnIndex)) {

						this.col_Compte_preleve_fond_forestier = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_divers.ColumnIndex)) {

						this.col_Compte_preleve_divers = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_divers.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_mise_en_commun.ColumnIndex)) {

						this.col_Compte_mise_en_commun = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_mise_en_commun.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_surcharge.ColumnIndex)) {

						this.col_Compte_surcharge = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_surcharge.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_indexation_carburant.ColumnIndex)) {

						this.col_Compte_indexation_carburant = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_indexation_carburant.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_Actif.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTPS.ColumnIndex)) {

						this.col_NePaiePasTPS = DR.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTPS.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTVQ.ColumnIndex)) {

						this.col_NePaiePasTVQ = DR.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTVQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NoTPS.ColumnIndex)) {

						this.col_NoTPS = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_NoTPS.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NoTVQ.ColumnIndex)) {

						this.col_NoTVQ = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_NoTVQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_chargeur.ColumnIndex)) {

						this.col_Compte_chargeur = DR.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_chargeur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_UsineGestionVolume.ColumnIndex)) {

						this.col_UsineGestionVolume = DR.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_UsineGestionVolume.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex)) {

						this.col_AuSoinsDe = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Rue.ColumnIndex)) {

						this.col_Rue = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Rue.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Ville.ColumnIndex)) {

						this.col_Ville = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Ville.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_PaysID.ColumnIndex)) {

						this.col_PaysID = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_PaysID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Code_postal.ColumnIndex)) {

						this.col_Code_postal = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Code_postal.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone.ColumnIndex)) {

						this.col_Telephone = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex)) {

						this.col_Telephone_Poste = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telecopieur.ColumnIndex)) {

						this.col_Telecopieur = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telecopieur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2.ColumnIndex)) {

						this.col_Telephone2 = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex)) {

						this.col_Telephone2_Desc = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex)) {

						this.col_Telephone2_Poste = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3.ColumnIndex)) {

						this.col_Telephone3 = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex)) {

						this.col_Telephone3_Desc = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex)) {

						this.col_Telephone3_Poste = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Email.ColumnIndex)) {

						this.col_Email = DR.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Email.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Usine", "Refresh");
			}
		}
	}
}
