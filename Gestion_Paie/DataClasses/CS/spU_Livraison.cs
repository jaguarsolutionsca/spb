using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spU_Livraison'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spU_Livraison : MarshalByRefObject, IDisposable, IParameter {

		private ErrorSource errorSource = ErrorSource.NotAvailable;
		private System.Data.SqlClient.SqlException sqlException = null;
		private System.Exception otherException = null;
		private string connectionString = String.Empty;
		private System.Data.SqlClient.SqlConnection sqlConnection = null;
		private System.Data.SqlClient.SqlTransaction sqlTransaction = null;
		private ConnectionType lastKnownConnectionType = ConnectionType.None;
		private int commandTimeOut = 30;

		internal void internal_UpdateExceptionInformation(System.Data.SqlClient.SqlException sqlException) {

			this.sqlException = sqlException;
		}

		internal void internal_UpdateExceptionInformation(System.Exception otherException) {

			this.otherException = otherException;
		}

		internal void internal_SetErrorSource(ErrorSource errorSource) {

			this.errorSource = errorSource;
		}

		private bool useDefaultValue = true;

		/// <summary>
		/// Initializes a new instance of the spU_Livraison class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spU_Livraison() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Livraison class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spU_Livraison(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DatePaye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Sciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DroitCoupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EntentePaiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VR_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VR_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MasseLimite_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_MasseLimite_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeBrut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeTare_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeTare_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeTransporte_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeSurcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeAPayer_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Periode_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Periode_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateCalcul_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DateCalcul_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Usine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Producteur1_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Producteur2_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Surcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_MiseEnCommun_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Facture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Facture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Producteur1_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Producteur2_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Transporteur_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Usine_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ErreurCalcul_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ErreurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_LotID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Transporteur_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PaieTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeSurcharge_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_SurchargeManuel_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NombrePermis_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_NombrePermis_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ChargeurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ChargeurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Chargeur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresAuProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresAuTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Chargeur_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Commentaires_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Commentaires_Transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Commentaires_Chargeur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TauxChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TauxChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_SurchargeProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgVert_Brut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgVert_Tare_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgVert_Net_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgVert_Rejets_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgVert_Paye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Pourcent_Sec_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TMA_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Pourcent_Sec_Transport_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TMA_Transport_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IsTMA_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_IsTMA_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_SuspendrePaiement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_BonCommande_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = this.useDefaultValue;
		}


		/// <summary>
		/// Sets the connection string to be used against the 
		/// SQL Server database.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public void SetUpConnection(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

			this.connectionString = connectionString;
			this.lastKnownConnectionType = ConnectionType.ConnectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Livraison'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif
		}

		/// <summary>
		/// Sets the System.Data.SqlClient.SqlConnection to be used
		/// against the SQL Server database.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection object. It can be opened or not. If it is not opened, it will be opened when used then closed again after the job is done.</param>
		public void SetUpConnection(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {
				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

			this.sqlConnection = sqlConnection;
			this.lastKnownConnectionType = ConnectionType.SqlConnection;

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Livraison'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Sets the System.Data.SqlClient.SqlTransaction to be used
		/// against the SQL Server database.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction object.</param>
		public void SetUpConnection(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid connection!");
			}

			this.sqlTransaction= sqlTransaction;
			this.lastKnownConnectionType = ConnectionType.SqlTransaction;

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Livraison'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Disposes the current instance of this object.
		/// </summary>
		public void Dispose() {

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing) {

			if (disposing) {

				this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DateLivraison = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DatePaye = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ContratID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_UniteMesureID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_EssenceID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_NumeroFactureUsine = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_DroitCoupeID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_EntentePaiementID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_TransporteurID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VR = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_VR = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_MasseLimite = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_VolumeBrut = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeTare = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_VolumeTare = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeTransporte = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_VolumeTransporte = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeSurcharge = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_VolumeSurcharge = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeAPayer = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_VolumeAPayer = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Annee = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Periode = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Periode = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DateCalcul = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Taux_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Taux_Transporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Transporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Usine = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Producteur1 = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Producteur1 = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Producteur2 = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Producteur2 = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Preleve_Divers = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Surcharge = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Surcharge = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_MiseEnCommun = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Montant_MiseEnCommun = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Facture = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Facture = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Producteur1_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Producteur2_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Transporteur_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Usine_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ErreurDescription = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ErreurDescription = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_LotID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Code = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NombrePermis = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_NombrePermis = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ZoneID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_MunicipaliteID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ChargeurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ChargeurID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_Chargeur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_Chargeur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Chargeur_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Commentaires_Producteur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Commentaires_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Commentaires_Transporteur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Commentaires_Transporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Commentaires_Chargeur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Commentaires_Chargeur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgVert_Brut = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgVert_Brut = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgVert_Tare = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgVert_Tare = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgVert_Net = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgVert_Net = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgVert_Rejets = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgVert_Rejets = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgVert_Paye = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TMA_Producteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_TMA_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TMA_Transport = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_TMA_Transport = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_BonCommande = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_BonCommande = System.Data.SqlTypes.SqlBoolean.Null;

				this.sqlException = null;
				this.otherException = null;
				this.connectionString = null;
				this.sqlConnection = null;
				this.sqlTransaction = null;

			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~spU_Livraison() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spU_Livraison'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spU_Livraison");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateLivraison;
		internal bool internal_Param_DateLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DateLivraison;
		internal bool internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DatePaye;
		internal bool internal_Param_DatePaye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DatePaye;
		internal bool internal_Param_ConsiderNull_DatePaye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ContratID;
		internal bool internal_Param_ConsiderNull_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteMesureID;
		internal bool internal_Param_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_UniteMesureID;
		internal bool internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_EssenceID;
		internal bool internal_Param_ConsiderNull_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Sciage;
		internal bool internal_Param_Sciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Sciage;
		internal bool internal_Param_ConsiderNull_Sciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NumeroFactureUsine;
		internal bool internal_Param_NumeroFactureUsine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_NumeroFactureUsine;
		internal bool internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_DroitCoupeID;
		internal bool internal_Param_DroitCoupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DroitCoupeID;
		internal bool internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EntentePaiementID;
		internal bool internal_Param_EntentePaiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_EntentePaiementID;
		internal bool internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TransporteurID;
		internal bool internal_Param_TransporteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TransporteurID;
		internal bool internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_VR;
		internal bool internal_Param_VR_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VR;
		internal bool internal_Param_ConsiderNull_VR_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_MasseLimite;
		internal bool internal_Param_MasseLimite_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_MasseLimite;
		internal bool internal_Param_ConsiderNull_MasseLimite_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeBrut;
		internal bool internal_Param_VolumeBrut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeBrut;
		internal bool internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeTare;
		internal bool internal_Param_VolumeTare_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeTare;
		internal bool internal_Param_ConsiderNull_VolumeTare_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeTransporte;
		internal bool internal_Param_VolumeTransporte_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeTransporte;
		internal bool internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeSurcharge;
		internal bool internal_Param_VolumeSurcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeSurcharge;
		internal bool internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeAPayer;
		internal bool internal_Param_VolumeAPayer_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeAPayer;
		internal bool internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Annee;
		internal bool internal_Param_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Annee;
		internal bool internal_Param_ConsiderNull_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Periode;
		internal bool internal_Param_Periode_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Periode;
		internal bool internal_Param_ConsiderNull_Periode_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateCalcul;
		internal bool internal_Param_DateCalcul_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DateCalcul;
		internal bool internal_Param_ConsiderNull_DateCalcul_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Transporteur;
		internal bool internal_Param_Taux_Transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Taux_Transporteur;
		internal bool internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Transporteur;
		internal bool internal_Param_Montant_Transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Transporteur;
		internal bool internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Usine;
		internal bool internal_Param_Montant_Usine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Usine;
		internal bool internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Producteur1;
		internal bool internal_Param_Montant_Producteur1_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Producteur1;
		internal bool internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Producteur2;
		internal bool internal_Param_Montant_Producteur2_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Producteur2;
		internal bool internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Plan_Conjoint;
		internal bool internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint;
		internal bool internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Fond_Roulement;
		internal bool internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement;
		internal bool internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Fond_Forestier;
		internal bool internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier;
		internal bool internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Divers;
		internal bool internal_Param_Montant_Preleve_Divers_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Preleve_Divers;
		internal bool internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Surcharge;
		internal bool internal_Param_Montant_Surcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Surcharge;
		internal bool internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Montant_MiseEnCommun;
		internal bool internal_Param_Montant_MiseEnCommun_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_MiseEnCommun;
		internal bool internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Facture;
		internal bool internal_Param_Facture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Facture;
		internal bool internal_Param_ConsiderNull_Facture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Producteur1_FactureID;
		internal bool internal_Param_Producteur1_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Producteur1_FactureID;
		internal bool internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Producteur2_FactureID;
		internal bool internal_Param_Producteur2_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Producteur2_FactureID;
		internal bool internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Transporteur_FactureID;
		internal bool internal_Param_Transporteur_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Transporteur_FactureID;
		internal bool internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Usine_FactureID;
		internal bool internal_Param_Usine_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Usine_FactureID;
		internal bool internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ErreurCalcul;
		internal bool internal_Param_ErreurCalcul_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ErreurCalcul;
		internal bool internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ErreurDescription;
		internal bool internal_Param_ErreurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ErreurDescription;
		internal bool internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LotID;
		internal bool internal_Param_LotID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_LotID;
		internal bool internal_Param_ConsiderNull_LotID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Taux_Transporteur_Override;
		internal bool internal_Param_Taux_Transporteur_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Taux_Transporteur_Override;
		internal bool internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_PaieTransporteur;
		internal bool internal_Param_PaieTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_PaieTransporteur;
		internal bool internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_VolumeSurcharge_Override;
		internal bool internal_Param_VolumeSurcharge_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeSurcharge_Override;
		internal bool internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_SurchargeManuel;
		internal bool internal_Param_SurchargeManuel_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_SurchargeManuel;
		internal bool internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code;
		internal bool internal_Param_Code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Code;
		internal bool internal_Param_ConsiderNull_Code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_NombrePermis;
		internal bool internal_Param_NombrePermis_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_NombrePermis;
		internal bool internal_Param_ConsiderNull_NombrePermis_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ZoneID;
		internal bool internal_Param_ZoneID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ZoneID;
		internal bool internal_Param_ConsiderNull_ZoneID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteID;
		internal bool internal_Param_MunicipaliteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_MunicipaliteID;
		internal bool internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ChargeurID;
		internal bool internal_Param_ChargeurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ChargeurID;
		internal bool internal_Param_ConsiderNull_ChargeurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Chargeur;
		internal bool internal_Param_Montant_Chargeur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_Chargeur;
		internal bool internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_ChargeurAuProducteur;
		internal bool internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_ChargeurAuProducteur;
		internal bool internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_ChargeurAuTransporteur;
		internal bool internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur;
		internal bool internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_AutresAuProducteur;
		internal bool internal_Param_Frais_AutresAuProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresAuProducteur;
		internal bool internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Frais_AutresAuProducteurDescription;
		internal bool internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription;
		internal bool internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_AutresAuProducteurTransportSciage;
		internal bool internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage;
		internal bool internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_AutresAuTransporteur;
		internal bool internal_Param_Frais_AutresAuTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresAuTransporteur;
		internal bool internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Frais_AutresAuTransporteurDescription;
		internal bool internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription;
		internal bool internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_CompensationDeDeplacement;
		internal bool internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_CompensationDeDeplacement;
		internal bool internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Chargeur_FactureID;
		internal bool internal_Param_Chargeur_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Chargeur_FactureID;
		internal bool internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Commentaires_Producteur;
		internal bool internal_Param_Commentaires_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Commentaires_Producteur;
		internal bool internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Commentaires_Transporteur;
		internal bool internal_Param_Commentaires_Transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Commentaires_Transporteur;
		internal bool internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Commentaires_Chargeur;
		internal bool internal_Param_Commentaires_Chargeur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Commentaires_Chargeur;
		internal bool internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_TauxChargeurAuProducteur;
		internal bool internal_Param_TauxChargeurAuProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TauxChargeurAuProducteur;
		internal bool internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_TauxChargeurAuTransporteur;
		internal bool internal_Param_TauxChargeurAuTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TauxChargeurAuTransporteur;
		internal bool internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_AutresRevenusTransporteur;
		internal bool internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur;
		internal bool internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Frais_AutresRevenusTransporteurDescription;
		internal bool internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription;
		internal bool internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Frais_AutresRevenusProducteur;
		internal bool internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresRevenusProducteur;
		internal bool internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Frais_AutresRevenusProducteurDescription;
		internal bool internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription;
		internal bool internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_SurchargeProducteur;
		internal bool internal_Param_Montant_SurchargeProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Montant_SurchargeProducteur;
		internal bool internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgVert_Brut;
		internal bool internal_Param_KgVert_Brut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgVert_Brut;
		internal bool internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgVert_Tare;
		internal bool internal_Param_KgVert_Tare_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgVert_Tare;
		internal bool internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgVert_Net;
		internal bool internal_Param_KgVert_Net_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgVert_Net;
		internal bool internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgVert_Rejets;
		internal bool internal_Param_KgVert_Rejets_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgVert_Rejets;
		internal bool internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgVert_Paye;
		internal bool internal_Param_KgVert_Paye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgVert_Paye;
		internal bool internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Pourcent_Sec_Producteur;
		internal bool internal_Param_Pourcent_Sec_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Pourcent_Sec_Producteur;
		internal bool internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Pourcent_Sec_Producteur_Override;
		internal bool internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override;
		internal bool internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_TMA_Producteur;
		internal bool internal_Param_TMA_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TMA_Producteur;
		internal bool internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Pourcent_Sec_Transport;
		internal bool internal_Param_Pourcent_Sec_Transport_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Pourcent_Sec_Transport;
		internal bool internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Pourcent_Sec_Transport_Override;
		internal bool internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override;
		internal bool internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_TMA_Transport;
		internal bool internal_Param_TMA_Transport_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TMA_Transport;
		internal bool internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IsTMA;
		internal bool internal_Param_IsTMA_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_IsTMA;
		internal bool internal_Param_ConsiderNull_IsTMA_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_SuspendrePaiement;
		internal bool internal_Param_SuspendrePaiement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_SuspendrePaiement;
		internal bool internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_BonCommande;
		internal bool internal_Param_BonCommande_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_BonCommande;
		internal bool internal_Param_ConsiderNull_BonCommande_UseDefaultValue = true;


		/// <summary>
		/// Allows you to know at which step did the error occured if one occured. See <see cref="ErrorSource" />
		/// for more information.
		/// </summary>
		public ErrorSource ErrorSource {

			get {

				return(this.errorSource);
			}
		}

		/// <summary>
		/// This method allows you to reset the parameter object. Please note that this
		/// method resets all the parameters members except the connection information and
		/// the command time-out which are left in their current state.
		/// </summary>
		public void Reset() {


			this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;

			this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DateLivraison = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DatePaye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DatePaye = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ContratID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_UniteMesureID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_EssenceID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Sciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_NumeroFactureUsine = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_DroitCoupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DroitCoupeID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EntentePaiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_EntentePaiementID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TransporteurID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VR = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_VR_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VR = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VR_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_MasseLimite_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_MasseLimite = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_MasseLimite_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeBrut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeBrut = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeTare = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeTare_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeTare = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeTare_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeTransporte = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeTransporte_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeTransporte = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeSurcharge = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeSurcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeSurcharge = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeAPayer = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeAPayer_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeAPayer = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Annee = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Periode = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Periode_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Periode = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Periode_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateCalcul_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DateCalcul = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DateCalcul_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Taux_Transporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Transporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Usine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Usine = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Producteur1 = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Producteur1_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Producteur1 = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Producteur2 = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Producteur2_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Producteur2 = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Preleve_Divers = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Surcharge = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Surcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Surcharge = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_MiseEnCommun = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Montant_MiseEnCommun_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_MiseEnCommun = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Facture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Facture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Producteur1_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Producteur1_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Producteur2_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Producteur2_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Transporteur_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Transporteur_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Usine_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Usine_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ErreurCalcul_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ErreurDescription = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ErreurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ErreurDescription = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_LotID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_LotID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Taux_Transporteur_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_PaieTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_VolumeSurcharge_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_SurchargeManuel_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Code = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NombrePermis = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_NombrePermis_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_NombrePermis = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_NombrePermis_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ZoneID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_MunicipaliteID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ChargeurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ChargeurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ChargeurID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ChargeurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Chargeur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Chargeur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_Chargeur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_AutresAuProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_AutresAuTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Chargeur_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Chargeur_FactureID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Commentaires_Producteur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Commentaires_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Commentaires_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Commentaires_Transporteur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Commentaires_Transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Commentaires_Transporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Commentaires_Chargeur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Commentaires_Chargeur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Commentaires_Chargeur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_TauxChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_TauxChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_SurchargeProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgVert_Brut = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgVert_Brut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgVert_Brut = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgVert_Tare = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgVert_Tare_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgVert_Tare = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgVert_Net = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgVert_Net_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgVert_Net = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgVert_Rejets = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgVert_Rejets_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgVert_Rejets = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgVert_Paye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgVert_Paye = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Pourcent_Sec_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TMA_Producteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_TMA_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TMA_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Pourcent_Sec_Transport_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TMA_Transport = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_TMA_Transport_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TMA_Transport = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IsTMA_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_IsTMA_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_SuspendrePaiement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_BonCommande = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_BonCommande_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_BonCommande = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = this.useDefaultValue;

			this.errorSource = ErrorSource.NotAvailable;
			this.sqlException = null;
			this.otherException = null;
		}

		/// <summary>
		/// Returns the connection string to be used against the 
		/// SQL Server database.
		/// </summary>
		public System.String ConnectionString {

			get {

				return(this.connectionString);
			}
		}
            
		/// <summary>
		/// Returns the System.Data.SqlClient.SqlConnection to be used
		/// against the SQL Server database.
		/// </summary>
		public System.Data.SqlClient.SqlConnection SqlConnection {

			get {

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Returns the System.Data.SqlClient.SqlTransaction to be used
		/// against the SQL Server database.
		/// </summary>
		public System.Data.SqlClient.SqlTransaction SqlTransaction {

			get {

				return(this.sqlTransaction);
			}
		}

		/// <summary>
		/// Returns the current type of connection that is going or has been used
		/// against the Sql Server database. It can be: ConnectionString, SqlConnection
		/// or SqlTransaction
		/// </summary>
		public ConnectionType ConnectionType {

			get {

				return(this.lastKnownConnectionType );
			}
		}

		/// <summary>
		/// In case of an ADO exception, returns the SqlException exception (System.Data.SqlClient.SqlException)
		/// that has occured.
		/// </summary>
		public System.Data.SqlClient.SqlException SqlException {

			get {

				return(this.sqlException);
			}
		}

		/// <summary>
		/// In case of a System exception, returns the standard exception (System.Exception) that 
		/// has occured.
		/// </summary>
		public System.Exception OtherException {

			get {

				return(this.otherException);
			}
		}

		/// <summary>
		/// Sets or returns the time-out (in seconds) to be use by the ADO command object
		/// (System.Data.SqlClient.SqlCommand).
		/// <remarks>
		/// Default value is 30 seconds.
		/// </remarks>
		/// </summary>
		public int CommandTimeOut {

			get {

				return(this.commandTimeOut);
			}

			set {

				this.commandTimeOut = value;
				if (this.commandTimeOut <= 0) {

					this.commandTimeOut = 30;
				}
			}
		}


		/// <summary>
		/// Returns the value returned back by the stored procedure execution.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Param_RETURN_VALUE {

			get {

				return(this.internal_Param_RETURN_VALUE);
			}
		}
            
		internal void internal_Set_RETURN_VALUE(System.Data.SqlTypes.SqlInt32 value) {

			this.internal_Param_RETURN_VALUE = value;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_ID {

			get {

				if (this.internal_Param_ID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ID);
			}

			set {

				this.internal_Param_ID_UseDefaultValue = false;
				this.internal_Param_ID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ID_UseDefaultValue() {

			this.internal_Param_ID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateLivraison'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DateLivraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateLivraison {

			get {

				if (this.internal_Param_DateLivraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateLivraison);
			}

			set {

				this.internal_Param_DateLivraison_UseDefaultValue = false;
				this.internal_Param_DateLivraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateLivraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateLivraison_UseDefaultValue() {

			this.internal_Param_DateLivraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DateLivraison'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_DateLivraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DateLivraison {

			get {

				if (this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DateLivraison);
			}

			set {

				this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DateLivraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DateLivraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DateLivraison_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DatePaye'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DatePaye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DatePaye {

			get {

				if (this.internal_Param_DatePaye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DatePaye);
			}

			set {

				this.internal_Param_DatePaye_UseDefaultValue = false;
				this.internal_Param_DatePaye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DatePaye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DatePaye_UseDefaultValue() {

			this.internal_Param_DatePaye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DatePaye'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_DatePaye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DatePaye {

			get {

				if (this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DatePaye);
			}

			set {

				this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DatePaye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DatePaye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DatePaye_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ContratID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](10)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ContratID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ContratID {

			get {

				if (this.internal_Param_ContratID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContratID);
			}

			set {

				this.internal_Param_ContratID_UseDefaultValue = false;
				this.internal_Param_ContratID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContratID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContratID_UseDefaultValue() {

			this.internal_Param_ContratID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ContratID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_ContratID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ContratID {

			get {

				if (this.internal_Param_ConsiderNull_ContratID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ContratID);
			}

			set {

				this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ContratID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ContratID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ContratID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@UniteMesureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_UniteMesureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_UniteMesureID {

			get {

				if (this.internal_Param_UniteMesureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UniteMesureID);
			}

			set {

				this.internal_Param_UniteMesureID_UseDefaultValue = false;
				this.internal_Param_UniteMesureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UniteMesureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UniteMesureID_UseDefaultValue() {

			this.internal_Param_UniteMesureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_UniteMesureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_UniteMesureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_UniteMesureID {

			get {

				if (this.internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_UniteMesureID);
			}

			set {

				this.internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_UniteMesureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_UniteMesureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_UniteMesureID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@EssenceID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_EssenceID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_EssenceID {

			get {

				if (this.internal_Param_EssenceID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EssenceID);
			}

			set {

				this.internal_Param_EssenceID_UseDefaultValue = false;
				this.internal_Param_EssenceID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EssenceID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EssenceID_UseDefaultValue() {

			this.internal_Param_EssenceID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_EssenceID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_EssenceID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_EssenceID {

			get {

				if (this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_EssenceID);
			}

			set {

				this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_EssenceID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_EssenceID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_EssenceID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Sciage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Sciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Sciage {

			get {

				if (this.internal_Param_Sciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Sciage);
			}

			set {

				this.internal_Param_Sciage_UseDefaultValue = false;
				this.internal_Param_Sciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Sciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Sciage_UseDefaultValue() {

			this.internal_Param_Sciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Sciage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Sciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Sciage {

			get {

				if (this.internal_Param_ConsiderNull_Sciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Sciage);
			}

			set {

				this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Sciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Sciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Sciage_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NumeroFactureUsine'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](25)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NumeroFactureUsine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NumeroFactureUsine {

			get {

				if (this.internal_Param_NumeroFactureUsine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NumeroFactureUsine);
			}

			set {

				this.internal_Param_NumeroFactureUsine_UseDefaultValue = false;
				this.internal_Param_NumeroFactureUsine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NumeroFactureUsine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NumeroFactureUsine_UseDefaultValue() {

			this.internal_Param_NumeroFactureUsine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_NumeroFactureUsine'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_NumeroFactureUsine {

			get {

				if (this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_NumeroFactureUsine);
			}

			set {

				this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_NumeroFactureUsine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_NumeroFactureUsine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue() {

			this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DroitCoupeID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DroitCoupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_DroitCoupeID {

			get {

				if (this.internal_Param_DroitCoupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DroitCoupeID);
			}

			set {

				this.internal_Param_DroitCoupeID_UseDefaultValue = false;
				this.internal_Param_DroitCoupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DroitCoupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DroitCoupeID_UseDefaultValue() {

			this.internal_Param_DroitCoupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DroitCoupeID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_DroitCoupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DroitCoupeID {

			get {

				if (this.internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DroitCoupeID);
			}

			set {

				this.internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DroitCoupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DroitCoupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DroitCoupeID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@EntentePaiementID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_EntentePaiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_EntentePaiementID {

			get {

				if (this.internal_Param_EntentePaiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EntentePaiementID);
			}

			set {

				this.internal_Param_EntentePaiementID_UseDefaultValue = false;
				this.internal_Param_EntentePaiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EntentePaiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EntentePaiementID_UseDefaultValue() {

			this.internal_Param_EntentePaiementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_EntentePaiementID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_EntentePaiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_EntentePaiementID {

			get {

				if (this.internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_EntentePaiementID);
			}

			set {

				this.internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_EntentePaiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_EntentePaiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_EntentePaiementID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TransporteurID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TransporteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TransporteurID {

			get {

				if (this.internal_Param_TransporteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TransporteurID);
			}

			set {

				this.internal_Param_TransporteurID_UseDefaultValue = false;
				this.internal_Param_TransporteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TransporteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TransporteurID_UseDefaultValue() {

			this.internal_Param_TransporteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TransporteurID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_TransporteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TransporteurID {

			get {

				if (this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TransporteurID);
			}

			set {

				this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TransporteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TransporteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TransporteurID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VR'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](10)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VR_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_VR {

			get {

				if (this.internal_Param_VR_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VR);
			}

			set {

				this.internal_Param_VR_UseDefaultValue = false;
				this.internal_Param_VR = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VR' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VR_UseDefaultValue() {

			this.internal_Param_VR_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VR'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VR_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VR {

			get {

				if (this.internal_Param_ConsiderNull_VR_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VR);
			}

			set {

				this.internal_Param_ConsiderNull_VR_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VR = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VR' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VR_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VR_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MasseLimite'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_MasseLimite_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_MasseLimite {

			get {

				if (this.internal_Param_MasseLimite_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MasseLimite);
			}

			set {

				this.internal_Param_MasseLimite_UseDefaultValue = false;
				this.internal_Param_MasseLimite = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MasseLimite' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MasseLimite_UseDefaultValue() {

			this.internal_Param_MasseLimite_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_MasseLimite'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_MasseLimite_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_MasseLimite {

			get {

				if (this.internal_Param_ConsiderNull_MasseLimite_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_MasseLimite);
			}

			set {

				this.internal_Param_ConsiderNull_MasseLimite_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_MasseLimite = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_MasseLimite' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_MasseLimite_UseDefaultValue() {

			this.internal_Param_ConsiderNull_MasseLimite_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeBrut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VolumeBrut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeBrut {

			get {

				if (this.internal_Param_VolumeBrut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeBrut);
			}

			set {

				this.internal_Param_VolumeBrut_UseDefaultValue = false;
				this.internal_Param_VolumeBrut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeBrut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeBrut_UseDefaultValue() {

			this.internal_Param_VolumeBrut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeBrut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeBrut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeBrut {

			get {

				if (this.internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeBrut);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeBrut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeBrut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeBrut_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeTare'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VolumeTare_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeTare {

			get {

				if (this.internal_Param_VolumeTare_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeTare);
			}

			set {

				this.internal_Param_VolumeTare_UseDefaultValue = false;
				this.internal_Param_VolumeTare = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeTare' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeTare_UseDefaultValue() {

			this.internal_Param_VolumeTare_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeTare'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeTare_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeTare {

			get {

				if (this.internal_Param_ConsiderNull_VolumeTare_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeTare);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeTare_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeTare = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeTare' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeTare_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeTare_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeTransporte'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VolumeTransporte_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeTransporte {

			get {

				if (this.internal_Param_VolumeTransporte_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeTransporte);
			}

			set {

				this.internal_Param_VolumeTransporte_UseDefaultValue = false;
				this.internal_Param_VolumeTransporte = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeTransporte' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeTransporte_UseDefaultValue() {

			this.internal_Param_VolumeTransporte_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeTransporte'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeTransporte_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeTransporte {

			get {

				if (this.internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeTransporte);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeTransporte = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeTransporte' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeTransporte_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeSurcharge'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VolumeSurcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeSurcharge {

			get {

				if (this.internal_Param_VolumeSurcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeSurcharge);
			}

			set {

				this.internal_Param_VolumeSurcharge_UseDefaultValue = false;
				this.internal_Param_VolumeSurcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeSurcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeSurcharge_UseDefaultValue() {

			this.internal_Param_VolumeSurcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeSurcharge'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeSurcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeSurcharge {

			get {

				if (this.internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeSurcharge);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeSurcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeSurcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeSurcharge_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeAPayer'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VolumeAPayer_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeAPayer {

			get {

				if (this.internal_Param_VolumeAPayer_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeAPayer);
			}

			set {

				this.internal_Param_VolumeAPayer_UseDefaultValue = false;
				this.internal_Param_VolumeAPayer = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeAPayer' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeAPayer_UseDefaultValue() {

			this.internal_Param_VolumeAPayer_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeAPayer'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeAPayer_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeAPayer {

			get {

				if (this.internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeAPayer);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeAPayer = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeAPayer' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeAPayer_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Annee'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Annee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Annee {

			get {

				if (this.internal_Param_Annee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Annee);
			}

			set {

				this.internal_Param_Annee_UseDefaultValue = false;
				this.internal_Param_Annee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Annee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Annee_UseDefaultValue() {

			this.internal_Param_Annee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Annee'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Annee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Annee {

			get {

				if (this.internal_Param_ConsiderNull_Annee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Annee);
			}

			set {

				this.internal_Param_ConsiderNull_Annee_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Annee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Annee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Annee_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Annee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Periode'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Periode_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Periode {

			get {

				if (this.internal_Param_Periode_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Periode);
			}

			set {

				this.internal_Param_Periode_UseDefaultValue = false;
				this.internal_Param_Periode = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Periode' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Periode_UseDefaultValue() {

			this.internal_Param_Periode_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Periode'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Periode_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Periode {

			get {

				if (this.internal_Param_ConsiderNull_Periode_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Periode);
			}

			set {

				this.internal_Param_ConsiderNull_Periode_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Periode = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Periode' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Periode_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Periode_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateCalcul'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [datetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DateCalcul_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateCalcul {

			get {

				if (this.internal_Param_DateCalcul_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateCalcul);
			}

			set {

				this.internal_Param_DateCalcul_UseDefaultValue = false;
				this.internal_Param_DateCalcul = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateCalcul' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateCalcul_UseDefaultValue() {

			this.internal_Param_DateCalcul_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DateCalcul'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_DateCalcul_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DateCalcul {

			get {

				if (this.internal_Param_ConsiderNull_DateCalcul_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DateCalcul);
			}

			set {

				this.internal_Param_ConsiderNull_DateCalcul_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DateCalcul = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DateCalcul' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DateCalcul_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DateCalcul_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Transporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Taux_Transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Transporteur {

			get {

				if (this.internal_Param_Taux_Transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Transporteur);
			}

			set {

				this.internal_Param_Taux_Transporteur_UseDefaultValue = false;
				this.internal_Param_Taux_Transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Transporteur_UseDefaultValue() {

			this.internal_Param_Taux_Transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Taux_Transporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Taux_Transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Taux_Transporteur {

			get {

				if (this.internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Taux_Transporteur);
			}

			set {

				this.internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Taux_Transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Taux_Transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Taux_Transporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Transporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Transporteur {

			get {

				if (this.internal_Param_Montant_Transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Transporteur);
			}

			set {

				this.internal_Param_Montant_Transporteur_UseDefaultValue = false;
				this.internal_Param_Montant_Transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Transporteur_UseDefaultValue() {

			this.internal_Param_Montant_Transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Transporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Transporteur {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Transporteur);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Transporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Usine'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Usine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Usine {

			get {

				if (this.internal_Param_Montant_Usine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Usine);
			}

			set {

				this.internal_Param_Montant_Usine_UseDefaultValue = false;
				this.internal_Param_Montant_Usine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Usine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Usine_UseDefaultValue() {

			this.internal_Param_Montant_Usine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Usine'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Usine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Usine {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Usine);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Usine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Usine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Usine_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Producteur1'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Producteur1_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Producteur1 {

			get {

				if (this.internal_Param_Montant_Producteur1_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Producteur1);
			}

			set {

				this.internal_Param_Montant_Producteur1_UseDefaultValue = false;
				this.internal_Param_Montant_Producteur1 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Producteur1' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Producteur1_UseDefaultValue() {

			this.internal_Param_Montant_Producteur1_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Producteur1'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Producteur1_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Producteur1 {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Producteur1);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Producteur1 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Producteur1' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Producteur1_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Producteur2'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Producteur2_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Producteur2 {

			get {

				if (this.internal_Param_Montant_Producteur2_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Producteur2);
			}

			set {

				this.internal_Param_Montant_Producteur2_UseDefaultValue = false;
				this.internal_Param_Montant_Producteur2 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Producteur2' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Producteur2_UseDefaultValue() {

			this.internal_Param_Montant_Producteur2_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Producteur2'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Producteur2_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Producteur2 {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Producteur2);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Producteur2 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Producteur2' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Producteur2_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Plan_Conjoint'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Plan_Conjoint {

			get {

				if (this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Plan_Conjoint);
			}

			set {

				this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Plan_Conjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Plan_Conjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Preleve_Plan_Conjoint'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Preleve_Plan_Conjoint {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Preleve_Plan_Conjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Fond_Roulement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Preleve_Fond_Roulement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Fond_Roulement {

			get {

				if (this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Fond_Roulement);
			}

			set {

				this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Fond_Roulement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Fond_Roulement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Fond_Roulement_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Preleve_Fond_Roulement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Preleve_Fond_Roulement {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Preleve_Fond_Roulement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Fond_Forestier'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Preleve_Fond_Forestier_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Fond_Forestier {

			get {

				if (this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Fond_Forestier);
			}

			set {

				this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Fond_Forestier = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Fond_Forestier' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Fond_Forestier_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Preleve_Fond_Forestier'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Preleve_Fond_Forestier {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Preleve_Fond_Forestier' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Divers'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Preleve_Divers_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Divers {

			get {

				if (this.internal_Param_Montant_Preleve_Divers_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Divers);
			}

			set {

				this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Divers = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Divers' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Divers_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Preleve_Divers'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Preleve_Divers {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Preleve_Divers);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Preleve_Divers = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Preleve_Divers' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Surcharge'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Surcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Surcharge {

			get {

				if (this.internal_Param_Montant_Surcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Surcharge);
			}

			set {

				this.internal_Param_Montant_Surcharge_UseDefaultValue = false;
				this.internal_Param_Montant_Surcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Surcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Surcharge_UseDefaultValue() {

			this.internal_Param_Montant_Surcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Surcharge'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Surcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Surcharge {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Surcharge);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Surcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Surcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Surcharge_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_MiseEnCommun'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_MiseEnCommun_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Montant_MiseEnCommun {

			get {

				if (this.internal_Param_Montant_MiseEnCommun_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_MiseEnCommun);
			}

			set {

				this.internal_Param_Montant_MiseEnCommun_UseDefaultValue = false;
				this.internal_Param_Montant_MiseEnCommun = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_MiseEnCommun' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_MiseEnCommun_UseDefaultValue() {

			this.internal_Param_Montant_MiseEnCommun_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_MiseEnCommun'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_MiseEnCommun {

			get {

				if (this.internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_MiseEnCommun);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_MiseEnCommun = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_MiseEnCommun' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Facture'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Facture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Facture {

			get {

				if (this.internal_Param_Facture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Facture);
			}

			set {

				this.internal_Param_Facture_UseDefaultValue = false;
				this.internal_Param_Facture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Facture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Facture_UseDefaultValue() {

			this.internal_Param_Facture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Facture'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Facture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Facture {

			get {

				if (this.internal_Param_ConsiderNull_Facture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Facture);
			}

			set {

				this.internal_Param_ConsiderNull_Facture_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Facture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Facture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Facture_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Facture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Producteur1_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Producteur1_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Producteur1_FactureID {

			get {

				if (this.internal_Param_Producteur1_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Producteur1_FactureID);
			}

			set {

				this.internal_Param_Producteur1_FactureID_UseDefaultValue = false;
				this.internal_Param_Producteur1_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Producteur1_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Producteur1_FactureID_UseDefaultValue() {

			this.internal_Param_Producteur1_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Producteur1_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Producteur1_FactureID {

			get {

				if (this.internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Producteur1_FactureID);
			}

			set {

				this.internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Producteur1_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Producteur1_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Producteur2_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Producteur2_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Producteur2_FactureID {

			get {

				if (this.internal_Param_Producteur2_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Producteur2_FactureID);
			}

			set {

				this.internal_Param_Producteur2_FactureID_UseDefaultValue = false;
				this.internal_Param_Producteur2_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Producteur2_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Producteur2_FactureID_UseDefaultValue() {

			this.internal_Param_Producteur2_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Producteur2_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Producteur2_FactureID {

			get {

				if (this.internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Producteur2_FactureID);
			}

			set {

				this.internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Producteur2_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Producteur2_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Transporteur_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Transporteur_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Transporteur_FactureID {

			get {

				if (this.internal_Param_Transporteur_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Transporteur_FactureID);
			}

			set {

				this.internal_Param_Transporteur_FactureID_UseDefaultValue = false;
				this.internal_Param_Transporteur_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Transporteur_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Transporteur_FactureID_UseDefaultValue() {

			this.internal_Param_Transporteur_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Transporteur_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Transporteur_FactureID {

			get {

				if (this.internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Transporteur_FactureID);
			}

			set {

				this.internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Transporteur_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Transporteur_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Usine_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Usine_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Usine_FactureID {

			get {

				if (this.internal_Param_Usine_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Usine_FactureID);
			}

			set {

				this.internal_Param_Usine_FactureID_UseDefaultValue = false;
				this.internal_Param_Usine_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Usine_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Usine_FactureID_UseDefaultValue() {

			this.internal_Param_Usine_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Usine_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Usine_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Usine_FactureID {

			get {

				if (this.internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Usine_FactureID);
			}

			set {

				this.internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Usine_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Usine_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Usine_FactureID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ErreurCalcul'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ErreurCalcul_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ErreurCalcul {

			get {

				if (this.internal_Param_ErreurCalcul_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ErreurCalcul);
			}

			set {

				this.internal_Param_ErreurCalcul_UseDefaultValue = false;
				this.internal_Param_ErreurCalcul = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ErreurCalcul' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ErreurCalcul_UseDefaultValue() {

			this.internal_Param_ErreurCalcul_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ErreurCalcul'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_ErreurCalcul_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ErreurCalcul {

			get {

				if (this.internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ErreurCalcul);
			}

			set {

				this.internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ErreurCalcul = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ErreurCalcul' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ErreurCalcul_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ErreurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4000)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ErreurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ErreurDescription {

			get {

				if (this.internal_Param_ErreurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ErreurDescription);
			}

			set {

				this.internal_Param_ErreurDescription_UseDefaultValue = false;
				this.internal_Param_ErreurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ErreurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ErreurDescription_UseDefaultValue() {

			this.internal_Param_ErreurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ErreurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_ErreurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ErreurDescription {

			get {

				if (this.internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ErreurDescription);
			}

			set {

				this.internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ErreurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ErreurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ErreurDescription_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@LotID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_LotID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_LotID {

			get {

				if (this.internal_Param_LotID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LotID);
			}

			set {

				this.internal_Param_LotID_UseDefaultValue = false;
				this.internal_Param_LotID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LotID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LotID_UseDefaultValue() {

			this.internal_Param_LotID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_LotID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_LotID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_LotID {

			get {

				if (this.internal_Param_ConsiderNull_LotID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_LotID);
			}

			set {

				this.internal_Param_ConsiderNull_LotID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_LotID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_LotID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_LotID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_LotID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Transporteur_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Taux_Transporteur_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Taux_Transporteur_Override {

			get {

				if (this.internal_Param_Taux_Transporteur_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Transporteur_Override);
			}

			set {

				this.internal_Param_Taux_Transporteur_Override_UseDefaultValue = false;
				this.internal_Param_Taux_Transporteur_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Transporteur_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Transporteur_Override_UseDefaultValue() {

			this.internal_Param_Taux_Transporteur_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Taux_Transporteur_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Taux_Transporteur_Override {

			get {

				if (this.internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Taux_Transporteur_Override);
			}

			set {

				this.internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Taux_Transporteur_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Taux_Transporteur_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PaieTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_PaieTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_PaieTransporteur {

			get {

				if (this.internal_Param_PaieTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PaieTransporteur);
			}

			set {

				this.internal_Param_PaieTransporteur_UseDefaultValue = false;
				this.internal_Param_PaieTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PaieTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PaieTransporteur_UseDefaultValue() {

			this.internal_Param_PaieTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_PaieTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_PaieTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_PaieTransporteur {

			get {

				if (this.internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_PaieTransporteur);
			}

			set {

				this.internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_PaieTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_PaieTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_PaieTransporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeSurcharge_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_VolumeSurcharge_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_VolumeSurcharge_Override {

			get {

				if (this.internal_Param_VolumeSurcharge_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeSurcharge_Override);
			}

			set {

				this.internal_Param_VolumeSurcharge_Override_UseDefaultValue = false;
				this.internal_Param_VolumeSurcharge_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeSurcharge_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeSurcharge_Override_UseDefaultValue() {

			this.internal_Param_VolumeSurcharge_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeSurcharge_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeSurcharge_Override {

			get {

				if (this.internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeSurcharge_Override);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeSurcharge_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeSurcharge_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@SurchargeManuel'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_SurchargeManuel_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_SurchargeManuel {

			get {

				if (this.internal_Param_SurchargeManuel_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_SurchargeManuel);
			}

			set {

				this.internal_Param_SurchargeManuel_UseDefaultValue = false;
				this.internal_Param_SurchargeManuel = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@SurchargeManuel' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_SurchargeManuel_UseDefaultValue() {

			this.internal_Param_SurchargeManuel_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_SurchargeManuel'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_SurchargeManuel_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_SurchargeManuel {

			get {

				if (this.internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_SurchargeManuel);
			}

			set {

				this.internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_SurchargeManuel = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_SurchargeManuel' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_SurchargeManuel_UseDefaultValue() {

			this.internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Code'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [char](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Code_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Code {

			get {

				if (this.internal_Param_Code_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Code);
			}

			set {

				this.internal_Param_Code_UseDefaultValue = false;
				this.internal_Param_Code = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Code' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Code_UseDefaultValue() {

			this.internal_Param_Code_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Code'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Code_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Code {

			get {

				if (this.internal_Param_ConsiderNull_Code_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Code);
			}

			set {

				this.internal_Param_ConsiderNull_Code_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Code = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Code' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Code_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Code_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NombrePermis'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NombrePermis_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_NombrePermis {

			get {

				if (this.internal_Param_NombrePermis_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NombrePermis);
			}

			set {

				this.internal_Param_NombrePermis_UseDefaultValue = false;
				this.internal_Param_NombrePermis = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NombrePermis' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NombrePermis_UseDefaultValue() {

			this.internal_Param_NombrePermis_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_NombrePermis'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_NombrePermis_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_NombrePermis {

			get {

				if (this.internal_Param_ConsiderNull_NombrePermis_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_NombrePermis);
			}

			set {

				this.internal_Param_ConsiderNull_NombrePermis_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_NombrePermis = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_NombrePermis' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_NombrePermis_UseDefaultValue() {

			this.internal_Param_ConsiderNull_NombrePermis_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ZoneID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](2)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ZoneID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ZoneID {

			get {

				if (this.internal_Param_ZoneID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ZoneID);
			}

			set {

				this.internal_Param_ZoneID_UseDefaultValue = false;
				this.internal_Param_ZoneID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ZoneID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ZoneID_UseDefaultValue() {

			this.internal_Param_ZoneID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ZoneID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_ZoneID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ZoneID {

			get {

				if (this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ZoneID);
			}

			set {

				this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ZoneID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ZoneID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ZoneID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MunicipaliteID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_MunicipaliteID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_MunicipaliteID {

			get {

				if (this.internal_Param_MunicipaliteID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MunicipaliteID);
			}

			set {

				this.internal_Param_MunicipaliteID_UseDefaultValue = false;
				this.internal_Param_MunicipaliteID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MunicipaliteID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MunicipaliteID_UseDefaultValue() {

			this.internal_Param_MunicipaliteID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_MunicipaliteID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_MunicipaliteID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_MunicipaliteID {

			get {

				if (this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_MunicipaliteID);
			}

			set {

				this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_MunicipaliteID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_MunicipaliteID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_MunicipaliteID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ChargeurID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ChargeurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ChargeurID {

			get {

				if (this.internal_Param_ChargeurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ChargeurID);
			}

			set {

				this.internal_Param_ChargeurID_UseDefaultValue = false;
				this.internal_Param_ChargeurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ChargeurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ChargeurID_UseDefaultValue() {

			this.internal_Param_ChargeurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ChargeurID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_ChargeurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ChargeurID {

			get {

				if (this.internal_Param_ConsiderNull_ChargeurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ChargeurID);
			}

			set {

				this.internal_Param_ConsiderNull_ChargeurID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ChargeurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ChargeurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ChargeurID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ChargeurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Chargeur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_Chargeur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Chargeur {

			get {

				if (this.internal_Param_Montant_Chargeur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Chargeur);
			}

			set {

				this.internal_Param_Montant_Chargeur_UseDefaultValue = false;
				this.internal_Param_Montant_Chargeur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Chargeur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Chargeur_UseDefaultValue() {

			this.internal_Param_Montant_Chargeur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_Chargeur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_Chargeur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_Chargeur {

			get {

				if (this.internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_Chargeur);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_Chargeur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_Chargeur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_Chargeur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_ChargeurAuProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_ChargeurAuProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_ChargeurAuProducteur {

			get {

				if (this.internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_ChargeurAuProducteur);
			}

			set {

				this.internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue = false;
				this.internal_Param_Frais_ChargeurAuProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_ChargeurAuProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_ChargeurAuProducteur_UseDefaultValue() {

			this.internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_ChargeurAuProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_ChargeurAuProducteur {

			get {

				if (this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_ChargeurAuProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_ChargeurAuTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_ChargeurAuTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_ChargeurAuTransporteur {

			get {

				if (this.internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_ChargeurAuTransporteur);
			}

			set {

				this.internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue = false;
				this.internal_Param_Frais_ChargeurAuTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_ChargeurAuTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_ChargeurAuTransporteur_UseDefaultValue() {

			this.internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_ChargeurAuTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_ChargeurAuTransporteur {

			get {

				if (this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_ChargeurAuTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresAuProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresAuProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_AutresAuProducteur {

			get {

				if (this.internal_Param_Frais_AutresAuProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresAuProducteur);
			}

			set {

				this.internal_Param_Frais_AutresAuProducteur_UseDefaultValue = false;
				this.internal_Param_Frais_AutresAuProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresAuProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresAuProducteur_UseDefaultValue() {

			this.internal_Param_Frais_AutresAuProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresAuProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresAuProducteur {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresAuProducteur);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresAuProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresAuProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresAuProducteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresAuProducteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Frais_AutresAuProducteurDescription {

			get {

				if (this.internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresAuProducteurDescription);
			}

			set {

				this.internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue = false;
				this.internal_Param_Frais_AutresAuProducteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresAuProducteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresAuProducteurDescription_UseDefaultValue() {

			this.internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresAuProducteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresAuProducteurDescription {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresAuProducteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresAuProducteurTransportSciage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_AutresAuProducteurTransportSciage {

			get {

				if (this.internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresAuProducteurTransportSciage);
			}

			set {

				this.internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = false;
				this.internal_Param_Frais_AutresAuProducteurTransportSciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresAuProducteurTransportSciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue() {

			this.internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresAuProducteurTransportSciage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresAuProducteurTransportSciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresAuTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresAuTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_AutresAuTransporteur {

			get {

				if (this.internal_Param_Frais_AutresAuTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresAuTransporteur);
			}

			set {

				this.internal_Param_Frais_AutresAuTransporteur_UseDefaultValue = false;
				this.internal_Param_Frais_AutresAuTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresAuTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresAuTransporteur_UseDefaultValue() {

			this.internal_Param_Frais_AutresAuTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresAuTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresAuTransporteur {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresAuTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresAuTransporteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresAuTransporteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Frais_AutresAuTransporteurDescription {

			get {

				if (this.internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresAuTransporteurDescription);
			}

			set {

				this.internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue = false;
				this.internal_Param_Frais_AutresAuTransporteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresAuTransporteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresAuTransporteurDescription_UseDefaultValue() {

			this.internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresAuTransporteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresAuTransporteurDescription {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresAuTransporteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_CompensationDeDeplacement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_CompensationDeDeplacement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_CompensationDeDeplacement {

			get {

				if (this.internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_CompensationDeDeplacement);
			}

			set {

				this.internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue = false;
				this.internal_Param_Frais_CompensationDeDeplacement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_CompensationDeDeplacement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_CompensationDeDeplacement_UseDefaultValue() {

			this.internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_CompensationDeDeplacement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_CompensationDeDeplacement {

			get {

				if (this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_CompensationDeDeplacement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Chargeur_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Chargeur_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Chargeur_FactureID {

			get {

				if (this.internal_Param_Chargeur_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Chargeur_FactureID);
			}

			set {

				this.internal_Param_Chargeur_FactureID_UseDefaultValue = false;
				this.internal_Param_Chargeur_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Chargeur_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Chargeur_FactureID_UseDefaultValue() {

			this.internal_Param_Chargeur_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Chargeur_FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Chargeur_FactureID {

			get {

				if (this.internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Chargeur_FactureID);
			}

			set {

				this.internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Chargeur_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Chargeur_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Commentaires_Producteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](500)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Commentaires_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Commentaires_Producteur {

			get {

				if (this.internal_Param_Commentaires_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Commentaires_Producteur);
			}

			set {

				this.internal_Param_Commentaires_Producteur_UseDefaultValue = false;
				this.internal_Param_Commentaires_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Commentaires_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Commentaires_Producteur_UseDefaultValue() {

			this.internal_Param_Commentaires_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Commentaires_Producteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Commentaires_Producteur {

			get {

				if (this.internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Commentaires_Producteur);
			}

			set {

				this.internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Commentaires_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Commentaires_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Commentaires_Transporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](500)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Commentaires_Transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Commentaires_Transporteur {

			get {

				if (this.internal_Param_Commentaires_Transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Commentaires_Transporteur);
			}

			set {

				this.internal_Param_Commentaires_Transporteur_UseDefaultValue = false;
				this.internal_Param_Commentaires_Transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Commentaires_Transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Commentaires_Transporteur_UseDefaultValue() {

			this.internal_Param_Commentaires_Transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Commentaires_Transporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Commentaires_Transporteur {

			get {

				if (this.internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Commentaires_Transporteur);
			}

			set {

				this.internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Commentaires_Transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Commentaires_Transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Commentaires_Chargeur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](500)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Commentaires_Chargeur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Commentaires_Chargeur {

			get {

				if (this.internal_Param_Commentaires_Chargeur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Commentaires_Chargeur);
			}

			set {

				this.internal_Param_Commentaires_Chargeur_UseDefaultValue = false;
				this.internal_Param_Commentaires_Chargeur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Commentaires_Chargeur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Commentaires_Chargeur_UseDefaultValue() {

			this.internal_Param_Commentaires_Chargeur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Commentaires_Chargeur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Commentaires_Chargeur {

			get {

				if (this.internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Commentaires_Chargeur);
			}

			set {

				this.internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Commentaires_Chargeur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Commentaires_Chargeur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TauxChargeurAuProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TauxChargeurAuProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_TauxChargeurAuProducteur {

			get {

				if (this.internal_Param_TauxChargeurAuProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TauxChargeurAuProducteur);
			}

			set {

				this.internal_Param_TauxChargeurAuProducteur_UseDefaultValue = false;
				this.internal_Param_TauxChargeurAuProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TauxChargeurAuProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TauxChargeurAuProducteur_UseDefaultValue() {

			this.internal_Param_TauxChargeurAuProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TauxChargeurAuProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TauxChargeurAuProducteur {

			get {

				if (this.internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TauxChargeurAuProducteur);
			}

			set {

				this.internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TauxChargeurAuProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TauxChargeurAuProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TauxChargeurAuTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TauxChargeurAuTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_TauxChargeurAuTransporteur {

			get {

				if (this.internal_Param_TauxChargeurAuTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TauxChargeurAuTransporteur);
			}

			set {

				this.internal_Param_TauxChargeurAuTransporteur_UseDefaultValue = false;
				this.internal_Param_TauxChargeurAuTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TauxChargeurAuTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TauxChargeurAuTransporteur_UseDefaultValue() {

			this.internal_Param_TauxChargeurAuTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TauxChargeurAuTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TauxChargeurAuTransporteur {

			get {

				if (this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur);
			}

			set {

				this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TauxChargeurAuTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresRevenusTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresRevenusTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_AutresRevenusTransporteur {

			get {

				if (this.internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresRevenusTransporteur);
			}

			set {

				this.internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue = false;
				this.internal_Param_Frais_AutresRevenusTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresRevenusTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresRevenusTransporteur_UseDefaultValue() {

			this.internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresRevenusTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresRevenusTransporteur {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresRevenusTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresRevenusTransporteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Frais_AutresRevenusTransporteurDescription {

			get {

				if (this.internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresRevenusTransporteurDescription);
			}

			set {

				this.internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = false;
				this.internal_Param_Frais_AutresRevenusTransporteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresRevenusTransporteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue() {

			this.internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresRevenusTransporteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresRevenusTransporteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresRevenusProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresRevenusProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Frais_AutresRevenusProducteur {

			get {

				if (this.internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresRevenusProducteur);
			}

			set {

				this.internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue = false;
				this.internal_Param_Frais_AutresRevenusProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresRevenusProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresRevenusProducteur_UseDefaultValue() {

			this.internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresRevenusProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresRevenusProducteur {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresRevenusProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Frais_AutresRevenusProducteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Frais_AutresRevenusProducteurDescription {

			get {

				if (this.internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Frais_AutresRevenusProducteurDescription);
			}

			set {

				this.internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue = false;
				this.internal_Param_Frais_AutresRevenusProducteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Frais_AutresRevenusProducteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue() {

			this.internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Frais_AutresRevenusProducteurDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Frais_AutresRevenusProducteurDescription {

			get {

				if (this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription);
			}

			set {

				this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Frais_AutresRevenusProducteurDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_SurchargeProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Montant_SurchargeProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_SurchargeProducteur {

			get {

				if (this.internal_Param_Montant_SurchargeProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_SurchargeProducteur);
			}

			set {

				this.internal_Param_Montant_SurchargeProducteur_UseDefaultValue = false;
				this.internal_Param_Montant_SurchargeProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_SurchargeProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_SurchargeProducteur_UseDefaultValue() {

			this.internal_Param_Montant_SurchargeProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Montant_SurchargeProducteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Montant_SurchargeProducteur {

			get {

				if (this.internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Montant_SurchargeProducteur);
			}

			set {

				this.internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Montant_SurchargeProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Montant_SurchargeProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgVert_Brut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_KgVert_Brut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgVert_Brut {

			get {

				if (this.internal_Param_KgVert_Brut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgVert_Brut);
			}

			set {

				this.internal_Param_KgVert_Brut_UseDefaultValue = false;
				this.internal_Param_KgVert_Brut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgVert_Brut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgVert_Brut_UseDefaultValue() {

			this.internal_Param_KgVert_Brut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgVert_Brut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_KgVert_Brut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgVert_Brut {

			get {

				if (this.internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgVert_Brut);
			}

			set {

				this.internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgVert_Brut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgVert_Brut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgVert_Brut_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgVert_Tare'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_KgVert_Tare_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgVert_Tare {

			get {

				if (this.internal_Param_KgVert_Tare_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgVert_Tare);
			}

			set {

				this.internal_Param_KgVert_Tare_UseDefaultValue = false;
				this.internal_Param_KgVert_Tare = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgVert_Tare' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgVert_Tare_UseDefaultValue() {

			this.internal_Param_KgVert_Tare_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgVert_Tare'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_KgVert_Tare_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgVert_Tare {

			get {

				if (this.internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgVert_Tare);
			}

			set {

				this.internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgVert_Tare = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgVert_Tare' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgVert_Tare_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgVert_Net'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_KgVert_Net_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgVert_Net {

			get {

				if (this.internal_Param_KgVert_Net_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgVert_Net);
			}

			set {

				this.internal_Param_KgVert_Net_UseDefaultValue = false;
				this.internal_Param_KgVert_Net = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgVert_Net' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgVert_Net_UseDefaultValue() {

			this.internal_Param_KgVert_Net_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgVert_Net'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_KgVert_Net_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgVert_Net {

			get {

				if (this.internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgVert_Net);
			}

			set {

				this.internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgVert_Net = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgVert_Net' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgVert_Net_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgVert_Rejets'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_KgVert_Rejets_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgVert_Rejets {

			get {

				if (this.internal_Param_KgVert_Rejets_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgVert_Rejets);
			}

			set {

				this.internal_Param_KgVert_Rejets_UseDefaultValue = false;
				this.internal_Param_KgVert_Rejets = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgVert_Rejets' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgVert_Rejets_UseDefaultValue() {

			this.internal_Param_KgVert_Rejets_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgVert_Rejets'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_KgVert_Rejets_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgVert_Rejets {

			get {

				if (this.internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgVert_Rejets);
			}

			set {

				this.internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgVert_Rejets = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgVert_Rejets' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgVert_Rejets_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgVert_Paye'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_KgVert_Paye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgVert_Paye {

			get {

				if (this.internal_Param_KgVert_Paye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgVert_Paye);
			}

			set {

				this.internal_Param_KgVert_Paye_UseDefaultValue = false;
				this.internal_Param_KgVert_Paye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgVert_Paye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgVert_Paye_UseDefaultValue() {

			this.internal_Param_KgVert_Paye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgVert_Paye'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_KgVert_Paye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgVert_Paye {

			get {

				if (this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgVert_Paye);
			}

			set {

				this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgVert_Paye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgVert_Paye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgVert_Paye_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Pourcent_Sec_Producteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Pourcent_Sec_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Pourcent_Sec_Producteur {

			get {

				if (this.internal_Param_Pourcent_Sec_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Pourcent_Sec_Producteur);
			}

			set {

				this.internal_Param_Pourcent_Sec_Producteur_UseDefaultValue = false;
				this.internal_Param_Pourcent_Sec_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Pourcent_Sec_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Pourcent_Sec_Producteur_UseDefaultValue() {

			this.internal_Param_Pourcent_Sec_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Pourcent_Sec_Producteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Pourcent_Sec_Producteur {

			get {

				if (this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur);
			}

			set {

				this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Pourcent_Sec_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Pourcent_Sec_Producteur_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Pourcent_Sec_Producteur_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Pourcent_Sec_Producteur_Override {

			get {

				if (this.internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Pourcent_Sec_Producteur_Override);
			}

			set {

				this.internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue = false;
				this.internal_Param_Pourcent_Sec_Producteur_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Pourcent_Sec_Producteur_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Pourcent_Sec_Producteur_Override_UseDefaultValue() {

			this.internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Pourcent_Sec_Producteur_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Pourcent_Sec_Producteur_Override {

			get {

				if (this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override);
			}

			set {

				this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Pourcent_Sec_Producteur_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TMA_Producteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TMA_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_TMA_Producteur {

			get {

				if (this.internal_Param_TMA_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TMA_Producteur);
			}

			set {

				this.internal_Param_TMA_Producteur_UseDefaultValue = false;
				this.internal_Param_TMA_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TMA_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TMA_Producteur_UseDefaultValue() {

			this.internal_Param_TMA_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TMA_Producteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_TMA_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TMA_Producteur {

			get {

				if (this.internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TMA_Producteur);
			}

			set {

				this.internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TMA_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TMA_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TMA_Producteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Pourcent_Sec_Transport'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Pourcent_Sec_Transport_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Pourcent_Sec_Transport {

			get {

				if (this.internal_Param_Pourcent_Sec_Transport_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Pourcent_Sec_Transport);
			}

			set {

				this.internal_Param_Pourcent_Sec_Transport_UseDefaultValue = false;
				this.internal_Param_Pourcent_Sec_Transport = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Pourcent_Sec_Transport' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Pourcent_Sec_Transport_UseDefaultValue() {

			this.internal_Param_Pourcent_Sec_Transport_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Pourcent_Sec_Transport'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Pourcent_Sec_Transport {

			get {

				if (this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Pourcent_Sec_Transport);
			}

			set {

				this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Transport = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Pourcent_Sec_Transport' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Pourcent_Sec_Transport_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Pourcent_Sec_Transport_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Pourcent_Sec_Transport_Override {

			get {

				if (this.internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Pourcent_Sec_Transport_Override);
			}

			set {

				this.internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue = false;
				this.internal_Param_Pourcent_Sec_Transport_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Pourcent_Sec_Transport_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Pourcent_Sec_Transport_Override_UseDefaultValue() {

			this.internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Pourcent_Sec_Transport_Override'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Pourcent_Sec_Transport_Override {

			get {

				if (this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override);
			}

			set {

				this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Pourcent_Sec_Transport_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TMA_Transport'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TMA_Transport_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_TMA_Transport {

			get {

				if (this.internal_Param_TMA_Transport_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TMA_Transport);
			}

			set {

				this.internal_Param_TMA_Transport_UseDefaultValue = false;
				this.internal_Param_TMA_Transport = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TMA_Transport' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TMA_Transport_UseDefaultValue() {

			this.internal_Param_TMA_Transport_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TMA_Transport'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_TMA_Transport_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TMA_Transport {

			get {

				if (this.internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TMA_Transport);
			}

			set {

				this.internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TMA_Transport = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TMA_Transport' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TMA_Transport_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IsTMA'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_IsTMA_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IsTMA {

			get {

				if (this.internal_Param_IsTMA_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IsTMA);
			}

			set {

				this.internal_Param_IsTMA_UseDefaultValue = false;
				this.internal_Param_IsTMA = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IsTMA' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IsTMA_UseDefaultValue() {

			this.internal_Param_IsTMA_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_IsTMA'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_IsTMA_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_IsTMA {

			get {

				if (this.internal_Param_ConsiderNull_IsTMA_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_IsTMA);
			}

			set {

				this.internal_Param_ConsiderNull_IsTMA_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_IsTMA = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_IsTMA' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_IsTMA_UseDefaultValue() {

			this.internal_Param_ConsiderNull_IsTMA_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@SuspendrePaiement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_SuspendrePaiement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_SuspendrePaiement {

			get {

				if (this.internal_Param_SuspendrePaiement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_SuspendrePaiement);
			}

			set {

				this.internal_Param_SuspendrePaiement_UseDefaultValue = false;
				this.internal_Param_SuspendrePaiement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@SuspendrePaiement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_SuspendrePaiement_UseDefaultValue() {

			this.internal_Param_SuspendrePaiement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_SuspendrePaiement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_SuspendrePaiement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_SuspendrePaiement {

			get {

				if (this.internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_SuspendrePaiement);
			}

			set {

				this.internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_SuspendrePaiement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_SuspendrePaiement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_SuspendrePaiement_UseDefaultValue() {

			this.internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@BonCommande'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](25)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_BonCommande_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_BonCommande {

			get {

				if (this.internal_Param_BonCommande_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_BonCommande);
			}

			set {

				this.internal_Param_BonCommande_UseDefaultValue = false;
				this.internal_Param_BonCommande = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@BonCommande' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_BonCommande_UseDefaultValue() {

			this.internal_Param_BonCommande_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_BonCommande'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_BonCommande_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_BonCommande {

			get {

				if (this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_BonCommande);
			}

			set {

				this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_BonCommande = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_BonCommande' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_BonCommande_UseDefaultValue() {

			this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spU_Livraison' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spU_Livraison : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spU_Livraison class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spU_Livraison() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Livraison class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spU_Livraison(bool throwExceptionOnExecute) {

			this.throwExceptionOnExecute = throwExceptionOnExecute;
		}

		private System.Data.SqlClient.SqlConnection sqlConnection;
		/// <summary>
		/// The <see cref="System.Data.SqlClient.SqlConnection">System.Data.SqlClient.SqlConnection</see> that was actually used by this class.
		/// </summary>
		public System.Data.SqlClient.SqlConnection Connection {

			get {

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Disposes the current instance of this object.
		/// </summary>
		public void Dispose() {

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
		/// </summary>
		private void Dispose(bool disposing) {

			if (disposing) {

			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~spU_Livraison() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spU_Livraison parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spU_Livraison parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Livraison object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Livraison object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Livraison object before doing this call.");
				}

				switch (parameters.ConnectionType) {

					case ConnectionType.ConnectionString:

						string connectionString;
				
						if (parameters.ConnectionString.Length == 0) {

							connectionString = Information.GetConnectionStringFromConfigurationFile;
							if (connectionString.Length == 0) {

								connectionString = Information.GetConnectionStringFromRegistry;
							}
						}

						else {

							connectionString = parameters.ConnectionString;
						}

						if (connectionString.Length == 0) {

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spU_Livraison)");
						}

						parameters.internal_SetErrorSource(ErrorSource.ConnectionOpening);
						this.sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
						this.sqlConnection.Open();

						sqlCommand = sqlConnection.CreateCommand();
						break;

					case ConnectionType.SqlConnection:

						sqlConnection = parameters.SqlConnection;

						if (this.sqlConnection.State != System.Data.ConnectionState.Open) {

							this.sqlConnection.Open();
						}
						else {

							connectionMustBeClosed = false;
						}
						sqlCommand = sqlConnection.CreateCommand();
						break;

					case ConnectionType.SqlTransaction:

						sqlCommand = new System.Data.SqlClient.SqlCommand();
						this.sqlConnection = parameters.SqlTransaction.Connection;
						if (this.sqlConnection == null) {

							throw new InvalidOperationException("The transaction is no longer valid.");
						}

						if (this.sqlConnection.State != System.Data.ConnectionState.Open) {
						
							this.sqlConnection.Open();
						}
						else {

							connectionMustBeClosed = false;
						}
						sqlCommand.Connection = sqlConnection;
						sqlCommand.Transaction = parameters.SqlTransaction;						break;
				}

				sqlCommand.CommandTimeout = parameters.CommandTimeOut;
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "spU_Livraison";

				return(true);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				sqlConnection = null;
				sqlCommand = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				sqlConnection = null;
				sqlCommand = null;
				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Livraison parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "ID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ID.IsNull) {

					sqlParameter.Value = parameters.Param_ID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateLivraison", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DateLivraison";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateLivraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateLivraison.IsNull) {

					sqlParameter.Value = parameters.Param_DateLivraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DateLivraison", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DateLivraison.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DateLivraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DatePaye", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DatePaye";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DatePaye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DatePaye.IsNull) {

					sqlParameter.Value = parameters.Param_DatePaye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DatePaye", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DatePaye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DatePaye.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DatePaye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContratID", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "ContratID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContratID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContratID.IsNull) {

					sqlParameter.Value = parameters.Param_ContratID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ContratID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ContratID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ContratID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ContratID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteMesureID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "UniteMesureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UniteMesureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UniteMesureID.IsNull) {

					sqlParameter.Value = parameters.Param_UniteMesureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_UniteMesureID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_UniteMesureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_UniteMesureID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_UniteMesureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "EssenceID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EssenceID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EssenceID.IsNull) {

					sqlParameter.Value = parameters.Param_EssenceID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EssenceID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_EssenceID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_EssenceID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_EssenceID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Sciage", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Sciage";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Sciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Sciage.IsNull) {

					sqlParameter.Value = parameters.Param_Sciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Sciage", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Sciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Sciage.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Sciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroFactureUsine", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "NumeroFactureUsine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NumeroFactureUsine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NumeroFactureUsine.IsNull) {

					sqlParameter.Value = parameters.Param_NumeroFactureUsine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NumeroFactureUsine", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_NumeroFactureUsine.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_NumeroFactureUsine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DroitCoupeID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "DroitCoupeID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DroitCoupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DroitCoupeID.IsNull) {

					sqlParameter.Value = parameters.Param_DroitCoupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DroitCoupeID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DroitCoupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DroitCoupeID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DroitCoupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EntentePaiementID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "EntentePaiementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EntentePaiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EntentePaiementID.IsNull) {

					sqlParameter.Value = parameters.Param_EntentePaiementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EntentePaiementID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_EntentePaiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_EntentePaiementID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_EntentePaiementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TransporteurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "TransporteurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TransporteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TransporteurID.IsNull) {

					sqlParameter.Value = parameters.Param_TransporteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TransporteurID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TransporteurID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TransporteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VR", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "VR";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VR_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VR.IsNull) {

					sqlParameter.Value = parameters.Param_VR;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VR", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VR_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VR.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VR;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MasseLimite", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "MasseLimite";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MasseLimite_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MasseLimite.IsNull) {

					sqlParameter.Value = parameters.Param_MasseLimite;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_MasseLimite", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_MasseLimite_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_MasseLimite.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_MasseLimite;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeBrut", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeBrut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeBrut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeBrut.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeBrut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeBrut", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeBrut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeBrut.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeBrut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeTare", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeTare";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeTare_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeTare.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeTare;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeTare", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeTare_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeTare.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeTare;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeTransporte", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeTransporte";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeTransporte_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeTransporte.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeTransporte;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeTransporte", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeTransporte_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeTransporte.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeTransporte;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeSurcharge", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeSurcharge";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeSurcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeSurcharge.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeSurcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeSurcharge", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeSurcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeSurcharge.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeSurcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeAPayer", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeAPayer";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeAPayer_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeAPayer.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeAPayer;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeAPayer", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeAPayer_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeAPayer.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeAPayer;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Annee";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Annee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Annee.IsNull) {

					sqlParameter.Value = parameters.Param_Annee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Annee", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Annee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Annee.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Annee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Periode";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Periode_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Periode.IsNull) {

					sqlParameter.Value = parameters.Param_Periode;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Periode", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Periode_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Periode.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Periode;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateCalcul", System.Data.SqlDbType.DateTime, 16);
				sqlParameter.SourceColumn = "DateCalcul";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateCalcul_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateCalcul.IsNull) {

					sqlParameter.Value = parameters.Param_DateCalcul;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DateCalcul", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DateCalcul_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DateCalcul.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DateCalcul;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Transporteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Transporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Taux_Transporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Taux_Transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Taux_Transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Taux_Transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Transporteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Transporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Transporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Usine", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Usine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Usine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Usine.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Usine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Usine", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Usine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Usine.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Usine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Producteur1", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Producteur1";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Producteur1_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Producteur1.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Producteur1;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Producteur1", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Producteur1_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Producteur1.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Producteur1;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Producteur2", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Producteur2";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Producteur2_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Producteur2.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Producteur2;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Producteur2", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Producteur2_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Producteur2.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Producteur2;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Plan_Conjoint", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Plan_Conjoint";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Plan_Conjoint.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Plan_Conjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Plan_Conjoint", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Preleve_Plan_Conjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Preleve_Plan_Conjoint.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Preleve_Plan_Conjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Roulement", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Fond_Roulement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Fond_Roulement.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Fond_Roulement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Fond_Roulement", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Preleve_Fond_Roulement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Preleve_Fond_Roulement.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Preleve_Fond_Roulement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Forestier", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Fond_Forestier";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Fond_Forestier.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Fond_Forestier;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Fond_Forestier", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Preleve_Fond_Forestier_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Preleve_Fond_Forestier.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Preleve_Fond_Forestier;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Divers", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Divers";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Divers_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Divers.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Divers;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Divers", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Preleve_Divers_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Preleve_Divers.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Preleve_Divers;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Surcharge", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Surcharge";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Surcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Surcharge.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Surcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Surcharge", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Surcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Surcharge.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Surcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_MiseEnCommun", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Montant_MiseEnCommun";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_MiseEnCommun_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_MiseEnCommun.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_MiseEnCommun;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_MiseEnCommun", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_MiseEnCommun_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_MiseEnCommun.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_MiseEnCommun;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Facture", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Facture";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Facture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Facture.IsNull) {

					sqlParameter.Value = parameters.Param_Facture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Facture", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Facture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Facture.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Facture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur1_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Producteur1_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Producteur1_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Producteur1_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Producteur1_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Producteur1_FactureID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Producteur1_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Producteur1_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Producteur1_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur2_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Producteur2_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Producteur2_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Producteur2_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Producteur2_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Producteur2_FactureID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Producteur2_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Producteur2_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Producteur2_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Transporteur_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Transporteur_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Transporteur_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Transporteur_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Transporteur_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Transporteur_FactureID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Transporteur_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Transporteur_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Transporteur_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Usine_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Usine_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Usine_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Usine_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Usine_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Usine_FactureID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Usine_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Usine_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Usine_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ErreurCalcul", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "ErreurCalcul";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ErreurCalcul_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ErreurCalcul.IsNull) {

					sqlParameter.Value = parameters.Param_ErreurCalcul;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ErreurCalcul", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ErreurCalcul_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ErreurCalcul.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ErreurCalcul;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ErreurDescription", System.Data.SqlDbType.VarChar, 4000);
				sqlParameter.SourceColumn = "ErreurDescription";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ErreurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ErreurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_ErreurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ErreurDescription", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ErreurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ErreurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ErreurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "LotID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LotID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LotID.IsNull) {

					sqlParameter.Value = parameters.Param_LotID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_LotID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_LotID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_LotID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_LotID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Transporteur_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Taux_Transporteur_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Transporteur_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Transporteur_Override.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Transporteur_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Taux_Transporteur_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Taux_Transporteur_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Taux_Transporteur_Override.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Taux_Transporteur_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PaieTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "PaieTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PaieTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PaieTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_PaieTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PaieTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_PaieTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_PaieTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_PaieTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeSurcharge_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "VolumeSurcharge_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeSurcharge_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeSurcharge_Override.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeSurcharge_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeSurcharge_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeSurcharge_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeSurcharge_Override.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeSurcharge_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@SurchargeManuel", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "SurchargeManuel";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_SurchargeManuel_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_SurchargeManuel.IsNull) {

					sqlParameter.Value = parameters.Param_SurchargeManuel;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_SurchargeManuel", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_SurchargeManuel_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_SurchargeManuel.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_SurchargeManuel;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Char, 4);
				sqlParameter.SourceColumn = "Code";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Code_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Code.IsNull) {

					sqlParameter.Value = parameters.Param_Code;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Code", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Code_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Code.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Code;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NombrePermis", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "NombrePermis";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NombrePermis_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NombrePermis.IsNull) {

					sqlParameter.Value = parameters.Param_NombrePermis;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NombrePermis", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_NombrePermis_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_NombrePermis.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_NombrePermis;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ZoneID", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.SourceColumn = "ZoneID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ZoneID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ZoneID.IsNull) {

					sqlParameter.Value = parameters.Param_ZoneID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ZoneID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ZoneID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ZoneID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ZoneID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "MunicipaliteID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MunicipaliteID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MunicipaliteID.IsNull) {

					sqlParameter.Value = parameters.Param_MunicipaliteID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_MunicipaliteID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_MunicipaliteID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_MunicipaliteID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ChargeurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ChargeurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ChargeurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ChargeurID.IsNull) {

					sqlParameter.Value = parameters.Param_ChargeurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ChargeurID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ChargeurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ChargeurID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ChargeurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Chargeur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Chargeur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Chargeur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Chargeur.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Chargeur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Chargeur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_Chargeur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_Chargeur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_Chargeur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_ChargeurAuProducteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_ChargeurAuProducteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_ChargeurAuProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_ChargeurAuProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_ChargeurAuProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_ChargeurAuProducteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_ChargeurAuProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_ChargeurAuProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_ChargeurAuProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_ChargeurAuTransporteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_ChargeurAuTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_ChargeurAuTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_ChargeurAuTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_ChargeurAuTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_ChargeurAuTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_ChargeurAuTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_ChargeurAuTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_ChargeurAuTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_AutresAuProducteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresAuProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresAuProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresAuProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuProducteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresAuProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresAuProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresAuProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteurDescription", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Frais_AutresAuProducteurDescription";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresAuProducteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresAuProducteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresAuProducteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuProducteurDescription", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresAuProducteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresAuProducteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresAuProducteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteurTransportSciage", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_AutresAuProducteurTransportSciage";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresAuProducteurTransportSciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresAuProducteurTransportSciage.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresAuProducteurTransportSciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuProducteurTransportSciage", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuTransporteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_AutresAuTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresAuTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresAuTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresAuTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresAuTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresAuTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresAuTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuTransporteurDescription", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Frais_AutresAuTransporteurDescription";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresAuTransporteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresAuTransporteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresAuTransporteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuTransporteurDescription", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresAuTransporteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresAuTransporteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresAuTransporteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_CompensationDeDeplacement", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_CompensationDeDeplacement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_CompensationDeDeplacement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_CompensationDeDeplacement.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_CompensationDeDeplacement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_CompensationDeDeplacement", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_CompensationDeDeplacement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_CompensationDeDeplacement.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_CompensationDeDeplacement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Chargeur_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Chargeur_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Chargeur_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Chargeur_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Chargeur_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Chargeur_FactureID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Chargeur_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Chargeur_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Chargeur_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Producteur", System.Data.SqlDbType.VarChar, 500);
				sqlParameter.SourceColumn = "Commentaires_Producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Commentaires_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Commentaires_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_Commentaires_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires_Producteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Commentaires_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Commentaires_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Commentaires_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Transporteur", System.Data.SqlDbType.VarChar, 500);
				sqlParameter.SourceColumn = "Commentaires_Transporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Commentaires_Transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Commentaires_Transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Commentaires_Transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires_Transporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Commentaires_Transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Commentaires_Transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Commentaires_Transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Chargeur", System.Data.SqlDbType.VarChar, 500);
				sqlParameter.SourceColumn = "Commentaires_Chargeur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Commentaires_Chargeur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Commentaires_Chargeur.IsNull) {

					sqlParameter.Value = parameters.Param_Commentaires_Chargeur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires_Chargeur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Commentaires_Chargeur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Commentaires_Chargeur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Commentaires_Chargeur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TauxChargeurAuProducteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "TauxChargeurAuProducteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TauxChargeurAuProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TauxChargeurAuProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_TauxChargeurAuProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TauxChargeurAuProducteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TauxChargeurAuProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TauxChargeurAuProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TauxChargeurAuProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TauxChargeurAuTransporteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "TauxChargeurAuTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TauxChargeurAuTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TauxChargeurAuTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_TauxChargeurAuTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TauxChargeurAuTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TauxChargeurAuTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TauxChargeurAuTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TauxChargeurAuTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusTransporteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_AutresRevenusTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresRevenusTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresRevenusTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresRevenusTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresRevenusTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresRevenusTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusTransporteurDescription", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Frais_AutresRevenusTransporteurDescription";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresRevenusTransporteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresRevenusTransporteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresRevenusTransporteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusTransporteurDescription", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusProducteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Frais_AutresRevenusProducteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresRevenusProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresRevenusProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresRevenusProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusProducteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresRevenusProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresRevenusProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresRevenusProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusProducteurDescription", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Frais_AutresRevenusProducteurDescription";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Frais_AutresRevenusProducteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Frais_AutresRevenusProducteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_Frais_AutresRevenusProducteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusProducteurDescription", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Frais_AutresRevenusProducteurDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Frais_AutresRevenusProducteurDescription.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Frais_AutresRevenusProducteurDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_SurchargeProducteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_SurchargeProducteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_SurchargeProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_SurchargeProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_SurchargeProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_SurchargeProducteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Montant_SurchargeProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Montant_SurchargeProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Montant_SurchargeProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Brut", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgVert_Brut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgVert_Brut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgVert_Brut.IsNull) {

					sqlParameter.Value = parameters.Param_KgVert_Brut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Brut", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgVert_Brut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgVert_Brut.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgVert_Brut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Tare", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgVert_Tare";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgVert_Tare_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgVert_Tare.IsNull) {

					sqlParameter.Value = parameters.Param_KgVert_Tare;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Tare", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgVert_Tare_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgVert_Tare.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgVert_Tare;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Net", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgVert_Net";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgVert_Net_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgVert_Net.IsNull) {

					sqlParameter.Value = parameters.Param_KgVert_Net;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Net", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgVert_Net_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgVert_Net.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgVert_Net;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Rejets", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgVert_Rejets";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgVert_Rejets_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgVert_Rejets.IsNull) {

					sqlParameter.Value = parameters.Param_KgVert_Rejets;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Rejets", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgVert_Rejets_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgVert_Rejets.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgVert_Rejets;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Paye", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgVert_Paye";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgVert_Paye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgVert_Paye.IsNull) {

					sqlParameter.Value = parameters.Param_KgVert_Paye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Paye", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgVert_Paye.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgVert_Paye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Producteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Pourcent_Sec_Producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Pourcent_Sec_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Pourcent_Sec_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_Pourcent_Sec_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Producteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Pourcent_Sec_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Pourcent_Sec_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Producteur_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Pourcent_Sec_Producteur_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Pourcent_Sec_Producteur_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Pourcent_Sec_Producteur_Override.IsNull) {

					sqlParameter.Value = parameters.Param_Pourcent_Sec_Producteur_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Producteur_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Pourcent_Sec_Producteur_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Pourcent_Sec_Producteur_Override.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Pourcent_Sec_Producteur_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TMA_Producteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "TMA_Producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TMA_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TMA_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_TMA_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TMA_Producteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TMA_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TMA_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TMA_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Transport", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Pourcent_Sec_Transport";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Pourcent_Sec_Transport_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Pourcent_Sec_Transport.IsNull) {

					sqlParameter.Value = parameters.Param_Pourcent_Sec_Transport;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Transport", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Pourcent_Sec_Transport_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Pourcent_Sec_Transport.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Pourcent_Sec_Transport;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Transport_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Pourcent_Sec_Transport_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Pourcent_Sec_Transport_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Pourcent_Sec_Transport_Override.IsNull) {

					sqlParameter.Value = parameters.Param_Pourcent_Sec_Transport_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Transport_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Pourcent_Sec_Transport_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Pourcent_Sec_Transport_Override.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Pourcent_Sec_Transport_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TMA_Transport", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "TMA_Transport";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TMA_Transport_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TMA_Transport.IsNull) {

					sqlParameter.Value = parameters.Param_TMA_Transport;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TMA_Transport", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TMA_Transport_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TMA_Transport.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TMA_Transport;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IsTMA", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IsTMA";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IsTMA_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IsTMA.IsNull) {

					sqlParameter.Value = parameters.Param_IsTMA;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsTMA", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_IsTMA_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_IsTMA.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_IsTMA;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@SuspendrePaiement", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "SuspendrePaiement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_SuspendrePaiement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_SuspendrePaiement.IsNull) {

					sqlParameter.Value = parameters.Param_SuspendrePaiement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_SuspendrePaiement", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_SuspendrePaiement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_SuspendrePaiement.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_SuspendrePaiement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@BonCommande", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "BonCommande";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_BonCommande_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_BonCommande.IsNull) {

					sqlParameter.Value = parameters.Param_BonCommande;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_BonCommande", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_BonCommande_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_BonCommande.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_BonCommande;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);


				return(true);

			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Livraison parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				if (sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

					parameters.internal_Set_RETURN_VALUE ((System.Int32)sqlCommand.Parameters["@RETURN_VALUE"].Value);
				}
				else {

					parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
				}

				return(true);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		/// <summary>
		/// This method allows you to execute the [spU_Livraison] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spU_Livraison parameters) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {
				ResetParameter(ref parameters);

				parameters.internal_SetErrorSource(ErrorSource.ConnectionInitialization);
				returnStatus = InitializeConnection(ref parameters, out sqlCommand, ref connectionMustBeClosed);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.ParametersSetting);
				returnStatus = DeclareParameters(ref parameters, ref sqlCommand);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.QueryExecution);
				sqlCommand.ExecuteNonQuery();
                
				parameters.internal_SetErrorSource(ErrorSource.ParametersRetrieval);
				returnStatus = RetrieveParameters(ref parameters, ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				returnStatus = false;
				parameters.internal_SetErrorSource(ErrorSource.Other);

				if (this.throwExceptionOnExecute) {

					throw exception;
				}
			}

			finally {

				if (sqlCommand != null) {

					sqlCommand.Dispose();
				}

				if (parameters.SqlTransaction == null) {

					if (this.sqlConnection != null && connectionMustBeClosed && this.sqlConnection.State == System.Data.ConnectionState.Open) {

						this.sqlConnection.Close();
						this.sqlConnection.Dispose();
					}
				}

				if (returnStatus) {

					parameters.internal_SetErrorSource(ErrorSource.NoError);
				}
				else {

					if (this.throwExceptionOnExecute) {

						if (parameters.SqlException != null) {

							throw parameters.SqlException;
						}
						else {

							throw parameters.OtherException;
						}
					}
				}
			}
			return(returnStatus);
       
		}

	}

}

