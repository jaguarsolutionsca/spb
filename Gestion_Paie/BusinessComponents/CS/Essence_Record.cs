using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Essence] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Essence_Collection"/> class to do so.
	/// </summary>
	public sealed class Essence_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Essence_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Essence_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Essence_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Essence_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Essence", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
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

		internal bool col_RegroupementIDWasSet = false;
		private bool col_RegroupementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RegroupementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_RegroupementID);
			}
			set {
			
				this.col_RegroupementIDWasUpdated = true;
				this.col_RegroupementIDWasSet = true;
				this.col_RegroupementID_Record = null;
				this.col_RegroupementID = value;
			}
		}

		
		private EssenceRegroupement_Record col_RegroupementID_Record = null;
		public EssenceRegroupement_Record Col_RegroupementID_EssenceRegroupement_Record {
		
			get {

				if (this.col_RegroupementID_Record == null) {
				
					this.col_RegroupementID_Record = new EssenceRegroupement_Record(this.connectionString, this.col_RegroupementID);
				}
				
				return(this.col_RegroupementID_Record);
			}
		}

		internal bool col_ContingentIDWasSet = false;
		private bool col_ContingentIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_ContingentID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ContingentID);
			}
			set {
			
				this.col_ContingentIDWasUpdated = true;
				this.col_ContingentIDWasSet = true;
				this.col_ContingentID_Record = null;
				this.col_ContingentID = value;
			}
		}

		
		private EssenceContingent_Record col_ContingentID_Record = null;
		public EssenceContingent_Record Col_ContingentID_EssenceContingent_Record {
		
			get {

				if (this.col_ContingentID_Record == null) {
				
					this.col_ContingentID_Record = new EssenceContingent_Record(this.connectionString, this.col_ContingentID);
				}
				
				return(this.col_ContingentID_Record);
			}
		}

		internal bool col_RepartitionIDWasSet = false;
		private bool col_RepartitionIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_RepartitionID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RepartitionID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_RepartitionID);
			}
			set {
			
				this.col_RepartitionIDWasUpdated = true;
				this.col_RepartitionIDWasSet = true;
				this.col_RepartitionID_Record = null;
				this.col_RepartitionID = value;
			}
		}

		
		private EssenceRepartition_Record col_RepartitionID_Record = null;
		public EssenceRepartition_Record Col_RepartitionID_EssenceRepartition_Record {
		
			get {

				if (this.col_RepartitionID_Record == null) {
				
					this.col_RepartitionID_Record = new EssenceRepartition_Record(this.connectionString, this.col_RepartitionID);
				}
				
				return(this.col_RepartitionID_Record);
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

			this.col_RegroupementIDWasUpdated = false;
			this.col_RegroupementIDWasSet = false;
			this.col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ContingentIDWasUpdated = false;
			this.col_ContingentIDWasSet = false;
			this.col_ContingentID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_RepartitionIDWasUpdated = false;
			this.col_RepartitionIDWasSet = false;
			this.col_RepartitionID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Essence Param = new Params.spS_Essence(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Essence Sp = new SPs.spS_Essence();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Essence.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Essence.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence.Resultset1.Fields.Column_RegroupementID.ColumnIndex)) {

						this.col_RegroupementID = sqlDataReader.GetSqlInt32(SPs.spS_Essence.Resultset1.Fields.Column_RegroupementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence.Resultset1.Fields.Column_ContingentID.ColumnIndex)) {

						this.col_ContingentID = sqlDataReader.GetSqlInt32(SPs.spS_Essence.Resultset1.Fields.Column_ContingentID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence.Resultset1.Fields.Column_RepartitionID.ColumnIndex)) {

						this.col_RepartitionID = sqlDataReader.GetSqlInt32(SPs.spS_Essence.Resultset1.Fields.Column_RepartitionID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Essence.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RegroupementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContingentIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RepartitionIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Essence Param = new Params.spU_Essence(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_RegroupementIDWasUpdated) {

				Param.Param_RegroupementID = this.col_RegroupementID;
				Param.Param_ConsiderNull_RegroupementID = true;
			}

			if (this.col_ContingentIDWasUpdated) {

				Param.Param_ContingentID = this.col_ContingentID;
				Param.Param_ConsiderNull_ContingentID = true;
			}

			if (this.col_RepartitionIDWasUpdated) {

				Param.Param_RepartitionID = this.col_RepartitionID;
				Param.Param_ConsiderNull_RepartitionID = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Essence Sp = new SPs.spU_Essence();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_RegroupementIDWasUpdated = false;
				this.col_ContingentIDWasUpdated = false;
				this.col_RepartitionIDWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Record", "Update");
			}		
		}

		private Contingentement_Collection internal_Contingentement_Col_EssenceID_Collection = null;
		public Contingentement_Collection Contingentement_Col_EssenceID_Collection {

			get {

				if (this.internal_Contingentement_Col_EssenceID_Collection == null) {

					this.internal_Contingentement_Col_EssenceID_Collection = new Contingentement_Collection(this.connectionString);
					this.internal_Contingentement_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Col_EssenceID_Collection);
			}
		}

		private Essence_Unite_Collection internal_Essence_Unite_Col_EssenceID_Collection = null;
		public Essence_Unite_Collection Essence_Unite_Col_EssenceID_Collection {

			get {

				if (this.internal_Essence_Unite_Col_EssenceID_Collection == null) {

					this.internal_Essence_Unite_Col_EssenceID_Collection = new Essence_Unite_Collection(this.connectionString);
					this.internal_Essence_Unite_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_ID, this);
				}

				return(this.internal_Essence_Unite_Col_EssenceID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_EssenceID_Collection = null;
		public Livraison_Collection Livraison_Col_EssenceID_Collection {

			get {

				if (this.internal_Livraison_Col_EssenceID_Collection == null) {

					this.internal_Livraison_Col_EssenceID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_EssenceID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_EssenceID_Collection = null;
		public Permit_Collection Permit_Col_EssenceID_Collection {

			get {

				if (this.internal_Permit_Col_EssenceID_Collection == null) {

					this.internal_Permit_Col_EssenceID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_EssenceID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Essence_Display Param = new Params.spS_Essence_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Essence_Display Sp = new SPs.spS_Essence_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Essence_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
