using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Livraison] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Livraison {

		Params.spS_Livraison Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Livraison class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Livraison(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Livraison(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Livraison class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Livraison(System.Data.SqlClient.SqlConnection sqlConnection) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Livraison(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Livraison class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Livraison(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Livraison(true);
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

		private System.Data.SqlTypes.SqlString col_UniteMesureID;
		/// <summary>
		/// Returns the value of the UniteMesureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteMesureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {

			get {

				return (this.col_UniteMesureID);
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

		private System.Data.SqlTypes.SqlString col_DroitCoupeID;
		/// <summary>
		/// Returns the value of the DroitCoupeID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DroitCoupeID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_DroitCoupeID {

			get {

				return (this.col_DroitCoupeID);
			}
		}

		private System.Data.SqlTypes.SqlString col_EntentePaiementID;
		/// <summary>
		/// Returns the value of the EntentePaiementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EntentePaiementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_EntentePaiementID {

			get {

				return (this.col_EntentePaiementID);
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

		private System.Data.SqlTypes.SqlString col_VR;
		/// <summary>
		/// Returns the value of the VR column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VR&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_VR {

			get {

				return (this.col_VR);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_MasseLimite;
		/// <summary>
		/// Returns the value of the MasseLimite column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MasseLimite&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_MasseLimite {

			get {

				return (this.col_MasseLimite);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeBrut;
		/// <summary>
		/// Returns the value of the VolumeBrut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeBrut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeBrut {

			get {

				return (this.col_VolumeBrut);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeTare;
		/// <summary>
		/// Returns the value of the VolumeTare column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeTare&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeTare {

			get {

				return (this.col_VolumeTare);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeTransporte;
		/// <summary>
		/// Returns the value of the VolumeTransporte column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeTransporte&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeTransporte {

			get {

				return (this.col_VolumeTransporte);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeSurcharge;
		/// <summary>
		/// Returns the value of the VolumeSurcharge column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeSurcharge&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeSurcharge {

			get {

				return (this.col_VolumeSurcharge);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeAPayer;
		/// <summary>
		/// Returns the value of the VolumeAPayer column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeAPayer&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeAPayer {

			get {

				return (this.col_VolumeAPayer);
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

		private System.Data.SqlTypes.SqlDouble col_Taux_Transporteur;
		/// <summary>
		/// Returns the value of the Taux_Transporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Transporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Transporteur {

			get {

				return (this.col_Taux_Transporteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Transporteur;
		/// <summary>
		/// Returns the value of the Montant_Transporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Transporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Transporteur {

			get {

				return (this.col_Montant_Transporteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Usine;
		/// <summary>
		/// Returns the value of the Montant_Usine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Usine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Usine {

			get {

				return (this.col_Montant_Usine);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Producteur1;
		/// <summary>
		/// Returns the value of the Montant_Producteur1 column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Producteur1&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Producteur1 {

			get {

				return (this.col_Montant_Producteur1);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Producteur2;
		/// <summary>
		/// Returns the value of the Montant_Producteur2 column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Producteur2&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Producteur2 {

			get {

				return (this.col_Montant_Producteur2);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Plan_Conjoint;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Plan_Conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Plan_Conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Plan_Conjoint {

			get {

				return (this.col_Montant_Preleve_Plan_Conjoint);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Fond_Roulement;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Fond_Roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Fond_Roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Fond_Roulement {

			get {

				return (this.col_Montant_Preleve_Fond_Roulement);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Fond_Forestier;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Fond_Forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Fond_Forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Fond_Forestier {

			get {

				return (this.col_Montant_Preleve_Fond_Forestier);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Divers;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Divers {

			get {

				return (this.col_Montant_Preleve_Divers);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Surcharge;
		/// <summary>
		/// Returns the value of the Montant_Surcharge column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Surcharge&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Surcharge {

			get {

				return (this.col_Montant_Surcharge);
			}
		}

		private System.Data.SqlTypes.SqlSingle col_Montant_MiseEnCommun;
		/// <summary>
		/// Returns the value of the Montant_MiseEnCommun column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_MiseEnCommun&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlSingle Col_Montant_MiseEnCommun {

			get {

				return (this.col_Montant_MiseEnCommun);
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

		private System.Data.SqlTypes.SqlInt32 col_Producteur1_FactureID;
		/// <summary>
		/// Returns the value of the Producteur1_FactureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Producteur1_FactureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Producteur1_FactureID {

			get {

				return (this.col_Producteur1_FactureID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Producteur2_FactureID;
		/// <summary>
		/// Returns the value of the Producteur2_FactureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Producteur2_FactureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Producteur2_FactureID {

			get {

				return (this.col_Producteur2_FactureID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Transporteur_FactureID;
		/// <summary>
		/// Returns the value of the Transporteur_FactureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Transporteur_FactureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Transporteur_FactureID {

			get {

				return (this.col_Transporteur_FactureID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Usine_FactureID;
		/// <summary>
		/// Returns the value of the Usine_FactureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Usine_FactureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Usine_FactureID {

			get {

				return (this.col_Usine_FactureID);
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

		private System.Data.SqlTypes.SqlBoolean col_Taux_Transporteur_Override;
		/// <summary>
		/// Returns the value of the Taux_Transporteur_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Transporteur_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Transporteur_Override {

			get {

				return (this.col_Taux_Transporteur_Override);
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

		private System.Data.SqlTypes.SqlBoolean col_VolumeSurcharge_Override;
		/// <summary>
		/// Returns the value of the VolumeSurcharge_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeSurcharge_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_VolumeSurcharge_Override {

			get {

				return (this.col_VolumeSurcharge_Override);
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

		private System.Data.SqlTypes.SqlInt32 col_NombrePermis;
		/// <summary>
		/// Returns the value of the NombrePermis column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;NombrePermis&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_NombrePermis {

			get {

				return (this.col_NombrePermis);
			}
		}

		private System.Data.SqlTypes.SqlString col_ZoneID;
		/// <summary>
		/// Returns the value of the ZoneID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ZoneID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ZoneID {

			get {

				return (this.col_ZoneID);
			}
		}

		private System.Data.SqlTypes.SqlString col_MunicipaliteID;
		/// <summary>
		/// Returns the value of the MunicipaliteID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MunicipaliteID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {

			get {

				return (this.col_MunicipaliteID);
			}
		}

		private System.Data.SqlTypes.SqlString col_ChargeurID;
		/// <summary>
		/// Returns the value of the ChargeurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ChargeurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ChargeurID {

			get {

				return (this.col_ChargeurID);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Chargeur;
		/// <summary>
		/// Returns the value of the Montant_Chargeur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Chargeur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Chargeur {

			get {

				return (this.col_Montant_Chargeur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_ChargeurAuProducteur;
		/// <summary>
		/// Returns the value of the Frais_ChargeurAuProducteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_ChargeurAuProducteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_ChargeurAuProducteur {

			get {

				return (this.col_Frais_ChargeurAuProducteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_ChargeurAuTransporteur;
		/// <summary>
		/// Returns the value of the Frais_ChargeurAuTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_ChargeurAuTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_ChargeurAuTransporteur {

			get {

				return (this.col_Frais_ChargeurAuTransporteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_AutresAuProducteur;
		/// <summary>
		/// Returns the value of the Frais_AutresAuProducteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresAuProducteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresAuProducteur {

			get {

				return (this.col_Frais_AutresAuProducteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Frais_AutresAuProducteurDescription;
		/// <summary>
		/// Returns the value of the Frais_AutresAuProducteurDescription column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresAuProducteurDescription&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Frais_AutresAuProducteurDescription {

			get {

				return (this.col_Frais_AutresAuProducteurDescription);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_AutresAuProducteurTransportSciage;
		/// <summary>
		/// Returns the value of the Frais_AutresAuProducteurTransportSciage column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresAuProducteurTransportSciage&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresAuProducteurTransportSciage {

			get {

				return (this.col_Frais_AutresAuProducteurTransportSciage);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_AutresAuTransporteur;
		/// <summary>
		/// Returns the value of the Frais_AutresAuTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresAuTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresAuTransporteur {

			get {

				return (this.col_Frais_AutresAuTransporteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Frais_AutresAuTransporteurDescription;
		/// <summary>
		/// Returns the value of the Frais_AutresAuTransporteurDescription column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresAuTransporteurDescription&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Frais_AutresAuTransporteurDescription {

			get {

				return (this.col_Frais_AutresAuTransporteurDescription);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_CompensationDeDeplacement;
		/// <summary>
		/// Returns the value of the Frais_CompensationDeDeplacement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_CompensationDeDeplacement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_CompensationDeDeplacement {

			get {

				return (this.col_Frais_CompensationDeDeplacement);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Chargeur_FactureID;
		/// <summary>
		/// Returns the value of the Chargeur_FactureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Chargeur_FactureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Chargeur_FactureID {

			get {

				return (this.col_Chargeur_FactureID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Commentaires_Producteur;
		/// <summary>
		/// Returns the value of the Commentaires_Producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Commentaires_Producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Commentaires_Producteur {

			get {

				return (this.col_Commentaires_Producteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Commentaires_Transporteur;
		/// <summary>
		/// Returns the value of the Commentaires_Transporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Commentaires_Transporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Commentaires_Transporteur {

			get {

				return (this.col_Commentaires_Transporteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Commentaires_Chargeur;
		/// <summary>
		/// Returns the value of the Commentaires_Chargeur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Commentaires_Chargeur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Commentaires_Chargeur {

			get {

				return (this.col_Commentaires_Chargeur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_TauxChargeurAuProducteur;
		/// <summary>
		/// Returns the value of the TauxChargeurAuProducteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TauxChargeurAuProducteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_TauxChargeurAuProducteur {

			get {

				return (this.col_TauxChargeurAuProducteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_TauxChargeurAuTransporteur;
		/// <summary>
		/// Returns the value of the TauxChargeurAuTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TauxChargeurAuTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_TauxChargeurAuTransporteur {

			get {

				return (this.col_TauxChargeurAuTransporteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_AutresRevenusTransporteur;
		/// <summary>
		/// Returns the value of the Frais_AutresRevenusTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresRevenusTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresRevenusTransporteur {

			get {

				return (this.col_Frais_AutresRevenusTransporteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Frais_AutresRevenusTransporteurDescription;
		/// <summary>
		/// Returns the value of the Frais_AutresRevenusTransporteurDescription column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresRevenusTransporteurDescription&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Frais_AutresRevenusTransporteurDescription {

			get {

				return (this.col_Frais_AutresRevenusTransporteurDescription);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Frais_AutresRevenusProducteur;
		/// <summary>
		/// Returns the value of the Frais_AutresRevenusProducteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresRevenusProducteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresRevenusProducteur {

			get {

				return (this.col_Frais_AutresRevenusProducteur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Frais_AutresRevenusProducteurDescription;
		/// <summary>
		/// Returns the value of the Frais_AutresRevenusProducteurDescription column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Frais_AutresRevenusProducteurDescription&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Frais_AutresRevenusProducteurDescription {

			get {

				return (this.col_Frais_AutresRevenusProducteurDescription);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_SurchargeProducteur;
		/// <summary>
		/// Returns the value of the Montant_SurchargeProducteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_SurchargeProducteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_SurchargeProducteur {

			get {

				return (this.col_Montant_SurchargeProducteur);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_KgVert_Brut;
		/// <summary>
		/// Returns the value of the KgVert_Brut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;KgVert_Brut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Brut {

			get {

				return (this.col_KgVert_Brut);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_KgVert_Tare;
		/// <summary>
		/// Returns the value of the KgVert_Tare column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;KgVert_Tare&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Tare {

			get {

				return (this.col_KgVert_Tare);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_KgVert_Net;
		/// <summary>
		/// Returns the value of the KgVert_Net column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;KgVert_Net&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Net {

			get {

				return (this.col_KgVert_Net);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_KgVert_Rejets;
		/// <summary>
		/// Returns the value of the KgVert_Rejets column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;KgVert_Rejets&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Rejets {

			get {

				return (this.col_KgVert_Rejets);
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

		private System.Data.SqlTypes.SqlDouble col_Pourcent_Sec_Producteur;
		/// <summary>
		/// Returns the value of the Pourcent_Sec_Producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourcent_Sec_Producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourcent_Sec_Producteur {

			get {

				return (this.col_Pourcent_Sec_Producteur);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Pourcent_Sec_Producteur_Override;
		/// <summary>
		/// Returns the value of the Pourcent_Sec_Producteur_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourcent_Sec_Producteur_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Pourcent_Sec_Producteur_Override {

			get {

				return (this.col_Pourcent_Sec_Producteur_Override);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_TMA_Producteur;
		/// <summary>
		/// Returns the value of the TMA_Producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TMA_Producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_TMA_Producteur {

			get {

				return (this.col_TMA_Producteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Pourcent_Sec_Transport;
		/// <summary>
		/// Returns the value of the Pourcent_Sec_Transport column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourcent_Sec_Transport&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Pourcent_Sec_Transport {

			get {

				return (this.col_Pourcent_Sec_Transport);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Pourcent_Sec_Transport_Override;
		/// <summary>
		/// Returns the value of the Pourcent_Sec_Transport_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Pourcent_Sec_Transport_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Pourcent_Sec_Transport_Override {

			get {

				return (this.col_Pourcent_Sec_Transport_Override);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_TMA_Transport;
		/// <summary>
		/// Returns the value of the TMA_Transport column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;TMA_Transport&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_TMA_Transport {

			get {

				return (this.col_TMA_Transport);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsTMA;
		/// <summary>
		/// Returns the value of the IsTMA column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsTMA&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsTMA {

			get {

				return (this.col_IsTMA);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_SuspendrePaiement;
		/// <summary>
		/// Returns the value of the SuspendrePaiement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;SuspendrePaiement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_SuspendrePaiement {

			get {

				return (this.col_SuspendrePaiement);
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

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
			this.col_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
			this.col_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_VR = System.Data.SqlTypes.SqlString.Null;
			this.col_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeTare = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeTransporte = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeSurcharge = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeAPayer = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Taux_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Producteur1 = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Producteur2 = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Surcharge = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_MiseEnCommun = System.Data.SqlTypes.SqlSingle.Null;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_NombrePermis = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.col_ChargeurID = System.Data.SqlTypes.SqlString.Null;
			this.col_Montant_Chargeur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.col_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.col_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Commentaires_Producteur = System.Data.SqlTypes.SqlString.Null;
			this.col_Commentaires_Transporteur = System.Data.SqlTypes.SqlString.Null;
			this.col_Commentaires_Chargeur = System.Data.SqlTypes.SqlString.Null;
			this.col_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.col_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.col_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_KgVert_Brut = System.Data.SqlTypes.SqlInt32.Null;
			this.col_KgVert_Tare = System.Data.SqlTypes.SqlInt32.Null;
			this.col_KgVert_Net = System.Data.SqlTypes.SqlInt32.Null;
			this.col_KgVert_Rejets = System.Data.SqlTypes.SqlInt32.Null;
			this.col_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
			this.col_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_TMA_Producteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_TMA_Transport = System.Data.SqlTypes.SqlDouble.Null;
			this.col_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_BonCommande = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Livraison] table.
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
			SPs.spS_Livraison SP = new SPs.spS_Livraison(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = DR.GetSqlDateTime(SPs.spS_Livraison.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DatePaye.ColumnIndex)) {

						this.col_DatePaye = DR.GetSqlDateTime(SPs.spS_Livraison.Resultset1.Fields.Column_DatePaye.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Sciage.ColumnIndex)) {

						this.col_Sciage = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Sciage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex)) {

						this.col_NumeroFactureUsine = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DroitCoupeID.ColumnIndex)) {

						this.col_DroitCoupeID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_DroitCoupeID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_EntentePaiementID.ColumnIndex)) {

						this.col_EntentePaiementID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_EntentePaiementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VR.ColumnIndex)) {

						this.col_VR = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_VR.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_MasseLimite.ColumnIndex)) {

						this.col_MasseLimite = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_MasseLimite.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeBrut.ColumnIndex)) {

						this.col_VolumeBrut = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeBrut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTare.ColumnIndex)) {

						this.col_VolumeTare = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTare.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTransporte.ColumnIndex)) {

						this.col_VolumeTransporte = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTransporte.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge.ColumnIndex)) {

						this.col_VolumeSurcharge = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeAPayer.ColumnIndex)) {

						this.col_VolumeAPayer = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeAPayer.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Annee.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Periode.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = DR.GetSqlDateTime(SPs.spS_Livraison.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur.ColumnIndex)) {

						this.col_Taux_Transporteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Transporteur.ColumnIndex)) {

						this.col_Montant_Transporteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Transporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Usine.ColumnIndex)) {

						this.col_Montant_Usine = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Usine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur1.ColumnIndex)) {

						this.col_Montant_Producteur1 = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur1.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur2.ColumnIndex)) {

						this.col_Montant_Producteur2 = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur2.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex)) {

						this.col_Montant_Preleve_Plan_Conjoint = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Roulement = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Forestier = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex)) {

						this.col_Montant_Preleve_Divers = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Surcharge.ColumnIndex)) {

						this.col_Montant_Surcharge = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Surcharge.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_MiseEnCommun.ColumnIndex)) {

						this.col_Montant_MiseEnCommun = DR.GetSqlSingle(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_MiseEnCommun.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Facture.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur1_FactureID.ColumnIndex)) {

						this.col_Producteur1_FactureID = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur1_FactureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur2_FactureID.ColumnIndex)) {

						this.col_Producteur2_FactureID = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur2_FactureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Transporteur_FactureID.ColumnIndex)) {

						this.col_Transporteur_FactureID = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Transporteur_FactureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Usine_FactureID.ColumnIndex)) {

						this.col_Usine_FactureID = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Usine_FactureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex)) {

						this.col_ErreurCalcul = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurDescription.ColumnIndex)) {

						this.col_ErreurDescription = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurDescription.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_LotID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur_Override.ColumnIndex)) {

						this.col_Taux_Transporteur_Override = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex)) {

						this.col_PaieTransporteur = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge_Override.ColumnIndex)) {

						this.col_VolumeSurcharge_Override = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex)) {

						this.col_SurchargeManuel = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_NombrePermis.ColumnIndex)) {

						this.col_NombrePermis = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_NombrePermis.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ChargeurID.ColumnIndex)) {

						this.col_ChargeurID = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ChargeurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Chargeur.ColumnIndex)) {

						this.col_Montant_Chargeur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Chargeur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuProducteur.ColumnIndex)) {

						this.col_Frais_ChargeurAuProducteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuProducteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuTransporteur.ColumnIndex)) {

						this.col_Frais_ChargeurAuTransporteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteur.ColumnIndex)) {

						this.col_Frais_AutresAuProducteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurDescription.ColumnIndex)) {

						this.col_Frais_AutresAuProducteurDescription = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurDescription.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurTransportSciage.ColumnIndex)) {

						this.col_Frais_AutresAuProducteurTransportSciage = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurTransportSciage.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteur.ColumnIndex)) {

						this.col_Frais_AutresAuTransporteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteurDescription.ColumnIndex)) {

						this.col_Frais_AutresAuTransporteurDescription = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteurDescription.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_CompensationDeDeplacement.ColumnIndex)) {

						this.col_Frais_CompensationDeDeplacement = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_CompensationDeDeplacement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Chargeur_FactureID.ColumnIndex)) {

						this.col_Chargeur_FactureID = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Chargeur_FactureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Producteur.ColumnIndex)) {

						this.col_Commentaires_Producteur = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Transporteur.ColumnIndex)) {

						this.col_Commentaires_Transporteur = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Transporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Chargeur.ColumnIndex)) {

						this.col_Commentaires_Chargeur = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Chargeur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuProducteur.ColumnIndex)) {

						this.col_TauxChargeurAuProducteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuProducteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuTransporteur.ColumnIndex)) {

						this.col_TauxChargeurAuTransporteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteur.ColumnIndex)) {

						this.col_Frais_AutresRevenusTransporteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteurDescription.ColumnIndex)) {

						this.col_Frais_AutresRevenusTransporteurDescription = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteurDescription.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteur.ColumnIndex)) {

						this.col_Frais_AutresRevenusProducteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteurDescription.ColumnIndex)) {

						this.col_Frais_AutresRevenusProducteurDescription = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteurDescription.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_SurchargeProducteur.ColumnIndex)) {

						this.col_Montant_SurchargeProducteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_SurchargeProducteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Brut.ColumnIndex)) {

						this.col_KgVert_Brut = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Brut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Tare.ColumnIndex)) {

						this.col_KgVert_Tare = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Tare.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Net.ColumnIndex)) {

						this.col_KgVert_Net = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Net.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Rejets.ColumnIndex)) {

						this.col_KgVert_Rejets = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Rejets.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex)) {

						this.col_KgVert_Paye = DR.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur.ColumnIndex)) {

						this.col_Pourcent_Sec_Producteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur_Override.ColumnIndex)) {

						this.col_Pourcent_Sec_Producteur_Override = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Producteur.ColumnIndex)) {

						this.col_TMA_Producteur = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport.ColumnIndex)) {

						this.col_Pourcent_Sec_Transport = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport_Override.ColumnIndex)) {

						this.col_Pourcent_Sec_Transport_Override = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Transport.ColumnIndex)) {

						this.col_TMA_Transport = DR.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Transport.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_IsTMA.ColumnIndex)) {

						this.col_IsTMA = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_IsTMA.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_SuspendrePaiement.ColumnIndex)) {

						this.col_SuspendrePaiement = DR.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_SuspendrePaiement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_BonCommande.ColumnIndex)) {

						this.col_BonCommande = DR.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_BonCommande.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Livraison", "Refresh");
			}
		}
	}
}
