using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Municipalite_Zone] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Municipalite_Zone_Collection"/> class to do so.
	/// </summary>
	public sealed class Municipalite_Zone_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Municipalite_Zone_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Municipalite_Zone_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Municipalite_Zone_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		public Municipalite_Zone_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID, System.Data.SqlTypes.SqlString col_MunicipaliteID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite_Zone'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Municipalite_Zone", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
			this.col_MunicipaliteID = col_MunicipaliteID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ID {
		
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
		internal System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {
		
			get {
			
				return(this.col_MunicipaliteID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_MunicipaliteID = value;
				}
			}
		}
		
		
		private Municipalite_Record col_MunicipaliteID_Record = null;
		public Municipalite_Record Col_MunicipaliteID_Municipalite_Record {
		
			get {

				if (this.col_MunicipaliteID_Record == null) {
				
					this.col_MunicipaliteID_Record = new Municipalite_Record(this.connectionString, this.col_MunicipaliteID);
				}
				
				return(this.col_MunicipaliteID_Record);
			}
		}

		internal bool col_DescriptionWasSet = false;
		private bool col_DescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Description = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Description {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Description);
			}
			set {
			
				this.col_DescriptionWasUpdated = true;
				this.col_DescriptionWasSet = true;
				this.col_Description = value;
			}
		}

		internal bool col_ActifWasSet = false;
		private bool col_ActifWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Actif {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Actif);
			}
			set {
			
				this.col_ActifWasUpdated = true;
				this.col_ActifWasSet = true;
				this.col_Actif = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Municipalite_Zone Param = new Params.spS_Municipalite_Zone(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Municipalite_Zone Sp = new SPs.spS_Municipalite_Zone();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite_Zone.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Municipalite_Zone.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite_Zone.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Municipalite_Zone.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Zone_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Municipalite_Zone Param = new Params.spU_Municipalite_Zone(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;
			Param.Param_MunicipaliteID = this.col_MunicipaliteID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Municipalite_Zone Sp = new SPs.spU_Municipalite_Zone();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Zone_Record", "Update");
			}		
		}

		private Contrat_Transporteur_Collection internal_Contrat_Transporteur_Col_MunicipaliteID_Collection = null;
		public Contrat_Transporteur_Collection Contrat_Transporteur_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Contrat_Transporteur_Col_MunicipaliteID_Collection == null) {

					this.internal_Contrat_Transporteur_Col_MunicipaliteID_Collection = new Contrat_Transporteur_Collection(this.connectionString);
					this.internal_Contrat_Transporteur_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_MunicipaliteID, this);
				}

				return(this.internal_Contrat_Transporteur_Col_MunicipaliteID_Collection);
			}
		}

		private Contrat_Transporteur_Collection internal_Contrat_Transporteur_Col_ZoneID_Collection = null;
		public Contrat_Transporteur_Collection Contrat_Transporteur_Col_ZoneID_Collection {

			get {

				if (this.internal_Contrat_Transporteur_Col_ZoneID_Collection == null) {

					this.internal_Contrat_Transporteur_Col_ZoneID_Collection = new Contrat_Transporteur_Collection(this.connectionString);
					this.internal_Contrat_Transporteur_Col_ZoneID_Collection.LoadFrom_ZoneID(this.col_ID, this);
				}

				return(this.internal_Contrat_Transporteur_Col_ZoneID_Collection);
			}
		}

		private Indexation_Municipalite_Collection internal_Indexation_Municipalite_Col_MunicipaliteID_Collection = null;
		public Indexation_Municipalite_Collection Indexation_Municipalite_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Indexation_Municipalite_Col_MunicipaliteID_Collection == null) {

					this.internal_Indexation_Municipalite_Col_MunicipaliteID_Collection = new Indexation_Municipalite_Collection(this.connectionString);
					this.internal_Indexation_Municipalite_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_MunicipaliteID, this);
				}

				return(this.internal_Indexation_Municipalite_Col_MunicipaliteID_Collection);
			}
		}

		private Indexation_Municipalite_Collection internal_Indexation_Municipalite_Col_ZoneID_Collection = null;
		public Indexation_Municipalite_Collection Indexation_Municipalite_Col_ZoneID_Collection {

			get {

				if (this.internal_Indexation_Municipalite_Col_ZoneID_Collection == null) {

					this.internal_Indexation_Municipalite_Col_ZoneID_Collection = new Indexation_Municipalite_Collection(this.connectionString);
					this.internal_Indexation_Municipalite_Col_ZoneID_Collection.LoadFrom_ZoneID(this.col_ID, this);
				}

				return(this.internal_Indexation_Municipalite_Col_ZoneID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_ZoneID_Collection = null;
		public Livraison_Collection Livraison_Col_ZoneID_Collection {

			get {

				if (this.internal_Livraison_Col_ZoneID_Collection == null) {

					this.internal_Livraison_Col_ZoneID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_ZoneID_Collection.LoadFrom_ZoneID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_ZoneID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_MunicipaliteID_Collection = null;
		public Livraison_Collection Livraison_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Livraison_Col_MunicipaliteID_Collection == null) {

					this.internal_Livraison_Col_MunicipaliteID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_MunicipaliteID, this);
				}

				return(this.internal_Livraison_Col_MunicipaliteID_Collection);
			}
		}

		private Lot_Collection internal_Lot_Col_MunicipaliteID_Collection = null;
		public Lot_Collection Lot_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Lot_Col_MunicipaliteID_Collection == null) {

					this.internal_Lot_Col_MunicipaliteID_Collection = new Lot_Collection(this.connectionString);
					this.internal_Lot_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_MunicipaliteID, this);
				}

				return(this.internal_Lot_Col_MunicipaliteID_Collection);
			}
		}

		private Lot_Collection internal_Lot_Col_ZoneID_Collection = null;
		public Lot_Collection Lot_Col_ZoneID_Collection {

			get {

				if (this.internal_Lot_Col_ZoneID_Collection == null) {

					this.internal_Lot_Col_ZoneID_Collection = new Lot_Collection(this.connectionString);
					this.internal_Lot_Col_ZoneID_Collection.LoadFrom_ZoneID(this.col_ID, this);
				}

				return(this.internal_Lot_Col_ZoneID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_ZoneID_Collection = null;
		public Permit_Collection Permit_Col_ZoneID_Collection {

			get {

				if (this.internal_Permit_Col_ZoneID_Collection == null) {

					this.internal_Permit_Col_ZoneID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_ZoneID_Collection.LoadFrom_ZoneID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_ZoneID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_MunicipaliteID_Collection = null;
		public Permit_Collection Permit_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Permit_Col_MunicipaliteID_Collection == null) {

					this.internal_Permit_Col_MunicipaliteID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_MunicipaliteID, this);
				}

				return(this.internal_Permit_Col_MunicipaliteID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Municipalite_Zone_Display Param = new Params.spS_Municipalite_Zone_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;
				Param.Param_MunicipaliteID = this.col_MunicipaliteID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Municipalite_Zone_Display Sp = new SPs.spS_Municipalite_Zone_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite_Zone_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Municipalite_Zone_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Zone_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
