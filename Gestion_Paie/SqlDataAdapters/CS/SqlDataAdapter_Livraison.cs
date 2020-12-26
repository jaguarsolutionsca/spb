using System;

namespace Gestion_Paie.SqlDataAdapters {

	/// <summary>
	/// This class represents a full operational System.Data.SqlClient.SqlDataAdapter that can be
	/// used against the [Livraison] table. The four basics operations are supported: Insert, Update, Delete and Select.
	/// </summary>
	public sealed class SqlDataAdapter_Livraison {

		private string connectionString;
		private System.Data.SqlClient.SqlConnection sqlConnection;
		private System.Data.SqlClient.SqlTransaction sqlTransaction;
		private bool CloseConnectionAfterUse = true;
		private Gestion_Paie.DataClasses.ConnectionType lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.None;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter;
		private bool hasBeenConfigured = false;

		/// <summary>
		/// Returns the current type of connection that is going or has been used
		/// against the Sql Server database. It can be: ConnectionString, SqlConnection
		/// or SqlTransaction
		/// </summary>
		public Gestion_Paie.DataClasses.ConnectionType ConnectionType {

			get {

				return(this.lastKnownConnectionType);
			}
		}

		/// <summary>
		/// Returns the connection string used to access the Sql Server database.
		/// </summary>
		public string ConnectionString {

			get {

				if (this.lastKnownConnectionType != Gestion_Paie.DataClasses.ConnectionType.ConnectionString) {

					throw new InvalidOperationException("The connection string was not set in the class constructor.");
				}

				return(this.connectionString);
			}
		}

		/// <summary>
		/// Returns the SqlConnection used to access the Sql Server database.
		/// </summary>
		public System.Data.SqlClient.SqlConnection SqlConnection {

			get {

				if (this.lastKnownConnectionType != Gestion_Paie.DataClasses.ConnectionType.SqlConnection) {

					throw new InvalidOperationException("The SqlConnection was not set in the class constructor.");
				}

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Returns the SqlTransaction used to access the Sql Server database.
		/// </summary>
		public System.Data.SqlClient.SqlTransaction SqlTransaction{

			get {

				if (this.lastKnownConnectionType != Gestion_Paie.DataClasses.ConnectionType.SqlTransaction) {

					throw new InvalidOperationException("The SqlTransaction was not set in the class constructor.");
				}

				return(this.sqlTransaction);
			}
		}

		/// <summary>
		/// Returns the underlying System.Data.SqlClient.SqlDataAdapter object.
		/// </summary>
		public System.Data.SqlClient.SqlDataAdapter SqlDataAdapter {

			get {

				return(this.sqlDataAdapter);
			}
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Livraison class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public SqlDataAdapter_Livraison(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

			this.connectionString = connectionString;
			this.lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.ConnectionString;

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
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Livraison class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public SqlDataAdapter_Livraison(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

			this.sqlConnection = sqlConnection;
			this.lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.SqlConnection;

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
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Livraison class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public SqlDataAdapter_Livraison(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {

				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

			this.sqlTransaction = sqlTransaction;
			this.lastKnownConnectionType = Gestion_Paie.DataClasses.ConnectionType.SqlTransaction;

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
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Livraison class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Livraison(string connectionString, System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID, string tableName) : this(connectionString) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Livraison class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Livraison(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID, string tableName) : this(sqlConnection) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Livraison class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Livraison(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID, string tableName) : this(sqlTransaction) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Livraison class.
		/// The table name in the DataSet will be: Livraison
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		public SqlDataAdapter_Livraison(string connectionString, System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID) : this(connectionString) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, "Livraison");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Livraison class.
		/// The table name in the DataSet will be: Livraison
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		public SqlDataAdapter_Livraison(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID) : this(sqlConnection) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, "Livraison");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Livraison class.
		/// The table name in the DataSet will be: Livraison
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		public SqlDataAdapter_Livraison(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID) : this(sqlTransaction) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, "Livraison");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// The table name in the DataSet will be: Livraison
		/// </summary>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		public void Configure(System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID) {

			this.Configure(FK_ID, FK_ContratID, FK_UniteMesureID, FK_EssenceID, FK_DroitCoupeID, FK_EntentePaiementID, FK_TransporteurID, FK_Annee, FK_Periode, FK_Producteur1_FactureID, FK_Producteur2_FactureID, FK_Transporteur_FactureID, FK_Usine_FactureID, FK_LotID, FK_ZoneID, FK_MunicipaliteID, FK_ChargeurID, FK_Chargeur_FactureID, "Livraison");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// </summary>
		/// <param name="FK_ID">Value for this foreign key.</param>
		/// <param name="FK_ContratID">Value for this foreign key.</param>
		/// <param name="FK_UniteMesureID">Value for this foreign key.</param>
		/// <param name="FK_EssenceID">Value for this foreign key.</param>
		/// <param name="FK_DroitCoupeID">Value for this foreign key.</param>
		/// <param name="FK_EntentePaiementID">Value for this foreign key.</param>
		/// <param name="FK_TransporteurID">Value for this foreign key.</param>
		/// <param name="FK_Annee">Value for this foreign key.</param>
		/// <param name="FK_Periode">Value for this foreign key.</param>
		/// <param name="FK_Producteur1_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Producteur2_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Transporteur_FactureID">Value for this foreign key.</param>
		/// <param name="FK_Usine_FactureID">Value for this foreign key.</param>
		/// <param name="FK_LotID">Value for this foreign key.</param>
		/// <param name="FK_ZoneID">Value for this foreign key.</param>
		/// <param name="FK_MunicipaliteID">Value for this foreign key.</param>
		/// <param name="FK_ChargeurID">Value for this foreign key.</param>
		/// <param name="FK_Chargeur_FactureID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public void Configure(System.Data.SqlTypes.SqlInt32 FK_ID, System.Data.SqlTypes.SqlString FK_ContratID, System.Data.SqlTypes.SqlString FK_UniteMesureID, System.Data.SqlTypes.SqlString FK_EssenceID, System.Data.SqlTypes.SqlString FK_DroitCoupeID, System.Data.SqlTypes.SqlString FK_EntentePaiementID, System.Data.SqlTypes.SqlString FK_TransporteurID, System.Data.SqlTypes.SqlInt32 FK_Annee, System.Data.SqlTypes.SqlInt32 FK_Periode, System.Data.SqlTypes.SqlInt32 FK_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 FK_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 FK_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 FK_Usine_FactureID, System.Data.SqlTypes.SqlInt32 FK_LotID, System.Data.SqlTypes.SqlString FK_ZoneID, System.Data.SqlTypes.SqlString FK_MunicipaliteID, System.Data.SqlTypes.SqlString FK_ChargeurID, System.Data.SqlTypes.SqlInt32 FK_Chargeur_FactureID, string tableName) {

			this.hasBeenConfigured = true;

			this.sqlDataAdapter = null;

			System.Data.SqlClient.SqlCommand sqlSelectCommand;
			System.Data.SqlClient.SqlCommand sqlInsertCommand;
			System.Data.SqlClient.SqlCommand sqlUpdateCommand;
			System.Data.SqlClient.SqlCommand sqlDeleteCommand;
			System.Data.SqlClient.SqlParameter sqlParameter;
			
			sqlSelectCommand = new System.Data.SqlClient.SqlCommand();
			sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
			sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
			sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();

			System.Data.SqlClient.SqlConnection localSqlConnection = null;
			switch (this.lastKnownConnectionType) {

				case Gestion_Paie.DataClasses.ConnectionType.ConnectionString:

					string connectionString = this.ConnectionString;
				
					if (connectionString.Length == 0) {

						connectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
						if (connectionString.Length == 0) {

							connectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
						}
					}

					if (connectionString.Length == 0) {

						throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.SqlDataAdapters.SqlDataAdapter_Livraison)");
					}

					localSqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);

					sqlSelectCommand.Connection = localSqlConnection;
					sqlInsertCommand.Connection = localSqlConnection;
					sqlUpdateCommand.Connection = localSqlConnection;
					sqlDeleteCommand.Connection = localSqlConnection;

					break;

				case Gestion_Paie.DataClasses.ConnectionType.SqlConnection:

					localSqlConnection = this.SqlConnection;

					sqlSelectCommand.Connection = localSqlConnection;
					sqlInsertCommand.Connection = localSqlConnection;
					sqlUpdateCommand.Connection = localSqlConnection;
					sqlDeleteCommand.Connection = localSqlConnection;

					break;

				case Gestion_Paie.DataClasses.ConnectionType.SqlTransaction:

					sqlSelectCommand.Connection = this.sqlTransaction.Connection;
					sqlSelectCommand.Transaction = this.sqlTransaction;

					sqlInsertCommand.Connection = this.sqlTransaction.Connection;
					sqlInsertCommand.Transaction = this.sqlTransaction;

					sqlUpdateCommand.Connection = this.sqlTransaction.Connection;
					sqlUpdateCommand.Transaction = this.sqlTransaction;

					sqlDeleteCommand.Connection = this.sqlTransaction.Connection;
					sqlDeleteCommand.Transaction = this.sqlTransaction;

					break;
			}

			sqlSelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlSelectCommand.CommandText = "spS_Livraison";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_ID.IsNull) {

				sqlParameter.Value = FK_ID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ContratID", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "ContratID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_ContratID.IsNull) {

				sqlParameter.Value = FK_ContratID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteMesureID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "UniteMesureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_UniteMesureID.IsNull) {

				sqlParameter.Value = FK_UniteMesureID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "EssenceID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_EssenceID.IsNull) {

				sqlParameter.Value = FK_EssenceID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DroitCoupeID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "DroitCoupeID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_DroitCoupeID.IsNull) {

				sqlParameter.Value = FK_DroitCoupeID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EntentePaiementID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "EntentePaiementID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_EntentePaiementID.IsNull) {

				sqlParameter.Value = FK_EntentePaiementID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TransporteurID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "TransporteurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_TransporteurID.IsNull) {

				sqlParameter.Value = FK_TransporteurID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Annee";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Annee.IsNull) {

				sqlParameter.Value = FK_Annee;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Periode";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Periode.IsNull) {

				sqlParameter.Value = FK_Periode;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur1_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Producteur1_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Producteur1_FactureID.IsNull) {

				sqlParameter.Value = FK_Producteur1_FactureID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur2_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Producteur2_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Producteur2_FactureID.IsNull) {

				sqlParameter.Value = FK_Producteur2_FactureID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Transporteur_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Transporteur_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Transporteur_FactureID.IsNull) {

				sqlParameter.Value = FK_Transporteur_FactureID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Usine_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Usine_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Usine_FactureID.IsNull) {

				sqlParameter.Value = FK_Usine_FactureID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "LotID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_LotID.IsNull) {

				sqlParameter.Value = FK_LotID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ZoneID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ZoneID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_ZoneID.IsNull) {

				sqlParameter.Value = FK_ZoneID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_MunicipaliteID.IsNull) {

				sqlParameter.Value = FK_MunicipaliteID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ChargeurID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ChargeurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_ChargeurID.IsNull) {

				sqlParameter.Value = FK_ChargeurID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Chargeur_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Chargeur_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Chargeur_FactureID.IsNull) {

				sqlParameter.Value = FK_Chargeur_FactureID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ReturnXML", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = false;
			sqlSelectCommand.Parameters.Add(sqlParameter);


			sqlInsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlInsertCommand.CommandText = "spI_Livraison";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DateLivraison", System.Data.SqlDbType.SmallDateTime, 16);
			sqlParameter.SourceColumn = "DateLivraison";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DatePaye", System.Data.SqlDbType.SmallDateTime, 16);
			sqlParameter.SourceColumn = "DatePaye";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ContratID", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "ContratID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteMesureID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "UniteMesureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "EssenceID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Sciage", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Sciage";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroFactureUsine", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "NumeroFactureUsine";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DroitCoupeID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "DroitCoupeID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EntentePaiementID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "EntentePaiementID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TransporteurID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "TransporteurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VR", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "VR";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MasseLimite", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "MasseLimite";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeBrut", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeBrut";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeTare", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeTare";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeTransporte", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeTransporte";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeSurcharge", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeSurcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeAPayer", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeAPayer";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Annee";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Periode";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DateCalcul", System.Data.SqlDbType.DateTime, 16);
			sqlParameter.SourceColumn = "DateCalcul";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Transporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Taux_Transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Transporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Usine", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Usine";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Producteur1", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Producteur1";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Producteur2", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Producteur2";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Plan_Conjoint", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Plan_Conjoint";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Roulement", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Fond_Roulement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Forestier", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Fond_Forestier";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Divers", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Divers";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Surcharge", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Surcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_MiseEnCommun", System.Data.SqlDbType.Real, 4);
			sqlParameter.SourceColumn = "Montant_MiseEnCommun";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Facture", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Facture";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur1_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Producteur1_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur2_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Producteur2_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Transporteur_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Transporteur_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Usine_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Usine_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ErreurCalcul", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "ErreurCalcul";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ErreurDescription", System.Data.SqlDbType.VarChar, 4000);
			sqlParameter.SourceColumn = "ErreurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "LotID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Transporteur_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Taux_Transporteur_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaieTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PaieTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeSurcharge_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "VolumeSurcharge_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@SurchargeManuel", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "SurchargeManuel";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Char, 4);
			sqlParameter.SourceColumn = "Code";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NombrePermis", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "NombrePermis";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ZoneID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ZoneID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ChargeurID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ChargeurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Chargeur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Chargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_ChargeurAuProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_ChargeurAuProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_ChargeurAuTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_ChargeurAuTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresAuProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresAuProducteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteurTransportSciage", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresAuProducteurTransportSciage";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresAuTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuTransporteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresAuTransporteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_CompensationDeDeplacement", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_CompensationDeDeplacement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Chargeur_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Chargeur_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Producteur", System.Data.SqlDbType.VarChar, 500);
			sqlParameter.SourceColumn = "Commentaires_Producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Transporteur", System.Data.SqlDbType.VarChar, 500);
			sqlParameter.SourceColumn = "Commentaires_Transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Chargeur", System.Data.SqlDbType.VarChar, 500);
			sqlParameter.SourceColumn = "Commentaires_Chargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TauxChargeurAuProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TauxChargeurAuProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TauxChargeurAuTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TauxChargeurAuTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresRevenusTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusTransporteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresRevenusTransporteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresRevenusProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusProducteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresRevenusProducteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_SurchargeProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_SurchargeProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Brut", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Brut";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Tare", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Tare";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Net", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Net";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Rejets", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Rejets";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Paye", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Paye";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Producteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Pourcent_Sec_Producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Producteur_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Pourcent_Sec_Producteur_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TMA_Producteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TMA_Producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Transport", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Pourcent_Sec_Transport";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Transport_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Pourcent_Sec_Transport_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TMA_Transport", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TMA_Transport";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsTMA", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsTMA";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@SuspendrePaiement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "SuspendrePaiement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@BonCommande", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "BonCommande";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);


			sqlUpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlUpdateCommand.CommandText = "spU_Livraison";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DateLivraison", System.Data.SqlDbType.SmallDateTime, 16);
			sqlParameter.SourceColumn = "DateLivraison";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DateLivraison", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DatePaye", System.Data.SqlDbType.SmallDateTime, 16);
			sqlParameter.SourceColumn = "DatePaye";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DatePaye", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ContratID", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "ContratID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ContratID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteMesureID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "UniteMesureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_UniteMesureID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "EssenceID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EssenceID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Sciage", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Sciage";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Sciage", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroFactureUsine", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "NumeroFactureUsine";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NumeroFactureUsine", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DroitCoupeID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "DroitCoupeID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DroitCoupeID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@EntentePaiementID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "EntentePaiementID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EntentePaiementID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TransporteurID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "TransporteurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TransporteurID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VR", System.Data.SqlDbType.VarChar, 10);
			sqlParameter.SourceColumn = "VR";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VR", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MasseLimite", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "MasseLimite";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_MasseLimite", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeBrut", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeBrut";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeBrut", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeTare", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeTare";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeTare", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeTransporte", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeTransporte";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeTransporte", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeSurcharge", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeSurcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeSurcharge", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeAPayer", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "VolumeAPayer";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeAPayer", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Annee";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Annee", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Periode";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Periode", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@DateCalcul", System.Data.SqlDbType.DateTime, 16);
			sqlParameter.SourceColumn = "DateCalcul";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DateCalcul", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Transporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Taux_Transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Taux_Transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Transporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Usine", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Usine";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Usine", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Producteur1", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Producteur1";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Producteur1", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Producteur2", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Producteur2";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Producteur2", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Plan_Conjoint", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Plan_Conjoint";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Plan_Conjoint", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Roulement", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Fond_Roulement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Fond_Roulement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Forestier", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Fond_Forestier";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Fond_Forestier", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Divers", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Preleve_Divers";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Preleve_Divers", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Surcharge", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Surcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Surcharge", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_MiseEnCommun", System.Data.SqlDbType.Real, 4);
			sqlParameter.SourceColumn = "Montant_MiseEnCommun";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_MiseEnCommun", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Facture", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Facture";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Facture", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur1_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Producteur1_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Producteur1_FactureID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur2_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Producteur2_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Producteur2_FactureID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Transporteur_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Transporteur_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Transporteur_FactureID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Usine_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Usine_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Usine_FactureID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ErreurCalcul", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "ErreurCalcul";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ErreurCalcul", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ErreurDescription", System.Data.SqlDbType.VarChar, 4000);
			sqlParameter.SourceColumn = "ErreurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ErreurDescription", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "LotID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_LotID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Transporteur_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Taux_Transporteur_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Taux_Transporteur_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaieTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "PaieTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PaieTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeSurcharge_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "VolumeSurcharge_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeSurcharge_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@SurchargeManuel", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "SurchargeManuel";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_SurchargeManuel", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Char, 4);
			sqlParameter.SourceColumn = "Code";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Code", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NombrePermis", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "NombrePermis";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NombrePermis", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ZoneID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "ZoneID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ZoneID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "MunicipaliteID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_MunicipaliteID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ChargeurID", System.Data.SqlDbType.VarChar, 15);
			sqlParameter.SourceColumn = "ChargeurID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ChargeurID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Chargeur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_Chargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_Chargeur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_ChargeurAuProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_ChargeurAuProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_ChargeurAuProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_ChargeurAuTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_ChargeurAuTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_ChargeurAuTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresAuProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresAuProducteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuProducteurDescription", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuProducteurTransportSciage", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresAuProducteurTransportSciage";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuProducteurTransportSciage", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresAuTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresAuTransporteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresAuTransporteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresAuTransporteurDescription", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_CompensationDeDeplacement", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_CompensationDeDeplacement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_CompensationDeDeplacement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Chargeur_FactureID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Chargeur_FactureID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Chargeur_FactureID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Producteur", System.Data.SqlDbType.VarChar, 500);
			sqlParameter.SourceColumn = "Commentaires_Producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires_Producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Transporteur", System.Data.SqlDbType.VarChar, 500);
			sqlParameter.SourceColumn = "Commentaires_Transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires_Transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires_Chargeur", System.Data.SqlDbType.VarChar, 500);
			sqlParameter.SourceColumn = "Commentaires_Chargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Commentaires_Chargeur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TauxChargeurAuProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TauxChargeurAuProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TauxChargeurAuProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TauxChargeurAuTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TauxChargeurAuTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TauxChargeurAuTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusTransporteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresRevenusTransporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusTransporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusTransporteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresRevenusTransporteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusTransporteurDescription", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Frais_AutresRevenusProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Frais_AutresRevenusProducteurDescription", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Frais_AutresRevenusProducteurDescription";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Frais_AutresRevenusProducteurDescription", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_SurchargeProducteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Montant_SurchargeProducteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Montant_SurchargeProducteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Brut", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Brut";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Brut", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Tare", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Tare";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Tare", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Net", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Net";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Net", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Rejets", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Rejets";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Rejets", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Paye", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "KgVert_Paye";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Paye", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Producteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Pourcent_Sec_Producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Producteur_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Pourcent_Sec_Producteur_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Producteur_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TMA_Producteur", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TMA_Producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TMA_Producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Transport", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "Pourcent_Sec_Transport";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Transport", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec_Transport_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Pourcent_Sec_Transport_Override";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec_Transport_Override", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@TMA_Transport", System.Data.SqlDbType.Float, 8);
			sqlParameter.SourceColumn = "TMA_Transport";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TMA_Transport", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@IsTMA", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "IsTMA";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IsTMA", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@SuspendrePaiement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "SuspendrePaiement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_SuspendrePaiement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@BonCommande", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "BonCommande";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_BonCommande", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);


			sqlDeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlDeleteCommand.CommandText = "spD_Livraison";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);


			// Let's create the SqlDataAdapter
			this.sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();

			this.sqlDataAdapter.SelectCommand = sqlSelectCommand;
			this.sqlDataAdapter.InsertCommand = sqlInsertCommand;
			this.sqlDataAdapter.UpdateCommand = sqlUpdateCommand;
			this.sqlDataAdapter.DeleteCommand = sqlDeleteCommand;

			this.sqlDataAdapter.TableMappings.AddRange (

				new System.Data.Common.DataTableMapping[] {

					new System.Data.Common.DataTableMapping (
						 "Livraison"
						,tableName
						,new System.Data.Common.DataColumnMapping[] {
							 new System.Data.Common.DataColumnMapping("ID", "ID")
							,new System.Data.Common.DataColumnMapping("DateLivraison", "DateLivraison")
							,new System.Data.Common.DataColumnMapping("DatePaye", "DatePaye")
							,new System.Data.Common.DataColumnMapping("ContratID", "ContratID")
							,new System.Data.Common.DataColumnMapping("UniteMesureID", "UniteMesureID")
							,new System.Data.Common.DataColumnMapping("EssenceID", "EssenceID")
							,new System.Data.Common.DataColumnMapping("Sciage", "Sciage")
							,new System.Data.Common.DataColumnMapping("NumeroFactureUsine", "NumeroFactureUsine")
							,new System.Data.Common.DataColumnMapping("DroitCoupeID", "DroitCoupeID")
							,new System.Data.Common.DataColumnMapping("EntentePaiementID", "EntentePaiementID")
							,new System.Data.Common.DataColumnMapping("TransporteurID", "TransporteurID")
							,new System.Data.Common.DataColumnMapping("VR", "VR")
							,new System.Data.Common.DataColumnMapping("MasseLimite", "MasseLimite")
							,new System.Data.Common.DataColumnMapping("VolumeBrut", "VolumeBrut")
							,new System.Data.Common.DataColumnMapping("VolumeTare", "VolumeTare")
							,new System.Data.Common.DataColumnMapping("VolumeTransporte", "VolumeTransporte")
							,new System.Data.Common.DataColumnMapping("VolumeSurcharge", "VolumeSurcharge")
							,new System.Data.Common.DataColumnMapping("VolumeAPayer", "VolumeAPayer")
							,new System.Data.Common.DataColumnMapping("Annee", "Annee")
							,new System.Data.Common.DataColumnMapping("Periode", "Periode")
							,new System.Data.Common.DataColumnMapping("DateCalcul", "DateCalcul")
							,new System.Data.Common.DataColumnMapping("Taux_Transporteur", "Taux_Transporteur")
							,new System.Data.Common.DataColumnMapping("Montant_Transporteur", "Montant_Transporteur")
							,new System.Data.Common.DataColumnMapping("Montant_Usine", "Montant_Usine")
							,new System.Data.Common.DataColumnMapping("Montant_Producteur1", "Montant_Producteur1")
							,new System.Data.Common.DataColumnMapping("Montant_Producteur2", "Montant_Producteur2")
							,new System.Data.Common.DataColumnMapping("Montant_Preleve_Plan_Conjoint", "Montant_Preleve_Plan_Conjoint")
							,new System.Data.Common.DataColumnMapping("Montant_Preleve_Fond_Roulement", "Montant_Preleve_Fond_Roulement")
							,new System.Data.Common.DataColumnMapping("Montant_Preleve_Fond_Forestier", "Montant_Preleve_Fond_Forestier")
							,new System.Data.Common.DataColumnMapping("Montant_Preleve_Divers", "Montant_Preleve_Divers")
							,new System.Data.Common.DataColumnMapping("Montant_Surcharge", "Montant_Surcharge")
							,new System.Data.Common.DataColumnMapping("Montant_MiseEnCommun", "Montant_MiseEnCommun")
							,new System.Data.Common.DataColumnMapping("Facture", "Facture")
							,new System.Data.Common.DataColumnMapping("Producteur1_FactureID", "Producteur1_FactureID")
							,new System.Data.Common.DataColumnMapping("Producteur2_FactureID", "Producteur2_FactureID")
							,new System.Data.Common.DataColumnMapping("Transporteur_FactureID", "Transporteur_FactureID")
							,new System.Data.Common.DataColumnMapping("Usine_FactureID", "Usine_FactureID")
							,new System.Data.Common.DataColumnMapping("ErreurCalcul", "ErreurCalcul")
							,new System.Data.Common.DataColumnMapping("ErreurDescription", "ErreurDescription")
							,new System.Data.Common.DataColumnMapping("LotID", "LotID")
							,new System.Data.Common.DataColumnMapping("Taux_Transporteur_Override", "Taux_Transporteur_Override")
							,new System.Data.Common.DataColumnMapping("PaieTransporteur", "PaieTransporteur")
							,new System.Data.Common.DataColumnMapping("VolumeSurcharge_Override", "VolumeSurcharge_Override")
							,new System.Data.Common.DataColumnMapping("SurchargeManuel", "SurchargeManuel")
							,new System.Data.Common.DataColumnMapping("Code", "Code")
							,new System.Data.Common.DataColumnMapping("NombrePermis", "NombrePermis")
							,new System.Data.Common.DataColumnMapping("ZoneID", "ZoneID")
							,new System.Data.Common.DataColumnMapping("MunicipaliteID", "MunicipaliteID")
							,new System.Data.Common.DataColumnMapping("ChargeurID", "ChargeurID")
							,new System.Data.Common.DataColumnMapping("Montant_Chargeur", "Montant_Chargeur")
							,new System.Data.Common.DataColumnMapping("Frais_ChargeurAuProducteur", "Frais_ChargeurAuProducteur")
							,new System.Data.Common.DataColumnMapping("Frais_ChargeurAuTransporteur", "Frais_ChargeurAuTransporteur")
							,new System.Data.Common.DataColumnMapping("Frais_AutresAuProducteur", "Frais_AutresAuProducteur")
							,new System.Data.Common.DataColumnMapping("Frais_AutresAuProducteurDescription", "Frais_AutresAuProducteurDescription")
							,new System.Data.Common.DataColumnMapping("Frais_AutresAuProducteurTransportSciage", "Frais_AutresAuProducteurTransportSciage")
							,new System.Data.Common.DataColumnMapping("Frais_AutresAuTransporteur", "Frais_AutresAuTransporteur")
							,new System.Data.Common.DataColumnMapping("Frais_AutresAuTransporteurDescription", "Frais_AutresAuTransporteurDescription")
							,new System.Data.Common.DataColumnMapping("Frais_CompensationDeDeplacement", "Frais_CompensationDeDeplacement")
							,new System.Data.Common.DataColumnMapping("Chargeur_FactureID", "Chargeur_FactureID")
							,new System.Data.Common.DataColumnMapping("Commentaires_Producteur", "Commentaires_Producteur")
							,new System.Data.Common.DataColumnMapping("Commentaires_Transporteur", "Commentaires_Transporteur")
							,new System.Data.Common.DataColumnMapping("Commentaires_Chargeur", "Commentaires_Chargeur")
							,new System.Data.Common.DataColumnMapping("TauxChargeurAuProducteur", "TauxChargeurAuProducteur")
							,new System.Data.Common.DataColumnMapping("TauxChargeurAuTransporteur", "TauxChargeurAuTransporteur")
							,new System.Data.Common.DataColumnMapping("Frais_AutresRevenusTransporteur", "Frais_AutresRevenusTransporteur")
							,new System.Data.Common.DataColumnMapping("Frais_AutresRevenusTransporteurDescription", "Frais_AutresRevenusTransporteurDescription")
							,new System.Data.Common.DataColumnMapping("Frais_AutresRevenusProducteur", "Frais_AutresRevenusProducteur")
							,new System.Data.Common.DataColumnMapping("Frais_AutresRevenusProducteurDescription", "Frais_AutresRevenusProducteurDescription")
							,new System.Data.Common.DataColumnMapping("Montant_SurchargeProducteur", "Montant_SurchargeProducteur")
							,new System.Data.Common.DataColumnMapping("KgVert_Brut", "KgVert_Brut")
							,new System.Data.Common.DataColumnMapping("KgVert_Tare", "KgVert_Tare")
							,new System.Data.Common.DataColumnMapping("KgVert_Net", "KgVert_Net")
							,new System.Data.Common.DataColumnMapping("KgVert_Rejets", "KgVert_Rejets")
							,new System.Data.Common.DataColumnMapping("KgVert_Paye", "KgVert_Paye")
							,new System.Data.Common.DataColumnMapping("Pourcent_Sec_Producteur", "Pourcent_Sec_Producteur")
							,new System.Data.Common.DataColumnMapping("Pourcent_Sec_Producteur_Override", "Pourcent_Sec_Producteur_Override")
							,new System.Data.Common.DataColumnMapping("TMA_Producteur", "TMA_Producteur")
							,new System.Data.Common.DataColumnMapping("Pourcent_Sec_Transport", "Pourcent_Sec_Transport")
							,new System.Data.Common.DataColumnMapping("Pourcent_Sec_Transport_Override", "Pourcent_Sec_Transport_Override")
							,new System.Data.Common.DataColumnMapping("TMA_Transport", "TMA_Transport")
							,new System.Data.Common.DataColumnMapping("IsTMA", "IsTMA")
							,new System.Data.Common.DataColumnMapping("SuspendrePaiement", "SuspendrePaiement")
							,new System.Data.Common.DataColumnMapping("BonCommande", "BonCommande")
						}
					)
				}
			);
		}

		/// <summary>
		/// Populates the supplied DataSet object. By default,
		///the populated table name in the DataSet will be: Livraison.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet) {

			this.FillDataSet(ref dataSet, "Livraison", -1, -1);
		}

		/// <summary>
		/// Populates the supplied DataSet object.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, string tableName) {

			this.FillDataSet(ref dataSet, tableName, -1, -1);
		}

		/// <summary>
		/// Populates the supplied DataSet object. By default,
		///the populated table name in the DataSet will be: Livraison.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, int startRecord, int maxRecords) {

			this.FillDataSet(ref dataSet, "Livraison", startRecord, maxRecords);
		}

		/// <summary>
		/// Populates the supplied DataSet object.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, string tableName, int startRecord, int maxRecords) {

			if (!this.hasBeenConfigured) {

				throw new InvalidOperationException("This SqlDataAdapter has not been configured. Call the Configure method first.");
			}

			if (this.lastKnownConnectionType == Gestion_Paie.DataClasses.ConnectionType.SqlConnection && this.sqlConnection != null) {
			
				CloseConnectionAfterUse = (this.SqlConnection.State != System.Data.ConnectionState.Open);
			}

			if (dataSet == null) {

				dataSet = new System.Data.DataSet();
			}

			if (startRecord == -1) {

				this.sqlDataAdapter.Fill(dataSet, tableName);
			}
			else {

				this.sqlDataAdapter.Fill(dataSet, startRecord, maxRecords, tableName);
			}

			if (this.CloseConnectionAfterUse && this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open) {

				this.sqlConnection.Close();
			}
		}	
	}
}
