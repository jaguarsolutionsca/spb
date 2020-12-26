using System;

namespace Gestion_Paie.SqlDataAdapters {

	/// <summary>
	/// This class represents a full operational System.Data.SqlClient.SqlDataAdapter that can be
	/// used against the [Usine] table. The four basics operations are supported: Insert, Update, Delete and Select.
	/// </summary>
	public sealed class SqlDataAdapter_Usine {

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
		/// Creates a new instance of the SqlDataAdapter_Usine class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public SqlDataAdapter_Usine(string connectionString) {

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
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Usine class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public SqlDataAdapter_Usine(System.Data.SqlClient.SqlConnection sqlConnection) {

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
		}

		/// <summary>
		/// Creates a new instance of the SqlDataAdapter_Usine class.
		/// In this constructor version, the SqlDataAdapter is not pre-configured. You need
		/// to call the Configure method before calling the FillDataSet method.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public SqlDataAdapter_Usine(System.Data.SqlClient.SqlTransaction sqlTransaction) {

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
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Usine class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Usine(string connectionString, System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID, string tableName) : this(connectionString) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Usine class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Usine(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID, string tableName) : this(sqlConnection) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Usine class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public SqlDataAdapter_Usine(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID, string tableName) : this(sqlTransaction) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, tableName);
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Usine class.
		/// The table name in the DataSet will be: Usine
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		public SqlDataAdapter_Usine(string connectionString, System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID) : this(connectionString) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, "Usine");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Usine class.
		/// The table name in the DataSet will be: Usine
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		public SqlDataAdapter_Usine(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID) : this(sqlConnection) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, "Usine");
		}

		/// <summary>
		/// Creates and configures a new instance of the SqlDataAdapter_Usine class.
		/// The table name in the DataSet will be: Usine
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		public SqlDataAdapter_Usine(System.Data.SqlClient.SqlTransaction sqlTransaction, System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID) : this(sqlTransaction) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, "Usine");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// The table name in the DataSet will be: Usine
		/// </summary>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		public void Configure(System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID) {

			this.Configure(FK_UtilisationID, FK_Compte_a_recevoir, FK_Compte_ajustement, FK_Compte_transporteur, FK_Compte_producteur, FK_Compte_preleve_plan_conjoint, FK_Compte_preleve_fond_roulement, FK_Compte_preleve_fond_forestier, FK_Compte_preleve_divers, FK_Compte_mise_en_commun, FK_Compte_surcharge, FK_Compte_indexation_carburant, FK_PaysID, "Usine");
		}

		/// <summary>
		/// Configures the SqlDataAdapter.
		/// </summary>
		/// <param name="FK_UtilisationID">Value for this foreign key.</param>
		/// <param name="FK_Compte_a_recevoir">Value for this foreign key.</param>
		/// <param name="FK_Compte_ajustement">Value for this foreign key.</param>
		/// <param name="FK_Compte_transporteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_producteur">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_plan_conjoint">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_roulement">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_fond_forestier">Value for this foreign key.</param>
		/// <param name="FK_Compte_preleve_divers">Value for this foreign key.</param>
		/// <param name="FK_Compte_mise_en_commun">Value for this foreign key.</param>
		/// <param name="FK_Compte_surcharge">Value for this foreign key.</param>
		/// <param name="FK_Compte_indexation_carburant">Value for this foreign key.</param>
		/// <param name="FK_PaysID">Value for this foreign key.</param>
		/// <param name="tableName">Table name to be use in the DataSet.</param>
		public void Configure(System.Data.SqlTypes.SqlInt32 FK_UtilisationID, System.Data.SqlTypes.SqlInt32 FK_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 FK_Compte_ajustement, System.Data.SqlTypes.SqlInt32 FK_Compte_transporteur, System.Data.SqlTypes.SqlInt32 FK_Compte_producteur, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 FK_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 FK_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 FK_Compte_surcharge, System.Data.SqlTypes.SqlInt32 FK_Compte_indexation_carburant, System.Data.SqlTypes.SqlString FK_PaysID, string tableName) {

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

						throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.SqlDataAdapters.SqlDataAdapter_Usine)");
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
			sqlSelectCommand.CommandText = "spS_Usine";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UtilisationID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "UtilisationID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_UtilisationID.IsNull) {

				sqlParameter.Value = FK_UtilisationID;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_a_recevoir", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_a_recevoir";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_a_recevoir.IsNull) {

				sqlParameter.Value = FK_Compte_a_recevoir;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_ajustement", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_ajustement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_ajustement.IsNull) {

				sqlParameter.Value = FK_Compte_ajustement;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_transporteur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_transporteur.IsNull) {

				sqlParameter.Value = FK_Compte_transporteur;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_producteur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_producteur.IsNull) {

				sqlParameter.Value = FK_Compte_producteur;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_plan_conjoint", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_plan_conjoint";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_preleve_plan_conjoint.IsNull) {

				sqlParameter.Value = FK_Compte_preleve_plan_conjoint;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_roulement", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_fond_roulement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_preleve_fond_roulement.IsNull) {

				sqlParameter.Value = FK_Compte_preleve_fond_roulement;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_forestier", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_fond_forestier";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_preleve_fond_forestier.IsNull) {

				sqlParameter.Value = FK_Compte_preleve_fond_forestier;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_divers", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_divers";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_preleve_divers.IsNull) {

				sqlParameter.Value = FK_Compte_preleve_divers;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_mise_en_commun", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_mise_en_commun";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_mise_en_commun.IsNull) {

				sqlParameter.Value = FK_Compte_mise_en_commun;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_surcharge", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_surcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_surcharge.IsNull) {

				sqlParameter.Value = FK_Compte_surcharge;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_indexation_carburant", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_indexation_carburant";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_Compte_indexation_carburant.IsNull) {

				sqlParameter.Value = FK_Compte_indexation_carburant;
			}

			else {

				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
			}
			sqlSelectCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "PaysID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			if (!FK_PaysID.IsNull) {

				sqlParameter.Value = FK_PaysID;
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
			sqlInsertCommand.CommandText = "spI_Usine";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Description";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UtilisationID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "UtilisationID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Paye_producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Paye_producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Paye_transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Paye_transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Specification", System.Data.SqlDbType.Text, 2147483647);
			sqlParameter.SourceColumn = "Specification";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_a_recevoir", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_a_recevoir";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_ajustement", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_ajustement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_transporteur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_producteur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_plan_conjoint", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_plan_conjoint";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_roulement", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_fond_roulement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_forestier", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_fond_forestier";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_divers", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_divers";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_mise_en_commun", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_mise_en_commun";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_surcharge", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_surcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_indexation_carburant", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_indexation_carburant";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Actif";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NePaiePasTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "NePaiePasTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NePaiePasTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "NePaiePasTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NoTPS", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "NoTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NoTVQ", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "NoTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_chargeur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_chargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UsineGestionVolume", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "UsineGestionVolume";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AuSoinsDe", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "AuSoinsDe";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rue", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Rue";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Ville";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "PaysID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Code_postal", System.Data.SqlDbType.VarChar, 7);
			sqlParameter.SourceColumn = "Code_postal";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telecopieur", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telecopieur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone2";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone2_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone2_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone3";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone3_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone3_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlInsertCommand.Parameters.Add(sqlParameter);


			sqlUpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlUpdateCommand.CommandText = "spU_Usine";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 6);
			sqlParameter.SourceColumn = "ID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50);
			sqlParameter.SourceColumn = "Description";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Description", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UtilisationID", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "UtilisationID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_UtilisationID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Paye_producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Paye_producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Paye_producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Paye_transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Paye_transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Paye_transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Specification", System.Data.SqlDbType.Text, 2147483647);
			sqlParameter.SourceColumn = "Specification";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Specification", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_a_recevoir", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_a_recevoir";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_a_recevoir", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_ajustement", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_ajustement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_ajustement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_transporteur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_transporteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_transporteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_producteur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_producteur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_producteur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_plan_conjoint", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_plan_conjoint";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_preleve_plan_conjoint", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_roulement", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_fond_roulement";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_preleve_fond_roulement", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_forestier", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_fond_forestier";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_preleve_fond_forestier", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_divers", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_preleve_divers";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_preleve_divers", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_mise_en_commun", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_mise_en_commun";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_mise_en_commun", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_surcharge", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_surcharge";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_surcharge", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_indexation_carburant", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_indexation_carburant";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_indexation_carburant", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "Actif";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Actif", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NePaiePasTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "NePaiePasTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NePaiePasTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NePaiePasTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "NePaiePasTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NePaiePasTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NoTPS", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "NoTPS";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NoTPS", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@NoTVQ", System.Data.SqlDbType.VarChar, 25);
			sqlParameter.SourceColumn = "NoTVQ";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NoTVQ", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_chargeur", System.Data.SqlDbType.Int, 4);
			sqlParameter.SourceColumn = "Compte_chargeur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Compte_chargeur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@UsineGestionVolume", System.Data.SqlDbType.Bit, 1);
			sqlParameter.SourceColumn = "UsineGestionVolume";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_UsineGestionVolume", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@AuSoinsDe", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "AuSoinsDe";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_AuSoinsDe", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Rue", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Rue";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rue", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 30);
			sqlParameter.SourceColumn = "Ville";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Ville", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
			sqlParameter.SourceColumn = "PaysID";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PaysID", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Code_postal", System.Data.SqlDbType.VarChar, 7);
			sqlParameter.SourceColumn = "Code_postal";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Code_postal", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telecopieur", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telecopieur";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telecopieur", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone2";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone2", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone2_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone2_Desc", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone2_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone2_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3", System.Data.SqlDbType.VarChar, 12);
			sqlParameter.SourceColumn = "Telephone3";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone3", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Desc", System.Data.SqlDbType.VarChar, 20);
			sqlParameter.SourceColumn = "Telephone3_Desc";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone3_Desc", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Poste", System.Data.SqlDbType.VarChar, 4);
			sqlParameter.SourceColumn = "Telephone3_Poste";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Telephone3_Poste", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 80);
			sqlParameter.SourceColumn = "Email";
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlUpdateCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Email", System.Data.SqlDbType.Bit, 1);
			sqlParameter.Direction = System.Data.ParameterDirection.Input;
			sqlParameter.Value = true;
			sqlUpdateCommand.Parameters.Add(sqlParameter);


			sqlDeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlDeleteCommand.CommandText = "spD_Usine";

			sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
			sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
			sqlParameter.IsNullable = true;
			sqlParameter.Value = System.DBNull.Value;
			sqlDeleteCommand.Parameters.Add(sqlParameter);

			sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 6);
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
						 "Usine"
						,tableName
						,new System.Data.Common.DataColumnMapping[] {
							 new System.Data.Common.DataColumnMapping("ID", "ID")
							,new System.Data.Common.DataColumnMapping("Description", "Description")
							,new System.Data.Common.DataColumnMapping("UtilisationID", "UtilisationID")
							,new System.Data.Common.DataColumnMapping("Paye_producteur", "Paye_producteur")
							,new System.Data.Common.DataColumnMapping("Paye_transporteur", "Paye_transporteur")
							,new System.Data.Common.DataColumnMapping("Specification", "Specification")
							,new System.Data.Common.DataColumnMapping("Compte_a_recevoir", "Compte_a_recevoir")
							,new System.Data.Common.DataColumnMapping("Compte_ajustement", "Compte_ajustement")
							,new System.Data.Common.DataColumnMapping("Compte_transporteur", "Compte_transporteur")
							,new System.Data.Common.DataColumnMapping("Compte_producteur", "Compte_producteur")
							,new System.Data.Common.DataColumnMapping("Compte_preleve_plan_conjoint", "Compte_preleve_plan_conjoint")
							,new System.Data.Common.DataColumnMapping("Compte_preleve_fond_roulement", "Compte_preleve_fond_roulement")
							,new System.Data.Common.DataColumnMapping("Compte_preleve_fond_forestier", "Compte_preleve_fond_forestier")
							,new System.Data.Common.DataColumnMapping("Compte_preleve_divers", "Compte_preleve_divers")
							,new System.Data.Common.DataColumnMapping("Compte_mise_en_commun", "Compte_mise_en_commun")
							,new System.Data.Common.DataColumnMapping("Compte_surcharge", "Compte_surcharge")
							,new System.Data.Common.DataColumnMapping("Compte_indexation_carburant", "Compte_indexation_carburant")
							,new System.Data.Common.DataColumnMapping("Actif", "Actif")
							,new System.Data.Common.DataColumnMapping("NePaiePasTPS", "NePaiePasTPS")
							,new System.Data.Common.DataColumnMapping("NePaiePasTVQ", "NePaiePasTVQ")
							,new System.Data.Common.DataColumnMapping("NoTPS", "NoTPS")
							,new System.Data.Common.DataColumnMapping("NoTVQ", "NoTVQ")
							,new System.Data.Common.DataColumnMapping("Compte_chargeur", "Compte_chargeur")
							,new System.Data.Common.DataColumnMapping("UsineGestionVolume", "UsineGestionVolume")
							,new System.Data.Common.DataColumnMapping("AuSoinsDe", "AuSoinsDe")
							,new System.Data.Common.DataColumnMapping("Rue", "Rue")
							,new System.Data.Common.DataColumnMapping("Ville", "Ville")
							,new System.Data.Common.DataColumnMapping("PaysID", "PaysID")
							,new System.Data.Common.DataColumnMapping("Code_postal", "Code_postal")
							,new System.Data.Common.DataColumnMapping("Telephone", "Telephone")
							,new System.Data.Common.DataColumnMapping("Telephone_Poste", "Telephone_Poste")
							,new System.Data.Common.DataColumnMapping("Telecopieur", "Telecopieur")
							,new System.Data.Common.DataColumnMapping("Telephone2", "Telephone2")
							,new System.Data.Common.DataColumnMapping("Telephone2_Desc", "Telephone2_Desc")
							,new System.Data.Common.DataColumnMapping("Telephone2_Poste", "Telephone2_Poste")
							,new System.Data.Common.DataColumnMapping("Telephone3", "Telephone3")
							,new System.Data.Common.DataColumnMapping("Telephone3_Desc", "Telephone3_Desc")
							,new System.Data.Common.DataColumnMapping("Telephone3_Poste", "Telephone3_Poste")
							,new System.Data.Common.DataColumnMapping("Email", "Email")
						}
					)
				}
			);
		}

		/// <summary>
		/// Populates the supplied DataSet object. By default,
		///the populated table name in the DataSet will be: Usine.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet) {

			this.FillDataSet(ref dataSet, "Usine", -1, -1);
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
		///the populated table name in the DataSet will be: Usine.
		/// </summary>
		/// <param name="dataSet">DataSet to be populated by the SqlDataAdapter.</param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		public void FillDataSet(ref System.Data.DataSet dataSet, int startRecord, int maxRecords) {

			this.FillDataSet(ref dataSet, "Usine", startRecord, maxRecords);
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
