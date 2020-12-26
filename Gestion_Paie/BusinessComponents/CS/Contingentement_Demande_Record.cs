using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contingentement_Demande] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contingentement_Demande_Collection"/> class to do so.
	/// </summary>
	public sealed class Contingentement_Demande_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contingentement_Demande_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contingentement_Demande_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contingentement_Demande_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Contingentement_Demande_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString != String.Empty) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Demande'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_Demande", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_AnneeWasSet = false;
		private bool col_AnneeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Annee);
			}
			set {
			
				this.col_AnneeWasUpdated = true;
				this.col_AnneeWasSet = true;
				this.col_Annee = value;
			}
		}

		internal bool col_ProducteurIDWasSet = false;
		private bool col_ProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurID);
			}
			set {
			
				this.col_ProducteurIDWasUpdated = true;
				this.col_ProducteurIDWasSet = true;
				this.col_ProducteurID_Record = null;
				this.col_ProducteurID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurID_Record = null;
		public Fournisseur_Record Col_ProducteurID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurID_Record == null) {
				
					this.col_ProducteurID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurID);
				}
				
				return(this.col_ProducteurID_Record);
			}
		}

		internal bool col_TransporteurIDWasSet = false;
		private bool col_TransporteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TransporteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TransporteurID);
			}
			set {
			
				this.col_TransporteurIDWasUpdated = true;
				this.col_TransporteurIDWasSet = true;
				this.col_TransporteurID_Record = null;
				this.col_TransporteurID = value;
			}
		}

		
		private Fournisseur_Record col_TransporteurID_Record = null;
		public Fournisseur_Record Col_TransporteurID_Fournisseur_Record {
		
			get {

				if (this.col_TransporteurID_Record == null) {
				
					this.col_TransporteurID_Record = new Fournisseur_Record(this.connectionString, this.col_TransporteurID);
				}
				
				return(this.col_TransporteurID_Record);
			}
		}

		internal bool col_Superficie_BoiseeWasSet = false;
		private bool col_Superficie_BoiseeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Superficie_Boisee = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Superficie_Boisee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Superficie_Boisee);
			}
			set {
			
				this.col_Superficie_BoiseeWasUpdated = true;
				this.col_Superficie_BoiseeWasSet = true;
				this.col_Superficie_Boisee = value;
			}
		}

		internal bool col_RemarquesWasSet = false;
		private bool col_RemarquesWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Remarques = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Remarques {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Remarques);
			}
			set {
			
				this.col_RemarquesWasUpdated = true;
				this.col_RemarquesWasSet = true;
				this.col_Remarques = value;
			}
		}

		internal bool col_DateModificationWasSet = false;
		private bool col_DateModificationWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateModification = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateModification {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateModification);
			}
			set {
			
				this.col_DateModificationWasUpdated = true;
				this.col_DateModificationWasSet = true;
				this.col_DateModification = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_TransporteurIDWasUpdated = false;
			this.col_TransporteurIDWasSet = false;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_Superficie_BoiseeWasUpdated = false;
			this.col_Superficie_BoiseeWasSet = false;
			this.col_Superficie_Boisee = System.Data.SqlTypes.SqlSingle.Null;

			this.col_RemarquesWasUpdated = false;
			this.col_RemarquesWasSet = false;
			this.col_Remarques = System.Data.SqlTypes.SqlString.Null;

			this.col_DateModificationWasUpdated = false;
			this.col_DateModificationWasSet = false;
			this.col_DateModification = System.Data.SqlTypes.SqlDateTime.Null;

			Params.spS_Contingentement_Demande Param = new Params.spS_Contingentement_Demande(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_Demande Sp = new SPs.spS_Contingentement_Demande();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = sqlDataReader.GetSqlString(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_Superficie_Boisee.ColumnIndex)) {

						this.col_Superficie_Boisee = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_Superficie_Boisee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_Remarques.ColumnIndex)) {

						this.col_Remarques = sqlDataReader.GetSqlString(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_Remarques.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_DateModification.ColumnIndex)) {

						this.col_DateModification = sqlDataReader.GetSqlDateTime(SPs.spS_Contingentement_Demande.Resultset1.Fields.Column_DateModification.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Demande_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransporteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Superficie_BoiseeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RemarquesWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateModificationWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contingentement_Demande Param = new Params.spU_Contingentement_Demande(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_TransporteurIDWasUpdated) {

				Param.Param_TransporteurID = this.col_TransporteurID;
				Param.Param_ConsiderNull_TransporteurID = true;
			}

			if (this.col_Superficie_BoiseeWasUpdated) {

				Param.Param_Superficie_Boisee = this.col_Superficie_Boisee;
				Param.Param_ConsiderNull_Superficie_Boisee = true;
			}

			if (this.col_RemarquesWasUpdated) {

				Param.Param_Remarques = this.col_Remarques;
				Param.Param_ConsiderNull_Remarques = true;
			}

			if (this.col_DateModificationWasUpdated) {

				Param.Param_DateModification = this.col_DateModification;
				Param.Param_ConsiderNull_DateModification = true;
			}

			SPs.spU_Contingentement_Demande Sp = new SPs.spU_Contingentement_Demande();
			if (Sp.Execute(ref Param)) {

				this.col_AnneeWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_TransporteurIDWasUpdated = false;
				this.col_Superficie_BoiseeWasUpdated = false;
				this.col_RemarquesWasUpdated = false;
				this.col_DateModificationWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Demande_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contingentement_Demande_Display Param = new Params.spS_Contingentement_Demande_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contingentement_Demande_Display Sp = new SPs.spS_Contingentement_Demande_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Demande_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contingentement_Demande_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Demande_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
